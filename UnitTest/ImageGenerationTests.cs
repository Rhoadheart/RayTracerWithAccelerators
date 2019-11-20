using System;
using NUnit.Framework;
using System.Numerics;
using project.RayTracing;
using System.IO;

namespace UnitTest
{
    
    class ImageGenerationTests
    {
        public Camera c1;
        public Image output;
        public Vector3  up;
        public Mesh m1;

        [SetUp]
        public void Before()
        {
            var dir = Path.GetDirectoryName(typeof(ImageGenerationTests).Assembly.Location);
            Environment.CurrentDirectory = dir;
            Directory.SetCurrentDirectory(dir);
            
            up = new Vector3(0, 1, 0);

            

        }

        [Test]
        public void ImageGenTest()
        {
            LoadOBJ loader = new LoadOBJ();

            c1 = new Camera(new Vector3(2, 2, 2), new Vector3(0, 0, 0), up, 1920, 1080);
            string filename = "../../../crate.obj";
            m1 = loader.Load(filename);
            filename = "../../crate.png";
            output = new Image(c1, m1, filename);
            //filename = "../crate.png";
            Assert.IsTrue(File.Exists(filename));
            

        }
    }
}
