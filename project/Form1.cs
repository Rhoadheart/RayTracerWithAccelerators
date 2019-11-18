using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Numerics;

namespace project.RayTracing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        //Read InputFile parameters
                        Process.Start("notepad.exe", filePath);
                        
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Camera c1;
            Image output;
            Triangle[] triangles;
            Vector3 origin, up;
            Mesh m1;

            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);
            triangles = new Triangle[3];
            c1 = new Camera(new Vector3(-2, 0, 0), new Vector3(1, 0, 0), up, 1920, 1080);
            triangles[0] = new Triangle(new Vector3(2, -1, 1), new Vector3(2, 1, 0), new Vector3(2, -1, -1));
            triangles[1] = new Triangle(new Vector3(2, -1, 1), new Vector3(1, 1, 1), new Vector3(2, 1, 0));
            triangles[2] = new Triangle(new Vector3(2, -1, -1), new Vector3(2, 1, 0), new Vector3(1, 1, -1));
            m1 = new Mesh(triangles);

            string filename = "../../TestMesh2.png";
            output = new Image(c1, m1, filename);

            LoadOBJ loader = new LoadOBJ();

            c1 = new Camera(new Vector3(-2, -2, -2), new Vector3(1, 1, 1), up, 1920, 1080);
            filename = "../../../crate.obj";
            m1 = loader.Load(filename);
            filename = "../../crate.png";
            output = new Image(c1, m1, filename);
            
            filename = "../../../sphere.obj";
            m1 = loader.Load(filename);
            filename = "../../sphere.png";
            output = new Image(c1, m1, filename);
            
            //This code takes extremely long. I calculated it as lasting around 9.6 hours
            /*
            filename = "../../../bunny_max_res.obj";
            loader = new LoadOBJ();
            m1 = loader.Load(filename);
            filename = "../../TestMesh4.png";
            output = new Image(c1, m1, filename);
            */
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputGenerator IG = new InputGenerator();
            IG.Show();
            IG.Owner = this;
            this.Hide();
        
        }
        
    }
}
