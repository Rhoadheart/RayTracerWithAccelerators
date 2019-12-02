using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{
    public class BoundingBox
    {
        public Vector3 max;
        public Vector3 min;

        /// <summary>
        /// Default Constructor.
        /// Creates a bounding box from just one point. 
        /// This box will have a volume of 0.
        /// This constructor is also called by other constructors in this class
        /// </summary>
        /// <param name="point"></param>
        public BoundingBox(Vector3 point)
        {
            this.max = point;
            this.min = point;
        }

        /// <summary>
        /// Creates a BoundingBox from 3 points.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public BoundingBox(Vector3 p1, Vector3 p2, Vector3 p3) : this(p1)
        {
            this.addPoint(p2);
            this.addPoint(p3);
        }

        /// <summary>
        /// Creates a BoundingBox from the 3 points that define a triangle.
        /// </summary>
        /// <param name="t1"></param>
        public BoundingBox(Triangle t1) : this(t1.p1)
        {
            this.addPoint(t1.p2);
            this.addPoint(t1.p3);
            
        }

        /// <summary>
        /// Adds a point to the BoundingBox. If the point is outside the current BoundingBox, it resizes.
        /// </summary>
        /// <param name="point"></param>
        public void addPoint(Vector3 point)
        {
            this.max = new Vector3(Math.Max(max.X, point.X), Math.Max(max.Y, point.Y), Math.Max(max.Z, point.Z));
            this.min = new Vector3(Math.Min(min.X, point.X), Math.Min(min.Y, point.Y), Math.Min(min.Z, point.Z));
        }

        /// <summary>
        /// Adds the three points of a triangle to the BoundingBox.
        /// </summary>
        /// <param name="t1"></param>
        public void addTriangle(Triangle t1)
        {
            this.addPoint(t1.p1);
            this.addPoint(t1.p2);
            this.addPoint(t1.p3);
        }

        public void Union(BoundingBox b)
        {
            this.addPoint(b.max);
            this.addPoint(b.min);
        }

        //This code handles intersection by creating a mesh to represent our BoundingBox, 
        //and then calls our mesh.Intersect(Ray) method.
        //This however, is about 2x slower than the other method below...
        /*
        public bool Intersect(Ray r)
        {
            List<Vector3> vertices = new List<Vector3>(8);
            //Create all the corners of the Box
            vertices.Add(new Vector3(q.X, q.Y, q.Z));//111
            vertices.Add(new Vector3(p.X, q.Y, q.Z));//011
            vertices.Add(new Vector3(q.X, p.Y, q.Z));//101
            vertices.Add(new Vector3(p.X, p.Y, q.Z));//001

            vertices.Add(new Vector3(q.X, q.Y, p.Z));//110
            vertices.Add(new Vector3(p.X, q.Y, p.Z));//010
            vertices.Add(new Vector3(q.X, p.Y, p.Z));//100
            vertices.Add(new Vector3(p.X, p.Y, p.Z));//000

            List<int> faces = new List<int>(36);
            faces.Add(0); faces.Add(1); faces.Add(2);
            faces.Add(0); faces.Add(2); faces.Add(3);

            faces.Add(1); faces.Add(5); faces.Add(6);
            faces.Add(1); faces.Add(6); faces.Add(2);

            faces.Add(5); faces.Add(4); faces.Add(7);
            faces.Add(5); faces.Add(7); faces.Add(6);

            faces.Add(4); faces.Add(0); faces.Add(7);
            faces.Add(4); faces.Add(7); faces.Add(3);

            faces.Add(3); faces.Add(2); faces.Add(6);
            faces.Add(3); faces.Add(6); faces.Add(7);

            faces.Add(4); faces.Add(5); faces.Add(1);
            faces.Add(4); faces.Add(1); faces.Add(0);

            List<Vector3> normals = new List<Vector3>(6);
            normals.Add(new Vector3(0, 0, -1));
            normals.Add(new Vector3(1, 0, 0));
            normals.Add(new Vector3(0, 0, 1));
            normals.Add(new Vector3(-1, 0, 0));
            normals.Add(new Vector3(0, 1, 0));
            normals.Add(new Vector3(0, -1, 0));

            List<int> vertexNormals = new List<int>(36);

            vertexNormals.Add(0); vertexNormals.Add(0); vertexNormals.Add(0);
            vertexNormals.Add(0); vertexNormals.Add(0); vertexNormals.Add(0);

            vertexNormals.Add(1); vertexNormals.Add(1); vertexNormals.Add(1);
            vertexNormals.Add(1); vertexNormals.Add(1); vertexNormals.Add(1);

            vertexNormals.Add(2); vertexNormals.Add(2); vertexNormals.Add(2);
            vertexNormals.Add(2); vertexNormals.Add(2); vertexNormals.Add(2);

            vertexNormals.Add(3); vertexNormals.Add(3); vertexNormals.Add(3);
            vertexNormals.Add(3); vertexNormals.Add(3); vertexNormals.Add(3);

            vertexNormals.Add(4); vertexNormals.Add(4); vertexNormals.Add(4);
            vertexNormals.Add(4); vertexNormals.Add(4); vertexNormals.Add(4);

            vertexNormals.Add(5); vertexNormals.Add(5); vertexNormals.Add(5);
            vertexNormals.Add(5); vertexNormals.Add(5); vertexNormals.Add(5);


            //Create a Mesh from these points
            Mesh m1 = new Mesh(vertices, normals, faces, vertexNormals);

            return m1.intersect(r) == null ? false : true;


        }
        */

        /// <summary>
        /// Efficient Intersection routine for BoundingBox and Ray intersection.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool Intersect(Ray r, out float outT)
        {
            // r.dir is unit direction vector of ray
            Vector3 weightedRatio = new Vector3(1f / r.getDirection().X, 1f / r.getDirection().Y, 1f / r.getDirection().Z);

            //Look for intersection for each plane
            float t1 = (this.min.X - r.getOrigin().X) * weightedRatio.X;
            float t2 = (this.max.X - r.getOrigin().X) * weightedRatio.X;
            float t3 = (this.min.Y - r.getOrigin().Y) * weightedRatio.Y;
            float t4 = (this.max.Y - r.getOrigin().Y) * weightedRatio.Y;
            float t5 = (this.min.Z - r.getOrigin().Z) * weightedRatio.Z;
            float t6 = (this.max.Z - r.getOrigin().Z) * weightedRatio.Z;
            
            
            //The t distance of the last slab in the BoundingBox hit.
            float maxT = Math.Min(Math.Min(Math.Max(t1, t2), Math.Max(t3, t4)), Math.Max(t5, t6));


            // if maxT < 0: the BoundingBox is behind the Ray
            if (maxT < 0)
            {
                outT = maxT;
                return false;
            }
            

            //The t distance of the first slab in the BoundingBox hit.
            float minT = Math.Max(Math.Max(Math.Min(t1, t2), Math.Min(t3, t4)), Math.Min(t5, t6));
            
            
            // if minT > maxT: the ray doesn't intersect with the BoundingBox
            if (minT > maxT)
            {
                outT = maxT;
                return false;
            }

            //Note: If minT is less than 0, this means the origin of the ray is within the Bounding Box. 
            //      This ray will definitely intersect with the BoundingBox

            if (minT < 0)
            {
                outT = maxT;
            }
            else
            {
                outT = minT;
            }
            return true;
        }

        public int MaximumExtent()
        {
            Vector3 diag = max - min;
            if (diag.X > diag.Y && diag.X > diag.Z)
                return 0;
            else if (diag.Y > diag.Z)
                return 1;
            else
                return 2;

        }


    }
}
