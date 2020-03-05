using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    class BvHNode
    {

        private BoundingBox BBox;
        private BvHNode left;
        private BvHNode right;
        private Triangle t;
        private int axis;


        public BvHNode(List<BoundingBox> BBoxes, int axis)
        {
            int count = BBoxes.Count;

            if(count == 1)
            {
                //left = A[0]

                //right = NULL

                //bbox = bounding-box(A[0])
            }
            else if(count == 2)
            {
                 //left = A[0]

                 //right = A[1]
                 //bbox = combine(bounding-box(A[0]), bounding-box(A[1]))

            }
            else
            {
                //find the midpoint m of the bounding box of A along AXIS

                //partition A into lists with lengths k and(N − k) surrounding m

                //left = new bvh- node(A[0..k], (AXIS + 1) mod 3)

                //right = new bvh- node(A[k + 1..N − 1], (AXIS + 1) mod 3)

                //bbox = combine(left → bbox, right → bbox)
            }

        }
        
                 

    }
}
