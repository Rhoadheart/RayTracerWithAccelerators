using project.RayTracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace project.RayTracing
{
    public class Triangle
    {
        Vector3 p1;
        Vector3 p2;
        Vector3 p3;

        /// <summary>
        /// Default triangle constructor given 3 points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

        }

        /// <summary>
        /// Determines if the given ray intesects with this triangle
        /// </summary>
        /// <param name="r"></param>
        /// <param name="tOut"></param>
        /// <returns></returns>
        public bool intersection(Ray r, out float tOut)
        {
            //Computing s1
            Vector3 edge1 = this.p2 - this.p1;
            Vector3 edge2 = this.p3 - this.p1;
            Vector3 s1 = Vector3.Cross(r.getDirection(), edge2);
            float divisor = Vector3.Dot(s1, edge1);
            if(divisor == 0)
            {
                tOut = 0;
                return false;
            }
            float invDivisor = 1f / divisor;

            //Barysentric coordinate 1
            Vector3 d = r.getOrigin() - p1;
            float b1 = Vector3.Dot(d, s1) * invDivisor;
            if(b1 < 0 || b1 > 1)
            {
                tOut = 0;
                return false;
            }

            //Barysentric coordinate 2
            Vector3 s2 = Vector3.Cross(d,edge1);
            float b2 = Vector3.Dot(r.getDirection(), s2) * invDivisor;
            if(b2 < 0 || b1 + b2 > 1)
            {
                tOut = 0;
                return false;
            }

            //Check for positive T
            float t = Vector3.Dot(edge2, s2) * invDivisor;
            if (t < 0 ||  t > r.getMaxT()){
                tOut = 0;
                return false;
            }
            tOut = t;
            return true;
        }

        /// <summary>
        /// Determines the normal of a triangle after an intersection occurs.
        /// </summary>
        /// <returns></returns>
        public Vector3 normal()
        {
            Vector3 A = p2 - p1;
            Vector3 B = p3 - p2;
            return Vector3.Normalize(Vector3.Cross(A, B));
        }
        
    }
}
