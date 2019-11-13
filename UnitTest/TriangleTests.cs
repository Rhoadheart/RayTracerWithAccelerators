using System;
using project.RayTracing;
using System.Numerics;
using NUnit.Framework;

namespace UnitTest
{

    class TriangleTests
    {
        public Triangle t1, t2;
        public Vector3 origin;
        public Vector3 up;
        public Ray r1, r2, r3, r4, r5, r6, r7;

        [SetUp]
        public void Before()
        {
            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);
            r1 = new Ray(new Vector3(1, 1, 1), new Vector3(2, 0, 0));
            r2 = new Ray(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
            t1 = new Triangle(new Vector3(2, -1, 1), new Vector3(2, 1, 0), new Vector3(2, -1, -1));
            r4 = new Ray(origin, new Vector3(2, 0, 0));
            t2 = new Triangle(new Vector3(2, 0, 0), new Vector3(0, 2, 0), new Vector3(0, 0, 2));
            r5 = new Ray(origin, new Vector3(1, 1, 1));
            r6 = new Ray(origin, new Vector3(1, -1, 1));
            r7 = new Ray(origin, new Vector3(-1, -1, -1));
        }

        [Test]
        public void IntersectionTest1()
        {
            float outFloat;
            Assert.IsTrue(t1.intersection(r4, out outFloat));
        }

        [Test]
        public void IntersectionTest2()
        {
            float outFloat;
            Assert.IsTrue(t2.intersection(r5, out outFloat));
        }

        [Test]
        public void IntersectionTest3()
        {
            float outFloat;
            Assert.IsFalse(t2.intersection(r6, out outFloat));
        }

        [Test]
        public void IntersectionTest4()
        {
            float outFloat;
            Assert.IsFalse(t2.intersection(r7, out outFloat));
        }
    }
}
