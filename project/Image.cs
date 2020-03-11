using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Drawing.Imaging;

namespace project.RayTracing
{
    public class Image
    {
        Bitmap b;
        RenderVisualizer RV;

        /// <summary>
        /// Creates an image based off a bitmap 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFilePath"></param>
        public Image(Camera c, Mesh scene, string outputFilePath, String accelStruct)
        {
            this.b = generateImage(c, scene, accelStruct);
            Graphics g = Graphics.FromImage(b);
            g.Dispose();
            b.Save(outputFilePath, ImageFormat.Png);
            b.Dispose();
        }

        

        /// <summary>
        /// Creates an image based off a bitmap 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFilePath"></param>
        public Image(Camera c, Mesh scene, string outputFilePath, RenderVisualizer RV, String accelStruct, int raysPerPix, float rayDistLimit, int heightLimit, int TriPerNode, bool AmbientOcclusion)
        {
            
            this.RV = RV;
            this.b = generateImage(c, scene, accelStruct, raysPerPix, rayDistLimit, heightLimit, TriPerNode, AmbientOcclusion);
            Graphics g = Graphics.FromImage(b);
            g.Dispose();
            b.Save(outputFilePath, ImageFormat.Png);
            b.Dispose();
        }

        /// <summary>
        /// Creates an image based off a bitmap 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFilePath"></param>
        public Image(Camera c, Mesh scene, string outputFilePath, RenderVisualizer RV, String accelStruct)
        {
            this.RV = RV;
            this.b = generateImage(c, scene, accelStruct);
            Graphics g = Graphics.FromImage(b);
            g.Dispose();
            b.Save(outputFilePath, ImageFormat.Png);
            b.Dispose();
        }

        /// <summary>
        /// generates an Image by shooting one Ray per pixel into our scene
        /// </summary>
        /// <param name="c"></param>
        /// <param name="scene"></param>
        /// <returns></returns>
        public Bitmap generateImage(Camera c, Mesh scene, String accelStruct, int raysPerPix = -100, float rayDistLimit = -1f, int heightLimit = -1, int TriPerNode = -1, bool AmbientOcclu = true)
        {
            //Todo: Dynamically pass in colorizer, RaysPerPixel, and RayDistanceLimit from InputGenerator
            string colorizer = "";
            if (AmbientOcclu == true)
            {
                colorizer = "Ambient Occlusion";
            }
            int ResX = c.getResX();
            int ResY = c.getResY();
            Bitmap b = new Bitmap(ResX, ResY);
            //Start Timer here.
            Accelerator accelerator = null;

            switch (accelStruct)
            {
                
                case ("Grid"):
                    accelerator = new GridAccelerator(scene);
                    break;
                case ("Octree"):
                    //TODO: Dynamically change limits from UI?
                    accelerator = new OctreeAccelerator(scene, heightLimit, TriPerNode);
                    break;
                case ("Bounding Volume Hierarchy"):
                    accelerator = new BvHAccelerator(scene, heightLimit, TriPerNode);
                    break;
                default:
                    break;
            }

            Random rand = new Random();
            for (int i = 0; i < ResX; i++)
            {
                //Check how far the rendering is
                for (int j = 0; j < ResY; j++)
                {
                    if(i == 650 && j == 375)
                    {
                        Console.WriteLine("Test");
                    }
                    
                    Color newColor;
                    Ray r = c.getRay(new Vector2(i,j));


                    Triangle intersect = null;
                    float outT;
                    
                    if(accelStruct != "Brute Force")
                    {
                        intersect = accelerator.intersect(r, out outT);
                    }
                    else
                    {
                        intersect = scene.intersect(r, out outT);
                    }

                    
                    Shader shader = new Shader(intersect, r);
                    if(colorizer == "Ambient Occlusion")
                    {
                        newColor = shader.AmbientOcclusionShade(rayDistLimit, raysPerPix, r.at(outT), accelerator, scene, rand);
                    }
                    else
                    {
                        newColor = shader.TestColoringShade();
                    }

                    //RV.updateBitmap(b);

                    b.SetPixel(i, ResY - j - 1 , newColor);
                }
                if (RV != null && i % 25 == 0)
                {
                    RV.updateBitmap(b);
                }



            }
            //End Timer here
            return b;
        }
    }
}
