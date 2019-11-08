using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project.RayTracing;
using System.Numerics;

namespace UnitTest
{
    
    [TestClass]
    public class TriangleTests
    {
        
        [TestMethod]
        public void IntersectionTest1()
        {
            float outFloat;
            Vector3 origin = new Vector3(0, 0, 0);
            Triangle t1 = new Triangle(new Vector3(2, -1, 1), new Vector3(2, 1, 0), new Vector3(2, -1, -1));
            Ray r4 = new Ray(origin, new Vector3(2, 0, 0));
            Assert.IsTrue(t1.intersection(r4, out outFloat));
        }

        [TestMethod]
        public void IntersectionTest2()
        {
            float outFloat;
            Vector3 origin = new Vector3(0, 0, 0);
            Triangle t2 = new Triangle(new Vector3(2, 0, 0), new Vector3(0, 2, 0), new Vector3(0, 0, 2));
            Ray r5 = new Ray(origin, new Vector3(1, 1, 1));
            Assert.IsTrue(t2.intersection(r5, out outFloat));
        }

        [TestMethod]
        public void IntersectionTest3()
        {
            float outFloat;
            Vector3 origin = new Vector3(0, 0, 0);
            Ray r6 = new Ray(origin, new Vector3(1, -1, 1));
            Triangle t2 = new Triangle(new Vector3(2, 0, 0), new Vector3(0, 2, 0), new Vector3(0, 0, 2));
            Assert.IsFalse(t2.intersection(r6, out outFloat));
        }

        [TestMethod]
        public void IntersectionTest4()
        {
            float outFloat;
            Vector3 origin = new Vector3(0, 0, 0);
            Ray r7 = new Ray(origin, new Vector3(-1, -1, -1));
            Triangle t2 = new Triangle(new Vector3(2, 0, 0), new Vector3(0, 2, 0), new Vector3(0, 0, 2));
            Assert.IsFalse(t2.intersection(r7, out outFloat));
        }
    }
}
