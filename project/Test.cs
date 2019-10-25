using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{
    class Test
    {
        public void Run()
        {
            Point p1 = new Point(1, 2, 3);
            Point p2 = new Point(6, 4, 2);
            Point p3 = new Point(2, 2, 2);
            Point origin = new Point(0, 0, 0);
            Vector3 up = new Vector3(0, 1, 0);
            //Test for Point Class
            try
            {
                if (p1.x != 1 || p1.y != 2 || p1.z != 3)
                    throw new Exception("Constructor Test Failed");
                if (Point.Add(p1, p2) != new Point(7, 6, 5))
                    throw new Exception("Add Test Failed");
                if (Point.Sub(p2, p3) != new Point(4, 2, 0))
                    throw new Exception("Sub Test Failed");
                if (p1 * p2 != new Point(6, 8, 6))
                    throw new Exception("*Operator Test Failed");
                if (p2 - p3 != new Vector3(4, 2, 0))
                    throw new Exception("-Operator Test Failed");
                if (p1 + p2 != new Vector3(7, 6, 5))
                    throw new Exception("+Operator Test Failed");


                Console.WriteLine("Point Tests Succeeded");

            }
            catch(Exception e)
            {
                Console.WriteLine("Point Test Failed: " + e.Message);
            }


            Ray r1 = new Ray(new Point (1,1,1), new Vector3(2,0,0));
            //TODO: Tests for Ray Class
            //Tests for Ray Class
            try
            {
                if(r1.getOrigin() != new Point(1, 1, 1))
                    throw new Exception("getOrigin() Test Failed");
                if (r1.getDirection() != Vector3.Normalize(new Vector3(2, 0, 0)))
                    throw new Exception("getDirection() Test Failed");


                Console.WriteLine("Ray Tests Succeeded");

            }
            catch (Exception e)
            {
                Console.WriteLine("Ray Test Failed: " + e.Message);
            }

            Triangle t1 = new Triangle(new Point(2, -1, 1), new Point(2, 1, 0), new Point(2, -1, -1));
            Ray r4 = new Ray(origin, new Vector3(2, 0, 0));
            Triangle t2 = new Triangle(new Point(2, 0, 0), new Point(0, 2, 0), new Point(0, 0, 2));
            Ray r5 = new Ray(origin, new Vector3(1, 1, 1));
            Ray r6 = new Ray(origin, new Vector3(1, -1, 1));
            Ray r7 = new Ray(origin, new Vector3(-1, -1, -1));

            //Tests for Triangle Class
            try
            {
                if (!t1.intersection(r4))
                    throw new Exception("intersection() Test 1 Failed");
                if (!t2.intersection(r5))
                    throw new Exception("intersection() Test 2 Failed");
                if (t2.intersection(r6))
                    throw new Exception("intersection() Test 3 Failed");
                if (t2.intersection(r7))
                    throw new Exception("intersection() Test 4 Failed Backwards Ray is intersecting");
                
                Console.WriteLine("Triangle Tests Succeeded");

            }
            catch (Exception e)
            {
                Console.WriteLine("Triangle Test Failed: " + e.Message);
            }

            Camera c1 = new Camera(origin, new Point(1, 0, 0), up, 1920, 1080);
            //Tests for Camera Class
            try
            {
                //TODO: Not Working just yet...
                Console.WriteLine(c1.getRay(new Point(960, 540, 0)));
               

                Console.WriteLine("Camera Tests Failed");

            }
            catch (Exception e)
            {
                Console.WriteLine("Camera Test Failed: " + e.Message);
            }


        }
    }
}
