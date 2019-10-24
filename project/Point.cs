using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{
    class Point
    {
        public float x;
        public float y;
        public float z;

        /**
         * <summary> 
         * Default constructor for a point given 3 floats
         * </summary>
         */
        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /**
         * <summary>
         * Takes 2 point objects and subtracts A from B coordinate-wise
         * </summary>
         */
        public static Vector3 operator-(Point a, Point b)
        {
            Vector3 vectA = a.toVector3();
            Vector3 vectB = b.toVector3();
            return vectA - vectB;
        }

        /**
         * <summary>
         * Takes 2 point objects and adds A to B coordinate-wise
         * </summary>
         */
        public static Vector3 operator+(Point a, Point b)
        {
            Vector3 vectA = a.toVector3();
            Vector3 vectB = b.toVector3();
            return vectA + vectB;
        }

        /**
         * <summary>
         * Converts point object to Vector3
         * </summary>
         */
        public Vector3 toVector3()
        {
            return new Vector3(this.getX(), this.getY(), this.getZ());
        }

        /**
         * <summary>
         * Returns this points x coordinate
         * </summary>
         */
        public float getX()
        {
            return this.x;
        }

        /**
         * <summary>
         * Returns this points y coordinate
         * </summary>
         */
        public float getY()
        {
            return this.y;
        }

        /**
         * <summary>
         * Returns this points z coordinate
         * </summary>
         */
        public float getZ()
        {
            return this.z;
        }
        
    }
}
