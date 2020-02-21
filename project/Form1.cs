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
using Json.Net;
using Newtonsoft.Json;

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
            Mesh m1;
            Image output;
            LoadOBJ loader = new LoadOBJ();

            openFileDialog1.Filter = "Text File | *.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        //InputFile input = Json.Convert.Deserialize(filepath);
                        //Now that we have the input, we can extract the variables
                        //string AccelerationStructure = input.AcceleraltionStructure;
                        //For each variable
                        

                        Vector3 CP, CO, CU; 
                        InputFile input = JSONDeserialize(filePath);
                        CP = new Vector3(input.CPx, input.CPy, input.CPz);
                        CO = new Vector3(input.COx, input.COy, input.COz);
                        CU = new Vector3(input.CUx, input.CUy, input.CUz);
                        
                        Camera c1 = new Camera(CP, CO, CU, input.ResolutionX, input.ResolutionY);
                        c1.setFov(43);
                        string filename = input.OBJLocation;
                        m1 = loader.Load(filename);
                        filename = input.CSVLocation + "/" + input.OutputFilename +".png";

                        RenderVisualizer RV = new RenderVisualizer(input.ResolutionX, input.ResolutionY);

                        if (input.RealTimeRend == true)
                        {
                            RV.Text = "Render Visualizer";
                            RV.Show();
                            RV.Owner = this;
                            //RV.Parent = this;
                            this.Hide();
                        }

                        //Todo: Dynamically pass in Colorizer and RaysPerPixel and RayDistanceLimit from JSON
                        output = new Image(c1, m1, filename, RV, input.AccelerationStruct);
                        RV.Close();
                        this.Show();
                        GoodGenLabel.Show();
                        GoodGenLabel.Text = "Output Image Created";
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        
        /// <summary>
        /// Takes a file path and returns a InputFile with JSON text
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private InputFile JSONDeserialize(String filepath)
        {
            String JsonString;
            FileStream inputfile = File.OpenRead(filepath);

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(inputfile))
                {
                    // Read the stream to a string, and write the string to the console.
                    JsonString = sr.ReadToEnd();
                }
                
                InputFile input = JsonConvert.DeserializeObject<InputFile>(JsonString);
                return input;
                
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return null;
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            GoodGenLabel.Hide();

        }

        /*
        private void button3_Click(object sender, EventArgs e)
        {
            Camera c1;
            Image output;
            Vector3 origin, up;
            Mesh m1;
            string filename;

            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);
            LoadOBJ loader = new LoadOBJ();
            
            
            
            c1 = new Camera(new Vector3(2, 2, 2), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../crate.obj";
            m1 = loader.Load(filename);
            filename = "../../crate.png";
            output = new Image(c1, m1, filename, "Grid");
            
            
            
            c1 = new Camera(new Vector3(0, 0, 5), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../sphere.obj";
            m1 = loader.Load(filename);
            filename = "../../sphere005.png";
            output = new Image(c1, m1, filename, "Grid");

            

            c1 = new Camera(new Vector3(2, 2, 2), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../sphere.obj";
            m1 = loader.Load(filename);
            filename = "../../sphere222.png";
            output = new Image(c1, m1, filename, "Grid");
            
            
            
            c1 = new Camera(new Vector3(-40, -40, -70), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../pokeball.obj";
            m1 = loader.Load(filename);
            filename = "../../pokeball.png";
            output = new Image(c1, m1, filename);
            
            
            

            //This object has over 20,000 triangles and takes a while to run. 
            
            
            c1 = new Camera(new Vector3(-160, 135, 250), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../sword.obj";
            m1 = loader.Load(filename);
            filename = "../../sword.png";
            output = new Image(c1, m1, filename);

            

            //This object has over 150,000 triangles and takes extremely long to render.
            //I calculated it as lasting around 9.6 hours

            c1 = new Camera(new Vector3(5, 5, 5), new Vector3(0, 0, 0), up, 1920, 1080);
            filename = "../../../bunny_max_res.obj";
            loader = new LoadOBJ();
            m1 = loader.Load(filename);
            filename = "../../bunny.png";
            output = new Image(c1, m1, filename);
            
        }
    */

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
