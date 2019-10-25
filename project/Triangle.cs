using project.RayTracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace project.RayTracing
{
    class Triangle
    {
        Point p1;
        Point p2;
        Point p3;

        /**
         * <summary>
         * Default Triangle constructor given 3 points
         * </summary>
         */
        public Triangle(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

        }

        /**
         * <summary>
         * Determines if the given ray intersects with this Triangle
         * </summary>
         */
        public bool intersection(Ray r)
        {
            //Computing s1
            Vector3 edge1 = this.p2 - this.p1;
            Vector3 edge2 = this.p3 - this.p1;
            Vector3 s1 = Vector3.Cross(r.getDirection(), edge2);
            float divisor = Vector3.Dot(s1, edge1);
            if(divisor == 0)
            {
                return false;
            }
            float invDivisor = 1f / divisor;

            //Barysentric coordinate 1
            Vector3 d = r.getOrigin() - p1;
            float b1 = Vector3.Dot(d, s1) * invDivisor;
            if(b1 < 0 || b1 > 1)
            {
                return false;
            }

            //Barysentric coordinate 2
            Vector3 s2 = Vector3.Cross(d,edge1);
            float b2 = Vector3.Dot(r.getDirection(), s2) * invDivisor;
            if(b2 < 0 || b1 + b2 > 1)
            {
                return false;
            }

            //Check for positive T
            float t = Vector3.Dot(edge2, s2) * invDivisor;
            if (t < 0 ||  t > r.getMaxT()){
                return false;
            }

            return true;
        }
        
    }
}
