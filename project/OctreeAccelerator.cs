using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    class OctreeAccelerator
    {
        //Todo: Spring Sprints  1/2
        Node root;

        
        public OctreeAccelerator(Mesh mesh, int heightLimit, int triangleLimit)
        {
            int numTriangles = mesh.faces.Count / 3;
            List<Triangle> triangles = new List<Triangle>();

            //Add all triangles to bounds and triangle list
            BoundingBox bounds = new BoundingBox(new Triangle(mesh, 0));
            triangles.Add(new Triangle(mesh, 0));
            for (int i = 1; i < numTriangles; i++)
            {
                Triangle tri = new Triangle(mesh, i);
                bounds.addTriangle(tri);
                triangles.Add(tri);
            }

            //Create overrarching node. The constructor will recursively create a tree
            root = new Node(bounds, triangles, 0, heightLimit, triangleLimit);

            
        }


        public Triangle intersect(Ray r)
        {
            float t;
            return root.intersection(r, float.MaxValue, out t);
        }
        
    }
}
