using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project.RayTracing;
using System.Numerics;


namespace project.RayTracing
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
    }
}
