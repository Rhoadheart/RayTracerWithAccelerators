using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using MyExtensions;

namespace project.RayTracing
{
    class Shader
    {

        private Triangle intersect;
        private Ray r;


        public Shader(Triangle intersect, Ray r)
        {
            this.intersect = intersect;
            this.r = r;
        }

        public Color AmbientOcclusionShade(float RayDistanceLimit, int RaysPerPixel, Vector3 p, Accelerator accelerator, Mesh scene)
        {
            Color newColor = Color.FromArgb(0, 0, 0);
            if (intersect != null)
            {
                Vector3 u;
                Vector3 v;
                Vector3 n;

                n = intersect.normal(r);

                Vector3 nOffset = new Vector3(n.X * .1f, n.Y * .1f, n.Z * .1f);

                p = p + nOffset;

                if (Vector3.Normalize(n).Y < 0.95f)
                    u = Vector3.Cross(n, new Vector3(0, 1, 0));
                else
                    u = Vector3.Cross(n, new Vector3(1, 0, 0));

                v = Vector3.Cross(n, u);

                //Generate random rays sampling the hemisphere 
                float gray = 0f;

                Random rand = new Random();
                for (int i = 0; i < RaysPerPixel; i++)
                {
                    Vector3 randomLocal = UniformSampleHemisphere((float)rand.NextDouble(), (float)rand.NextDouble());

                    Matrix4x4 M = new Matrix4x4(u.X, v.X, n.X, 0,
                                                u.Y, v.Y, n.Y, 0,
                                                u.Z, v.Z, n.Z, 0,
                                                0, 0, 0, 1);

                    

                    Ray q = new Ray(p, randomLocal.ApplyMatrix(M));
                    if (accelerator != null)
                    {
                        float outT;

                        if (accelerator.intersect(q, out outT) != null)
                        {
                            if (outT < RayDistanceLimit)
                            {
                                gray +=  outT / RayDistanceLimit;

                            }
                        }
                        else
                        {
                            gray += 1;
                            
                        }

                    }
                    else
                    {
                        float outT;
                        if (accelerator.intersect(q, out outT) != null)
                        {
                            if (outT < RayDistanceLimit)
                            {
                                gray += outT / RayDistanceLimit;

                            }
                        }
                        else
                        {
                            gray += 1;

                        }
                    }


                }
                if(gray != 10)
                {
                    Console.WriteLine();
                }
                gray = gray / RaysPerPixel;
                int adjGray = (int)(gray * 255);

                newColor = Color.FromArgb(adjGray, adjGray, adjGray);
            }
            
            return newColor;

        }

        public Color TestColoringShade()
        {
            Color newColor = Color.FromArgb(0, 0, 0);

            //Default Normal Coloring
            if (intersect != null)
            {
                Vector3 normal = intersect.normal(r);
                float red = ((normal.X + 1) / 2) * 255;
                float green = ((normal.Y + 1) / 2) * 255;
                float blue = ((normal.Z + 1) / 2) * 255;
                newColor = Color.FromArgb((int)red, (int)green, (int)blue);
            }
            
            return newColor;
        }

        private Vector3 UniformSampleHemisphere(float rand1, float rand2) {
            float z = rand1;
            float r = (float)Math.Sqrt(Math.Max((double)0, (double)(1f - (z * z))));
            float phi =(float)(2 * Math.PI * rand2);

            return new Vector3((float)(r * Math.Cos(phi)), (float)(r * Math.Sin(phi)), z);
        }

}
}
