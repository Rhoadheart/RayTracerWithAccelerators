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
            FoVBox.Text = "Degrees";
            FoVBox.ForeColor = Color.Gray;
            //Output
            OutputBox.Text = "File path";
            OutputBox.ForeColor = Color.Gray;
            //Input
            InputBox.Text = "File path";
            InputBox.ForeColor = Color.Gray;
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

        }

        private void OnClose(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void FoVBox_Enter(object sender, EventArgs e)
        {
            if (FoVBox.Text == "Degrees")
            {
                FoVBox.Text = "";
                FoVBox.ForeColor = Color.Black;
            }
        }

        private void FoVBox_Leave(object sender, EventArgs e)
        {
            if (FoVBox.Text == "")
            {
                FoVBox.Text = "Degrees";
                FoVBox.ForeColor = Color.Gray;
            }
        }

        private void OutputBox_Enter(object sender, EventArgs e)
        {
            if (OutputBox.Text == "File path")
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
        }

        private void InputBox_Enter(object sender, EventArgs e)
        {
            if (InputBox.Text == "File path")
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

        private void CPBox_Enter(object sender, EventArgs e)
        {
            if (CPBox.Text == "EX: x,y,z")
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

        private void ResXBox_Enter(object sender, EventArgs e)
        {
            if (ResXBox.Text == "Width")
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
            if (ResYBox.Text == "Height")
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
            if (CUBox.Text == "Default: 0,1,0")
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
            StringBuilder sb = new StringBuilder();

            String combo = comboBox1.Text;
            String resX = ResXBox.Text;
            String resY = ResYBox.Text;
            String CPbox = CPBox.Text;
            String CObox = COBox.Text;
            String CUbox = CUBox.Text;
            String input = InputBox.Text;
            String output = OutputBox.Text;
            String fov = FoVBox.Text;
            bool PNG = GenPNG.Checked;
            String png = PNG.ToString();

            sb.AppendLine(combo);
            sb.AppendLine(resX);
            sb.AppendLine(resY);
            sb.AppendLine(CPbox);
            sb.AppendLine(CObox);
            sb.AppendLine(CUbox);
            sb.AppendLine(input);
            sb.AppendLine(output);
            sb.AppendLine(fov);
            sb.AppendLine(png);
            File.WriteAllText(input, sb.ToString());
            
        }

        private void Search1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "RayTracingInputFile";
            save.Filter = "TextFile | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                InputBox.Text = save.FileName;
                InputBox.ForeColor = Color.Black;
            }
        }

        private void Search2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "RayTracingInputFile";
            save.Filter = "TextFile | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                OutputBox.Text = save.FileName;
                OutputBox.ForeColor = Color.Black;
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
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue) && (e.KeyCode) != Keys.Oemcomma)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void COBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue) && (e.KeyCode) != Keys.Oemcomma)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void CUBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue) && (e.KeyCode) != Keys.Oemcomma)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void FoVBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyValue) && !char.IsControl((char)e.KeyValue))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}

