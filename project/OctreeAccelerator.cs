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
        BoundingBox bounds;
        Mesh mesh;
        List<Triangle> triangles;
        List<Node> children;
        int numTriangles;

        int heightLimit;
        int trianglesLimit;



        public OctreeAccelerator(Mesh mesh, int heightLimit, int trianglesLimit)
        {
            numTriangles = mesh.faces.Count / 3;

            //Add all triangles to bounds
            bounds = new BoundingBox(new Triangle(mesh, 0));
            for (int i = 1; i < numTriangles; i++)
            {
                Triangle tri = new Triangle(mesh, i);
                bounds.addTriangle(tri);
            }
            
        }


        public Triangle intersect(Ray r)
        {
            return null;
        }
        
        private bool AddLevel()
        {
            return false;
        }
    }
}
