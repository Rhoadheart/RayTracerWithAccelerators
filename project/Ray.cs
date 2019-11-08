using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MyExtensions;

namespace project.RayTracing
{
    class Ray
    {
        Vector3 origin;
        Vector3 direction;
        float maxT;
        float minT;

        /// <summary>
        /// Default constructor for creating a ray
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="direction"></param>
        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = Vector3.Normalize(direction);
            this.maxT = float.MaxValue;
        }

        /// <summary>
        /// Returns a point along the ray at the given distance
        /// </summary>
        /// <param name="dist"></param>
        /// <returns></returns>
        public Vector3 at(double dist)
        {
            Vector3 output = Vector3.Add(Vector3.Multiply(direction, (float)dist), new Vector3(origin.X, origin.Y, origin.Z));
            return new Vector3(output.X, output.Y, output.Z);
        }

        public Ray transform(Matrix4x4 Projection)
        {
            Vector3 origin = new Vector3(Projection.M14 + this.origin.X, Projection.M24 + this.origin.Y, Projection.M34 + this.origin.Z);
            return new Ray(origin, this.direction.ApplyMatrix(Projection));
        }

        /// <summary>
        /// Updates this rays maxT to the given int
        /// </summary>
        /// <param name="maxT"></param>
        public void updatemaxT(float maxT)
        {
            this.maxT = maxT;
        }

        /// <summary>
        /// Returns this rays maxT value
        /// </summary>
        /// <returns></returns>
        public float? getMaxT()
        {
                return this.maxT;
        }

        /// <summary>
        /// Getter for the origin
        /// </summary>
        /// <returns></returns>
        public Vector3 getOrigin()
        {
            return this.origin;
        }

        /// <summary>
        /// Geter for the direction
        /// </summary>
        /// <returns></returns>
        public Vector3 getDirection()
        {
            return this.direction;
        }

        /// <summary>
        /// ToString for the ray class
        /// </summary>
        /// <returns>
        /// (origin: origin direction: direction
        /// </returns>
        public override string ToString()
        {
            return "origin: " + this.origin + ", direction: " + direction;
        }


    }
}
