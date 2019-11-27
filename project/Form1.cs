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

                        //InputFile input = Json.Convert.Deserialize(filepath);
                        //Now that we have the input, we can extract the variables
                        //string AccelerationStructure = input.AcceleraltionStructure;
                        //For each variable



                        
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
            GoodGenLabel.Hide();

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Camera c1;
            Image output;
            Vector3 origin, up;
            Mesh m1;

            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);
            LoadOBJ loader = new LoadOBJ();

            
            c1 = new Camera(new Vector3(2, 2, 2), new Vector3(0, 0, 0), up, 1920, 1080);
            string filename = "../../../crate.obj";
            m1 = loader.Load(filename);
            filename = "../../crate.png";
            output = new Image(c1, m1, filename);
            /*
            
            c1 = new Camera(new Vector3(0, 0, 5), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../sphere.obj";
            m1 = loader.Load(filename);
            filename = "../../sphere005.png";
            output = new Image(c1, m1, filename);

            /*
            c1 = new Camera(new Vector3(2, 2, 2), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../sphere.obj";
            m1 = loader.Load(filename);
            filename = "../../sphere222.png";
            output = new Image(c1, m1, filename);
            

            
            c1 = new Camera(new Vector3(-40, -40, -70), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../pokeball.obj";
            m1 = loader.Load(filename);
            filename = "../../pokeball.png";
            output = new Image(c1, m1, filename);
            */
            
            

            //This object has over 20,000 triangles and takes a while to run. 
            
            /*
            c1 = new Camera(new Vector3(-160, 135, 250), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../sword.obj";
            m1 = loader.Load(filename);
            filename = "../../sword.png";
            output = new Image(c1, m1, filename);
            


            //This object has over 150,000 triangles and takes extremely long to render.
            //I calculated it as lasting around 9.6 hours
            
            filename = "../../../bunny_max_res.obj";
            loader = new LoadOBJ();
            m1 = loader.Load(filename);
            filename = "../../bunny.png";
            output = new Image(c1, m1, filename);
            
    */
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InputGenerator IG = new InputGenerator();
            IG.Show();
            IG.Owner = this;
            //IG.Parent = this;
            this.Hide();

        
        }
        public string GoodGenLabelMethod
        {
            get
            {
                return GoodGenLabel.Text;
            }
            set
            {
                GoodGenLabel.Text = value;
            }
        }
    }
}
