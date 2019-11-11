using System;
using project.RayTracing;
using System.Numerics;
using NUnit.Framework;
using MyExtensions;

namespace UnitTest
{
    
    class CameraTests
    {
        public Camera c1, c2, c3;
        public Vector3 origin, up, output;

        [SetUp]
        public void Before()
        {
            Vector3 origin = new Vector3(0, 0, 0);
            Vector3 up = new Vector3(0, 1, 0);
            c1 = new Camera(origin, new Vector3(1, 0, 0), up, 1920, 1080);
            c2 = new Camera(new Vector3(2, 2, 0), new Vector3(0, 0, 0), up, 1920, 1080);
            c3 = new Camera(new Vector3(-3, -3, -3), new Vector3(0, 0, 0), up, 1920, 1080);
            
        }


        [Test]
        public void GetRayTest1()
        {
            c1.setFov(90);
            output = c1.getRay(new Vector2(960, 1080)).getDirection();
            Assert.AreEqual(output, new Vector3(.707106769f, .707106769f, 0));
        }

        [Test]
        public void GetRayTest2()
        {
            c1.setFov(43);
            output = c1.getRay(new Vector2(960, 540)).getOrigin();
            Assert.AreEqual(output, origin);
        }

        [Test]
        public void GetRayTest3()
        {
            output = c1.getRay(new Vector2(960, 540)).getDirection();
            Assert.AreEqual(output, new Vector3(1, 0, 0));
        }

        [Test]
        public void GetRayTest4()
        {
            output = c2.getRay(new Vector2(960, 540)).getOrigin();
            Assert.AreEqual(output, new Vector3(2, 2, 0));
        }

        [Test]
        public void GetRayTest5()
        {
            output = c2.getRay(new Vector2(960, 540)).getDirection();
            Assert.AreEqual(output, new Vector3(-0.707106769f, -0.707106769f, 0));
        }

        [Test]
        public void GetRayTest6()
        {
            output = c3.getRay(new Vector2(960, 540)).getOrigin();
            Assert.AreEqual(output, new Vector3(-3, -3, -3));
        }
        
        [Test]
        public void GetRayTest7()
        {
            output = c3.getRay(new Vector2(960, 540)).getDirection();
            Assert.AreEqual(output,new Vector3(.577350259f, .577350259f, .577350259f));
        }
    }
}
