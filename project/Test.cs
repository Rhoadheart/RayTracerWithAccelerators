using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    class Test
    {
        public void Run()
        {
            Point p1 = new Point(1, 2, 3);
            if(p1.x == 1 && p1.y == 2 && p1.z == 3)
            {
                Console.WriteLine("Point Tests Passed Successfully");
            }

        }
    }
}
