using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MyExtensions
{
    public static class Vector3Extensions
    {
        public static Vector3 ApplyMatrix(this Vector3 self, Matrix4x4 matrix)
        {
            return new Vector3(
                matrix.M11 * self.X + matrix.M12 * self.Y + matrix.M13 * self.Z + matrix.M14 * 1,
                matrix.M21 * self.X + matrix.M22 * self.Y + matrix.M23 * self.Z + matrix.M24 * 1,
                matrix.M31 * self.X + matrix.M32 * self.Y + matrix.M33 * self.Z + matrix.M34 * 1
            );
        }
    }
}
