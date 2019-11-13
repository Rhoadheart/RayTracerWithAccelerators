using System;
using project.RayTracing;
using System.Numerics;
using NUnit.Framework;


namespace UnitTest
{
    class RayTests
    {
        public Vector3 origin, up;
        public Ray r1, r2;
        public Matrix4x4 proj;

        [SetUp]
        public void Before()
        {

            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);
            r1 = new Ray(new Vector3(1, 1, 1), new Vector3(2, 0, 0));
            r2 = new Ray(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
            proj = new Matrix4x4(2, 0, 0, 1,
                                 0, 1, 0, 1,
                                 0, 0, 1, 1,
                                 0, 0, 0, 1);
        }
        [Test]
        public void TestGetOrigin()
        {
            Assert.AreEqual(r1.getOrigin(), new Vector3(1, 1, 1));
        }

        [Test]
        public void TestGetDirection()
        {
            Assert.AreEqual(r1.getDirection(), Vector3.Normalize(new Vector3(2, 0, 0)));
        }

        [Test]
        public void TestTransform1()
        {
            Ray answer = new Ray(new Vector3(1, 1, 1), new Vector3(0.8164966f, 0.4082483f, 0.4082483f));
            Ray output = r2.transform(proj);
            Assert.AreEqual(output.getOrigin(), answer.getOrigin());
        }

        [Test]
        public void TestTransform2()
        {
            Ray output = r2.transform(proj);
            Assert.AreEqual(output.getDirection(), new Vector3(0.816496551f, 0.408248276f, 0.408248276f));
        }
    }
}
