﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.RayTracing
{
    static class Program
    {
        /// The main entry point for the application.        /// <summary>

        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AcceleratorAnalyzer());
        }
    }
}
