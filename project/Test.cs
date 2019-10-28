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
            Vector3 origin = new Vector3(0, 0, 0);
            Vector3 up = new Vector3(0, 1, 0);
            Ray r1 = new Ray(new Vector3 (1,1,1), new Vector3(2,0,0));
            //TODO: Tests for Ray Class
            //Tests for Ray Class
            try
            {
                if(r1.getOrigin() != new Vector3(1, 1, 1))
                    throw new Exception("getOrigin() Test Failed");
                if (r1.getDirection() != Vector3.Normalize(new Vector3(2, 0, 0)))
                    throw new Exception("getDirection() Test Failed");


                Console.WriteLine("Ray Tests Succeeded");

            }
            catch (Exception e)
            {
                Console.WriteLine("Ray Test Failed: " + e.Message);
            }

            Triangle t1 = new Triangle(new Vector3(2, -1, 1), new Vector3(2, 1, 0), new Vector3(2, -1, -1));
            Ray r4 = new Ray(origin, new Vector3(2, 0, 0));
            Triangle t2 = new Triangle(new Vector3(2, 0, 0), new Vector3(0, 2, 0), new Vector3(0, 0, 2));
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


            Camera c1 = new Camera(origin, new Vector3(1, 0, 0), up, 1920, 1080);
            //Tests for Camera Class
            try
            {
                if(c1.getRay(new Vector2(960, 540)).getOrigin() != origin)
                    throw new Exception("getRay() Test Failed. Origin Mismatch");
                if (c1.getRay(new Vector2(960, 540)).getDirection() != new Vector3(1,0,0))
                    throw new Exception("getRay() Test Failed. Direction Mismatch");



                Console.WriteLine("Camera Tests Succeeded");

            }
            catch (Exception e)
            {
                Console.WriteLine("Camera Test Failed: " + e.Message);
            }


        }
    }
}
