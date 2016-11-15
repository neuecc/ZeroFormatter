using System;
using ZeroFormatter;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;
using ZeroFormatter.Segments;
using ZeroFormatter.Internal;
using System.Runtime.InteropServices;

namespace Sandbox
{
    [ZeroFormattable]
    public struct Vector3
    {
        [Index(0)]
        public float x;

        [Index(1)]
        public float y;

        [Index(2)]
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

   
}
