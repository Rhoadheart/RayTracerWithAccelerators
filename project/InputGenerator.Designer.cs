namespace project
{
    partial class InputGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Generate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResXBox = new System.Windows.Forms.TextBox();
            this.ResYBox = new System.Windows.Forms.TextBox();
            this.CUBox = new System.Windows.Forms.TextBox();
            this.COBox = new System.Windows.Forms.TextBox();
            this.CPBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GenPNG = new System.Windows.Forms.CheckBox();
            this.FoVBox = new System.Windows.Forms.TextBox();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Search2 = new System.Windows.Forms.Button();
            this.Search1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(302, 395);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(85, 23);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Acceleration Structure\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Camera Position:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Camera Orientation:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Camera Up:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "OBJ Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Input File Location:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(356, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Field of View:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resolution:";
            // 
            // ResXBox
            // 
            this.ResXBox.Location = new System.Drawing.Point(166, 99);
            this.ResXBox.Name = "ResXBox";
            this.ResXBox.Size = new System.Drawing.Size(80, 22);
            this.ResXBox.TabIndex = 11;
            this.ResXBox.Enter += new System.EventHandler(this.ResXBox_Enter);
            this.ResXBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResXBox_KeyDown);
            this.ResXBox.Leave += new System.EventHandler(this.ResXBox_Leave);
            // 
            // ResYBox
            // 
            this.ResYBox.Location = new System.Drawing.Point(270, 99);
            this.ResYBox.Name = "ResYBox";
            this.ResYBox.Size = new System.Drawing.Size(80, 22);
            this.ResYBox.TabIndex = 12;
            this.ResYBox.Enter += new System.EventHandler(this.ResYBox_Enter);
            this.ResYBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResYBox_KeyDown);
            this.ResYBox.Leave += new System.EventHandler(this.ResYBox_Leave);
            // 
            // CUBox
            // 
            this.CUBox.Location = new System.Drawing.Point(166, 326);
            this.CUBox.Name = "CUBox";
            this.CUBox.Size = new System.Drawing.Size(184, 22);
            this.CUBox.TabIndex = 15;
            this.CUBox.Enter += new System.EventHandler(this.CUBox_Enter);
            this.CUBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CUBox_KeyDown);
            this.CUBox.Leave += new System.EventHandler(this.CUBox_Leave);
            // 
            // COBox
            // 
            this.COBox.Location = new System.Drawing.Point(166, 251);
            this.COBox.Name = "COBox";
            this.COBox.Size = new System.Drawing.Size(184, 22);
            this.COBox.TabIndex = 14;
            this.COBox.Enter += new System.EventHandler(this.COBox_Enter);
            this.COBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.COBox_KeyDown);
            this.COBox.Leave += new System.EventHandler(this.COBox_Leave);
            // 
            // CPBox
            // 
            this.CPBox.Location = new System.Drawing.Point(166, 176);
            this.CPBox.Name = "CPBox";
            this.CPBox.Size = new System.Drawing.Size(184, 22);
            this.CPBox.TabIndex = 13;
            this.CPBox.Enter += new System.EventHandler(this.CPBox_Enter);
            this.CPBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CPBox_KeyDown);
            this.CPBox.Leave += new System.EventHandler(this.CPBox_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "x";
            // 
            // GenPNG
            // 
            this.GenPNG.AutoSize = true;
            this.GenPNG.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GenPNG.Location = new System.Drawing.Point(359, 253);
            this.GenPNG.Name = "GenPNG";
            this.GenPNG.Size = new System.Drawing.Size(124, 21);
            this.GenPNG.TabIndex = 21;
            this.GenPNG.Text = "Generate PNG";
            this.GenPNG.UseVisualStyleBackColor = true;
            // 
            // FoVBox
            // 
            this.FoVBox.ForeColor = System.Drawing.Color.Black;
            this.FoVBox.Location = new System.Drawing.Point(487, 180);
            this.FoVBox.Name = "FoVBox";
            this.FoVBox.Size = new System.Drawing.Size(102, 22);
            this.FoVBox.TabIndex = 20;
            this.FoVBox.Enter += new System.EventHandler(this.FoVBox_Enter);
            this.FoVBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FoVBox_KeyDown);
            this.FoVBox.Leave += new System.EventHandler(this.FoVBox_Leave);
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(487, 99);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(298, 22);
            this.OutputBox.TabIndex = 18;
            this.OutputBox.Enter += new System.EventHandler(this.OutputBox_Enter);
            this.OutputBox.Leave += new System.EventHandler(this.OutputBox_Leave);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(487, 26);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(298, 22);
            this.InputBox.TabIndex = 16;
            this.InputBox.Enter += new System.EventHandler(this.InputBox_Enter);
            this.InputBox.Leave += new System.EventHandler(this.InputBox_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "AS1";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Octree",
            "K-D Trees",
            "Grid",
            "Bounding Volume Hierarchy",
            "All"});
            this.comboBox1.Location = new System.Drawing.Point(166, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // Search2
            // 
            this.Search2.Location = new System.Drawing.Point(711, 127);
            this.Search2.Name = "Search2";
            this.Search2.Size = new System.Drawing.Size(74, 23);
            this.Search2.TabIndex = 19;
            this.Search2.Text = "Search";
            this.Search2.UseVisualStyleBackColor = true;
            this.Search2.Click += new System.EventHandler(this.Search2_Click);
            // 
            // Search1
            // 
            this.Search1.Location = new System.Drawing.Point(711, 54);
            this.Search1.Name = "Search1";
            this.Search1.Size = new System.Drawing.Size(74, 23);
            this.Search1.TabIndex = 17;
            this.Search1.Text = "Search";
            this.Search1.UseVisualStyleBackColor = true;
            this.Search1.Click += new System.EventHandler(this.Search1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // InputGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.Search1);
            this.Controls.Add(this.Search2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.FoVBox);
            this.Controls.Add(this.GenPNG);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CPBox);
            this.Controls.Add(this.COBox);
            this.Controls.Add(this.CUBox);
            this.Controls.Add(this.ResYBox);
            this.Controls.Add(this.ResXBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Generate);
            this.Name = "InputGenerator";
            this.Text = "InputGenerator";
            this.Load += new System.EventHandler(this.InputGenerator_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ResXBox;
        private System.Windows.Forms.TextBox ResYBox;
        private System.Windows.Forms.TextBox CUBox;
        private System.Windows.Forms.TextBox COBox;
        private System.Windows.Forms.TextBox CPBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox GenPNG;
        private System.Windows.Forms.TextBox FoVBox;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Search2;
        private System.Windows.Forms.Button Search1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}