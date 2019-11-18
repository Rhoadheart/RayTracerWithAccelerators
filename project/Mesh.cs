using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project.RayTracing
{
    public class Mesh
    {
        Triangle[] triangles;

        /// <summary>
        /// Default Constructor for a Mesh. Holds an array of triangles.
        /// </summary>
        /// <param name="triangles"></param>
        public Mesh(Triangle[] triangles)
        {
            this.triangles = triangles;
        }

        /// <summary>
        /// Default Constructor for a Mesh. Holds an array of triangles.
        /// </summary>
        /// <param name="triangles"></param>
        public Mesh(List<Triangle> triangles)
        {
            this.triangles = triangles.ToArray<Triangle>();
        }

        /// <summary>
        /// Loops through all triangles and returns the closest triangle that intersects with r.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Triangle intersect(Ray r)
        {
            float tOut;
            float minT = float.MaxValue;
            Triangle closestTriangle = null;
            foreach(Triangle t in triangles)
            {
                if (t.intersection(r, out tOut))
                    if (tOut < minT)
                    {
                        closestTriangle = t;
                        minT = tOut;
                    }
                        
                
            }

            return closestTriangle;
            
            
        }

    }
}
