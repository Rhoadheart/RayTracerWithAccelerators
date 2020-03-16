using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace project.RayTracing
{
    public class Mesh
    {
        //Triangle[] triangles;
        public List<Vector3> vertices;
        public List<Vector3> normals;
        public List<int> faces;
        public List<int> vertexNormals;
        public int numTriangles
        {
            get{ return faces.Count / 3; }
        }
        public int numIntersects = 0;




        /// <summary>
        /// Default Constructor for a Mesh. Holds an references to vertices and normals for an array of triangle faces.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="normals"></param>
        /// <param name="faces"></param>
        /// <param name="vertexNormals"></param>
        public Mesh(List<Vector3> vertices, List<Vector3> normals, List<int> faces, List<int> vertexNormals)
        {
            this.vertices = vertices;
            this.normals = normals;
            this.faces = faces;
            this.vertexNormals = vertexNormals;
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
            //Foreach triangle
            for(int i = 0; i < faces.Count/3; i++)
            {
                Triangle thisTriangle = new Triangle(this, i);
                numIntersects++;
                if (thisTriangle.intersection(r, out tOut))
                {
                    if (tOut < minT)
                    {
                        closestTriangle = thisTriangle;
                        minT = tOut;
                    }
                }
                   
            }
            return closestTriangle;
        }


        /// <summary>
        /// Loops through all triangles and returns the closest triangle that intersects with r.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Triangle intersect(Ray r, out float outT)
        {
            float tOut;
            float minT = float.MaxValue;
            Triangle closestTriangle = null;
            //Foreach triangle
            for (int i = 0; i < faces.Count / 3; i++)
            {
                Triangle thisTriangle = new Triangle(this, i);
                numIntersects++;
                if (thisTriangle.intersection(r, out tOut))
                {
                    if (tOut < minT)
                    {
                        closestTriangle = thisTriangle;
                        minT = tOut;
                    }
                }

            }
            outT = minT;
            return closestTriangle;
        }




    }
}
