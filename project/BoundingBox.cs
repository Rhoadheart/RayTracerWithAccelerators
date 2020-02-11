using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{
    public class BoundingBox
    {
        public Vector3 min;
        public Vector3 max;
        

        /// <summary>
        /// Default Constructor.
        /// Creates a bounding box from just one point. 
        /// This box will have a volume of 0.
        /// This constructor is also called by other constructors in this class
        /// </summary>
        /// <param name="point"></param>
        public BoundingBox(Vector3 point)
        {
            this.min = point;
            this.max = point;
        }

        /// <summary>
        /// Default Constructor.
        /// Creates a bounding box from just one point. 
        /// This box will have a volume of 0.
        /// This constructor is also called by other constructors in this class
        /// </summary>
        /// <param name="point"></param>
        public BoundingBox(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Creates a BoundingBox from 3 points.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public BoundingBox(Vector3 p1, Vector3 p2, Vector3 p3) : this(p1)
        {
            this.addPoint(p2);
            this.addPoint(p3);
        }

        /// <summary>
        /// Creates a BoundingBox from the 3 points that define a triangle.
        /// </summary>
        /// <param name="t1"></param>
        public BoundingBox(Triangle t1) : this(t1.p1)
        {
            this.addPoint(t1.p2);
            this.addPoint(t1.p3);
            
        }

        /// <summary>
        /// Adds a point to the BoundingBox. If the point is outside the current BoundingBox, it resizes.
        /// </summary>
        /// <param name="point"></param>
        public void addPoint(Vector3 point)
        {
            this.min = new Vector3(Math.Min(min.X, point.X), Math.Min(min.Y, point.Y), Math.Min(min.Z, point.Z));
            this.max = new Vector3(Math.Max(max.X, point.X), Math.Max(max.Y, point.Y), Math.Max(max.Z, point.Z));
            
        }

        /// <summary>
        /// Adds the three points of a triangle to the BoundingBox.
        /// </summary>
        /// <param name="t1"></param>
        public void addTriangle(Triangle t1)
        {
            this.addPoint(t1.p1);
            this.addPoint(t1.p2);
            this.addPoint(t1.p3);
        }

        public void Union(BoundingBox b)
        {
            this.addPoint(b.min);
            this.addPoint(b.max);
        }

        /// <summary>
        /// Transcription of the author's code for Ray/BoundingBox intersection
        /// </summary>
        /// <param name="r"></param>
        /// <param name="hit0"></param>
        /// <param name="hit1"></param>
        /// <returns></returns>
        public bool Intersect(Ray r, out float hit0, out float hit1)
        {
            float t0 = r.getMinT();//I dont know why I have to cast these. Compiler says r.getMaxT returns float?. This doesn't make sense
            float t1 = r.getMaxT();

            for(int i = 0; i<3; ++i)
            {
                //Update interval for ith bounding box slab
                float invRaydir;
                float tNear;
                float tFar;
                if(i == 0)
                {
                    invRaydir = 1f / r.getDirection().X;
                    tNear = (min.X - r.getOrigin().X) * invRaydir;
                    tFar = (max.X - r.getOrigin().X) * invRaydir;
                    //Update parametric interval from slab intersection ts
                    if (tNear > tFar)
                        Swap(ref tNear,ref tFar);
                    t0 = tNear > t0 ? tNear : t0;
                    t1 = tFar < t1 ? tFar : t1;
                    if (t0 > t1)
                    {
                        hit0 = -1f;
                        hit1 = -1f;
                        return false;
                    }
                }else if (i == 1)
                {
                    invRaydir = 1f / r.getDirection().Y;
                    tNear = (min.Y - r.getOrigin().Y) * invRaydir;
                    tFar = (max.Y - r.getOrigin().Y) * invRaydir;
                    //Update parametric interval from slab intersection ts
                    if (tNear > tFar)
                        Swap(ref tNear, ref tFar);
                    t0 = tNear > t0 ? tNear : t0;
                    t1 = tFar < t1 ? tFar : t1;
                    if (t0 > t1)
                    {
                        hit0 = -1f;
                        hit1 = -1f;
                        return false;
                    }
                }
                else
                {
                    invRaydir = 1f / r.getDirection().Z;
                    tNear = (min.Z- r.getOrigin().Z) * invRaydir;
                    tFar = (max.Z - r.getOrigin().Z) * invRaydir;
                    //Update parametric interval from slab intersection ts
                    if (tNear > tFar)
                        Swap(ref tNear, ref tFar);
                    t0 = tNear > t0 ? tNear : t0;
                    t1 = tFar < t1 ? tFar : t1;
                    if (t0 > t1)
                    {
                        hit0 = -1f;
                        hit1 = -1f;
                        return false;
                    }
                }
            }
            hit0 = t0;
            hit1 = t1;
            return true;
        }
        
        
        public bool inside(Vector3 p)
        {
            return (p.X >= min.X && p.X <= max.X &&
                    p.Y >= min.Y && p.Y <= max.Y &&
                    p.Z >= min.Z && p.Z <= max.Z);
        }
        

        public int MaximumExtent()
        {
            Vector3 diag = max - min;
            if (diag.X > diag.Y && diag.X > diag.Z)
                return 0;
            else if (diag.Y > diag.Z)
                return 1;
            else
                return 2;

        }

        static void Swap(ref float a, ref float b)
        {
            float temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Splits a bounding box into 8 equal parts.
        /// </summary>
        /// <returns>Returns a list of 8 BoundingBoxes </returns>
        public List<BoundingBox> Split()
        {
            Vector3 min = this.min;
            Vector3 max = this.max;

            float xdim = max.X - min.X;
            float ydim = max.Y - min.Y;
            float zdim = max.Z - min.Z;

            float xOffset = xdim / 2;
            float yOffset = ydim / 2;
            float zOffset = zdim / 2;

            Vector3 center = min + new Vector3(xOffset, yOffset, zOffset);

            //Create a list of BoundingBoxes, and fill them in.
            List<BoundingBox> BBoxes = new List<BoundingBox>(8);
            Vector3 offset = new Vector3(0, 0, 0);

            BBoxes.Add(new BoundingBox(min, center));

            offset = new Vector3(xOffset, 0, 0);
            BBoxes.Add(new BoundingBox(min + offset, center + offset));

            offset = new Vector3(0, yOffset, 0);
            BBoxes.Add(new BoundingBox(min + offset, center + offset));

            offset = new Vector3(xOffset, yOffset, 0);
            BBoxes.Add(new BoundingBox(min + offset, center + offset));

            offset = new Vector3(0, 0, zOffset);
            BBoxes.Add(new BoundingBox(min + offset, center + offset));

            offset = new Vector3(xOffset, 0, zOffset);
            BBoxes.Add(new BoundingBox(min + offset, center + offset));

            offset = new Vector3(0, yOffset, zOffset);
            BBoxes.Add(new BoundingBox(min + offset, center + offset));

            offset = new Vector3(xOffset, yOffset, zOffset);
            BBoxes.Add(new BoundingBox(min + offset, center + offset));

            return BBoxes;

        }

    }
    
}
