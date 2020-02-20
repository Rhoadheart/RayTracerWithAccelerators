using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{

    public class Node
    {
        /** The Master BoundingBox used to create the 8 children nodes*/
        private BoundingBox BBox;
        /** A list referring to each subbox of the Master boundingBox*/
        private List<Node> Children;
        /** A List refering to all Triangles in the Bounding Box */
        private List<Triangle> Triangles;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <param name="T"></param>
        /// <param name="currentHeight"></param>
        /// <param name="heightLimit"></param>
        /// <param name="triangleLimit"></param>
        public Node(BoundingBox B, List<Triangle> T, int currentHeight, int heightLimit, int triangleLimit, OctreeAccelerator Octree)
        {
            //Set BBox
            BBox = B;

            //Attempt to Create 8 Children
            Children = new List<Node>();

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
                    Children.Add(new Node(ChildBBox, trianglesInside, currentHeight + 1, heightLimit, triangleLimit, Octree));
                }
            }
            else
            {
                Triangles = T;
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
