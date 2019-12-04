using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Numerics;
using Json.Net;

namespace project
{
    public partial class InputGenerator : Form
    {
        public InputGenerator()
        {
            InitializeComponent();
            FormClosed += OnClose;


        }
        
        private void InputGenerator_Load_1(object sender, EventArgs e)
        {
            //FOV
            FoVBox.Text = "Default: 43";
            FoVBox.ForeColor = Color.Gray;
            //InputFile Location
            OutputBox.Text = "File path";
            OutputBox.ForeColor = Color.Gray;
            //OBJ Location
            InputBox.Text = "File path";
            InputBox.ForeColor = Color.Gray;
            //PNG/CSV Location
            PNGCSVLocation.Text = "File path";
            PNGCSVLocation.ForeColor = Color.Gray;
            //CPBox
            CPBox.Text = "EX: x,y,z";
            CPBox.ForeColor = Color.Gray;
            //ResXBox
            ResXBox.Text = "Width";
            ResXBox.ForeColor = Color.Gray;
            //ResYBox
            ResYBox.Text = "Height";
            ResYBox.ForeColor = Color.Gray;
            //CUBox
            CUBox.Text = "Default: 0,1,0";
            CUBox.ForeColor = Color.Gray;
            //COBox
            COBox.Text = "EX: x,y,z";
            COBox.ForeColor = Color.Gray;

            GenerateLabel.Hide();

        }

        private void OnClose(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void FoVBox_Enter(object sender, EventArgs e)
        {
            if (FoVBox.Text == "Default: 43" && FoVBox.ForeColor == Color.Gray)
            {
                FoVBox.Text = "";
                FoVBox.ForeColor = Color.Black;
            }
        }

        private void FoVBox_Leave(object sender, EventArgs e)
        {
            if (FoVBox.Text == "")
            {
                FoVBox.Text = "Default: 43";
                FoVBox.ForeColor = Color.Gray;
            }
        }

        private void OutputBox_Enter(object sender, EventArgs e)
        {
            if (OutputBox.Text == "File path" && OutputBox.ForeColor == Color.Gray)
            {
                OutputBox.Text = "";
                OutputBox.ForeColor = Color.Black;
            }
        }

        private void OutputBox_Leave(object sender, EventArgs e)
        {
            if (OutputBox.Text == "")
            {
                OutputBox.Text = "File path";
                OutputBox.ForeColor = Color.Gray;
            }
            else
            {
                OutputBox.ForeColor = Color.Black;
            }
        }

        private void InputBox_Enter(object sender, EventArgs e)
        {
            if (InputBox.Text == "File path" && InputBox.ForeColor == Color.Gray)
            {
                InputBox.Text = "";
                InputBox.ForeColor = Color.Black;
            }
        }

        private void InputBox_Leave(object sender, EventArgs e)
        {
            if (InputBox.Text == "")
            {
                InputBox.Text = "File path";
                InputBox.ForeColor = Color.Gray;
            }
        }

        private void PNGCSVLocation_Enter(object sender, EventArgs e)
        {
            if(PNGCSVLocation.Text == "File path")
            {
                PNGCSVLocation.Text = "";
                PNGCSVLocation.ForeColor = Color.Black;
            }
        }

        private void PNGCSVLocation_Leave(object sender, EventArgs e)
        {
            if(PNGCSVLocation.Text == "")
            {
                PNGCSVLocation.Text = "File path";
                PNGCSVLocation.ForeColor = Color.Gray;
            }
        }

        private void CPBox_Enter(object sender, EventArgs e)
        {
            if (CPBox.Text == "EX: x,y,z" && CPBox.ForeColor == Color.Gray)
            {
                CPBox.Text = "";
                CPBox.ForeColor = Color.Black;
            }
        }

        private void CPBox_Leave(object sender, EventArgs e)
        {
            if (CPBox.Text == "")
            {
                CPBox.Text = "EX: x,y,z";
                CPBox.ForeColor = Color.Gray;
            }
        }

        private void COBox_Enter(object sender, EventArgs e)
        {
            if (COBox.Text == "EX: x,y,z" && COBox.ForeColor == Color.Gray)
            {
                COBox.Text = "";
                COBox.ForeColor = Color.Black;
            }
        }

        private void COBox_Leave(object sender, EventArgs e)
        {
            if (COBox.Text == "")
            {
                COBox.Text = "EX: x,y,z";
                COBox.ForeColor = Color.Gray;
            }
        }

        private void ResXBox_Enter(object sender, EventArgs e)
        {
            if (ResXBox.Text == "Width" && ResXBox.ForeColor == Color.Gray)
            {
                ResXBox.Text = "";
                ResXBox.ForeColor = Color.Black;
            }
        }

        private void ResXBox_Leave(object sender, EventArgs e)
        {
            if (ResXBox.Text == "")
            {
                ResXBox.Text = "Width";
                ResXBox.ForeColor = Color.Gray;
            }
        }

        private void ResYBox_Enter(object sender, EventArgs e)
        {
            if (ResYBox.Text == "Height" && ResYBox.ForeColor == Color.Gray)
            {
                ResYBox.Text = "";
                ResYBox.ForeColor = Color.Black;
            }
        }

        private void ResYBox_Leave(object sender, EventArgs e)
        {
            if (ResYBox.Text == "")
            {
                ResYBox.Text = "Height";
                ResYBox.ForeColor = Color.Gray;
            }
        }

        private void CUBox_Enter(object sender, EventArgs e)
        {
            if (CUBox.Text == "Default: 0,1,0" && CUBox.ForeColor == Color.Gray)
            {
                CUBox.Text = "";
                CUBox.ForeColor = Color.Black;
            }
        }

        private void CUBox_Leave(object sender, EventArgs e)
        {
            if (CUBox.Text == "")
            {
                CUBox.Text = "Default: 0,1,0";
                CUBox.ForeColor = Color.Gray;
            }
        }


        private void Generate_Click(object sender, EventArgs e)
        {
            String combo = comboBox1.Text;
            String resX = ResXBox.Text;
            String resY = ResYBox.Text;
            String CPbox = CPBox.Text;
            String CObox = COBox.Text;
            String CUbox = CUBox.Text;
            String input = InputBox.Text;
            String output = OutputBox.Text;
            String CSVLocation = PNGCSVLocation.Text;
            String fov = FoVBox.Text;
            bool PNG = GenPNG.Checked;
            String png = PNG.ToString();

            if (combo == "")
            {
                GenerateLabel.Text = "Choose an Acceleration Structure";
                GenerateLabel.Show();
                return;
            }
            if (resX == "" || resX == "Width")
            {
                GenerateLabel.Text = "Enter a valid X Width";
                GenerateLabel.Show();
                return;
            }
            if(resY == "" || resY == "Height")
            {
                GenerateLabel.Text = "Enter a valid Y Height";
                GenerateLabel.Show();
                return;
            }
            if(CPbox == "" || CPbox == "EX: x,y,z")
            {
                GenerateLabel.Text = "Enter a valid Camera Position";
                GenerateLabel.Show();
                return;
            }
            if(CObox == "" || CObox == "EX: x,y,z")
            {
                GenerateLabel.Text = "Enter a valid Camera Orientation";
                GenerateLabel.Show();
                return;
            }
            if(CUbox == "" || CUbox == "Default: 0,1,0")
            {
                CUBox.Text = "0,1,0";
                GenerateLabel.Show();
            }
            if(input == "" || input == "File path")
            {
                GenerateLabel.Text = "Not valid OBJ path";
                GenerateLabel.Show();
                return;
            }
            if(output == "" || output == "File path")
            {
                GenerateLabel.Text = "Not valid input file path";
                GenerateLabel.Show();
                return;
            }
            if(fov == "" || fov == "Default: 43")
            {
                FoVBox.Text = "43";
            }
            if (GenPNG.Checked)
            {
                png = "true";
            }
            if(PNGCSVLocation.Text == "" || PNGCSVLocation.Text == "File path")
            {
                GenerateLabel.Text = "Not a valid CSV Location path";
                GenerateLabel.Show();
                return;
            }
            String Jsonstring = JSONSerilaize();
            File.WriteAllText(output, Jsonstring);
            
            //Adjust the Label in the parent form
            Label a = (Label)this.Owner.Controls["GoodGenLabel"];
            a.Text = "Generation Succesful";
            a.Show();
            Close();
            
        }

        private void Search1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    InputBox.Text = openFileDialog1.FileName;
                    InputBox.ForeColor = Color.Black;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Search2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "RayTracingInputFile";
            save.Filter = "TextFile | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OutputBox.Text = save.FileName;
                    OutputBox.ForeColor = Color.Black;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Search3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PNGCSVLocation.Text = folderBrowserDialog1.SelectedPath;
                    PNGCSVLocation.ForeColor = Color.Black;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }


        private void ResXBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void ResYBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void CPBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue) && (e.KeyCode) != Keys.Oemcomma && (e.KeyCode) != Keys.OemMinus)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void COBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue) && (e.KeyCode) != Keys.Oemcomma && (e.KeyCode) != Keys.OemMinus)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void CUBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue) && (e.KeyCode) != Keys.Oemcomma && (e.KeyCode) != Keys.OemMinus)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void FoVBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue) )
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }


        private string JSONSerilaize()
        {
            InputFile input = new InputFile();
            input.AccelerationStruct = comboBox1.Text;
            input.ResolutionX = Convert.ToInt32(ResXBox.Text);
            input.ResolutionY = Convert.ToInt32(ResYBox.Text);

            int[] CPvalues = TexttoArray(CPBox.Text);
            input.CPx = CPvalues[0];
            input.CPy = CPvalues[1];
            input.CPz = CPvalues[2];

            int[] COvalues = TexttoArray(COBox.Text);
            input.COx = COvalues[0];
            input.COy = COvalues[1];
            input.COz = COvalues[2];

            int[] CUvalues = TexttoArray(CUBox.Text);
            input.CUx = CUvalues[0];
            input.CUy = CUvalues[1];
            input.CUz = CUvalues[2];

            //Vector3 CameraPos = TexttoVector3(CPBox.Text);
            //input.CameraPosition = CameraPos;
            //Vector3 CameraOrientation = TexttoVector3(COBox.Text);
            //input.CameraOrientation = CameraOrientation;
            //Vector3 CameraUP = TexttoVector3(CPBox.Text);
            //input.CameraUp = CameraUP;

            input.OBJLocation = InputBox.Text;
            input.CSVLocation = PNGCSVLocation.Text;
            input.FiledOfView = Convert.ToInt32(FoVBox.Text);
            input.GeneratePNG = GenPNG.Checked;

           
            string JSONfile = JsonNet.Serialize(input);
            return JSONfile;
        }

        /// <summary>
        /// Takes a String of 3 garenteed ints seperated by comma and returns a vector
        /// of the tree given points 
        /// </summary>
        /// <param name="preVectString"></param>
        /// <returns></returns>
        private Vector3 TexttoVector3(String preVectString)
        {
            string[] nums = preVectString.Split(',');
            int num1 = Convert.ToInt32(nums[0]);
            int num2 = Convert.ToInt32(nums[1]);
            int num3 = Convert.ToInt32(nums[2]);
            Vector3 vec = new Vector3(num1, num2, num3);
            return vec;

        }

        /// <summary>
        /// Turns the text from the camera boxes and returns a int array of the 3 numbers
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int[] TexttoArray(String s)
        {
            String[] nums = s.Split(',');
            try
            {

                int num1 = Convert.ToInt32(nums[0]);
                int num2 = Convert.ToInt32(nums[1]);
                int num3 = Convert.ToInt32(nums[2]);
                int[] values = { num1, num2, num3 };
                return values;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }
    }
}

