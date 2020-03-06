using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.RayTracing;
using NUnit.Framework;
using System.Numerics;

namespace UnitTest
{
    class NodeTests
    {

        public OctreeNode masterNode;
        public Triangle t1;
        public Triangle t2;
        public Ray r1;
        public List<Triangle> triangleList1;
        public List<OctreeNode> nodeList1;
        public BoundingBox bBox;


        [SetUp]
        public void before()
        {
            bBox = new BoundingBox(new System.Numerics.Vector3(0, 0, 0), new System.Numerics.Vector3(5, 5, 5));
            triangleList1 = new List<Triangle>();

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

            t1 = new Triangle(m1, 0);
            t2 = new Triangle(m1, 1);

            triangleList1.Add(t1);
            triangleList1.Add(t2);
        }

        [Test]
        public void nodeTest01()
        {

        }
    }
}
