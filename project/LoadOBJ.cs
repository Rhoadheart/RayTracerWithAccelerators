using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

namespace project.RayTracing
{
    public class LoadOBJ
    {
        List<Vector3> vertices;
        List<Vector3> normals;
        List<Triangle> triangles;

        public Mesh Load(string filepath)
        {
            try
            {
                vertices = new List<Vector3>();
                normals = new List<Vector3>();
                triangles = new List<Triangle>();



                string result = "";
                using (StreamReader fileRead = new StreamReader(filepath))
                {
                    result = fileRead.ReadToEnd();
                    fileRead.Close();
                }

                string[] resultLines = result.Split('\n');
                
                foreach (string line in resultLines)
                {
                    switch (line[0])
                    {
                        case 'v':
                            string[] verts = line.Split(' ');
                            vertices.Add(new Vector3(float.Parse(verts[1]), float.Parse(verts[2]), float.Parse(verts[3])));
                            break;
                        case 'n':
                            string[] norms = line.Split(' ');
                            normals.Add(new Vector3(float.Parse(norms[1]), float.Parse(norms[2]), float.Parse(norms[3])));
                            break;
                        case 'f':
                            //Assuming we have triangles (3 vertices per face)
                            string[] values = line.Split(' ');
                            //Vector3 vert1 = 

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }



            return null;
        }

        


    }
}
