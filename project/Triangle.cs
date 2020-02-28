using project.RayTracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace project.RayTracing
{
    public class Triangle
    {
        Mesh mesh;
        int index;

        public Vector3 p1
        {
            get { return mesh.vertices[mesh.faces[index * 3]]; }
        }

        public Vector3 p2
        {
            get { return mesh.vertices[mesh.faces[index * 3 + 1]]; }
        }

        public Vector3 p3
        {
            get { return mesh.vertices[mesh.faces[index * 3 + 2]]; }
        }
        
        public Vector3 centroid
        {
            get
            {
                return new Vector3((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3, (p1.Z + p2.Z + p3.Z) / 3);
            }
        }

        //We can use these to generate p1,p2,p3,n1,n2,n3

        /*
        /// <summary>
        /// Triangle constructor given 3 points. 
        /// This constructor does not use a Mesh, and thus does not calculate normals.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            Vector3 A = p2 - p1;
            Vector3 B = p3 - p2;
            Vector3 normals = Vector3.Normalize(Vector3.Cross(A, B));

        }
        */

        public Triangle(Mesh mesh, int index)
        {
            this.mesh = mesh;
            this.index = index;
        }

        /*
        /// <summary>
        /// Default triangle constructor given 3 points and a normal
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 n1, Vector3 n2, Vector3 n3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;

        }
        */

        /// <summary>
        /// Determines if the given ray intesects with this triangle
        /// </summary>
        /// <param name="r"></param>
        /// <param name="tOut"></param>
        /// <returns></returns>
        public bool intersection(Ray r, out float tOut)
        {
            Vector3 p1 = mesh.vertices[mesh.faces[index * 3]];
            Vector3 p2 = mesh.vertices[mesh.faces[index * 3 + 1]];
            Vector3 p3 = mesh.vertices[mesh.faces[index * 3 + 2]];
            //Vector3 n1 = mesh.normals[mesh.vertexNormals[index * 3]];
            //Vector3 n2 = mesh.normals[mesh.vertexNormals[index * 3 + 1]];
            //Vector3 n3 = mesh.normals[mesh.vertexNormals[index * 3 + 2]];
            Vector3 edge1 = p2 - p1;
            Vector3 edge2 = p3 - p1;
            Vector3 s1 = Vector3.Cross(r.getDirection(), edge2);
            float divisor = Vector3.Dot(s1, edge1);
            if (divisor == 0)
            {
                tOut = 0;
                return false;
            }
            float invDivisor = 1f / divisor;

            //Barysentric coordinate 1
            Vector3 d = r.getOrigin() - p1;
            float b1 = (Vector3.Dot(d, s1) * invDivisor);
            if (b1 < 0 || b1 > 1)
            {
                tOut = 0;
                return false;
            }

            //Barysentric coordinate 2
            Vector3 s2 = Vector3.Cross(d, edge1);
            float b2 = Vector3.Dot(r.getDirection(), s2) * invDivisor;
            if (b2 < 0 || b1 + b2 > 1)
            {
                tOut = 0;
                return false;
            }

            //Check for positive T
            float t = Vector3.Dot(edge2, s2) * invDivisor;
            if (t < 0 || t > r.getMaxT())
            {
                tOut = 0;
                return false;
            }
            tOut = t;
            return true;
        }


        /// <summary>
        /// Determines the face normal of a triangle after an intersection occurs.
        /// </summary>
        /// <returns></returns>
        public Vector3 normal()
        {
            Vector3 p1 = mesh.vertices[mesh.faces[index * 3]];
            Vector3 p2 = mesh.vertices[mesh.faces[index * 3 + 1]];
            Vector3 p3 = mesh.vertices[mesh.faces[index * 3 + 2]];
            //Vector3 n1 = mesh.normals[mesh.vertexNormals[index * 3]];
            //Vector3 n2 = mesh.normals[mesh.vertexNormals[index * 3 + 1]];
            //Vector3 n3 = mesh.normals[mesh.vertexNormals[index * 3 + 2]];

            Vector3 A = p2 - p1;
            Vector3 B = p3 - p2;
            return Vector3.Normalize(Vector3.Cross(A, B));
            
        }

        /// <summary>
        /// Determines the interpolated normal based on an intersecting Ray r
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public Vector3 normal(Ray r)
        {
            Vector3 p1 = mesh.vertices[mesh.faces[index * 3]];
            Vector3 p2 = mesh.vertices[mesh.faces[index * 3 + 1]];
            Vector3 p3 = mesh.vertices[mesh.faces[index * 3 + 2]];
            Vector3 n1 = mesh.normals[mesh.vertexNormals[index * 3]];
            Vector3 n2 = mesh.normals[mesh.vertexNormals[index * 3 + 1]];
            Vector3 n3 = mesh.normals[mesh.vertexNormals[index * 3 + 2]];

            //Computing s1
            Vector3 edge1 = p2 - p1;
            Vector3 edge2 = p3 - p1;
            Vector3 s1 = Vector3.Cross(r.getDirection(), edge2);
            float divisor = Vector3.Dot(s1, edge1);
            float invDivisor = 1f / divisor;

            //Barycentric coordinate 1
            Vector3 d = r.getOrigin() - p1;
            float b1 = Vector3.Dot(d, s1) * invDivisor;
            

            //Barycentric coordinate 2
            Vector3 s2 = Vector3.Cross(d, edge1);
            float b2 = Vector3.Dot(r.getDirection(), s2) * invDivisor;

            //Barycentric coordinate 3
            float b0 = 1 - b1 - b2;
            
            Vector3 interpolatedNormal = (b0 * n1) + (b1 * n2) + (b2 * n3);
            
            return interpolatedNormal;
        }

        public int CompareTo(Object ob, int axis)
        {
            if (axis == 0)
            {
                if (ob == null) return 1;
                Triangle otherTriangle = ob as Triangle;
                if (otherTriangle != null)
                    return this.centroid.X.CompareTo(otherTriangle.centroid.X);
                else
                    throw new ArgumentException("Object is not a Triangle");
            }else if(axis == 1)
            {
                if (ob == null) return 1;
                Triangle otherTriangle = ob as Triangle;
                if (otherTriangle != null)
                    return this.centroid.Y.CompareTo(otherTriangle.centroid.Y);
                else
                    throw new ArgumentException("Object is not a Triangle");
            }else
            {
                if (ob == null) return 1;
                Triangle otherTriangle = ob as Triangle;
                if (otherTriangle != null)
                    return this.centroid.Z.CompareTo(otherTriangle.centroid.Z);
                else
                    throw new ArgumentException("Object is not a Triangle");
            }
        }

    }
}
