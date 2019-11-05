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
    class Image
    {
        Bitmap b;

        /// <summary>
        /// Creates an image based off a bitmap 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFilePath"></param>
        public Image(Bitmap b, string outputFilePath)
        {
            this.b = generateImage(c, scene);
            Graphics g = Graphics.FromImage(b);
            //g.FillRectangle(Brushes.Red, 0, 0, c.getResX(), c.getResY());
            g.Dispose();
            b.Save(outputFilePath, ImageFormat.Png);
            b.Dispose();
        }
        // This code will help us create a BitMap in the future.

        public Bitmap generateImage(Camera c, Triangle scene)
        {
            int ResX = c.getResX();
            int ResY = c.getResY();
            Bitmap b = new Bitmap(ResX, ResY);
            for (int i = 0; i < ResX; i++)
            {
                for (int j = 0; j < ResY; j++)
                {
                    Ray r = c.getRay(new Vector2(i,j));
                    //This can be changed to Camera.getRay(ScreenCoordinates).intersection()...
                    Color newColor;
                    if (scene.intersection(r))
                    {
                        newColor = Color.FromArgb(0, 0, 255);
                    }
                    else
                    {
                        newColor = Color.FromArgb(0, 255, 0);
                    }
                    
                    b.SetPixel(ResX - i - 1, ResY - j - 1, newColor);
                }
            }
            return b;
        }
    }
}
