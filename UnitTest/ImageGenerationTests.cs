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
        public Triangle[] triangles;
        public Vector3 origin, up;
        public Mesh m1;

        [SetUp]
        public void Before()
        {
            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);
            triangles = new Triangle[3];
            c1 = new Camera(new Vector3(-2, 0, 0), new Vector3(1, 0, 0), up, 1920, 1080);
            triangles[0] = new Triangle(new Vector3(2, -1, 1), new Vector3(2, 1, 0), new Vector3(2, -1, -1));
            triangles[1] = new Triangle(new Vector3(2, -1, 1), new Vector3(1, 1, 1), new Vector3(2, 1, 0));
            triangles[2] = new Triangle(new Vector3(2, -1, -1), new Vector3(2, 1, 0), new Vector3(1, 1, -1));
            m1 = new Mesh(triangles);

        }

        [Test]
        public void ImageGenTest()
        {
            string filename = "../../TestMesh2.png";
            output = new Image(c1, m1, filename);
            Assert.IsTrue(File.Exists(filename));
            

        }
    }
}
