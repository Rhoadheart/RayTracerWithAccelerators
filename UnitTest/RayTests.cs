using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project.RayTracing;
using System.Numerics;


namespace UnitTest
{
    [TestClass]
    public class RayTests
    {

        [TestMethod]
        public void TestGetOrigin()
        {
            Vector3 origin = new Vector3(0, 0, 0);
            Vector3 up = new Vector3(0, 1, 0);
            Ray r1 = new Ray(new Vector3(1, 1, 1), new Vector3(2, 0, 0));
            Assert.AreEqual(r1.getOrigin(), new Vector3(1, 1, 1), "Test falied");
        }

        [TestMethod]
        public void TestGetDirection()
        {
            Vector3 origin = new Vector3(0, 0, 0);
            Vector3 up = new Vector3(0, 1, 0);
            Ray r1 = new Ray(new Vector3(1, 1, 1), new Vector3(2, 0, 0));
            Assert.AreEqual(r1.getDirection(), Vector3.Normalize(new Vector3(2, 0, 0)), "TestFailed");
        }

        [TestMethod]
        public void TestOrigin2()
        {
            Ray r2 = new Ray(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
            Matrix4x4 proj = new Matrix4x4(2, 0, 0, 1,
                                           0, 1, 0, 1,
                                           0, 0, 1, 1,
                                           0, 0, 0, 1);
            Ray answer = new Ray(new Vector3(1, 1, 1), new Vector3(0.8164966f, 0.4082483f, 0.4082483f));
            Ray output = r2.transform(proj);
            Assert.AreEqual(output.getOrigin(), answer.getOrigin(), "Origin Test 2 Fail");
        }

        [TestMethod]
        public void TestDirection2()
        {
            Ray r2 = new Ray(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
            Matrix4x4 proj = new Matrix4x4(2, 0, 0, 1,
                                           0, 1, 0, 1,
                                           0, 0, 1, 1,
                                           0, 0, 0, 1);
            Ray answer = new Ray(new Vector3(1, 1, 1), new Vector3(0.8164966f, 0.4082483f, 0.4082483f));
            Ray output = r2.transform(proj);
            Assert.AreEqual(output.getDirection(), answer.getDirection(), "Direction test 2 Fail");
        }
    }
}
