using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    class BvHAccelerator : Accelerator
    {
        public List<Triangle> triangles;
        public int heightLimit;
        public int triangleLimit;
        public int triCount = 0;
        public Mesh mesh;
        public float minT;
        private BvHNode root;

        public BvHAccelerator(Mesh mesh, int heightLimit, int triangleLimit)
        {
            this.mesh = mesh;
            this.heightLimit = heightLimit;
            this.triangleLimit = triangleLimit;
            //Get Triangles from mesh
            triangles = new List<Triangle>();
            int numTriangles = mesh.faces.Count / 3;

            //Add all triangles to bounds and triangle list
            BoundingBox bounds = new BoundingBox(new Triangle(mesh, 0));
            triangles.Add(new Triangle(mesh, 0));
            for (int i = 1; i < numTriangles; i++)
            {
                Triangle tri = new Triangle(mesh, i);
                bounds.addTriangle(tri);
                triangles.Add(tri);
            }
            
            //Create a BvH Node that recursively creates more
            root = new BvHNode(this, 0, triangles.Count - 1, 0);


        }

        public override Triangle intersect(Ray r, out float t)
        {
            minT = float.MaxValue;
            Triangle temp = root.intersection(r, out t);

            return temp;
        }





    }
}
