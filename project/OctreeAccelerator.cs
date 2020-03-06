using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    public class OctreeAccelerator : Accelerator
    {
        //Todo: Spring Sprints  1/2
        OctreeNode root;
        public int NodeCount;
        public List<OctreeNode> Leaves;


        public OctreeAccelerator(Mesh mesh, int heightLimit, int triangleLimit)
        {
            Leaves = new List<OctreeNode>();
            NodeCount = 0;
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
            root = new OctreeNode(bounds, triangles, 0, heightLimit, triangleLimit, this);

            
        }


        public override Triangle intersect(Ray r, out float t)
        {
            Triangle temp = root.intersection(r, float.MaxValue, out t);

            return temp;
        }
        
    }
}
