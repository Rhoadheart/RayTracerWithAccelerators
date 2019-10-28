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
        Vector3 origin;
        Vector3 direction;
        float maxT;

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = Vector3.Normalize(direction);
            this.maxT = float.MaxValue;
        }

        /**
         * <summary>
         * Returns a point along the ray at a given distance.
         * </summary>
         * 
         */ 
        public Vector3 at(double dist)
        {
            Vector3 output = Vector3.Add(Vector3.Multiply(direction, (float)dist), new Vector3(origin.X, origin.Y, origin.Z));
            return new Vector3(output.X, output.Y, output.Z);
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
                return this.maxT;
        }

        /**
         * <summary> 
         * Getter for the origin
         * </summary>
         */
        public Vector3 getOrigin()
        {
            return this.origin;
        }

        /**
         * <summary>
         * Getter for the direction
         * </summary>
         */
        public Vector3 getDirection()
        {
            return this.direction;
        }

        public override string ToString()
        {
            return "origin: " + this.origin + ", direction: " + direction;
        }


    }
}
