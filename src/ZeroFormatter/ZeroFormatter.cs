using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Format;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter
{
    public static class ZeroFormatter
    {
        public static byte[] Serialize<T>(T obj)
        {
            byte[] result = null;
            Serialize(obj, ref result);
            return result;
        }

        public static void Serialize<T>(T obj, ref byte[] bytes)
        {
            var formatter = Formatter<T>.Instance;

            var size = formatter.Serialize(ref bytes, 0, obj);

            if (bytes.Length != size)
            {
                BinaryUtil.FastResize(ref bytes, size);
            }
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            return Deserialize<T>(bytes, 0);
        }

        public static T Deserialize<T>(byte[] bytes, int offset)
        {
            var formatter = Formatter<T>.Instance;
            return formatter.Deserialize(ref bytes, offset);
        }
    }
}