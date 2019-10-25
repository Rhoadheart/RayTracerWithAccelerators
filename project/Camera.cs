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
         * Default constructor for camera taking vectors (u,v,n), Position p, resolution width, resolution height  
         * </summary>
         */
        public Camera(Point p, Point LookAt, Vector3 Up, int resX, int resY)
        {
            this.n = p - LookAt;
            this.u = Vector3.Cross(Up, this.n);
            this.v = Vector3.Cross(n,u);
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

        /// <summary>
        /// Returns a Ray in World Coordinates from a point in Screen Coordinates
        /// </summary>
        /// <param name="screenCoords"></param>
        /// <returns></returns>
        public Ray getRay(Point screenCoords)
        {
            //Width and Height of screen.
            int Ws = resX;
            int Hs = resY;
            
            //Width and Height of Camera Projection
            float Hc = (float)(2 * Math.Tan(fov / 2));
            float Wc = Hc * (Ws / Hs);

            //Centering the point 
            Point CartisianPoint = new Point(Ws / 2, Hs / 2, 1);

            Point FOVScalar = new Point((Wc / Ws) + 1, (Hc / Hs) +1, 1);

            Point adjustedPoint = Point.Sub(screenCoords, CartisianPoint) * FOVScalar;
            Vector3 adjustedPosition = new Vector3(adjustedPoint.x, adjustedPoint.y, 1);

            Matrix4x4 MInverse = new Matrix4x4(u.X, v.X, n.X, p.x,
                                               u.Y, v.Y, n.Y, p.y, 
                                               u.Z, v.Z, n.Z, p.z, 
                                               0,   0,   0,   1);

            Ray q = new Ray(p, Vector3.Transform(adjustedPosition, MInverse));
            return q;
        }
        
    }
}
