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
            int Ws = resX;
            int Hs = resY;
            
            float Hc = (float)(2 * Math.Tan(fov / 2));
            float Wc = Hc * (Ws / Hs);
            Point CartisianPoint = new Point(Ws / 2, Hs / 2, 1);
            Point FOVScalar = new Point(Wc / Ws, Hc / Hs, 1);

            Vector3 adjPosition3 = screenCoords - (CartisianPoint * FOVScalar);
            Vector4 adjPosition4 = new Vector4(adjPosition3.X, adjPosition3.Y, 1, 1);
            Matrix4x4 MInverse = new Matrix4x4(u.X, v.X, n.X, p.x, u.Y, v.Y, n.Y, p.y, u.Z, v.Z, n.Z, p.z, 0, 0, 0, 1);
            Vector4 q4 = Vector4.Transform(adjPosition4, MInverse);
            Vector3 q3 = new Vector3(q4.X, q4.Y, q4.Z);
            Ray q = new Ray(p, q3);
            return q;
        }
        
    }
}
