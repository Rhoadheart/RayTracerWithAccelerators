using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{
    class Voxel
    {
        public List<Triangle> triangles;
        public int numTriangles;

        /// <summary>
        /// Creates an empty Voxel. 
        /// This is only used to create a list of empty Voxels in GridAccelerator so indexed voxels can be accessed.
        /// </summary>
        /// <param name="numTriangles"></param>
        public Voxel()
        {
           this.triangles = null;
           this.numTriangles = 0;
        }

        /// <summary>
        /// Creates a Voxel that contains just one triangle.
        /// </summary>
        /// <param name="t"></param>
        public Voxel(Triangle t)
        {
            this.triangles = new List<Triangle>();
            this.triangles.Add(t);
            this.numTriangles = 1;
        }

        /// <summary>
        /// Adds a triangle to the voxel.
        /// </summary>
        /// <param name="t"></param>
        public void addTriangle(Triangle t)
        {
            this.triangles.Add(t);
            this.numTriangles += 1;
        }

        /// <summary>
        /// Returns the closest intersecting triangle within the voxel.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="minT"></param>
        /// <returns></returns>
        public Triangle intersect (Ray r, out float outT)
        {
            float tOut;
            float minT = float.MaxValue;
            Triangle closestTriangle = null;

            foreach (Triangle t in triangles)
            {
                if (t.intersection(r, out tOut))
                {
                    if (tOut < minT)
                    {
                        closestTriangle = t;
                        minT = tOut;
                    }
                }
            }
            outT = minT;
            return closestTriangle;
        }
    }
}
