using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{
    class Ray
    {
        Point origin;
        Vector3 direction;
        float maxT;

        public Ray(Point origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = Vector3.Normalize(direction);
        }

        /**
         * <summary>
         * Returns a point along the ray at a given distance.
         * </summary>
         * 
         */ 
        public Point at(double dist)
        {
            Vector3 output = Vector3.Add(Vector3.Multiply(direction, (float)dist), new Vector3(origin.x, origin.y, origin.z));
            return new Point(output.X, output.Y, output.Z);
        }

        /**
         * <summary> 
         * Updates the current rays maxT with a given int
         * </summary>
         */
        public void updatemaxT(float maxT)
        {
            this.maxT = maxT;
        }

        /**
         * <summary>
         * Returns this rays maxT value
         * </summary>
         */
        public float? getMaxT()
        {
            if(this.maxT == null)
            {
                return null;
            }
            else
            {
                return this.maxT;
            }
        }


    }
}
