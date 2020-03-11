using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    class BvHNode
    {
        
        private BoundingBox BBox;
        private BvHNode left;
        private BvHNode right;

        private BvHAccelerator accelerator;
        private int start;
        private int end;
        private int height;


        public BvHNode(BvHAccelerator accelerator, int start, int end, int height)
        {
            this.accelerator = accelerator;
            this.start = start;
            this.end = end;
            this.height = height;

            int count = (end - start) + 1;
            int middle = start + (count / 2) - 1;

            //Setup BoundingBox
            BBox = new BoundingBox(accelerator.triangles[start]);
            for (int i = start + 1; i <= end; i++)
            {
                BBox.addTriangle(accelerator.triangles[i]);
            }

            if (count <= accelerator.triangleLimit || height >= accelerator.heightLimit)
            {
                left = null;
                right = null;
                accelerator.triCount += count;
            }
            else
            {

                //Find Greatest Axis
                int axis = getLargestAxis();
                

                //Sort Triangles List
                QuickSelect.nth_element(ref accelerator.triangles, start, end, middle, axis);
                
                //Create two new Node
                left = new BvHNode(accelerator, start, middle, height + 1);
                right = new BvHNode(accelerator, middle + 1, end, height + 1);

            }

        }


        public Triangle intersection(Ray r, out float outT)
        {
            float hit0;
            float hit1;
            float leftT;
            float rightT;

            if (BBox.Intersect(r, out hit0, out hit1) && hit0 < accelerator.minT)
            {
                if (left != null && right != null)
                {
                    //We have children, and need to check their values.
                    Triangle leftTriangle = left.intersection(r, out leftT);
                    if (leftT < accelerator.minT) accelerator.minT = leftT;

                    Triangle rightTriangle = right.intersection(r, out rightT);
                    if (rightT < accelerator.minT) accelerator.minT = rightT;



                    if (rightTriangle != null && leftTriangle != null)
                    {
                        if (leftT < rightT)
                        {
                            outT = leftT;
                            return leftTriangle;
                        }
                        else
                        {
                            outT = rightT;
                            return rightTriangle;
                        }
                    }
                    else if (rightTriangle != null)
                    {
                        outT = rightT;
                        return rightTriangle;

                    }
                    else if (leftTriangle != null)
                    {
                        outT = leftT;
                        return leftTriangle;
                    }
                    else
                    {
                        outT = float.MaxValue;
                        return null;
                    }
                }
                else
                {


                    //Base Case. We need to loop through our list of triangles.
                    outT = accelerator.minT;
                    int index = -1;

                    for(int i = start; i <= end; i++)
                    {
                        float currentTriangleT;
                        if(accelerator.triangles[i].intersection(r, out currentTriangleT))
                        {
                            if(currentTriangleT < outT)
                            {
                                index = i;
                                outT = currentTriangleT;
                            }
                        }

                    }
                    if (index == -1)
                    {
                        return null;
                    }
                    else
                    {
                        if(outT < accelerator.minT) accelerator.minT = outT;
                        return accelerator.triangles[index];
                    }
                        

                }
                    
            }
            //If the ray doesn't hit our node
            else
            {
                outT = float.MaxValue;
                return null;
            }
        }


        private int getLargestAxis()
        {
            //Set splitting axis
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

            for(int i = start; i <= end; i++)
            {
                Vector3 centroid = accelerator.triangles[i].centroid;

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
            if (span.X > span.Y && span.X > span.Z)
                return 0;
            else if (span.Y > span.Z)
                return 1;
            else
                return 2;

        }
        
                 

    }
}
