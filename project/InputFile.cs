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
        //1st Column
        public String AccelerationStruct { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        //Camera Position
        public float CPx { get; set; }
        public float CPy { get; set; }
        public float CPz { get; set; }
        //Camera Orientation
        public float COx { get; set; }
        public float COy { get; set; }
        public float COz { get; set; }
        //Camera UP
        public float CUx { get; set; }
        public float CUy { get; set; }
        public float CUz { get; set; }

        //2nd Column
        public String OBJLocation { get; set;}
        public int FieldofView { get; set; }
        public bool GeneratePNG { get; set; }
        public bool RealTimeRend { get; set; }
        public String CSVLocation { get; set; }
        public String OutputFilename { get; set; }

        //3rd Column
        public bool AmbientOclusion { get; set; }

        public int RaysPerPixel { get; set; }
        public float RayDistanceLimit { get; set; }

        public int TrianglesPerNod { get; set; }
        public int HeightLimit { get; set; }

    }
}
