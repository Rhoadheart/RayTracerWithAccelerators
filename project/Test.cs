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
        /// <summary>
        /// Method for running all tests
        /// </summary>
        public void Run()
        {
            Vector3 origin = new Vector3(0, 0, 0);
            Vector3 up = new Vector3(0, 1, 0);
            Ray r1 = new Ray(new Vector3 (1,1,1), new Vector3(2,0,0));
            Ray r2 = new Ray(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
            Matrix4x4 proj = new Matrix4x4(2, 0, 0, 1,
                                           0, 1, 0, 1,
                                           0, 0, 1, 1,
                                           0, 0, 0, 1);
            //TODO: Tests for Ray Class
            //Tests for Ray Class
            try
            {
                if(r1.getOrigin() != new Vector3(1, 1, 1))
                    throw new Exception("getOrigin() Test Failed");
                if (r1.getDirection() != Vector3.Normalize(new Vector3(2, 0, 0)))
                    throw new Exception("getDirection() Test Failed");
                Ray answer = new Ray(new Vector3(1, 1, 1), new Vector3(0.8164966f, 0.4082483f, 0.4082483f));
                Ray output = r2.transform(proj);
                if (output.getOrigin() != answer.getOrigin())
                    throw new Exception("transform() Test Failed");
                if (output.getDirection() != answer.getDirection())
                    throw new Exception("transform() Test Failed");


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
                float outFloat;
                if (!t1.intersection(r4, out outFloat))
                    throw new Exception("intersection() Test 1 Failed");
                if (!t2.intersection(r5, out outFloat))
                    throw new Exception("intersection() Test 2 Failed");
                if (t2.intersection(r6, out outFloat))
                    throw new Exception("intersection() Test 3 Failed");
                if (t2.intersection(r7, out outFloat))
                    throw new Exception("intersection() Test 4 Failed Backwards Ray is intersecting");
                

                Console.WriteLine("Triangle Tests Succeeded");

            }
            catch (Exception e)
            {
                Console.WriteLine("Triangle Test Failed: " + e.Message);
            }


            Camera c1 = new Camera(origin, new Vector3(1, 0, 0), up, 1920, 1080);
            Camera c2 = new Camera(new Vector3(2, 2, 0), new Vector3(0,0,0), up, 1920, 1080);
            Camera c3 = new Camera(new Vector3(-3, -3, -3), new Vector3(0, 0, 0), up, 1920, 1080);
            //Tests for Camera Class
            try
            {

                c1.setFov(90);
                Vector3 output;
                output = c1.getRay(new Vector2(960, 1080)).getDirection();
                if (output != new Vector3(.707106769f, .707106769f, 0))
                    throw new Exception("getRay() Test Failed. Camera Produced a Miscalculated Ray based on the FOV");

                c1.setFov(43);
                output = c1.getRay(new Vector2(960, 540)).getOrigin();
                if (output != origin)
                    throw new Exception("getRay() Test Failed. Origin Mismatch");

                output = c1.getRay(new Vector2(960, 540)).getDirection();
                if (output != new Vector3(1,0,0))
                    throw new Exception("getRay() Test Failed. Direction Mismatch");

                output = c2.getRay(new Vector2(960, 540)).getOrigin();
                if (output != new Vector3(2, 2, 0))
                    throw new Exception("getRay() Test Failed. Angled Camera Origin Mismatch");

                output = c2.getRay(new Vector2(960, 540)).getDirection();
                if (output != new Vector3(-0.707106769f, -0.707106769f, 0))
                    throw new Exception("getRay() Test Failed. Angled Camera Produced a Miscalculated Ray");

                output = c3.getRay(new Vector2(960, 540)).getOrigin();
                if (output != new Vector3(-3,-3,-3))
                    throw new Exception("getRay() Test Failed. Angled Camera Origin Mismatch");

                output = c3.getRay(new Vector2(960, 540)).getDirection();
                if (output != new Vector3(.577350259f, .577350259f, .577350259f))
                    throw new Exception("getRay() Test Failed. Angled Camera Produced a Miscalculated Ray");

                //FOV is not scaling correctly for some reason. Need to discuss this with Dr. Wolff on Monday
                Console.WriteLine("Camera Tests Succeeded");

            }
            catch (Exception e)
            {
                Console.WriteLine("Camera Test Failed: " + e.Message);
            }


            c1 = new Camera(new Vector3 (-2,0,0), new Vector3(1, 0, 0), up, 1920, 1080);
            Triangle[] triangles = new Triangle[3];
            triangles[0] = new Triangle(new Vector3(2, -1, 1), new Vector3(2, 1, 0), new Vector3(2, -1, -1));
            triangles[1] = new Triangle(new Vector3(2, -1, 1), new Vector3(1, 1, 1), new Vector3(2, 1, 0));
            triangles[2] = new Triangle(new Vector3(2, -1, -1), new Vector3(2, 1, 0), new Vector3(1, 1, -1));
            
            Mesh m1 = new Mesh(triangles);
            //Tests for Image Generation
            try
            {
                Image output = new Image(c1, m1, "../../TestMesh.png");
                Console.WriteLine("Image Tests Succeeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Image Test Failed: " + e.Message);
            }


        }
    }
}
