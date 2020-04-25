using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MyExtensions;

namespace project.RayTracing
{
    public class Ray
    {
        public Vector3 origin;
        public Vector3 direction;
        public float maxT;
        public float minT;
        public Vector3 invDirection;

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
            this.minT = 0;
            invDirection = new Vector3(1 / direction.X, 1 / direction.Y, 1 / direction.Z);
        }

        /// <summary>
        /// Returns a point along the ray at the given distance
        /// </summary>
        /// <param name="dist"></param>
        /// <returns></returns>
        public Vector3 at(float dist)
        {
            Vector3 output = Vector3.Add(Vector3.Multiply(direction, (float)dist), new Vector3(origin.X, origin.Y, origin.Z));
            return new Vector3(output.X, output.Y, output.Z);
        }

        /// <summary>
        /// Transforms this Ray based on the projection matrix.
        /// </summary>
        /// <param name="Projection"></param>
        /// <returns></returns>
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
        public float getMaxT()
        {
                return this.maxT;
        }

        /// <summary>
        /// Updates this rays maxT to the given int
        /// </summary>
        /// <param name="minT"></param>
        public void updateminT(float minT)
        {
            this.minT = minT;
        }

        /// <summary>
        /// Returns this rays minT value
        /// </summary>
        /// <returns></returns>
        public float getMinT()
        {
            return this.minT;
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
