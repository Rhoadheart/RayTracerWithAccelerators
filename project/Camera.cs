using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{

    class Camera
    {
        int resX;
        int resY;
        int fov;
        Vector3 u;
        Vector3 v;
        Vector3 n;
        Point p;
        
        /**
         * <summary>
         * Default constructor for camera tkaing vectors (u,v,n), Position p, resolution width, resolution height  
         * </summary>
         */
        public Camera(Point p, Point LookAt, Vector3 Up, int resX, int resY)
        {
            this.u = u;
            this.v = v;
            this.n = n;
            this.p = p;
            this.fov = 43;
            this.resX = resX;
            this.resY = resY;
        }

        /**
         * <summary>
         * Method for setting the Feild of View 
         * Pass in a degree
         * </summary>
         */
        public void setFov(int fov)
        {
            this.fov = fov;
        }

        /**
         * <summary>
         * Method for getting a ray at a particular position given screen Coordinates
         * </summary>
         */
        public Ray getRay(Point screenCoords)
        {
            Matrix4x4 Model = new Matrix4x4();
            Matrix4x4 Projection = new Matrix4x4();
            Matrix4x4 View = new Matrix4x4();

            Matrix4x4 MInverse;
            bool succeeded = Matrix4x4.Invert(Matrix4x4.Multiply(Projection, View), out MInverse);
            
            if (succeeded)
            {

            }
            

            return null;
        }
        
    }
}
