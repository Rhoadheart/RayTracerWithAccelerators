using System;
using project.RayTracing;
using System.Numerics;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{

    class QuickSelectTests
    {
        public List<Triangle> triangles;

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

            vertices.Add(new Vector3(1, 0, 0));
            vertices.Add(new Vector3(2, 2, 0));
            vertices.Add(new Vector3(4, 0, 2));
            normals.Add(new Vector3(-1, -1, -1));
            faces.Add(6);
            faces.Add(7);
            faces.Add(8);
            vertexNormals.Add(1);
            vertexNormals.Add(1);
            vertexNormals.Add(1);

            vertices.Add(new Vector3(5, 0, 0));
            vertices.Add(new Vector3(6, 2, 0));
            vertices.Add(new Vector3(7, 0, 2));
            normals.Add(new Vector3(-1, -1, -1));
            faces.Add(9);
            faces.Add(10);
            faces.Add(11);
            vertexNormals.Add(1);
            vertexNormals.Add(1);
            vertexNormals.Add(1);

            vertices.Add(new Vector3(12, 0, 0));
            vertices.Add(new Vector3(13, 2, 0));
            vertices.Add(new Vector3(14, 0, 2));
            normals.Add(new Vector3(-1, -1, -1));
            faces.Add(12);
            faces.Add(13);
            faces.Add(14);
            vertexNormals.Add(1);
            vertexNormals.Add(1);
            vertexNormals.Add(1);

            vertices.Add(new Vector3(20, 0, 0));
            vertices.Add(new Vector3(-2, 2, 0));
            vertices.Add(new Vector3(1, 0, 2));
            normals.Add(new Vector3(-1, -1, -1));
            faces.Add(15);
            faces.Add(16);
            faces.Add(17);
            vertexNormals.Add(1);
            vertexNormals.Add(1);
            vertexNormals.Add(1);

            Mesh m1 = new Mesh(vertices, normals, faces, vertexNormals);

            triangles = new List<Triangle>();
            int numTriangles = m1.faces.Count / 3;

            //Add all triangles to bounds and triangle list
            triangles.Add(new Triangle(m1, 0));
            for (int i = 1; i < numTriangles; i++)
            {
                Triangle tri = new Triangle(m1, i);
                triangles.Add(tri);
            }
            

        }

        [Test]
        public void IntersectionTest1()
        {
            QuickSelect.nth_element(ref triangles, 0, triangles.Count - 1, triangles.Count / 2, 0);
            
            
        }
    }
}
