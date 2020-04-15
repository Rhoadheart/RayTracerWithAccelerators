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

        //For Data Collection
        public int pNumIntersects = 0;
        public int pNumNodes = 0;
        public int pMaxTriPerLeaf = 0;
        public int pMaxHeight = 0;
        public int pTotalLeafHeight = 0;
        public int pTotalTriPerLeaf = 0;
        public int pNumLeaves = 0;
        public float pScale = 1;

        public override int numIntersects { get { return pNumIntersects; } }
        public override int numNodes { get { return pNumNodes; } }
        public override int avgTriPerLeaf { get { return pTotalTriPerLeaf / numLeaves; } }
        public override int maxTriPerLeaf { get { return pMaxTriPerLeaf; } }
        public override int maxHeight { get { return pMaxHeight; } }
        public override int avgHeight { get { return pTotalLeafHeight / numLeaves; } }
        public override int numLeaves { get { return pNumLeaves; } }
        public override float scale { get { return pScale; } }


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
            pScale = bounds.scale();

            //For Data Collection
            pNumNodes += 1;

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
