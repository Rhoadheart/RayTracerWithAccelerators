using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    public class QuickSelect
    {

        public static void nth_element(ref List<Triangle> array, int startIndex, int nthToSeek, int endIndex, int axis)
        {
            int from = startIndex;
            int to = endIndex;

            // if from == to we reached the kth element
            while (from < to)
            {
                int r = from, w = to;
                Triangle mid = array[(r + w) / 2];

                // stop if the reader and writer meets
                while (r < w)
                {
                    if (array[r].CompareTo(mid, axis) > -1)
                    { // put the large values at the end
                        Triangle tmp = array[w];
                        array[w] = array[r];
                        array[r] = tmp;
                        w--;
                    }
                    else
                    { // the value is smaller than the pivot, skip
                        r++;
                    }
                }

                // if we stepped up (r++) we need to step one down
                if (array[r].CompareTo(mid, axis) > 0)
                {
                    r--;
                }

                // the r pointer is on the end of the first k elements
                if (nthToSeek <= r)
                {
                    to = r;
                }
                else
                {
                    from = r + 1;
                }
            }

            return;
        }

        private static void Swap<Triangle>(ref List<Triangle> triangles, int index1, int index2)
        {
            Triangle temp = triangles[index1];
            triangles[index1] = triangles[index2];
            triangles[index2] = temp;
        }

    }
}
