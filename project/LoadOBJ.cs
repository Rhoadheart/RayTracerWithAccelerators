﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace project.RayTracing
{
    public class LoadOBJ
    {
        List<Vector3> vertices;
        List<Vector3> normals;
        List<Triangle> triangles;
        int verticesSize;
        int normalsSize;

        /// <summary>
        /// Loads the Object contained in 
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
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
                    string[] parameters = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parameters.Length > 0)
                    {
                        switch (parameters[0])
                        {
                            case "v":
                                vertices.Add(new Vector3(float.Parse(parameters[1]), float.Parse(parameters[2]), float.Parse(parameters[3])));
                                break;
                            case "vn":
                                normals.Add(new Vector3(float.Parse(parameters[1]), float.Parse(parameters[2]), float.Parse(parameters[3])));
                                break;
                            case "f":
                                
                                //Assuming we have triangles (3 vertices per face)
                                string[] values = line.Split(new Char[] { ' ', '/' });
                                Vector3 p1, p2, p3, n1, n2, n3;
                                if (int.Parse(values[1]) > 0)
                                {
                                    p1 = vertices[int.Parse(values[1]) - 1];
                                    n1 = normals[int.Parse(values[3]) - 1];

                                    p2 = vertices[int.Parse(values[4]) - 1];
                                    n2 = normals[int.Parse(values[6]) - 1];

                                    p3 = vertices[int.Parse(values[7]) - 1];
                                    n3 = normals[int.Parse(values[9]) - 1];
                                }
                                else
                                {
                                    if (verticesSize == default(int) || normalsSize == default(int))
                                    {
                                        verticesSize = vertices.Count;
                                        normalsSize = normals.Count;
                                    }
                                    p1 = vertices[verticesSize + int.Parse(values[1])];
                                    n1 = normals[normalsSize + int.Parse(values[3])];

                                    p2 = vertices[verticesSize + int.Parse(values[4])];
                                    n2 = normals[normalsSize + int.Parse(values[6])];

                                    p3 = vertices[verticesSize + int.Parse(values[7])];
                                    n3 = normals[normalsSize + int.Parse(values[9])];
                                }


                                Triangle thisTriangle = new Triangle(p1, p2, p3, n1, n2, n3);
                                triangles.Add(thisTriangle);

                                break;
                            default:
                                break;
                        }
                    }
                }
                return new Mesh(triangles);
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
