using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project
{
    class InputFile
    {
        public String AccelerationStruct { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public float CPx { get; set; }
        public float CPy { get; set; }
        public float CPz { get; set; }
        public float COx { get; set; }
        public float COy { get; set; }
        public float COz { get; set; }
        public float CUx { get; set; }
        public float CUy { get; set; }
        public float CUz { get; set; }
        //public Vector3 CameraPosition { get; set; }
        //public Vector3 CameraOrientation { get; set; }
        //public Vector3 CameraUp { get; set; }
        public String OBJLocation { get; set; }
        public int FieldofView { get; set; }
        public bool GeneratePNG { get; set; }
        public String CSVLocation { get; set; }

    }
}
