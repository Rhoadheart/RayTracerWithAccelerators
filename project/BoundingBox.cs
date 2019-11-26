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
        public Vector3 p;
        public Vector3 q;

        /// <summary>
        /// Default Constructor.
        /// Creates a bounding box from just one point. 
        /// This box will have a volume of 0.
        /// This constructor is also called by other constructors in this class
        /// </summary>
        /// <param name="point"></param>
        public BoundingBox(Vector3 point)
        {
            this.p = point;
            this.q = point;
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
            this.p = new Vector3(Math.Max(p.X, point.X), Math.Max(p.Y, point.Y), Math.Max(p.Z, point.Z));
            this.q = new Vector3(Math.Min(q.X, point.X), Math.Min(q.Y, point.Y), Math.Min(q.Z, point.Z));
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
        

        
    }
}
