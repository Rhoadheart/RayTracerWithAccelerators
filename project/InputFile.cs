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
        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraOrientation { get; set; }
        public Vector3 CameraUp { get; set; }
        public String OBJLocation { get; set; }
        public int FiledOfView { get; set; }
        public bool GeneratePNG { get; set; }

    }
}
