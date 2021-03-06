﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MyExtensions;

namespace project.RayTracing
{

    public class Camera
    {
        int resX;
        int resY;
        float fov;
        Vector3 u;
        Vector3 v;
        Vector3 n;
        public Vector3 p;
        public Vector3 LookAt;
        public Vector3 Up;
        
         /// <summary>
         /// Default constructor for camera taking vectors (u,v,n), Position p, resolution width, resolution height
         /// </summary>
         /// <param name="p"></param>
         /// <param name="LookAt"></param>
         /// <param name="Up"></param>
         /// <param name="resX"></param>
         /// <param name="resY"></param>
        public Camera(Vector3 p, Vector3 LookAt, Vector3 Up, int resX, int resY)
        {
            this.p = p;
            this.LookAt = LookAt;
            this.Up = Up;
            this.n = Vector3.Normalize(p - LookAt);
            this.u = Vector3.Normalize(Vector3.Cross(Up, this.n));
            this.v = Vector3.Normalize(Vector3.Cross(n,u));
            
            this.fov = (float)(Math.PI / 180) * 43; 
            this.resX = resX;
            this.resY = resY;
        }
        
        public int getResX()
        {
            return resX;
        }

        public int getResY()
        {
            return resY;
        }

        
        /// <summary>
        /// Method for setting the Feild of View 
        /// Pass in a degree
        /// </summary>
        /// <param name="fov"></param>
        public void setFov(float fov)
        {
            float radians = (float)(Math.PI / 180) * fov;
            this.fov = radians;
        }

        /// <summary>
        /// Returns a Ray in World Coordinates from a point in Screen Coordinates
        /// </summary>
        /// <param name="screenCoords"></param>
        /// <returns></returns>
        public Ray getRay(Vector2 screenCoords)
        {
            //Width and Height of screen.
            float Ws = resX;
            float Hs = resY;
            
            //Width and Height of Camera Projection
            float Hc = (float)(2 * Math.Tan(fov / 2));
            float Wc = Hc * (Ws / Hs);

            //Centering the point 
            Vector3 CartisianPoint = new Vector3(Ws / 2, Hs / 2, 0);
            Vector3 FOVScalar = new Vector3((Wc / Ws), (Hc / Hs), 1);


            Vector3 adjustedPosition = (new Vector3(screenCoords.X, screenCoords.Y, -1) - CartisianPoint) * FOVScalar;



            
            Matrix4x4 MInverse = new Matrix4x4(u.X, v.X, n.X, p.X, 
                                               u.Y, v.Y, n.Y, p.Y, 
                                               u.Z, v.Z, n.Z, p.Z, 
                                               0,   0,   0,   1  );
            




            Ray q = new Ray(p, adjustedPosition.ApplyMatrix(MInverse)); 
            return q;
        }
        
    }
}
