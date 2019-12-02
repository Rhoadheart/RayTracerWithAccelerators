﻿using System;
using project.RayTracing;
using System.Numerics;
using NUnit.Framework;
using MyExtensions;
using System.Collections.Generic;

namespace UnitTest
{

    class BoundingBoxTests
    {
        public Triangle t1, t2;
        public Vector3 origin;
        public Vector3 up;

        [SetUp]
        public void Before()
        {
            
            List<Vector3> vertices = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<int> faces = new List<int>();
            List<int> vertexNormals = new List<int>();

            vertices.Add(new Vector3(1, 0, 0));
            vertices.Add(new Vector3(0, 1, 0));
            vertices.Add(new Vector3(0, 0, 1));
            normals.Add(Vector3.Normalize(new Vector3(1, 1, 1)));
            faces.Add(0);
            faces.Add(1);
            faces.Add(2);
            vertexNormals.Add(0);
            vertexNormals.Add(0);
            vertexNormals.Add(0);

            vertices.Add(new Vector3(3, 0, 0));
            vertices.Add(new Vector3(2, 0, 1));
            vertices.Add(new Vector3(2, 0, -1));
            normals.Add(new Vector3(0, 1, 0));
            faces.Add(3);
            faces.Add(4);
            faces.Add(5);
            vertexNormals.Add(1);
            vertexNormals.Add(1);
            vertexNormals.Add(1);

            Mesh m1 = new Mesh(vertices, normals, faces, vertexNormals);
            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);

            t1 = new Triangle(m1, 0);
            t2 = new Triangle(m1, 1);
        }

        [Test]
        public void BoundingBoxTest1()
        {
            BoundingBox b1 = new BoundingBox(new Vector3(1, 1, 1));

            Assert.AreEqual(b1.max, new Vector3(1, 1, 1));
            Assert.AreEqual(b1.min, new Vector3(1, 1, 1));
        }

        [Test]
        public void BoundingBoxTest2()
        {
            BoundingBox b1 = new BoundingBox(t1);
            Assert.AreEqual(b1.max, new Vector3(1, 1, 1));
            Assert.AreEqual(b1.min, new Vector3(0, 0, 0));
        }

        [Test]
        public void BoundingBoxTest3()
        {
            BoundingBox b1 = new BoundingBox(t1);
            b1.addTriangle(t2);
            Assert.AreEqual(b1.max, new Vector3(3, 1, 1));
            Assert.AreEqual(b1.min, new Vector3(0, 0, -1));
        }

        [Test]
        public void BoundingBoxTest4()
        {
            BoundingBox b1 = new BoundingBox(t1);
            b1.addTriangle(t2);
            b1.addPoint(new Vector3(-2, -2, -2));
            Assert.AreEqual(b1.max, new Vector3(3, 1, 1));
            Assert.AreEqual(b1.min, new Vector3(-2, -2, -2));
        }

        [Test]
        public void BoundingBoxTest5()
        {
            BoundingBox b1 = new BoundingBox(new Vector3(2, 2, 2), new Vector3(3, -3, 3), new Vector3(-2, -2, -2));
            Assert.AreEqual(b1.max, new Vector3(3, 2, 3));
            Assert.AreEqual(b1.min, new Vector3(-2, -3, -2));
        }

        [Test]
        public void BoundingBoxTest6()
        {
            
            BoundingBox b1 = new BoundingBox(t1);
            // p = <1, 1, 1>
            // q = <0, 0, 0>
            float outT;

            Ray r1 = new Ray(new Vector3(-5, -5, -5), new Vector3(1, 1, 1));
            Assert.IsTrue(b1.Intersect(r1, out outT));


            Ray r2 = new Ray(new Vector3(-5, -5, -5), new Vector3(-1, -1, -1));
            Assert.IsFalse(b1.Intersect(r2, out outT));

            Ray r3 = new Ray(new Vector3(-1, -1, -1), new Vector3(1, 0, 0));
            Assert.IsFalse(b1.Intersect(r3, out outT));
            /*
            bool failed = false;
            
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 2000000; i++)
                {
                    if (b1.Intersect(r3, out outT))
                        failed = true;
                }
            }
            Assert.IsFalse(failed);
            */
        }




    }
}
