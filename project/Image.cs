using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading;

using System.IO;


namespace project.RayTracing
{
    public class Image
    {
        Bitmap b;
        RenderVisualizer RV;
        public string numIntersects;
        public string numNodes;
        public string avgTriPerLeaf;
        public string maxTriPerLeaf;
        public string numLeaves;
        public string maxHeight;
        public string avgHeight;
        public string raysPerPix;
        string sceneName;
        string csvFileName;

        /// <summary>
        /// Creates an image based off a bitmap 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFilePath"></param>
        public Image(Camera c, Mesh scene, string outputFilePath, String accelStruct) {
            this.sceneName = "?";
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
        public Image(Camera c, Mesh scene, string outputFilePath, RenderVisualizer RV, String accelStruct, int raysPerPix, float rayDistLimit, int heightLimit, int TriPerNode, bool AmbientOcclusion, string sceneName, string csvFileName)
        {
            this.sceneName = sceneName;
            this.raysPerPix = raysPerPix.ToString();
            this.csvFileName = csvFileName;
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
            this.sceneName = "?";
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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

           

            stopwatch.Stop();
            long setupDuration = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();

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
            stopwatch.Stop();
            long intersectDuration = stopwatch.ElapsedMilliseconds;

            if (accelStruct != "Brute Force")
            {
                numIntersects = accelerator.numIntersects.ToString();
                numNodes = accelerator.numNodes.ToString();
                avgTriPerLeaf = accelerator.avgTriPerLeaf.ToString();
                maxTriPerLeaf = accelerator.maxTriPerLeaf.ToString();
                numLeaves = accelerator.numLeaves.ToString();
                maxHeight = accelerator.maxHeight.ToString();
                avgHeight = accelerator.avgHeight.ToString();

            }
            else
            {
                numIntersects = scene.numIntersects.ToString();
                numNodes = "0";
                avgTriPerLeaf = "0";
                maxTriPerLeaf = "0";
                numLeaves = "0";
                maxHeight = "0";
                avgHeight = "0";
            }

            //Todo: Log Data in CSV

            //string accelStruct;
            //string sceneName = "";
            string sRaysPerPix = raysPerPix.ToString();
            string sSetupDuration = setupDuration.ToString();
            string sIntersectDuration = intersectDuration.ToString();
            string stotalDuration = (setupDuration + intersectDuration).ToString();

            string numTriangles = scene.numTriangles.ToString();



            //numIntersects
            //numNodes
            //avgTriPerLeaf
            //maxTriPerLeaf
            //numLeaves
            //avgHeight
            //maxHeight



            string sHeightLimit = heightLimit.ToString();
            string sTriPerNode = TriPerNode.ToString();
            string sResX = ResX.ToString();
            string sResY = ResY.ToString();
            string cameraPos = c.p.ToString().Replace(',',' ');
            string cameraOrient = c.LookAt.ToString().Replace(',', ' ');
            string cameraUp = c.Up.ToString().Replace(',', ' '); 

            if (!File.Exists(csvFileName))
            {
                string csvHeaders = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}\n", "Accel Struct", "Scene Name", "Rays Per Pixel", "Setup Duration", "Intersect Duration", "Total  Duration", "Num Triangles", "Num Intersects", "Num Nodes", "Avg Triangles per Leaf", "Max Triangles per Leaf", "Num Leaves", "Avg Leaf Height", "Max Leaf Height", "Height Limit", "Triangles per Node Limit", "Res X", "Res Y", "Camera Position", "Camera Orientation", "Camera Up");
                File.WriteAllText(csvFileName, csvHeaders);
            }
            
            string csv = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}\n", accelStruct, sceneName, sRaysPerPix, sSetupDuration, sIntersectDuration, stotalDuration, numTriangles, numIntersects, numNodes, avgTriPerLeaf, maxTriPerLeaf, numLeaves, avgHeight, maxHeight, sHeightLimit, sTriPerNode, sResX, sResY, cameraPos, cameraOrient, cameraUp);
            File.AppendAllText(csvFileName, csv);

            //End Timer here
            return b;
        }
    }
}
