using System;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Formatters
{


    internal class Int16ArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Int16[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int16[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 2;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Int16[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 2 + 4;
            }

            var arraySize = length * 2;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Int16[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class Int32ArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Int32[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int32[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 4;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Int32[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 4 + 4;
            }

            var arraySize = length * 4;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Int32[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class Int64ArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Int64[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Int64[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 8;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Int64[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 8 + 4;
            }

            var arraySize = length * 8;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Int64[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class UInt16ArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, UInt16[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt16[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 2;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override UInt16[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 2 + 4;
            }

            var arraySize = length * 2;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new UInt16[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class UInt32ArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, UInt32[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt32[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 4;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override UInt32[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 4 + 4;
            }

            var arraySize = length * 4;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new UInt32[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class UInt64ArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, UInt64[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, UInt64[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 8;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override UInt64[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 8 + 4;
            }

            var arraySize = length * 8;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new UInt64[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class SingleArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Single[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Single[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 4;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Single[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 4 + 4;
            }

            var arraySize = length * 4;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Single[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class DoubleArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Double[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Double[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 8;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Double[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 8 + 4;
            }

            var arraySize = length * 8;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Double[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class BooleanArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Boolean[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Boolean[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 1;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Boolean[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 1 + 4;
            }

            var arraySize = length * 1;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Boolean[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class ByteArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Byte[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Byte[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 1;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Byte[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 1 + 4;
            }

            var arraySize = length * 1;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Byte[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class SByteArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, SByte[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, SByte[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 1;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override SByte[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 1 + 4;
            }

            var arraySize = length * 1;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new SByte[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


    internal class CharArrayFormatter<TTypeResolver> : Formatter<TTypeResolver, Char[]>
        where TTypeResolver : ITypeResolver, new()
    {
        public override bool NoUseDirtyTracker
        {
            get
            {
                return true;
            }
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Char[] value)
        {
            if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }

            var writeSize = value.Length * 2;
            BinaryUtil.EnsureCapacity(ref bytes, offset, writeSize + 4);
            BinaryUtil.WriteInt32Unsafe(ref bytes, offset, value.Length);
            Buffer.BlockCopy(value, 0, bytes, offset + 4, writeSize);

            return writeSize + 4;
        }

        public override Char[] Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            tracker.Dirty(); // can not track so mark as dirty.

            var length = BinaryUtil.ReadInt32(ref bytes, offset);
            if (length == -1)
            {
                byteSize = 4;
                return null;
            }
            else
            {
                byteSize = length * 2 + 4;
            }

            var arraySize = length * 2;
            ZeroFormatterSerializer.ValidateNewLength(arraySize);
            var result = new Char[length];
            Buffer.BlockCopy(bytes, offset + 4, result, 0, arraySize);

            return result;
        }
    }


}