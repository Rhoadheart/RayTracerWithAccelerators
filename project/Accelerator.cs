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

        public virtual int numIntersects
        {
            get { return -1;}
        }
        
        public virtual int numNodes
        {
            get { return -1; }
        }

        public virtual int avgTriPerLeaf
        {
            get { return -1; }
        }
        
        public virtual int maxTriPerLeaf
        {
            get { return -1; }
        }
        public virtual int maxHeight
        {
            get { return -1; }
        }
        public virtual int avgHeight
        {
            get { return -1; }
        }
        public virtual int numLeaves
        {
            get { return -1; }
        }
    }
}
