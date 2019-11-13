using System;
using NUnit.Framework;
using System.Numerics;
using project.RayTracing;
using System.IO;

namespace UnitTest
{
    
    class LoadOBJTests
    {

        [SetUp]
        public void Before()
        {

        }

        [Test]
        public void LoadOBJTest1()
        {
            string filepath = "../crate.obj";
            LoadOBJ loader = new LoadOBJ();
            loader.Load(filepath);

        }
    }
}
