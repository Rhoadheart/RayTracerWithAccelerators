using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace project
{
    public partial class RenderVisualizer : Form
    {
        Bitmap b;
        PictureBox pb;

        public RenderVisualizer(int width, int height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            this.Text = "Render Visualizer";
            pb = new PictureBox();
            pb.Width = this.Width;
            pb.Height = this.Height;
            this.Controls.Add(pb);
        }

        public void updateBitmap(Bitmap b)
        {
            this.b = b;
            pb.Image = b;
            pb.Refresh();
           
            
        }
    }
}
