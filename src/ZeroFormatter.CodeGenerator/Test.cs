namespace ZeroFormatter.Tests
{
    using System;
    using ZeroFormatter.Formatters;
    using ZeroFormatter.Internal;
    using ZeroFormatter.Segments;

    public class MyClassFormatter : Formatter<global::ZeroFormatter.Tests.MyClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyClass value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (4 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 3, value.HogeMoge);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 4, value.MyList);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::ZeroFormatter.Tests.MyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClass_ObjectSegment : global::ZeroFormatter.Tests.MyClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _FirstName;
        readonly CacheSegment<string> _LastName;
        global::System.Collections.Generic.IList<int> _MyList;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 1
        public override string FirstName
        {
            get
            {
                return _FirstName.Value;
            }
            set
            {
                _FirstName.Value = value;
            }
        }

        // 2
        public override string LastName
        {
            get
            {
                return _LastName.Value;
            }
            set
            {
                _LastName.Value = value;
            }
        }

        // 3
        public override int HogeMoge
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 4
        public override global::System.Collections.Generic.IList<int> MyList
        {
            get
            {
                return _MyList;
            }
            set
            {
                __tracker.Dirty();
                _MyList = value;
            }
        }


        public MyClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex));
            _MyList = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex), __tracker, out __out);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _LastName);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 4, _MyList);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SkipIndexFormatter : Formatter<global::ZeroFormatter.Tests.ObjectFormatterTest.SkipIndex>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ObjectFormatterTest.SkipIndex value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 1, value.MyProperty1);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 2, value.MyProperty2);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 4, value.MyProperty4);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<string>(ref bytes, startOffset, offset, 5, value.MyProperty5);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::ZeroFormatter.Tests.ObjectFormatterTest.SkipIndex Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SkipIndex_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SkipIndex_ObjectSegment : global::ZeroFormatter.Tests.ObjectFormatterTest.SkipIndex, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 4, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IList<int> _MyProperty4;
        readonly CacheSegment<string> _MyProperty5;

        // 1
        public override int MyProperty1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 2
        public override int MyProperty2
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 3
        public override int MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 4
        public override global::System.Collections.Generic.IList<int> MyProperty4
        {
            get
            {
                return _MyProperty4;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty4 = value;
            }
        }

        // 5
        public override string MyProperty5
        {
            get
            {
                return _MyProperty5.Value;
            }
            set
            {
                _MyProperty5.Value = value;
            }
        }


        public SkipIndex_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _MyProperty4 = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex), __tracker, out __out);
            _MyProperty5 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 4, _MyProperty4);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 5, _MyProperty5);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema1Formatter : Formatter<global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema1>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema1 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 1, value.MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema1 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new OtherSchema1_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema1_ObjectSegment : global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema1, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 1
        public override int MyProperty1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value);
            }
        }


        public OtherSchema1_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema2Formatter : Formatter<global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema2 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new OtherSchema2_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema2_ObjectSegment : global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema2, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 3
        public override int MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value);
            }
        }


        public OtherSchema2_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema3Formatter : Formatter<global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema3>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema3 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (10 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<double>(ref bytes, startOffset, offset, 7, value.MyProperty7);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int?>(ref bytes, startOffset, offset, 8, value.MyProperty8);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 10, value.MyProperty10);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 10);
            }
        }

        public override global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema3 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new OtherSchema3_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema3_ObjectSegment : global::ZeroFormatter.Tests.ObjectFormatterTest.OtherSchema3, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 4, 0, 0, 0, 8, 5, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 3
        public override int MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 7
        public override double MyProperty7
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<double>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<double>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 8
        public override int? MyProperty8
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int?>(__originalBytes, 8, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int?>(__originalBytes, 8, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 10
        public override int MyProperty10
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 10, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 10, __binaryLastIndex, __extraFixedBytes, value);
            }
        }


        public OtherSchema3_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (10 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeFixedLength<double>(ref targetBytes, startOffset, offset, 7, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeFixedLength<int?>(ref targetBytes, startOffset, offset, 8, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 10, __binaryLastIndex, __originalBytes, __extraFixedBytes);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 10);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClassFormatter : Formatter<global::ZeroFormatter.Tests.ReadOnly.MyClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ReadOnly.MyClass value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IReadOnlyList<int>>(ref bytes, startOffset, offset, 0, value.MyReadOnlyListOne);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IReadOnlyList<string>>(ref bytes, startOffset, offset, 1, value.MyReadOnlyListTwo);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IReadOnlyDictionary<int, string>>(ref bytes, startOffset, offset, 2, value.MyReadOnlyDictOne);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IReadOnlyDictionary<global::ZeroFormatter.KeyTuple<int, string>, string>>(ref bytes, startOffset, offset, 3, value.MyReadOnlyDictTwo);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::ZeroFormatter.Tests.ReadOnly.MyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClass_ObjectSegment : global::ZeroFormatter.Tests.ReadOnly.MyClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IReadOnlyList<int> _MyReadOnlyListOne;
        global::System.Collections.Generic.IReadOnlyList<string> _MyReadOnlyListTwo;
        global::System.Collections.Generic.IReadOnlyDictionary<int, string> _MyReadOnlyDictOne;
        global::System.Collections.Generic.IReadOnlyDictionary<global::ZeroFormatter.KeyTuple<int, string>, string> _MyReadOnlyDictTwo;

        // 0
        public override global::System.Collections.Generic.IReadOnlyList<int> MyReadOnlyListOne
        {
            get
            {
                return _MyReadOnlyListOne;
            }
            set
            {
                __tracker.Dirty();
                _MyReadOnlyListOne = value;
            }
        }

        // 1
        public override global::System.Collections.Generic.IReadOnlyList<string> MyReadOnlyListTwo
        {
            get
            {
                return _MyReadOnlyListTwo;
            }
            set
            {
                __tracker.Dirty();
                _MyReadOnlyListTwo = value;
            }
        }

        // 2
        public override global::System.Collections.Generic.IReadOnlyDictionary<int, string> MyReadOnlyDictOne
        {
            get
            {
                return _MyReadOnlyDictOne;
            }
            set
            {
                __tracker.Dirty();
                _MyReadOnlyDictOne = value;
            }
        }

        // 3
        public override global::System.Collections.Generic.IReadOnlyDictionary<global::ZeroFormatter.KeyTuple<int, string>, string> MyReadOnlyDictTwo
        {
            get
            {
                return _MyReadOnlyDictTwo;
            }
            set
            {
                __tracker.Dirty();
                _MyReadOnlyDictTwo = value;
            }
        }


        public MyClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _MyReadOnlyListOne = Formatter<global::System.Collections.Generic.IReadOnlyList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 0, __binaryLastIndex), __tracker, out __out);
            _MyReadOnlyListTwo = Formatter<global::System.Collections.Generic.IReadOnlyList<string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 1, __binaryLastIndex), __tracker, out __out);
            _MyReadOnlyDictOne = Formatter<global::System.Collections.Generic.IReadOnlyDictionary<int, string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 2, __binaryLastIndex), __tracker, out __out);
            _MyReadOnlyDictTwo = Formatter<global::System.Collections.Generic.IReadOnlyDictionary<global::ZeroFormatter.KeyTuple<int, string>, string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex), __tracker, out __out);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IReadOnlyList<int>>(ref targetBytes, startOffset, offset, 0, _MyReadOnlyListOne);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IReadOnlyList<string>>(ref targetBytes, startOffset, offset, 1, _MyReadOnlyListTwo);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IReadOnlyDictionary<int, string>>(ref targetBytes, startOffset, offset, 2, _MyReadOnlyDictOne);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IReadOnlyDictionary<global::ZeroFormatter.KeyTuple<int, string>, string>>(ref targetBytes, startOffset, offset, 3, _MyReadOnlyDictTwo);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClassFormatter : Formatter<global::ZeroFormatter.Tests.RecursiveCheck.MyClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.RecursiveCheck.MyClass value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Hoge);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::ZeroFormatter.Tests.RecursiveCheck.MyClass>(ref bytes, startOffset, offset, 1, value.Rec);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.RecursiveCheck.MyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClass_ObjectSegment : global::ZeroFormatter.Tests.RecursiveCheck.MyClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::ZeroFormatter.Tests.RecursiveCheck.MyClass _Rec;

        // 0
        public override int Hoge
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 1
        public override global::ZeroFormatter.Tests.RecursiveCheck.MyClass Rec
        {
            get
            {
                return _Rec;
            }
            set
            {
                __tracker.Dirty();
                _Rec = value;
            }
        }


        public MyClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _Rec = Formatter<global::ZeroFormatter.Tests.RecursiveCheck.MyClass>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 1, __binaryLastIndex), __tracker, out __out);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.Tests.RecursiveCheck.MyClass>(ref targetBytes, startOffset, offset, 1, _Rec);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class AttrSerializableTargetFormatter : Formatter<global::ZeroFormatter.Tests.AttrSerializableTarget>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.AttrSerializableTarget value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<string>(ref bytes, startOffset, offset, 1, value.MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.AttrSerializableTarget Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new AttrSerializableTarget_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class AttrSerializableTarget_ObjectSegment : global::ZeroFormatter.Tests.AttrSerializableTarget, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _MyProperty1;

        // 0
        public override int MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value);
            }
        }

        // 1
        public override string MyProperty1
        {
            get
            {
                return _MyProperty1.Value;
            }
            set
            {
                _MyProperty1.Value = value;
            }
        }


        public AttrSerializableTarget_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _MyProperty1 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyFormatClassFormatter : Formatter<global::ZeroFormatter.Tests.MyFormatClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyFormatClass value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::ZeroFormatter.Tests.MyFormatClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyFormatClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyFormatClass_ObjectSegment : global::ZeroFormatter.Tests.MyFormatClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int MyProperty
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value);
            }
        }


        public MyFormatClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class AllNullClassFormatter : Formatter<global::ZeroFormatter.Tests.AllNullClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.AllNullClass value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (7 + 1));
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IDictionary<int, string>>(ref bytes, startOffset, offset, 0, value.MyProperty1);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 1, value.MyProperty2);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 2, value.MyProperty3);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 3, value.MyProperty4);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::ZeroFormatter.Tests.MyFormatClass>(ref bytes, startOffset, offset, 4, value.MyProperty5);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<string>(ref bytes, startOffset, offset, 6, value.MyProperty7);
                offset += ObjectSegmentHelper.SerialzieFromFormatter<global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 7, value.MyProperty8);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 7);
            }
        }

        public override global::ZeroFormatter.Tests.AllNullClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new AllNullClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class AllNullClass_ObjectSegment : global::ZeroFormatter.Tests.AllNullClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IDictionary<int, string> _MyProperty1;
        global::System.Collections.Generic.IList<int> _MyProperty2;
        global::System.Collections.Generic.IList<string> _MyProperty3;
        global::System.Linq.ILookup<bool, int> _MyProperty4;
        global::ZeroFormatter.Tests.MyFormatClass _MyProperty5;
        readonly CacheSegment<string> _MyProperty7;
        global::System.Collections.Generic.IDictionary<string, int> _MyProperty8;

        // 0
        public override global::System.Collections.Generic.IDictionary<int, string> MyProperty1
        {
            get
            {
                return _MyProperty1;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty1 = value;
            }
        }

        // 1
        public override global::System.Collections.Generic.IList<int> MyProperty2
        {
            get
            {
                return _MyProperty2;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty2 = value;
            }
        }

        // 2
        public override global::System.Collections.Generic.IList<string> MyProperty3
        {
            get
            {
                return _MyProperty3;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty3 = value;
            }
        }

        // 3
        public override global::System.Linq.ILookup<bool, int> MyProperty4
        {
            get
            {
                return _MyProperty4;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty4 = value;
            }
        }

        // 4
        public override global::ZeroFormatter.Tests.MyFormatClass MyProperty5
        {
            get
            {
                return _MyProperty5;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty5 = value;
            }
        }

        // 6
        public override string MyProperty7
        {
            get
            {
                return _MyProperty7.Value;
            }
            set
            {
                _MyProperty7.Value = value;
            }
        }

        // 7
        public override global::System.Collections.Generic.IDictionary<string, int> MyProperty8
        {
            get
            {
                return _MyProperty8;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty8 = value;
            }
        }


        public AllNullClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _MyProperty1 = Formatter<global::System.Collections.Generic.IDictionary<int, string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 0, __binaryLastIndex), __tracker, out __out);
            _MyProperty2 = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 1, __binaryLastIndex), __tracker, out __out);
            _MyProperty3 = Formatter<global::System.Collections.Generic.IList<string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 2, __binaryLastIndex), __tracker, out __out);
            _MyProperty4 = Formatter<global::System.Linq.ILookup<bool, int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex), __tracker, out __out);
            _MyProperty5 = Formatter<global::ZeroFormatter.Tests.MyFormatClass>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex), __tracker, out __out);
            _MyProperty7 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex));
            _MyProperty8 = Formatter<global::System.Collections.Generic.IDictionary<string, int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 7, __binaryLastIndex), __tracker, out __out);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (7 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IDictionary<int, string>>(ref targetBytes, startOffset, offset, 0, _MyProperty1);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 1, _MyProperty2);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 2, _MyProperty3);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 3, _MyProperty4);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.Tests.MyFormatClass>(ref targetBytes, startOffset, offset, 4, _MyProperty5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 6, _MyProperty7);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 7, _MyProperty8);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 7);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

