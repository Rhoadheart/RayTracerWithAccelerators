using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace project
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
            this.b = b;
            Graphics g = Graphics.FromImage(b);
            g.FillRectangle(Brushes.Green, 0, 0, 50, 50);
            g.Dispose();
            b.Save(outputFilePath, System.Drawing.Imaging.ImageFormat.Png);
            b.Dispose();
        }
        /*
         * 
         * This code will help us create a BitMap in the future.
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //This can be changed to Camera.getRay(ScreenCoordinates).intersection()...
                    Color newColor = Color.FromArgb(0, 0, 255);
                    b.SetPixel(i, j, newColor);
                }
            }
            return b;
         
         * 
         * 
         * 
         */
    }
}
