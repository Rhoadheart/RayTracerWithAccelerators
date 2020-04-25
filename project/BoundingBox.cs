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

        public Vector3 centroid
        {
            get
            {
                return (this.max + this.min) / 2;
            }
        }



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
            float t0 = r.minT;
            float t1 = r.maxT;
            Vector3 origin = r.origin;
            Vector3 direction = r.direction;
            Vector3 invDirection = r.invDirection;
            //Todo: Remove Loop and in-line code

            //Update interval for ith bounding box slab
            float tNear;
            float tFar;
            float temp;

            
            tNear = (min.X - origin.X) * invDirection.X;
            tFar = (max.X - origin.X) * invDirection.X;
            //Update parametric interval from slab intersection ts
            if (tNear > tFar)
            {
                temp = tNear;
                tNear = tFar;
                tFar = temp;
            }
            t0 = tNear > t0 ? tNear : t0;
            t1 = tFar < t1 ? tFar : t1;
            if (t0 > t1)
            {
                hit0 = -1f;
                hit1 = -1f;
                return false;
            }
            
            tNear = (min.Y - origin.Y) * invDirection.Y;
            tFar = (max.Y - origin.Y) * invDirection.Y;
            //Update parametric interval from slab intersection ts
            if (tNear > tFar)
            {
                temp = tNear;
                tNear = tFar;
                tFar = temp;
            }

            t0 = tNear > t0 ? tNear : t0;
            t1 = tFar < t1 ? tFar : t1;
            if (t0 > t1)
            {
                hit0 = -1f;
                hit1 = -1f;
                return false;
            }
            
            tNear = (min.Z- origin.Z) * invDirection.Z;
            tFar = (max.Z - origin.Z) * invDirection.Z;
            //Update parametric interval from slab intersection ts
            if (tNear > tFar)
            {
                temp = tNear;
                tNear = tFar;
                tFar = temp;
            }
            t0 = tNear > t0 ? tNear : t0;
            t1 = tFar < t1 ? tFar : t1;
            if (t0 > t1)
            {
                hit0 = -1f;
                hit1 = -1f;
                return false;
            }
            
            
            hit0 = t0;
            hit1 = t1;
            return true;
        }

        public bool Intersect(Ray r, out float hit0)
        {
            Vector3 t0s = (this.min - r.origin) * r.invDirection;
            Vector3 t1s = (this.max - r.origin) * r.invDirection;

            Vector3 tsmaller = Min(t0s, t1s);
            Vector3 tbigger = Max(t0s, t1s);
                
            hit0 = Max(r.minT,Max(tsmaller.X, Max(tsmaller.Y, tsmaller.Z)));
            float hit1 = Min(r.maxT,Min(tbigger.X, Min(tbigger.Y, tbigger.Z)));

            return (hit0 < hit1);
            
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

        static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X < b.X ? a.X : b.X,
                              a.Y < b.Y ? a.Y : b.Y,
                              a.Z < b.Z ? a.Z : b.Z);
        }

        static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X > b.X ? a.X : b.X,
                              a.Y > b.Y ? a.Y : b.Y,
                              a.Z > b.Z ? a.Z : b.Z);
        }

        static float Min(float a, float b)
        {
            if (a < b)
                return a;
            return b;
        }

        static float Max(float a, float b)
        {
            if (a > b)
                return a;
            return b;
        }

        /// <summary>
        /// Splits a bounding box into 8 equal parts. 
        /// </summary>
        /// <returns>Returns a list of 8 BoundingBoxes </returns>
        public List<BoundingBox> Split()
        {

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

        //Todo: Rewrite based on overlaps in PBRT

        /*
        bool Overlaps(const Bounds3<T> &b1, const Bounds3<T> &b2) {
            bool x = (b1.pMax.x >= b2.pMin.x) && (b1.pMin.x <= b2.pMax.x);
            bool y = (b1.pMax.y >= b2.pMin.y) && (b1.pMin.y <= b2.pMax.y);
            bool z = (b1.pMax.z >= b2.pMin.z) && (b1.pMin.z <= b2.pMax.z);
            return (x && y && z);
        }
        */
        public bool contains(Triangle t)
        {
            /*
             Intersect(const Bounds3<T> &b1, const Bounds3<T> &b2) {
                 return Bounds3<T>(Point3<T>(std::max(b1.pMin.x, b2.pMin.x),
                                std::max(b1.pMin.y, b2.pMin.y),
                                std::max(b1.pMin.z, b2.pMin.z)),
                      Point3<T>(std::min(b1.pMax.x, b2.pMax.x),
                                std::min(b1.pMax.y, b2.pMax.y),
                                std::min(b1.pMax.z, b2.pMax.z)));
            */
            BoundingBox triBBox = new BoundingBox(t);

            float minX = Math.Max(this.min.X, triBBox.min.X);
            float minY = Math.Max(this.min.Y, triBBox.min.Y);
            float minZ = Math.Max(this.min.Z, triBBox.min.Z);

            float maxX = Math.Min(this.max.X, triBBox.max.X);
            float maxY = Math.Min(this.max.Y, triBBox.max.Y);
            float maxZ = Math.Min(this.max.Z, triBBox.max.Z);

            //Vector3 min = new Vector3(minX, minY, minZ);
            //Vector3 max = new Vector3(maxX, maxY, maxZ);

            if (minX > maxX || minY > maxY || minZ > maxZ)
                return false;
            else
                return true;
            
        }


        public float scale()
        {
            Vector3 diag = max - min;
            return diag.Length();
        }
        

    }
    
}
