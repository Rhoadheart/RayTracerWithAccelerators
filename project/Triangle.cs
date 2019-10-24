using project.RayTracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project.RayTracing
{
    class Triangle
    {
        Point p1;
        Point p2;
        Point p3;

        /**
         * <summary>
         * Default Triangle constructor given 3 points
         * </summary>
         */
        public Triangle(Point p1, Point p2, Point p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

        }

        /**
         * <summary>
         * Determines if the given Ray intersects with this Triangle
         * </summary>
         */
         /*
        public bool intersection(Ray r)
        {

        }
        */
    }
}
