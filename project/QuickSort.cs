using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    public class QuickSort
    {

        public static void nth_element(ref List<Triangle> triangles, int start, int end, int n, int axis)
        {
            int i, j;
            int m;
            Triangle a;

            while(true)
            {
                if (end <= start + 1)
                {
                    if (end == start + 1 && triangles[end].CompareTo(triangles[start], axis) < 0)
                    {
                        Swap(ref triangles, start, end);
                    }

                    return;
                }
                else
                {
                    m = (start + end) / 2;
                    Swap(ref triangles, m, start + 1);

                    if (triangles[start].CompareTo(triangles[start], axis) > 0)
                    {
                        Swap(ref triangles, start, end);
                    }

                    if (triangles[start + 1].CompareTo(triangles[end], axis) > 0)
                    {
                        Swap(ref triangles, start + 1, end);
                    }

                    if (triangles[start].CompareTo(triangles[start + 1], axis) > 0)
                    {
                        Swap(ref triangles, start, start + 1);
                    }

                    i = start + 1;
                    j = end;
                    a = triangles[start + 1];

                    while(true)
                    {
                        while (triangles[i].CompareTo(a, axis) < 0) { i++; }
                        while (triangles[j].CompareTo(a, axis) > 0) { j--; }
                        if (j < i)
                            break;
                        Swap(ref triangles, i, j);
                    }

                    triangles[start + 1] = triangles[j];
                    triangles[j] = a;
                    if (j >= n) end = j - 1;
                    if (j <= n) start = i;
                }
            }
        }

        private static void Swap<Triangle>(ref List<Triangle> triangles, int index1, int index2)
        {
            Triangle temp = triangles[index1];
            triangles[index1] = triangles[index2];
            triangles[index2] = temp;
        }

    }
}
