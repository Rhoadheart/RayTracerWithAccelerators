using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime;
using Json.Net;

namespace project.RayTracing
{
    class GridAccelerator
    {
        Mesh mesh;
        int numTriangles;
        List<Voxel> voxels;
        BoundingBox bounds;
        Vector3 nVoxels;
        Vector3 delta;
        Vector3 width;
        Vector3 invWidth;
        int maxVoxels;

        Vector3 NextCrossingT, DeltaT;
        Vector3 Step, Out, Pos;
        Vector3 gridIntersect;
        float rayT;

        /// <summary>
        /// Constructor for a Grid Accelerator.
        /// Only call this once per image to generate. 
        /// After this Grid Accelerator is created, call it's intersect method for each Ray.
        /// </summary>
        /// <param name="mesh"></param>
        public GridAccelerator(Mesh mesh)
        {
            this.mesh = mesh;
            maxVoxels = 64;
            numTriangles = mesh.faces.Count / 3;

            //Add all triangles to bounds
            bounds = new BoundingBox(new Triangle(mesh, 0));
            for(int i = 1; i <numTriangles; i++)
            {
                Triangle tri = new Triangle(mesh, i);
                bounds.addTriangle(tri);
            }

            delta = bounds.max - bounds.min;

            //Calculate voxelsPerUnitDist
            float voxelsPerUnitDist = getVoxelsPerUnitDist();
            nVoxels = new Vector3(0, 0, 0);
            
            nVoxels.X = Clamp((int)Math.Round((decimal)delta.X * (decimal)voxelsPerUnitDist), 1, maxVoxels);
            nVoxels.Y = Clamp((int)Math.Round((decimal)delta.Y * (decimal)voxelsPerUnitDist), 1, maxVoxels);
            nVoxels.Z = Clamp((int)Math.Round((decimal)delta.Z * (decimal)voxelsPerUnitDist), 1, maxVoxels);

            width.X = delta.X / nVoxels.X;
            width.Y = delta.Y / nVoxels.Y;
            width.Z = delta.Z / nVoxels.Z;

            invWidth.X = width.X == 0f ? 0f : 1f / width.X;
            invWidth.Y = width.Y == 0f ? 0f : 1f / width.Y;
            invWidth.Z = width.Z == 0f ? 0f : 1f / width.Z;


            int nv = (int)(nVoxels.X * nVoxels.Y * nVoxels.Z);

            voxels = new List<Voxel>();
            for(int i = 0; i < nv; i++)
            {
                //Create empty voxels in the list.
                voxels.Add(new Voxel(0));
            }

            //Add primitives to grid voxels
            
            for(int i = 0; i < numTriangles; i++)
            {
                Triangle t = new Triangle(mesh, i);
                //Find voxel extent of primitive
                BoundingBox pb = new BoundingBox(t);
                Vector3 vmin = new Vector3();
                vmin.X = posToVoxel(pb.min, 0);
                vmin.Y = posToVoxel(pb.min, 1);
                vmin.Z = posToVoxel(pb.min, 2);

                Vector3 vmax = new Vector3();
                vmax.X = posToVoxel(pb.max, 0);
                vmax.Y = posToVoxel(pb.max, 1);
                vmax.Z = posToVoxel(pb.max, 2);

                //Add primitive to all overlapping voxels
                for(int z = (int)vmin.Z; z <= vmax.Z; z++)
                {
                    for(int y = (int)vmin.Y; y <= vmax.Y; y++)
                    {
                        for(int x = (int)vmin.X; x <= vmax.X; x++)
                        {
                            int o = offset(x, y, z);
                            if (voxels[o].numTriangles == 0)
                            {
                                //Allocate a new Voxel and store the primitive in it.
                                Voxel newVoxel = new Voxel(t);
                                voxels[o] = newVoxel;
                            }
                            else
                            {
                                //Add primitive to already allocated voxel.
                                voxels[o].addTriangle(t);

                            }
                        }
                    }
                }
                

            }

            
        }

        public Triangle intersect(Ray r)
        {
            //Check ray against overall grid bounds
            
            if (!bounds.Intersect(r, out rayT))
                return null;
            gridIntersect = r.at(rayT);


            //Set up 3D DDA for ray
            
            //foreach axis:
            //Compute current voxel for each axis
            Pos.X = posToVoxel(gridIntersect, 0);
            Pos.Y = posToVoxel(gridIntersect, 1);
            Pos.Z = posToVoxel(gridIntersect, 2);

            for(int axis = 0; axis < 3; axis++)
            {
                if (axis == 0)
                {
                    if (r.getDirection().X >= 0)
                        handlePositiveRay(r,0);
                    else
                        handleNegativeRay(r,0);
                }
                else if (axis == 1)
                {
                    if (r.getDirection().Y >= 0)
                        handlePositiveRay(r,1);
                    else
                        handleNegativeRay(r,1);
                }
                else
                {
                    if (r.getDirection().Z >= 0)
                        handlePositiveRay(r,2);
                    else
                        handleNegativeRay(r,2);
                }
                
            }

            //Walk ray through voxel grid
            bool hitSomething = false;
            float tOut;
            float minT = float.MaxValue;
            Triangle closestTriangle = null;
            while (!hitSomething)
            {
                Voxel voxel = voxels[offset((int)Pos.X, (int)Pos.Y, (int)Pos.Z)];
                if (voxel.numTriangles > 0)
                {
                    Triangle intersect = voxel.intersect(r, out tOut);
                    if(intersect != null)
                    {
                        if (tOut < minT)
                        {
                            closestTriangle = intersect;
                            minT = tOut;
                            return closestTriangle;
                        }
                    }
                    else
                    {
                        //Advance to next voxel
                        //Find stepAxis for stepping to next voxel
                        int xy = NextCrossingT.X < NextCrossingT.Y ? 1 : 0;
                        int xz = NextCrossingT.X < NextCrossingT.Z ? 1 : 0;
                        int yz = NextCrossingT.Y < NextCrossingT.Z ? 1 : 0;
                        int bits = (xy << 2) + (xz << 1) + yz;
                        List<int> cmpToAxis = new List<int>{ 2, 1, 2, 1, 2, 2, 0, 0 };
                        int stepAxis = cmpToAxis[bits];

                        //Use stepAxis to step to next voxel

                        if(stepAxis == 0)
                        {
                            //Our rays currently always have a MaxT of float.MaxValue;
                            if (r.getMaxT() < NextCrossingT.X)
                                return closestTriangle;
                            Pos.X += Step.X;

                            //If we hit an edge, return no intersection.
                            if (Pos.X == Out.X)
                                return closestTriangle;

                            NextCrossingT.X += DeltaT.X;


                        }else if(stepAxis == 1)
                        {
                            //Our rays currently always have a MaxT of float.MaxValue;
                            if (r.getMaxT() < NextCrossingT.Y)
                                return closestTriangle;
                            Pos.Y += Step.Y;

                            //If we hit an edge, return no intersection.
                            if (Pos.Y == Out.Y)
                                return closestTriangle;

                            NextCrossingT.Y += DeltaT.Y;
                        }
                        else
                        {
                            //Our rays currently always have a MaxT of float.MaxValue;
                            if (r.getMaxT() < NextCrossingT.Z)
                                return closestTriangle;
                            Pos.Z += Step.Z;

                            //If we hit an edge, return no intersection.
                            if (Pos.Z == Out.Z)
                                return closestTriangle;

                            NextCrossingT.Z += DeltaT.Z;
                        }


                    }
                }
                return closestTriangle;
            }
            return closestTriangle;
            
        }

        /// <summary>
        /// Prepares a ray with positive direction for voxel stepping
        /// </summary>
        /// <param name="r"></param>
        /// <param name="axis"></param>
        private void handlePositiveRay(Ray r, int axis)
        {
           
            if(axis == 0)
            {
                NextCrossingT.X = rayT + (voxelToPos((int)Pos.X + 1, 0) - gridIntersect.X) / r.getDirection().X;
                DeltaT.X = width.X / r.getDirection().X;
                Step.X = 1;
                Out.X = nVoxels.X;
            }
            else if (axis == 1)
            {
                NextCrossingT.Y = rayT + (voxelToPos((int)Pos.Y + 1, 1) - gridIntersect.Y) / r.getDirection().Y;
                DeltaT.Y = width.Y / r.getDirection().Y;
                Step.Y = 1;
                Out.Y = nVoxels.Y;
            }
            else
            {
                NextCrossingT.Z = rayT + (voxelToPos((int)Pos.Z + 1, 2) - gridIntersect.Z) / r.getDirection().Z;
                DeltaT.Z = width.Z / r.getDirection().Z;
                Step.Z = 1;
                Out.Z = nVoxels.Z;
            }

        }

        /// <summary>
        /// Prepares a ray with a negative direction for voxel stepping
        /// </summary>
        /// <param name="r"></param>
        /// <param name="axis"></param>
        private void handleNegativeRay(Ray r, int axis)
        {

            if (axis == 0)
            {
                NextCrossingT.X = rayT + (voxelToPos((int)Pos.X, 0) - gridIntersect.X) / r.getDirection().X;
                DeltaT.X = -width.X / r.getDirection().X;
                Step.X = -1;
                Out.X = -1;
            }
            else if (axis == 1)
            {
                NextCrossingT.Y = rayT + (voxelToPos((int)Pos.Y, 0) - gridIntersect.Y) / r.getDirection().Y;
                DeltaT.Y = -width.Y / r.getDirection().Y;
                Step.Y = -1;
                Out.Y = -1;
            }else
            {
                NextCrossingT.Z = rayT + (voxelToPos((int)Pos.Z, 0) - gridIntersect.Z) / r.getDirection().Z;
                DeltaT.Z = -width.Z / r.getDirection().Z;
                Step.Z = -1;
                Out.Z = -1;
            }

        }

        public int offset(int x, int y, int z)
        {
            return (int) (z * nVoxels.X * nVoxels.Y + y * nVoxels.X + x);
        }



        public void setMaxVoxels(int maxVoxels)
        {
            this.maxVoxels = maxVoxels;
        }

        private int posToVoxel(Vector3 p, int axis)
        {
            int v;
            if (axis == 0)
            {
                v = (int)Math.Round((p.X - bounds.min.X) * invWidth.X);
                return Clamp(v, 0, (int)nVoxels.X - 1);
            }else if(axis == 1)
            {
                v = (int)Math.Round((p.Y- bounds.min.Y) * invWidth.Y);
                return Clamp(v, 0, (int)nVoxels.Y - 1);
            }
            else
            {
                v = (int)Math.Round((p.Z - bounds.min.Z) * invWidth.Z);
                return Clamp(v, 0, (int)nVoxels.Z - 1);
            }
        }

        private float voxelToPos(int p, int axis)
        {
            if (axis == 0)
                return bounds.min.X + p * width.X;
            else if(axis == 1)
                return bounds.min.Y + p * width.Y;
            else
                return bounds.min.Z + p * width.Z;
        }

        private float getVoxelsPerUnitDist()
        {
            int maxAxis = bounds.MaximumExtent();
            float cubeRoot = (float)(3f * Math.Pow(numTriangles, 1f / 3f));

            float invMaxWidth;
            if (maxAxis == 0)
                invMaxWidth = 1f / delta.X;
            else if (maxAxis == 1)
                invMaxWidth = 1f / delta.Y;
            else
                invMaxWidth = 1f / delta.Z;

            

            return  cubeRoot * invMaxWidth;
            
        }

        private int Clamp(int value, int min, int max)
        {
            return value < min ? min : value > max ? max : value;
        }
    }
}
