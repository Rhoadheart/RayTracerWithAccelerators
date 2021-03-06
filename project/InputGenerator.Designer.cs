﻿namespace project
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
            this.GenerateLabel = new System.Windows.Forms.Label();
            this.PNGCSVLocation = new System.Windows.Forms.TextBox();
            this.CSVLocation = new System.Windows.Forms.Label();
            this.Open = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.RealTimeRend = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.OutputFilename = new System.Windows.Forms.TextBox();
            this.RaysPerPixBox = new System.Windows.Forms.TextBox();
            this.RayDistanceLimitBox = new System.Windows.Forms.TextBox();
            this.AmbientOcclusionCheckBox = new System.Windows.Forms.CheckBox();
            this.RayDistanceLimit = new System.Windows.Forms.Label();
            this.RaysPerPixel = new System.Windows.Forms.Label();
            this.TriangleNodeLimit = new System.Windows.Forms.Label();
            this.HeightLimit = new System.Windows.Forms.Label();
            this.TriangleNodeLimitBox = new System.Windows.Forms.TextBox();
            this.HeightLimitBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(512, 463);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(85, 23);
            this.Generate.TabIndex = 29;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Acceleration Structure\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Camera Position:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Camera Orientation:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Camera Up:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "OBJ Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Input File:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(382, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Field of View:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
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
            this.GenPNG.Checked = true;
            this.GenPNG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GenPNG.Location = new System.Drawing.Point(382, 253);
            this.GenPNG.Name = "GenPNG";
            this.GenPNG.Size = new System.Drawing.Size(124, 21);
            this.GenPNG.TabIndex = 21;
            this.GenPNG.Text = "Generate PNG";
            this.GenPNG.UseVisualStyleBackColor = true;
            this.GenPNG.CheckStateChanged += new System.EventHandler(this.GenPNG_CheckStateChanged);
            // 
            // FoVBox
            // 
            this.FoVBox.ForeColor = System.Drawing.Color.Black;
            this.FoVBox.Location = new System.Drawing.Point(512, 180);
            this.FoVBox.Name = "FoVBox";
            this.FoVBox.Size = new System.Drawing.Size(117, 22);
            this.FoVBox.TabIndex = 20;
            this.FoVBox.Enter += new System.EventHandler(this.FoVBox_Enter);
            this.FoVBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FoVBox_KeyDown);
            this.FoVBox.Leave += new System.EventHandler(this.FoVBox_Leave);
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(512, 99);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(313, 22);
            this.OutputBox.TabIndex = 18;
            this.OutputBox.Enter += new System.EventHandler(this.OutputBox_Enter);
            this.OutputBox.Leave += new System.EventHandler(this.OutputBox_Leave);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(512, 26);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(313, 22);
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
            "All",
            "Bounding Volume Hierarchy",
            "Brute Force",
            "Grid",
            "K-D Trees",
            "Octree"});
            this.comboBox1.Location = new System.Drawing.Point(166, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            this.comboBox1.Enter += new System.EventHandler(this.comboBox1_Enter);
            // 
            // Search2
            // 
            this.Search2.Location = new System.Drawing.Point(751, 127);
            this.Search2.Name = "Search2";
            this.Search2.Size = new System.Drawing.Size(74, 23);
            this.Search2.TabIndex = 19;
            this.Search2.Text = "Search";
            this.Search2.UseVisualStyleBackColor = true;
            this.Search2.Click += new System.EventHandler(this.Search2_Click);
            // 
            // Search1
            // 
            this.Search1.Location = new System.Drawing.Point(751, 54);
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
            // GenerateLabel
            // 
            this.GenerateLabel.AutoSize = true;
            this.GenerateLabel.Location = new System.Drawing.Point(628, 466);
            this.GenerateLabel.Name = "GenerateLabel";
            this.GenerateLabel.Size = new System.Drawing.Size(102, 17);
            this.GenerateLabel.TabIndex = 23;
            this.GenerateLabel.Text = "GenErrorLabel";
            // 
            // PNGCSVLocation
            // 
            this.PNGCSVLocation.Location = new System.Drawing.Point(512, 326);
            this.PNGCSVLocation.Name = "PNGCSVLocation";
            this.PNGCSVLocation.Size = new System.Drawing.Size(313, 22);
            this.PNGCSVLocation.TabIndex = 23;
            this.PNGCSVLocation.Enter += new System.EventHandler(this.PNGCSVLocation_Enter);
            this.PNGCSVLocation.Leave += new System.EventHandler(this.PNGCSVLocation_Leave);
            // 
            // CSVLocation
            // 
            this.CSVLocation.AutoSize = true;
            this.CSVLocation.Location = new System.Drawing.Point(382, 326);
            this.CSVLocation.Margin = new System.Windows.Forms.Padding(0);
            this.CSVLocation.Name = "CSVLocation";
            this.CSVLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CSVLocation.Size = new System.Drawing.Size(113, 17);
            this.CSVLocation.TabIndex = 25;
            this.CSVLocation.Text = "Output Location:\r\n";
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(751, 354);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(74, 26);
            this.Open.TabIndex = 24;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.OutputOpen_Click);
            // 
            // RealTimeRend
            // 
            this.RealTimeRend.AutoSize = true;
            this.RealTimeRend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RealTimeRend.Checked = true;
            this.RealTimeRend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RealTimeRend.Location = new System.Drawing.Point(584, 250);
            this.RealTimeRend.Name = "RealTimeRend";
            this.RealTimeRend.Size = new System.Drawing.Size(165, 21);
            this.RealTimeRend.TabIndex = 22;
            this.RealTimeRend.Text = "Real-Time Rendering";
            this.RealTimeRend.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 395);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "PNG Filename:\r\n";
            // 
            // OutputFilename
            // 
            this.OutputFilename.Location = new System.Drawing.Point(512, 395);
            this.OutputFilename.Name = "OutputFilename";
            this.OutputFilename.Size = new System.Drawing.Size(313, 22);
            this.OutputFilename.TabIndex = 25;
            this.OutputFilename.Enter += new System.EventHandler(this.OutputFilename_Enter);
            this.OutputFilename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutputFilename_KeyDown);
            this.OutputFilename.Leave += new System.EventHandler(this.OutputFilename_Leave);
            // 
            // RaysPerPixBox
            // 
            this.RaysPerPixBox.Location = new System.Drawing.Point(1020, 99);
            this.RaysPerPixBox.Name = "RaysPerPixBox";
            this.RaysPerPixBox.Size = new System.Drawing.Size(114, 22);
            this.RaysPerPixBox.TabIndex = 27;
            this.RaysPerPixBox.Enter += new System.EventHandler(this.RaysPerPixBox_Enter);
            this.RaysPerPixBox.Leave += new System.EventHandler(this.RaysPerPixBox_Leave);
            // 
            // RayDistanceLimitBox
            // 
            this.RayDistanceLimitBox.Location = new System.Drawing.Point(1020, 168);
            this.RayDistanceLimitBox.Name = "RayDistanceLimitBox";
            this.RayDistanceLimitBox.Size = new System.Drawing.Size(114, 22);
            this.RayDistanceLimitBox.TabIndex = 28;
            this.RayDistanceLimitBox.Enter += new System.EventHandler(this.RayDistanceLimitBox_Enter);
            this.RayDistanceLimitBox.Leave += new System.EventHandler(this.RayDistanceLimitBox_Leave);
            // 
            // AmbientOcclusionCheckBox
            // 
            this.AmbientOcclusionCheckBox.AutoSize = true;
            this.AmbientOcclusionCheckBox.Checked = true;
            this.AmbientOcclusionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AmbientOcclusionCheckBox.Location = new System.Drawing.Point(991, 29);
            this.AmbientOcclusionCheckBox.Name = "AmbientOcclusionCheckBox";
            this.AmbientOcclusionCheckBox.Size = new System.Drawing.Size(143, 21);
            this.AmbientOcclusionCheckBox.TabIndex = 26;
            this.AmbientOcclusionCheckBox.Text = "AmbientOcclusion";
            this.AmbientOcclusionCheckBox.UseVisualStyleBackColor = true;
            this.AmbientOcclusionCheckBox.CheckStateChanged += new System.EventHandler(this.AmbientOcclusionCheckBox_CheckStateChanged);
            // 
            // RayDistanceLimit
            // 
            this.RayDistanceLimit.AutoSize = true;
            this.RayDistanceLimit.Location = new System.Drawing.Point(870, 177);
            this.RayDistanceLimit.Name = "RayDistanceLimit";
            this.RayDistanceLimit.Size = new System.Drawing.Size(121, 17);
            this.RayDistanceLimit.TabIndex = 34;
            this.RayDistanceLimit.Text = "RayDistanceLimit:";
            // 
            // RaysPerPixel
            // 
            this.RaysPerPixel.AutoSize = true;
            this.RaysPerPixel.Location = new System.Drawing.Point(870, 102);
            this.RaysPerPixel.Name = "RaysPerPixel";
            this.RaysPerPixel.Size = new System.Drawing.Size(95, 17);
            this.RaysPerPixel.TabIndex = 33;
            this.RaysPerPixel.Text = "RaysPerPixel:";
            // 
            // TriangleNodeLimit
            // 
            this.TriangleNodeLimit.AutoSize = true;
            this.TriangleNodeLimit.Location = new System.Drawing.Point(870, 329);
            this.TriangleNodeLimit.Name = "TriangleNodeLimit";
            this.TriangleNodeLimit.Size = new System.Drawing.Size(127, 17);
            this.TriangleNodeLimit.TabIndex = 38;
            this.TriangleNodeLimit.Text = "TriangleNodeLimit:";
            // 
            // HeightLimit
            // 
            this.HeightLimit.AutoSize = true;
            this.HeightLimit.Location = new System.Drawing.Point(870, 254);
            this.HeightLimit.Name = "HeightLimit";
            this.HeightLimit.Size = new System.Drawing.Size(82, 17);
            this.HeightLimit.TabIndex = 37;
            this.HeightLimit.Text = "HeightLimit:";
            // 
            // TriangleNodeLimitBox
            // 
            this.TriangleNodeLimitBox.Enabled = false;
            this.TriangleNodeLimitBox.Location = new System.Drawing.Point(1020, 320);
            this.TriangleNodeLimitBox.Name = "TriangleNodeLimitBox";
            this.TriangleNodeLimitBox.Size = new System.Drawing.Size(114, 22);
            this.TriangleNodeLimitBox.TabIndex = 36;
            this.TriangleNodeLimitBox.Enter += new System.EventHandler(this.TriangleNodeLimitBox_Enter);
            this.TriangleNodeLimitBox.Leave += new System.EventHandler(this.TriangleNodeLimitBox_Leave);
            // 
            // HeightLimitBox
            // 
            this.HeightLimitBox.Enabled = false;
            this.HeightLimitBox.Location = new System.Drawing.Point(1020, 251);
            this.HeightLimitBox.Name = "HeightLimitBox";
            this.HeightLimitBox.Size = new System.Drawing.Size(114, 22);
            this.HeightLimitBox.TabIndex = 35;
            this.HeightLimitBox.Enter += new System.EventHandler(this.HeightLimitBox_Enter);
            this.HeightLimitBox.Leave += new System.EventHandler(this.HeightLimitBox_Leave);
            // 
            // InputGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 528);
            this.Controls.Add(this.TriangleNodeLimit);
            this.Controls.Add(this.HeightLimit);
            this.Controls.Add(this.TriangleNodeLimitBox);
            this.Controls.Add(this.HeightLimitBox);
            this.Controls.Add(this.RayDistanceLimit);
            this.Controls.Add(this.RaysPerPixel);
            this.Controls.Add(this.AmbientOcclusionCheckBox);
            this.Controls.Add(this.RayDistanceLimitBox);
            this.Controls.Add(this.RaysPerPixBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OutputFilename);
            this.Controls.Add(this.RealTimeRend);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.CSVLocation);
            this.Controls.Add(this.PNGCSVLocation);
            this.Controls.Add(this.GenerateLabel);
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
        private System.Windows.Forms.Label GenerateLabel;
        private System.Windows.Forms.TextBox PNGCSVLocation;
        private System.Windows.Forms.Label CSVLocation;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox RealTimeRend;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox OutputFilename;
        private System.Windows.Forms.TextBox RaysPerPixBox;
        private System.Windows.Forms.TextBox RayDistanceLimitBox;
        private System.Windows.Forms.CheckBox AmbientOcclusionCheckBox;
        private System.Windows.Forms.Label RayDistanceLimit;
        private System.Windows.Forms.Label RaysPerPixel;
        private System.Windows.Forms.Label TriangleNodeLimit;
        private System.Windows.Forms.Label HeightLimit;
        private System.Windows.Forms.TextBox TriangleNodeLimitBox;
        private System.Windows.Forms.TextBox HeightLimitBox;
    }
}