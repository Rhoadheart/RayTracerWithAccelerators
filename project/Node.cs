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
        /// <param name="B"> The first BoundingBox</param>
        /// <param name="T"> A List of Triangles </param>
        /// <param name="C"> A List of Children </param>
        public Node(BoundingBox B, List<Triangle> T, List<Node> C)
        {
            BBox = B;
            if(C == null)
            {
                Triangles = T;
                Children = null;
            }
            else
            {
                Children = C;
                Triangles = null;
            }
        }

        /// <summary>
        /// Determines what triangle is hit using the Octree Structure
        /// 
        /// </summary>
        /// <param name="r"> The Ray to check for triangles</param>
        /// <returns> The Triangle that was hit</returns>
        public Triangle intersection(Ray r)
        {
            float hit0;
            float hit1;
            float trianglehit;
            float rayMin = float.MaxValue;

            if(BBox.Intersect(r,out hit0, out hit1))
            {
                for (int i= 0; i < Children.Count; i++)
                {
                    intersection(r);
                }
                if(Children.Count == 0)
                {
                    foreach(Triangle triangle in Triangles)
                    {
                        if(triangle.intersection(r, out trianglehit))
                        {
                            if(trianglehit < rayMin)
                            {
                                rayMin = trianglehit;
                            }
                            return triangle;
                        }
                    } 
                }
            }
            else
            {
                return null;
            }

            return null;
        }


        
    }
}
