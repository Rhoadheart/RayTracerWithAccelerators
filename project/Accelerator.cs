using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.RayTracing
{
    
    public class Accelerator
    {
        public virtual Triangle intersect(Ray r, out float outT)
        {
            outT = -1f;
            return null;
        }
    }
}
