using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    class BvHAccelerator
    {
        public BvHAccelerator(Mesh mesh, int heightLimit, int triangleLimit)
        {
            //Get Triangles from mesh
            List<Triangle> triangles = new List<Triangle>();
            int numTriangles = mesh.faces.Count / 3;

            //Add all triangles to bounds and triangle list
            BoundingBox bounds = new BoundingBox(new Triangle(mesh, 0));
            triangles.Add(new Triangle(mesh, 0));
            for (int i = 1; i < numTriangles; i++)
            {
                Triangle tri = new Triangle(mesh, i);
                bounds.addTriangle(tri);
                triangles.Add(tri);
            }

            //Set splitting axis
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            foreach(Triangle t in triangles)
            {
                Vector3 centroid = t.centroid;
                if (centroid.X > max.X)
                    max.X = centroid.X;
                if (centroid.X < min.X)
                    min.X = centroid.X;

                if (centroid.Y > max.Y)
                    max.Y = centroid.Y;
                if (centroid.Y < min.Y)
                    min.Y = centroid.Y;

                if (centroid.Z > max.Z)
                    max.Z = centroid.Z;
                if (centroid.Z < min.Z)
                    min.Z = centroid.Z;
            }

            Vector3 span = new Vector3(max.X - min.X, max.Y - min.Y, max.Z - min.Z);
            int axis;
            if (span.X > span.Y && span.X > span.Z)
                axis = 0;
            else if (span.Y > span.Z)
                axis = 1;
            else
                axis = 2;

            //Sort Triangles List
            QuickSort.nth_element(ref triangles, 0, triangles.Count - 1, triangles.Count / 2, axis);

            //Create a BvH Node that recursively creates more

        }
        
        



    }
}
