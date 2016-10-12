using System;
using System.IO;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter
{
    public static class Serializer
    {
        public static byte[] Serialize<T>(T obj)
        {
            byte[] result = null;
            Serialize(obj, ref result);
            return result;
        }

        public static void Serialize<T>(T obj, ref byte[] bytes)
        {
            var formatter = Formatter<T>.Default;
            if (formatter == null) throw new InvalidOperationException("Formatter not found, " + typeof(T).Name);

            var size = formatter.Serialize(ref bytes, 0, obj);

            if (bytes.Length != size)
            {
                BinaryUtil.FastResize(ref bytes, size);
            }
        }

        public static void Serialize<T>(T obj, Stream stream)
        {
            // optimized path
            // TryGetBuffer does not supports before .NET 4.6
            // MEMO: If allowgetbuffer = false, throws Exception...

            var ms = stream as MemoryStream;
            if (ms != null && ms.Position == 0)
            {
                var zeroFormatterObj = obj as IZeroFormatterSegment;
                if (zeroFormatterObj != null && zeroFormatterObj.CanDirectCopy())
                {
                    var bufferRef = zeroFormatterObj.GetBufferReference();

                    ms.SetLength(bufferRef.Count);
                    var dest = ms.GetBuffer();
                    Buffer.BlockCopy(bufferRef.Array, bufferRef.Offset, dest, 0, bufferRef.Count);
                }
            }
            else
            {
                var buffer = Serialize<T>(obj);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            var formatter = Formatter<T>.Default;
            if (formatter == null) throw new InvalidOperationException("Formatter not found, " + typeof(T).Name);

            int _;
            return formatter.Deserialize(ref bytes, 0, new DirtyTracker(), out _);
        }

        public static T Deserialize<T>(Stream stream)
        {
            var ms = stream as MemoryStream;
            if (ms != null)
            {
                var buffer = ms.GetBuffer();
                var formatter = Formatter<T>.Default;
                int _;
                return formatter.Deserialize(ref buffer, (int)ms.Position, new DirtyTracker(), out _);
            }
            else
            {
                var buffer = FillFromStream(stream);
                var array = buffer.Array;

                var formatter = Formatter<T>.Default;
                int _;
                return formatter.Deserialize(ref array, buffer.Offset, new DirtyTracker(), out _);
            }
        }

        public static T Convert<T>(T obj)
        {
            var wrapper = obj as IZeroFormatterSegment;
            if (wrapper != null && wrapper.CanDirectCopy())
            {
                return obj;
            }

            return Deserialize<T>(Serialize(obj));
        }

        public static bool IsFormattedObject<T>(T obj)
        {
            return obj is IZeroFormatterSegment;
        }

        // copy to does not supports before .NET 4
        // Note:better to use System.Buffers.ArrayPool
        static ArraySegment<byte> FillFromStream(Stream input)
        {
            var buffer = new byte[input.CanSeek ? input.Length : 16];

            int length = 0;
            int read;
            while ((read = input.Read(buffer, length, buffer.Length - length)) > 0)
            {
                length += read;
                if (length == buffer.Length)
                {
                    BinaryUtil.FastResize(ref buffer, length * 2);
                }
            }

            return new ArraySegment<byte>(buffer, 0, length);
        }
    }
}