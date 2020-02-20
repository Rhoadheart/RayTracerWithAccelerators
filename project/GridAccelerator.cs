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
        //Vector3 nVoxels;
        int[] nVoxels;
        float[] delta;
        float[] width;
        float[] invWidth;
        int maxVoxels;

        float[] NextCrossingT, DeltaT;
        int[] Step, Out, Pos;
        Vector3 gridIntersect;
        float hit0;
        float hit1;

        /// <summary>
        /// Constructor for a Grid Accelerator.
        /// Only call this once per image to generate. 
        /// After this Grid Accelerator is created, call it's intersect method for each Ray.
        /// </summary>
        /// <param name="mesh"></param>
        public GridAccelerator(Mesh mesh)
        {

            nVoxels = new int[3];
            delta = new float[3];
            width = new float[3];
            invWidth = new float[3];

            this.mesh = mesh;
            maxVoxels = 64;
            numTriangles = mesh.faces.Count / 3;

            //Add all triangles to bounds
            bounds = new BoundingBox(new Triangle(mesh, 0));
            for (int i = 1; i < numTriangles; i++)
            {
                Triangle tri = new Triangle(mesh, i);
                bounds.addTriangle(tri);
            }

            Vector3 deltaVector = bounds.max - bounds.min;

            delta[0] = deltaVector.X;
            delta[1] = deltaVector.Y;
            delta[2] = deltaVector.Z;

            //Calculate voxelsPerUnitDist
            float voxelsPerUnitDist = getVoxelsPerUnitDist();

            for (int axis = 0; axis < 3; ++axis)
            {
                nVoxels[axis] = (int)Math.Round(delta[axis] * voxelsPerUnitDist);
                nVoxels[axis] = Clamp(nVoxels[axis], 1, maxVoxels);
            }

            for (int axis = 0; axis < 3; ++axis)
            {
                width[axis] = (float)delta[axis] / nVoxels[axis];

                invWidth[axis] = width[axis] == 0f ? 0f : 1f / width[axis];
            }

            int nv = (int)(nVoxels[0] * nVoxels[1] * nVoxels[2]);

            voxels = new List<Voxel>();

            //Create an empty list of voxels.
            for (int i = 0; i < nv; i++)
            {
                //Create empty voxels in the list.
                voxels.Add(new Voxel());
            }

            //Add primitives to grid voxels

            for (int i = 0; i < numTriangles; i++)
            {
                Triangle t = new Triangle(mesh, i);

                //Find voxel extent of primitive
                BoundingBox triBox = new BoundingBox(t);

                int[] minVoxel = new int[3];
                int[] maxVoxel = new int[3];
                for (int axis = 0; axis < 3; axis++)
                {
                    minVoxel[axis] = posToVoxel(triBox.min, axis);
                    maxVoxel[axis] = posToVoxel(triBox.max, axis);
                }
                
                //Add primitive to all overlapping voxels
                for (int z = minVoxel[2]; z <= maxVoxel[2]; ++z)
                {
                    for (int y = minVoxel[1]; y <= maxVoxel[1]; ++y)
                    {
                        for (int x = minVoxel[0]; x <= maxVoxel[0]; ++x)
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


        /// <summary>
        /// After a GridAccelerator is generated, 
        /// we can step through this method for each Ray that will intersect with our scene.
        /// This method first checks that the given ray intersects the BoundingBox for our scene
        /// Then, sets up a 3D stepping algorithm so we can step through each voxel.
        /// Lastly, walk the ray through the intersection routine for each voxel until we hit a triangle. 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Triangle intersect(Ray r)
        {
            
            NextCrossingT = new float[3];
            DeltaT = new float[3];
            Step = new int[3];
            Out = new int[3];
            Pos = new int[3];


            //Check ray against overall grid bounds
            if (bounds.inside(r.at(r.getMinT())))
                hit0 = r.getMinT();
            else if (!bounds.Intersect(r, out hit0, out hit1))
                return null;

            gridIntersect = r.at(hit0);


            //Set up 3D DDA for ray

            //foreach axis:

            for (int axis = 0; axis < 3; axis++)
            {
                //Compute current voxel for each axis
                Pos[axis] = posToVoxel(gridIntersect, axis);
                if (axis == 0)
                {
                    if (r.getDirection().X >= 0)
                        handlePositiveRay(r, 0);
                    else
                        handleNegativeRay(r, 0);
                }
                else if (axis == 1)
                {
                    if (r.getDirection().Y >= 0)
                        handlePositiveRay(r, 1);
                    else
                        handleNegativeRay(r, 1);
                }
                else
                {
                    if (r.getDirection().Z >= 0)
                        handlePositiveRay(r, 2);
                    else
                        handleNegativeRay(r, 2);
                }
            }



            //Walk ray through voxel grid
            bool hitSomething = false;
            float outT;
            while (!hitSomething)
            {
                Voxel voxel = voxels[offset((int)Pos[0], (int)Pos[1], (int)Pos[2])];
                
                if (voxel.numTriangles > 0)
                {

                    Triangle intersect = voxel.intersect(r, out outT);
                    if (intersect != null)
                    {
                        return intersect;

                    }
                }
                


                //Advance to next voxel

                //Find stepAxis for stepping to next voxel

                int stepAxis;
                if (NextCrossingT[0] <= NextCrossingT[1] && NextCrossingT[0] <= NextCrossingT[2])
                    stepAxis = 0;
                else if (NextCrossingT[1] <= NextCrossingT[0] && NextCrossingT[1] <= NextCrossingT[2])
                    stepAxis = 1;
                else
                    stepAxis = 2;

                //Our rays currently always have a MaxT of float.MaxValue;
                if (r.getMaxT() < NextCrossingT[stepAxis])
                    return null;


                //Move to next voxel
                Pos[stepAxis] += Step[stepAxis];

                //If we hit an edge, return no intersection.
                if (Pos[stepAxis] == Out[stepAxis])
                    return null;

                NextCrossingT[stepAxis] += DeltaT[stepAxis];

            }
            return null;
        }

        /// <summary>
        /// Prepares the NextCrossingT, DeltaT, Step, and Out Arrays for voxel stepping.
        /// This method can only handle rays that are positive in relation to the given axis.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="axis"></param>
        private void handlePositiveRay(Ray r, int axis)
        {

            if (axis == 0)
            {
                NextCrossingT[axis] = hit0 + (voxelToPos(Pos[axis] + 1, axis) - gridIntersect.X) / r.getDirection().X;
                DeltaT[axis] = width[axis] / r.getDirection().X;

            }
            else if (axis == 1)
            {
                NextCrossingT[axis] = hit0 + (voxelToPos(Pos[axis] + 1, axis) - gridIntersect.Y) / r.getDirection().Y;
                DeltaT[axis] = width[axis] / r.getDirection().Y;
            }
            else
            {
                NextCrossingT[axis] = hit0 + (voxelToPos(Pos[axis] + 1, axis) - gridIntersect.Z) / r.getDirection().Z;
                DeltaT[axis] = width[axis] / r.getDirection().Z;
            }
            Step[axis] = 1;
            Out[axis] = nVoxels[axis];

        }

        /// <summary>
        /// Prepares the NextCrossingT, DeltaT, Step, and Out Arrays for voxel stepping.
        /// This method can only handle rays that are negative in relation to the given axis.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="axis"></param>
        private void handleNegativeRay(Ray r, int axis)
        {

            if (axis == 0)
            {
                NextCrossingT[axis] = hit0 + (voxelToPos(Pos[axis], axis) - gridIntersect.X) / r.getDirection().X;
                DeltaT[axis] = -width[axis] / r.getDirection().X;
            }
            else if (axis == 1)
            {
                NextCrossingT[axis] = hit0 + (voxelToPos(Pos[axis], axis) - gridIntersect.Y) / r.getDirection().Y;
                DeltaT[axis] = -width[axis] / r.getDirection().Y;
            }
            else
            {
                NextCrossingT[axis] = hit0 + (voxelToPos(Pos[axis], axis) - gridIntersect.Z) / r.getDirection().Z;
                DeltaT[axis] = -width[axis] / r.getDirection().Z;

            }
            Step[axis] = -1;
            Out[axis] = -1;

        }

        /// <summary>
        /// This method calculates the position in the voxel array where the given voxel can be found.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public int offset(int x, int y, int z)
        {
            return z * nVoxels[0] * nVoxels[1] + y * nVoxels[0] + x;
        }

        /// <summary>
        /// Given a Position p, and an axis 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        private int posToVoxel(Vector3 p, int axis)
        {
            int v;

            if (axis == 0)
            {
                v = (int)Math.Floor((p.X - bounds.min.X) * invWidth[axis]);

            }
            else if (axis == 1)
            {
                v = (int)Math.Floor((p.Y - bounds.min.Y) * invWidth[axis]);
            }
            else
            {
                v = (int)Math.Floor((p.Z - bounds.min.Z) * invWidth[axis]);
            }

            return Clamp(v, 0, nVoxels[axis] - 1);
        }

        /// <summary>
        /// This method returns the position of the given voxel’s lower corner.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        private float voxelToPos(int p, int axis)
        {
            if (axis == 0)
                return bounds.min.X + (p * width[axis]);
            else if (axis == 1)
                return bounds.min.Y + (p * width[axis]);
            else
                return bounds.min.Z + (p * width[axis]);
        }

        /// <summary>
        /// Calculates the number of voxels to create per unit distance.
        /// </summary>
        /// <returns></returns>
        private float getVoxelsPerUnitDist()
        {
            int maxAxis = bounds.MaximumExtent();
            float cubeRoot = (float)(3f * Math.Pow(numTriangles, 1f / 3f));

            float invMaxWidth;
            invMaxWidth = 1f / delta[maxAxis];

            return cubeRoot * invMaxWidth;
        }

        /// <summary>
        /// Basic clamp function.
        /// Verifies the given value is between the min and max.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int Clamp(int value, int min, int max)
        {
            return value < min ? min : value > max ? max : value;
        }
    }
}
