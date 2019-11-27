using System;
using project.RayTracing;
using System.Numerics;
using NUnit.Framework;
using System.Collections.Generic;

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
            List<Vector3> vertices = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<int> faces = new List<int>();
            List<int> vertexNormals = new List<int>();

            vertices.Add(new Vector3(2, -1, 1));
            vertices.Add(new Vector3(2, 1, 0));
            vertices.Add(new Vector3(2, -1, -1));
            normals.Add(new Vector3(1, 0, 0));
            faces.Add(0);
            faces.Add(1);
            faces.Add(2);
            vertexNormals.Add(0);
            vertexNormals.Add(0);
            vertexNormals.Add(0);

            vertices.Add(new Vector3(2, 0, 0));
            vertices.Add(new Vector3(0, 2, 0));
            vertices.Add(new Vector3(0, 0, 2));
            normals.Add(new Vector3(-1, -1, -1));
            faces.Add(3);
            faces.Add(4);
            faces.Add(5);
            vertexNormals.Add(1);
            vertexNormals.Add(1);
            vertexNormals.Add(1);

            Mesh m1 = new Mesh(vertices, normals, faces, vertexNormals);
            origin = new Vector3(0, 0, 0);
            up = new Vector3(0, 1, 0);
            r1 = new Ray(new Vector3(1, 1, 1), new Vector3(2, 0, 0));
            r2 = new Ray(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
            t1 = new Triangle(m1, 0);
            r4 = new Ray(origin, new Vector3(2, 0, 0));
            t2 = new Triangle(m1, 1);
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
