using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Ray.cs;

namespace project
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
        public Camera(Vector3 u, Vector3 v, Vector3 n, Point p, int resX, int resY)
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
        /*public Ray getRay(Point screenCoords)
        {

        }
        */
    }
}
