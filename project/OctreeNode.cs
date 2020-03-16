using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{

    public class OctreeNode
    {
        /** The Master BoundingBox used to create the 8 children nodes*/
        private BoundingBox BBox;
        /** A list referring to each subbox of the Master boundingBox*/
        private List<OctreeNode> Children;
        /** A List refering to all Triangles in the Bounding Box */
        private List<Triangle> Triangles;

        private OctreeAccelerator Octree;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <param name="T"></param>
        /// <param name="currentHeight"></param>
        /// <param name="heightLimit"></param>
        /// <param name="triangleLimit"></param>
        public OctreeNode(BoundingBox B, List<Triangle> T, int currentHeight, int heightLimit, int triangleLimit, OctreeAccelerator Octree)
        {
            this.Octree = Octree;

            //For Data Collection
            Octree.pNumNodes += 1;
            if (currentHeight > Octree.maxHeight)
                Octree.pMaxHeight = currentHeight;

            //Set BBox
            BBox = B;

            //Attempt to Create 8 Children
            Children = new List<OctreeNode>();

            if (T.Count > triangleLimit && currentHeight < heightLimit) {
                
                List<BoundingBox> ChildrenBBoxes = BBox.Split();
                foreach (BoundingBox ChildBBox in ChildrenBBoxes)
                {
                    List<Triangle> trianglesInside = new List<Triangle>();
                    
                    //Todo: Pull out Bounding Box Generation from contains method. Only do this once
                    foreach (Triangle t in T)
                    {
                        if (ChildBBox.contains(t))
                        {
                            trianglesInside.Add(t);
                        }
                    }
                    //Todo: Don't create child node if count == 0
                    Octree.NodeCount++;
                    Children.Add(new OctreeNode(ChildBBox, trianglesInside, currentHeight + 1, heightLimit, triangleLimit, Octree));
                }
            }
            else
            {
                
                Triangles = T;
                Octree.Leaves.Add(this);

                //For Data Collection
                Octree.pTotalTriPerLeaf += Triangles.Count;
                Octree.pNumLeaves += 1;
                Octree.pTotalLeafHeight += currentHeight;
                if (Triangles.Count > Octree.maxTriPerLeaf)
                    Octree.pMaxTriPerLeaf = Triangles.Count;
            }
            

            
        }

        /// <summary>
        /// Determines what triangle is hit using the Octree Structure
        /// 
        /// </summary>
        /// <param name="r"> The Ray to check for triangles</param>
        /// <returns> The Triangle that was hit</returns>
        public Triangle intersection(Ray r, float minT, out float outT)
        {
            float hit0;
            float hit1;
            float thisT;
            //float minT = float.MaxValue;
            
            Triangle closestTriangle = null;

            if(BBox.Intersect(r,out hit0, out hit1) && hit0 < minT)
            {
                if (Children.Count != 0)
                {
                    //We have children, and need to check their values.
                    for (int i = 0; i < Children.Count; i++)
                    {
                        Triangle thisTriangle = Children[i].intersection(r,minT, out thisT);
                        if (thisTriangle != null)
                        {
                            if (thisT < minT)
                            {
                                closestTriangle = thisTriangle;
                                minT = thisT;
                            }
                        }
                    }
                    outT = minT;
                    return closestTriangle;
                }
                else
                {
                    //We are at a leaf, and need to check each triangle.
                    foreach (Triangle triangle in Triangles)
                    {
                        //For Data Collection
                        Octree.pNumIntersects += 1;

                        if (triangle.intersection(r, out thisT))
                        {
                            if(thisT < minT)
                            {
                                minT = thisT;
                                closestTriangle = triangle;
                            }
                            
                        }
                    }
                    outT = minT;
                    return closestTriangle;

                }
                
            }
            //If the ray doesn't hit our node
            else
            {
                outT = minT;
                return null;
            }
        }
        


        
    }
}
