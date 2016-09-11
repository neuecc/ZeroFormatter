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
        const int InitialLength = 16;

        public static byte[] Serialize<T>(T obj)
        {
            var formatter = Formatter<T>.Instance;

            byte[] result = null;
            var size = formatter.Serialize(ref result, 0, obj);

            if (result.Length != size)
            {
                Array.Resize(ref result, size);
            }

            return result;
        }

        public static void Serialize<T>(T obj, ref byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public static void Serialize<T>(T obj, MemoryStream memoryStream)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            var formatter = Formatter<T>.Instance;
            return formatter.Deserialize(ref bytes, 0);
        }
    }
}
