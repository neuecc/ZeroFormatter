#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.Internal
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;
    using global::ZeroFormatter.Comparers;

    public static partial class ZeroFormatterInitializer
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            // Enums
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMogeFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MogeMoge?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.NullableMogeMogeFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMogeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMoge2Formatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MogeMoge2?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.NullableMogeMoge2Formatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMoge2EqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMogeFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MogeMoge?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.NullableMogeMogeFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMogeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMoge2Formatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MogeMoge2?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.NullableMogeMoge2Formatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMoge2EqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::System.TypeCode>.Register(new ZeroFormatter.DynamicObjectSegments.System.TypeCodeFormatter());
            ZeroFormatter.Formatters.Formatter<global::System.TypeCode?>.Register(new ZeroFormatter.DynamicObjectSegments.System.NullableTypeCodeFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::System.TypeCode>.Register(new ZeroFormatter.DynamicObjectSegments.System.TypeCodeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.IntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.IntEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.IntEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableIntEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.IntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.IntEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.UIntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UIntEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.UIntEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableUIntEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.UIntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UIntEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.ShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ShortEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.ShortEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableShortEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ShortEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.UShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UShortEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.UShortEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableUShortEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.UShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UShortEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.ByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ByteEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.ByteEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableByteEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ByteEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.SByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.SByteEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.SByteEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableSByteEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.SByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.SByteEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.LongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.LongEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.LongEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableLongEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.LongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.LongEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.ULongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ULongEnumFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.ULongEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableULongEnumFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ULongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ULongEnumEqualityComparer());
            // Objects
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MyClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MyClass2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MyClass2Formatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MyClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MyClass2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MyClass2Formatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.InheritBase>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InheritBaseFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Inherit>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InheritFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.FooBarBaz>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.FooBarBazFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Standard>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.StandardFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Small>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.SmallFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Large>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.LargeFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyFormatClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyFormatClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.AllNullClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.AllNullClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.SkipIndex>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.SkipIndexFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.OtherSchema1>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OtherSchema1Formatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.OtherSchema2>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OtherSchema2Formatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.OtherSchema3>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OtherSchema3Formatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.RecMyClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.RecMyClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.KeyTupleCheck>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.KeyTupleCheckFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.Offset2>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.Offset2Formatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.OffsetType>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OffsetTypeFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.TestBase>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.TestBaseFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.Test2>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.Test2Formatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.IncludeStruct>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.IncludeStructFormatter());
            // Structs
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyStructFixedFormatter();
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyStructFixed>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyStructFixed?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<global::ZeroFormatter.Tests.MyStructFixed>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyStructVariableFormatter();
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyStructVariable>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyStructVariable?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<global::ZeroFormatter.Tests.MyStructVariable>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyVectorFormatter();
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyVector>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyVector?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<global::ZeroFormatter.Tests.MyVector>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyNonVectorFormatter();
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyNonVector>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyNonVector?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<global::ZeroFormatter.Tests.MyNonVector>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector2Formatter();
                ZeroFormatter.Formatters.Formatter<global::UnityEngine.Vector2>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<global::UnityEngine.Vector2?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<global::UnityEngine.Vector2>(structFormatter));
            }
            // Generics
            ZeroFormatter.Formatters.Formatter.RegisterKeyTuple<int, string>();
            ZeroFormatter.Formatters.Formatter.RegisterList<byte[]>();
            ZeroFormatter.Formatters.Formatter.RegisterList<global::Sandbox.Shared.Bar.MogeMoge>();
            ZeroFormatter.Formatters.Formatter.RegisterList<global::Sandbox.Shared.Foo.MogeMoge>();
            ZeroFormatter.Formatters.Formatter.RegisterList<int>();
            ZeroFormatter.Formatters.Formatter.RegisterList<string>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<int, string>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<string, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLookup<bool, int>();
        }
    }
}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MyClassFormatter : Formatter<global::Sandbox.Shared.Bar.MyClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.MyClass value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Sandbox.Shared.Bar.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::Sandbox.Shared.Bar.MyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClassObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClassObjectSegment : global::Sandbox.Shared.Bar.MyClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _FirstName;
        readonly CacheSegment<string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
        public override global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge> List
        {
            get
            {
                return _List;
            }
            set
            {
                __tracker.Dirty();
                _List = value;
            }
        }

        // 4
        public override global::Sandbox.Shared.Bar.MogeMoge Mone
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = Formatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<global::Sandbox.Shared.Bar.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClass2Formatter : Formatter<global::Sandbox.Shared.Bar.MyClass2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.MyClass2 value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Sandbox.Shared.Bar.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::Sandbox.Shared.Bar.MyClass2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClass2ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClass2ObjectSegment : global::Sandbox.Shared.Bar.MyClass2, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _FirstName;
        readonly CacheSegment<string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
        public override global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge> List
        {
            get
            {
                return _List;
            }
            set
            {
                __tracker.Dirty();
                _List = value;
            }
        }

        // 4
        public override global::Sandbox.Shared.Bar.MogeMoge Mone
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClass2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = Formatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<global::Sandbox.Shared.Bar.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MyClassFormatter : Formatter<global::Sandbox.Shared.Foo.MyClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Foo.MyClass value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Sandbox.Shared.Foo.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::Sandbox.Shared.Foo.MyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClassObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClassObjectSegment : global::Sandbox.Shared.Foo.MyClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _FirstName;
        readonly CacheSegment<string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
        public override global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge> List
        {
            get
            {
                return _List;
            }
            set
            {
                __tracker.Dirty();
                _List = value;
            }
        }

        // 4
        public override global::Sandbox.Shared.Foo.MogeMoge Mone
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = Formatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<global::Sandbox.Shared.Foo.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClass2Formatter : Formatter<global::Sandbox.Shared.Foo.MyClass2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Foo.MyClass2 value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Sandbox.Shared.Foo.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::Sandbox.Shared.Foo.MyClass2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClass2ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClass2ObjectSegment : global::Sandbox.Shared.Foo.MyClass2, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _FirstName;
        readonly CacheSegment<string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
        public override global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge> List
        {
            get
            {
                return _List;
            }
            set
            {
                __tracker.Dirty();
                _List = value;
            }
        }

        // 4
        public override global::Sandbox.Shared.Foo.MogeMoge Mone
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClass2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = Formatter<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<global::Sandbox.Shared.Foo.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class InheritBaseFormatter : Formatter<global::Sandbox.Shared.InheritBase>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InheritBase value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty0);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.InheritBase Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new InheritBaseObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class InheritBaseObjectSegment : global::Sandbox.Shared.InheritBase, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public InheritBaseObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class InheritFormatter : Formatter<global::Sandbox.Shared.Inherit>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Inherit value)
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

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 1, value.MyProperty1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.TypeCode>(ref bytes, startOffset, offset, 2, value.MyProperty2);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Sandbox.Shared.Inherit Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new InheritObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class InheritObjectSegment : global::Sandbox.Shared.Inherit, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int MyProperty1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override global::System.TypeCode MyProperty2
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::System.TypeCode>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::System.TypeCode>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public InheritObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<global::System.TypeCode>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class FooBarBazFormatter : Formatter<global::Sandbox.Shared.FooBarBaz>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.FooBarBaz value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<byte[]>>(ref bytes, startOffset, offset, 0, value.HugaHuga);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.FooBarBaz Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new FooBarBazObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class FooBarBazObjectSegment : global::Sandbox.Shared.FooBarBaz, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IList<byte[]> _HugaHuga;

        // 0
        public override global::System.Collections.Generic.IList<byte[]> HugaHuga
        {
            get
            {
                return _HugaHuga;
            }
            set
            {
                __tracker.Dirty();
                _HugaHuga = value;
            }
        }


        public FooBarBazObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _HugaHuga = Formatter<global::System.Collections.Generic.IList<byte[]>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 0, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<byte[]>>(ref targetBytes, startOffset, offset, 0, _HugaHuga);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class StandardFormatter : Formatter<global::Sandbox.Shared.Standard>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Standard value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Sandbox.Shared.Standard Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new StandardObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class StandardObjectSegment : global::Sandbox.Shared.Standard, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public StandardObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SmallFormatter : Formatter<global::Sandbox.Shared.Small>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Small value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.MyProperty1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 2, value.MyProperty2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Sandbox.Shared.Small Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SmallObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SmallObjectSegment : global::Sandbox.Shared.Small, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _MyProperty1;
        global::System.Collections.Generic.IList<int> _MyProperty2;

        // 0
        public override int MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

        // 2
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

        // 3
        public override int MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public SmallObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _MyProperty1 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _MyProperty2 = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 2, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _MyProperty1);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 2, _MyProperty2);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LargeFormatter : Formatter<global::Sandbox.Shared.Large>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Large value)
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

                offset += (8 + 4 * (6 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 4, value.MyProperty4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<long>(ref bytes, startOffset, offset, 5, value.MyProperty5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 6, value.MyProperty6);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 6);
            }
        }

        public override global::Sandbox.Shared.Large Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LargeObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LargeObjectSegment : global::Sandbox.Shared.Large, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4, 0, 8, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IList<string> _MyProperty4;
        readonly CacheSegment<string> _MyProperty6;

        // 0
        public override int MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override global::System.Collections.Generic.IList<string> MyProperty4
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
        public override long MyProperty5
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<long>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<long>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 6
        public override string MyProperty6
        {
            get
            {
                return _MyProperty6.Value;
            }
            set
            {
                _MyProperty6.Value = value;
            }
        }


        public LargeObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 6, __elementSizes);

            _MyProperty4 = Formatter<global::System.Collections.Generic.IList<string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex, __tracker), __tracker, out __out);
            _MyProperty6 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (6 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 4, _MyProperty4);
                offset += ObjectSegmentHelper.SerializeFixedLength<long>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 6, _MyProperty6);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 6);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty);

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
            return new MyFormatClassObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyFormatClassObjectSegment : global::ZeroFormatter.Tests.MyFormatClass, IZeroFormatterSegment
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyFormatClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IDictionary<int, string>>(ref bytes, startOffset, offset, 0, value.MyProperty1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 1, value.MyProperty2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 2, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 3, value.MyProperty4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.Tests.MyFormatClass>(ref bytes, startOffset, offset, 4, value.MyProperty5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<byte[]>(ref bytes, startOffset, offset, 5, value.MyProperty6);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 6, value.MyProperty7);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 7, value.MyProperty8);

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
            return new AllNullClassObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class AllNullClassObjectSegment : global::ZeroFormatter.Tests.AllNullClass, IZeroFormatterSegment
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
        readonly CacheSegment<byte[]> _MyProperty6;
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

        // 5
        public override byte[] MyProperty6
        {
            get
            {
                return _MyProperty6.Value;
            }
            set
            {
                _MyProperty6.Value = value;
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


        public AllNullClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 7, __elementSizes);

            _MyProperty1 = Formatter<global::System.Collections.Generic.IDictionary<int, string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 0, __binaryLastIndex, __tracker), __tracker, out __out);
            _MyProperty2 = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 1, __binaryLastIndex, __tracker), __tracker, out __out);
            _MyProperty3 = Formatter<global::System.Collections.Generic.IList<string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 2, __binaryLastIndex, __tracker), __tracker, out __out);
            _MyProperty4 = Formatter<global::System.Linq.ILookup<bool, int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex, __tracker), __tracker, out __out);
            _MyProperty5 = Formatter<global::ZeroFormatter.Tests.MyFormatClass>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex, __tracker), __tracker, out __out);
            _MyProperty6 = new CacheSegment<byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _MyProperty7 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
            _MyProperty8 = Formatter<global::System.Collections.Generic.IDictionary<string, int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 7, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (7 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IDictionary<int, string>>(ref targetBytes, startOffset, offset, 0, _MyProperty1);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 1, _MyProperty2);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 2, _MyProperty3);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 3, _MyProperty4);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.Tests.MyFormatClass>(ref targetBytes, startOffset, offset, 4, _MyProperty5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<byte[]>(ref targetBytes, startOffset, offset, 5, _MyProperty6);
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.HogeMoge);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 4, value.MyList);

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
            return new MyClassObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClassObjectSegment : global::ZeroFormatter.Tests.MyClass, IZeroFormatterSegment
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
            protected set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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


        public MyClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _MyList = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _LastName);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 4, _MyList);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SkipIndexFormatter : Formatter<global::ZeroFormatter.Tests.SkipIndex>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.SkipIndex value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 1, value.MyProperty1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 2, value.MyProperty2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 4, value.MyProperty4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 5, value.MyProperty5);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::ZeroFormatter.Tests.SkipIndex Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SkipIndexObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SkipIndexObjectSegment : global::ZeroFormatter.Tests.SkipIndex, IZeroFormatterSegment
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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


        public SkipIndexObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _MyProperty4 = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex, __tracker), __tracker, out __out);
            _MyProperty5 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
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

    public class OtherSchema1Formatter : Formatter<global::ZeroFormatter.Tests.OtherSchema1>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.OtherSchema1 value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 1, value.MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.OtherSchema1 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new OtherSchema1ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema1ObjectSegment : global::ZeroFormatter.Tests.OtherSchema1, IZeroFormatterSegment
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public OtherSchema1ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema2Formatter : Formatter<global::ZeroFormatter.Tests.OtherSchema2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.OtherSchema2 value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::ZeroFormatter.Tests.OtherSchema2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new OtherSchema2ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema2ObjectSegment : global::ZeroFormatter.Tests.OtherSchema2, IZeroFormatterSegment
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public OtherSchema2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema3Formatter : Formatter<global::ZeroFormatter.Tests.OtherSchema3>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.OtherSchema3 value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<double>(ref bytes, startOffset, offset, 7, value.MyProperty7);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int?>(ref bytes, startOffset, offset, 8, value.MyProperty8);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 10, value.MyProperty10);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 10);
            }
        }

        public override global::ZeroFormatter.Tests.OtherSchema3 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new OtherSchema3ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema3ObjectSegment : global::ZeroFormatter.Tests.OtherSchema3, IZeroFormatterSegment
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                ObjectSegmentHelper.SetFixedProperty<double>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                ObjectSegmentHelper.SetFixedProperty<int?>(__originalBytes, 8, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 10, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public OtherSchema3ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 10, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (10 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<double>(ref targetBytes, startOffset, offset, 7, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int?>(ref targetBytes, startOffset, offset, 8, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 10, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 10);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class RecMyClassFormatter : Formatter<global::ZeroFormatter.Tests.RecMyClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.RecMyClass value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Hoge);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.Tests.RecMyClass>(ref bytes, startOffset, offset, 1, value.Rec);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.RecMyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new RecMyClassObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class RecMyClassObjectSegment : global::ZeroFormatter.Tests.RecMyClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::ZeroFormatter.Tests.RecMyClass _Rec;

        // 0
        public override int Hoge
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::ZeroFormatter.Tests.RecMyClass Rec
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


        public RecMyClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _Rec = Formatter<global::ZeroFormatter.Tests.RecMyClass>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 1, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.Tests.RecMyClass>(ref targetBytes, startOffset, offset, 1, _Rec);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class KeyTupleCheckFormatter : Formatter<global::ZeroFormatter.Tests.KeyTupleCheck>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.KeyTupleCheck value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>(ref bytes, startOffset, offset, 0, value.KeyTupleDictionary);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::ZeroFormatter.Tests.KeyTupleCheck Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new KeyTupleCheckObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class KeyTupleCheckObjectSegment : global::ZeroFormatter.Tests.KeyTupleCheck, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass> _KeyTupleDictionary;

        // 0
        public override global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass> KeyTupleDictionary
        {
            get
            {
                return _KeyTupleDictionary;
            }
            set
            {
                __tracker.Dirty();
                _KeyTupleDictionary = value;
            }
        }


        public KeyTupleCheckObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _KeyTupleDictionary = Formatter<global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 0, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>(ref targetBytes, startOffset, offset, 0, _KeyTupleDictionary);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class Offset2Formatter : Formatter<global::ZeroFormatter.Tests.Offset2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.Offset2 value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Prop1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.Prop2);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.Offset2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new Offset2ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class Offset2ObjectSegment : global::ZeroFormatter.Tests.Offset2, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _Prop2;

        // 0
        public override int Prop1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string Prop2
        {
            get
            {
                return _Prop2.Value;
            }
            set
            {
                _Prop2.Value = value;
            }
        }


        public Offset2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _Prop2 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _Prop2);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OffsetTypeFormatter : Formatter<global::ZeroFormatter.Tests.OffsetType>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.OffsetType value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Dummy1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.Dummy2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 2, value.VariableSizeList);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 3, value.Dictionary);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.Tests.Offset2>(ref bytes, startOffset, offset, 4, value.ObjectProp);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::ZeroFormatter.Tests.OffsetType Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new OffsetTypeObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OffsetTypeObjectSegment : global::ZeroFormatter.Tests.OffsetType, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _Dummy2;
        global::System.Collections.Generic.IList<string> _VariableSizeList;
        global::System.Collections.Generic.IDictionary<string, int> _Dictionary;
        global::ZeroFormatter.Tests.Offset2 _ObjectProp;

        // 0
        public override int Dummy1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string Dummy2
        {
            get
            {
                return _Dummy2.Value;
            }
            set
            {
                _Dummy2.Value = value;
            }
        }

        // 2
        public override global::System.Collections.Generic.IList<string> VariableSizeList
        {
            get
            {
                return _VariableSizeList;
            }
            set
            {
                __tracker.Dirty();
                _VariableSizeList = value;
            }
        }

        // 3
        public override global::System.Collections.Generic.IDictionary<string, int> Dictionary
        {
            get
            {
                return _Dictionary;
            }
            set
            {
                __tracker.Dirty();
                _Dictionary = value;
            }
        }

        // 4
        public override global::ZeroFormatter.Tests.Offset2 ObjectProp
        {
            get
            {
                return _ObjectProp;
            }
            set
            {
                __tracker.Dirty();
                _ObjectProp = value;
            }
        }


        public OffsetTypeObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _Dummy2 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _VariableSizeList = Formatter<global::System.Collections.Generic.IList<string>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 2, __binaryLastIndex, __tracker), __tracker, out __out);
            _Dictionary = Formatter<global::System.Collections.Generic.IDictionary<string, int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 3, __binaryLastIndex, __tracker), __tracker, out __out);
            _ObjectProp = Formatter<global::ZeroFormatter.Tests.Offset2>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex, __tracker), __tracker, out __out);
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _Dummy2);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 2, _VariableSizeList);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 3, _Dictionary);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.Tests.Offset2>(ref targetBytes, startOffset, offset, 4, _ObjectProp);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class TestBaseFormatter : Formatter<global::ZeroFormatter.Tests.TestBase>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.TestBase value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::ZeroFormatter.Tests.TestBase Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new TestBaseObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class TestBaseObjectSegment : global::ZeroFormatter.Tests.TestBase, IZeroFormatterSegment
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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public TestBaseObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class Test2Formatter : Formatter<global::ZeroFormatter.Tests.Test2>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.Test2 value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 1, value.MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.Test2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new Test2ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class Test2ObjectSegment : global::ZeroFormatter.Tests.Test2, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4 };

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
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int MyProperty1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public Test2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class IncludeStructFormatter : Formatter<global::ZeroFormatter.Tests.IncludeStruct>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.IncludeStruct value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.Tests.MyStructFixed>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.Tests.MyStructVariable>(ref bytes, startOffset, offset, 1, value.MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.IncludeStruct Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new IncludeStructObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class IncludeStructObjectSegment : global::ZeroFormatter.Tests.IncludeStruct, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 16, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<global::ZeroFormatter.Tests.MyStructVariable> _MyProperty1;

        // 0
        public override global::ZeroFormatter.Tests.MyStructFixed MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::ZeroFormatter.Tests.MyStructFixed>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::ZeroFormatter.Tests.MyStructFixed>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::ZeroFormatter.Tests.MyStructVariable MyProperty1
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


        public IncludeStructObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _MyProperty1 = new CacheSegment<global::ZeroFormatter.Tests.MyStructVariable>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
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
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<global::ZeroFormatter.Tests.MyStructFixed>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::ZeroFormatter.Tests.MyStructVariable>(ref targetBytes, startOffset, offset, 1, _MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MyStructFixedFormatter : Formatter<global::ZeroFormatter.Tests.MyStructFixed>
    {
        public override int? GetLength()
        {
            return 16;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyStructFixed value)
        {
            var startOffset = offset;
            offset += Formatter<int>.Default.Serialize(ref bytes, offset, value.MyProperty1);
            offset += Formatter<long>.Default.Serialize(ref bytes, offset, value.MyProperty2);
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.MyProperty3);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyStructFixed Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = Formatter<int>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = Formatter<long>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::ZeroFormatter.Tests.MyStructFixed(item0, item1, item2);
        }
    }

    public class MyStructVariableFormatter : Formatter<global::ZeroFormatter.Tests.MyStructVariable>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyStructVariable value)
        {
            var startOffset = offset;
            offset += Formatter<int>.Default.Serialize(ref bytes, offset, value.MyProperty1);
            offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.MyProperty2);
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.MyProperty3);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyStructVariable Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = Formatter<int>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = Formatter<string>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::ZeroFormatter.Tests.MyStructVariable(item0, item1, item2);
        }
    }

    public class MyVectorFormatter : Formatter<global::ZeroFormatter.Tests.MyVector>
    {
        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyVector value)
        {
            var startOffset = offset;
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.X);
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.Y);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyVector Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::ZeroFormatter.Tests.MyVector(item0, item1);
        }
    }

    public class MyNonVectorFormatter : Formatter<global::ZeroFormatter.Tests.MyNonVector>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyNonVector value)
        {
            var startOffset = offset;
            offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.X);
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.Y);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyNonVector Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = Formatter<string>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::ZeroFormatter.Tests.MyNonVector(item0, item1);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.UnityEngine
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class Vector2Formatter : Formatter<global::UnityEngine.Vector2>
    {
        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector2 value)
        {
            var startOffset = offset;
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.x);
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.y);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::UnityEngine.Vector2(item0, item1);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class MogeMogeFormatter : Formatter<global::Sandbox.Shared.Bar.MogeMoge>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.MogeMoge value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.Bar.MogeMoge Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.Bar.MogeMoge)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableMogeMogeFormatter : Formatter<global::Sandbox.Shared.Bar.MogeMoge?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.MogeMoge? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::Sandbox.Shared.Bar.MogeMoge? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.Bar.MogeMoge)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class MogeMogeEqualityComparer : IEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge>
    {
        public bool Equals(global::Sandbox.Shared.Bar.MogeMoge x, global::Sandbox.Shared.Bar.MogeMoge y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.Bar.MogeMoge x)
        {
            return (int)x;
        }
    }


    public class MogeMoge2Formatter : Formatter<global::Sandbox.Shared.Bar.MogeMoge2>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.MogeMoge2 value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.Bar.MogeMoge2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.Bar.MogeMoge2)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableMogeMoge2Formatter : Formatter<global::Sandbox.Shared.Bar.MogeMoge2?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.MogeMoge2? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::Sandbox.Shared.Bar.MogeMoge2? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.Bar.MogeMoge2)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class MogeMoge2EqualityComparer : IEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge2>
    {
        public bool Equals(global::Sandbox.Shared.Bar.MogeMoge2 x, global::Sandbox.Shared.Bar.MogeMoge2 y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.Bar.MogeMoge2 x)
        {
            return (int)x;
        }
    }


}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class MogeMogeFormatter : Formatter<global::Sandbox.Shared.Foo.MogeMoge>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Foo.MogeMoge value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.Foo.MogeMoge Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.Foo.MogeMoge)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableMogeMogeFormatter : Formatter<global::Sandbox.Shared.Foo.MogeMoge?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Foo.MogeMoge? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::Sandbox.Shared.Foo.MogeMoge? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.Foo.MogeMoge)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class MogeMogeEqualityComparer : IEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge>
    {
        public bool Equals(global::Sandbox.Shared.Foo.MogeMoge x, global::Sandbox.Shared.Foo.MogeMoge y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.Foo.MogeMoge x)
        {
            return (int)x;
        }
    }


    public class MogeMoge2Formatter : Formatter<global::Sandbox.Shared.Foo.MogeMoge2>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Foo.MogeMoge2 value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.Foo.MogeMoge2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.Foo.MogeMoge2)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableMogeMoge2Formatter : Formatter<global::Sandbox.Shared.Foo.MogeMoge2?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Foo.MogeMoge2? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::Sandbox.Shared.Foo.MogeMoge2? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.Foo.MogeMoge2)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class MogeMoge2EqualityComparer : IEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge2>
    {
        public bool Equals(global::Sandbox.Shared.Foo.MogeMoge2 x, global::Sandbox.Shared.Foo.MogeMoge2 y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.Foo.MogeMoge2 x)
        {
            return (int)x;
        }
    }


}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.System
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class TypeCodeFormatter : Formatter<global::System.TypeCode>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::System.TypeCode value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::System.TypeCode Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::System.TypeCode)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableTypeCodeFormatter : Formatter<global::System.TypeCode?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::System.TypeCode? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::System.TypeCode? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::System.TypeCode)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class TypeCodeEqualityComparer : IEqualityComparer<global::System.TypeCode>
    {
        public bool Equals(global::System.TypeCode x, global::System.TypeCode y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::System.TypeCode x)
        {
            return (int)x;
        }
    }


}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class IntEnumFormatter : Formatter<global::ZeroFormatter.Tests.IntEnum>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.IntEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::ZeroFormatter.Tests.IntEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::ZeroFormatter.Tests.IntEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableIntEnumFormatter : Formatter<global::ZeroFormatter.Tests.IntEnum?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.IntEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::ZeroFormatter.Tests.IntEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.IntEnum)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class IntEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.IntEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.IntEnum x, global::ZeroFormatter.Tests.IntEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.IntEnum x)
        {
            return (int)x;
        }
    }


    public class UIntEnumFormatter : Formatter<global::ZeroFormatter.Tests.UIntEnum>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.UIntEnum value)
        {
            return BinaryUtil.WriteUInt32(ref bytes, offset, (UInt32)value);
        }

        public override global::ZeroFormatter.Tests.UIntEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::ZeroFormatter.Tests.UIntEnum)BinaryUtil.ReadUInt32(ref bytes, offset);
        }
    }

    public class NullableUIntEnumFormatter : Formatter<global::ZeroFormatter.Tests.UIntEnum?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.UIntEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt32(ref bytes, offset + 1, (UInt32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::ZeroFormatter.Tests.UIntEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.UIntEnum)BinaryUtil.ReadUInt32(ref bytes, offset + 1);
        }
    }

    public class UIntEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.UIntEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.UIntEnum x, global::ZeroFormatter.Tests.UIntEnum y)
        {
            return (UInt32)x == (UInt32)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.UIntEnum x)
        {
            return (int)(UInt32)x;
        }
    }


    public class ShortEnumFormatter : Formatter<global::ZeroFormatter.Tests.ShortEnum>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ShortEnum value)
        {
            return BinaryUtil.WriteInt16(ref bytes, offset, (Int16)value);
        }

        public override global::ZeroFormatter.Tests.ShortEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            return (global::ZeroFormatter.Tests.ShortEnum)BinaryUtil.ReadInt16(ref bytes, offset);
        }
    }

    public class NullableShortEnumFormatter : Formatter<global::ZeroFormatter.Tests.ShortEnum?>
    {
        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ShortEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt16(ref bytes, offset + 1, (Int16)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override global::ZeroFormatter.Tests.ShortEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 3;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.ShortEnum)BinaryUtil.ReadInt16(ref bytes, offset + 1);
        }
    }

    public class ShortEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.ShortEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.ShortEnum x, global::ZeroFormatter.Tests.ShortEnum y)
        {
            return (Int16)x == (Int16)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.ShortEnum x)
        {
            return (int)((Int16)x) | (int)(Int16)x << 16;
        }
    }


    public class UShortEnumFormatter : Formatter<global::ZeroFormatter.Tests.UShortEnum>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.UShortEnum value)
        {
            return BinaryUtil.WriteUInt16(ref bytes, offset, (UInt16)value);
        }

        public override global::ZeroFormatter.Tests.UShortEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            return (global::ZeroFormatter.Tests.UShortEnum)BinaryUtil.ReadUInt16(ref bytes, offset);
        }
    }

    public class NullableUShortEnumFormatter : Formatter<global::ZeroFormatter.Tests.UShortEnum?>
    {
        public override int? GetLength()
        {
            return 3;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.UShortEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt16(ref bytes, offset + 1, (UInt16)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 3);
            }

            return 3;
        }

        public override global::ZeroFormatter.Tests.UShortEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 3;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.UShortEnum)BinaryUtil.ReadUInt16(ref bytes, offset + 1);
        }
    }

    public class UShortEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.UShortEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.UShortEnum x, global::ZeroFormatter.Tests.UShortEnum y)
        {
            return (UInt16)x == (UInt16)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.UShortEnum x)
        {
            return (int)(UInt16)x;
        }
    }


    public class ByteEnumFormatter : Formatter<global::ZeroFormatter.Tests.ByteEnum>
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ByteEnum value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::ZeroFormatter.Tests.ByteEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::ZeroFormatter.Tests.ByteEnum)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }

    public class NullableByteEnumFormatter : Formatter<global::ZeroFormatter.Tests.ByteEnum?>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ByteEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteByte(ref bytes, offset + 1, (Byte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::ZeroFormatter.Tests.ByteEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.ByteEnum)BinaryUtil.ReadByte(ref bytes, offset + 1);
        }
    }

    public class ByteEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.ByteEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.ByteEnum x, global::ZeroFormatter.Tests.ByteEnum y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.ByteEnum x)
        {
            return (int)(Byte)x;
        }
    }


    public class SByteEnumFormatter : Formatter<global::ZeroFormatter.Tests.SByteEnum>
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.SByteEnum value)
        {
            return BinaryUtil.WriteSByte(ref bytes, offset, (SByte)value);
        }

        public override global::ZeroFormatter.Tests.SByteEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::ZeroFormatter.Tests.SByteEnum)BinaryUtil.ReadSByte(ref bytes, offset);
        }
    }

    public class NullableSByteEnumFormatter : Formatter<global::ZeroFormatter.Tests.SByteEnum?>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.SByteEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteSByte(ref bytes, offset + 1, (SByte)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 2);
            }

            return 2;
        }

        public override global::ZeroFormatter.Tests.SByteEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.SByteEnum)BinaryUtil.ReadSByte(ref bytes, offset + 1);
        }
    }

    public class SByteEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.SByteEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.SByteEnum x, global::ZeroFormatter.Tests.SByteEnum y)
        {
            return (SByte)x == (SByte)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.SByteEnum x)
        {
             return (int)(SByte)x ^ (int)(SByte)x << 8; 
        }
    }


    public class LongEnumFormatter : Formatter<global::ZeroFormatter.Tests.LongEnum>
    {
        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.LongEnum value)
        {
            return BinaryUtil.WriteInt64(ref bytes, offset, (Int64)value);
        }

        public override global::ZeroFormatter.Tests.LongEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 8;
            return (global::ZeroFormatter.Tests.LongEnum)BinaryUtil.ReadInt64(ref bytes, offset);
        }
    }

    public class NullableLongEnumFormatter : Formatter<global::ZeroFormatter.Tests.LongEnum?>
    {
        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.LongEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt64(ref bytes, offset + 1, (Int64)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override global::ZeroFormatter.Tests.LongEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 9;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.LongEnum)BinaryUtil.ReadInt64(ref bytes, offset + 1);
        }
    }

    public class LongEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.LongEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.LongEnum x, global::ZeroFormatter.Tests.LongEnum y)
        {
            return (Int64)x == (Int64)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.LongEnum x)
        {
            return (int)(Int64)x ^ (int)((Int64)x >> 32);
        }
    }


    public class ULongEnumFormatter : Formatter<global::ZeroFormatter.Tests.ULongEnum>
    {
        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ULongEnum value)
        {
            return BinaryUtil.WriteUInt64(ref bytes, offset, (UInt64)value);
        }

        public override global::ZeroFormatter.Tests.ULongEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 8;
            return (global::ZeroFormatter.Tests.ULongEnum)BinaryUtil.ReadUInt64(ref bytes, offset);
        }
    }

    public class NullableULongEnumFormatter : Formatter<global::ZeroFormatter.Tests.ULongEnum?>
    {
        public override int? GetLength()
        {
            return 9;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.ULongEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteUInt64(ref bytes, offset + 1, (UInt64)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 9);
            }

            return 9;
        }

        public override global::ZeroFormatter.Tests.ULongEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 9;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::ZeroFormatter.Tests.ULongEnum)BinaryUtil.ReadUInt64(ref bytes, offset + 1);
        }
    }

    public class ULongEnumEqualityComparer : IEqualityComparer<global::ZeroFormatter.Tests.ULongEnum>
    {
        public bool Equals(global::ZeroFormatter.Tests.ULongEnum x, global::ZeroFormatter.Tests.ULongEnum y)
        {
            return (UInt64)x == (UInt64)y;
        }

        public int GetHashCode(global::ZeroFormatter.Tests.ULongEnum x)
        {
            return (int)(UInt64)x ^ (int)((UInt64)x >> 32);
        }
    }


}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
