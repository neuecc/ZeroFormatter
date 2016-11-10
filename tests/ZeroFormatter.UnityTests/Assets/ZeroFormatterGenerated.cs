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
            ZeroFormatter.Formatters.Formatter<global::DataRoot.DataTypeVersion>.Register(new ZeroFormatter.DynamicObjectSegments.DataTypeVersionFormatter());
            ZeroFormatter.Formatters.Formatter<global::DataRoot.DataTypeVersion?>.Register(new ZeroFormatter.DynamicObjectSegments.NullableDataTypeVersionFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::DataRoot.DataTypeVersion>.Register(new ZeroFormatter.DynamicObjectSegments.DataTypeVersionEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::MyGlobal>.Register(new ZeroFormatter.DynamicObjectSegments.MyGlobalFormatter());
            ZeroFormatter.Formatters.Formatter<global::MyGlobal?>.Register(new ZeroFormatter.DynamicObjectSegments.NullableMyGlobalFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::MyGlobal>.Register(new ZeroFormatter.DynamicObjectSegments.MyGlobalEqualityComparer());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Sex>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.SexFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Sex?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableSexFormatter());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Sex>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.SexEqualityComparer());
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
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.AllNewFormat>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.AllNewFormatFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.CustomFormat>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.CustomFormatFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Person>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.PersonFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.InheritBase>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InheritBaseFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Inherit>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InheritFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.FooBarBaz>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.FooBarBazFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Standard>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.StandardFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Large>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.LargeFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MyClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Bar.MyClass2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MyClass2Formatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MyClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::Sandbox.Shared.Foo.MyClass2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MyClass2Formatter());
            ZeroFormatter.Formatters.Formatter<global::DataRoot>.Register(new ZeroFormatter.DynamicObjectSegments.DataRootFormatter());
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
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.MyVectorClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyVectorClassFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.IncludeStruct>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.IncludeStructFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.LazyFormats>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.LazyFormatsFormatter());
            ZeroFormatter.Formatters.Formatter<global::ZeroFormatter.Tests.FooBar>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.FooBarFormatter());
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
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector3Formatter();
                ZeroFormatter.Formatters.Formatter<global::UnityEngine.Vector3>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<global::UnityEngine.Vector3?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<global::UnityEngine.Vector3>(structFormatter));
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
            ZeroFormatter.Formatters.Formatter.RegisterLazyDictionary<string, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLookup<bool, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLazyLookup<bool, int>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<global::ZeroFormatter.Tests.MyVector>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<global::ZeroFormatter.Tests.MyVectorClass>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<int, global::System.Collections.Generic.List<int>>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<string, global::System.Collections.Generic.HashSet<string>>();
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

    public class AllNewFormatFormatter : Formatter<global::Sandbox.Shared.AllNewFormat>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.AllNewFormat value)
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

                offset += (8 + 4 * (17 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<short[]>(ref bytes, startOffset, offset, 0, value.A1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int[]>(ref bytes, startOffset, offset, 1, value.A2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<long[]>(ref bytes, startOffset, offset, 2, value.A3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<ushort[]>(ref bytes, startOffset, offset, 3, value.A4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<uint[]>(ref bytes, startOffset, offset, 4, value.A5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<ulong[]>(ref bytes, startOffset, offset, 5, value.A6);
                offset += ObjectSegmentHelper.SerializeFromFormatter<float[]>(ref bytes, startOffset, offset, 6, value.A7);
                offset += ObjectSegmentHelper.SerializeFromFormatter<double[]>(ref bytes, startOffset, offset, 7, value.A8);
                offset += ObjectSegmentHelper.SerializeFromFormatter<bool[]>(ref bytes, startOffset, offset, 8, value.A9);
                offset += ObjectSegmentHelper.SerializeFromFormatter<byte[]>(ref bytes, startOffset, offset, 9, value.A10);
                offset += ObjectSegmentHelper.SerializeFromFormatter<sbyte[]>(ref bytes, startOffset, offset, 10, value.A11);
                offset += ObjectSegmentHelper.SerializeFromFormatter<char[]>(ref bytes, startOffset, offset, 11, value.A12);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.Tests.MyVector[]>(ref bytes, startOffset, offset, 12, value.V1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.Tests.MyVectorClass[]>(ref bytes, startOffset, offset, 13, value.V2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.Dictionary<int, string>>(ref bytes, startOffset, offset, 14, value.V3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.List<int>>(ref bytes, startOffset, offset, 15, value.V4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.HashSet<string>>(ref bytes, startOffset, offset, 16, value.V5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.KeyValuePair<int, string>>(ref bytes, startOffset, offset, 17, value.V6);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 17);
            }
        }

        public override global::Sandbox.Shared.AllNewFormat Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new AllNewFormatObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class AllNewFormatObjectSegment : global::Sandbox.Shared.AllNewFormat, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<short[]> _A1;
        readonly CacheSegment<int[]> _A2;
        readonly CacheSegment<long[]> _A3;
        readonly CacheSegment<ushort[]> _A4;
        readonly CacheSegment<uint[]> _A5;
        readonly CacheSegment<ulong[]> _A6;
        readonly CacheSegment<float[]> _A7;
        readonly CacheSegment<double[]> _A8;
        readonly CacheSegment<bool[]> _A9;
        readonly CacheSegment<byte[]> _A10;
        readonly CacheSegment<sbyte[]> _A11;
        readonly CacheSegment<char[]> _A12;
        readonly CacheSegment<global::ZeroFormatter.Tests.MyVector[]> _V1;
        readonly CacheSegment<global::ZeroFormatter.Tests.MyVectorClass[]> _V2;
        readonly CacheSegment<global::System.Collections.Generic.Dictionary<int, string>> _V3;
        readonly CacheSegment<global::System.Collections.Generic.List<int>> _V4;
        readonly CacheSegment<global::System.Collections.Generic.HashSet<string>> _V5;
        readonly CacheSegment<global::System.Collections.Generic.KeyValuePair<int, string>> _V6;

        // 0
        public override short[] A1
        {
            get
            {
                return _A1.Value;
            }
            set
            {
                _A1.Value = value;
            }
        }

        // 1
        public override int[] A2
        {
            get
            {
                return _A2.Value;
            }
            set
            {
                _A2.Value = value;
            }
        }

        // 2
        public override long[] A3
        {
            get
            {
                return _A3.Value;
            }
            set
            {
                _A3.Value = value;
            }
        }

        // 3
        public override ushort[] A4
        {
            get
            {
                return _A4.Value;
            }
            set
            {
                _A4.Value = value;
            }
        }

        // 4
        public override uint[] A5
        {
            get
            {
                return _A5.Value;
            }
            set
            {
                _A5.Value = value;
            }
        }

        // 5
        public override ulong[] A6
        {
            get
            {
                return _A6.Value;
            }
            set
            {
                _A6.Value = value;
            }
        }

        // 6
        public override float[] A7
        {
            get
            {
                return _A7.Value;
            }
            set
            {
                _A7.Value = value;
            }
        }

        // 7
        public override double[] A8
        {
            get
            {
                return _A8.Value;
            }
            set
            {
                _A8.Value = value;
            }
        }

        // 8
        public override bool[] A9
        {
            get
            {
                return _A9.Value;
            }
            set
            {
                _A9.Value = value;
            }
        }

        // 9
        public override byte[] A10
        {
            get
            {
                return _A10.Value;
            }
            set
            {
                _A10.Value = value;
            }
        }

        // 10
        public override sbyte[] A11
        {
            get
            {
                return _A11.Value;
            }
            set
            {
                _A11.Value = value;
            }
        }

        // 11
        public override char[] A12
        {
            get
            {
                return _A12.Value;
            }
            set
            {
                _A12.Value = value;
            }
        }

        // 12
        public override global::ZeroFormatter.Tests.MyVector[] V1
        {
            get
            {
                return _V1.Value;
            }
            set
            {
                _V1.Value = value;
            }
        }

        // 13
        public override global::ZeroFormatter.Tests.MyVectorClass[] V2
        {
            get
            {
                return _V2.Value;
            }
            set
            {
                _V2.Value = value;
            }
        }

        // 14
        public override global::System.Collections.Generic.Dictionary<int, string> V3
        {
            get
            {
                return _V3.Value;
            }
            set
            {
                _V3.Value = value;
            }
        }

        // 15
        public override global::System.Collections.Generic.List<int> V4
        {
            get
            {
                return _V4.Value;
            }
            set
            {
                _V4.Value = value;
            }
        }

        // 16
        public override global::System.Collections.Generic.HashSet<string> V5
        {
            get
            {
                return _V5.Value;
            }
            set
            {
                _V5.Value = value;
            }
        }

        // 17
        public override global::System.Collections.Generic.KeyValuePair<int, string> V6
        {
            get
            {
                return _V6.Value;
            }
            set
            {
                _V6.Value = value;
            }
        }


        public AllNewFormatObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 17, __elementSizes);

            _A1 = new CacheSegment<short[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _A2 = new CacheSegment<int[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _A3 = new CacheSegment<long[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _A4 = new CacheSegment<ushort[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _A5 = new CacheSegment<uint[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _A6 = new CacheSegment<ulong[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _A7 = new CacheSegment<float[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
            _A8 = new CacheSegment<double[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 7, __binaryLastIndex, __tracker));
            _A9 = new CacheSegment<bool[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 8, __binaryLastIndex, __tracker));
            _A10 = new CacheSegment<byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 9, __binaryLastIndex, __tracker));
            _A11 = new CacheSegment<sbyte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 10, __binaryLastIndex, __tracker));
            _A12 = new CacheSegment<char[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 11, __binaryLastIndex, __tracker));
            _V1 = new CacheSegment<global::ZeroFormatter.Tests.MyVector[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 12, __binaryLastIndex, __tracker));
            _V2 = new CacheSegment<global::ZeroFormatter.Tests.MyVectorClass[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 13, __binaryLastIndex, __tracker));
            _V3 = new CacheSegment<global::System.Collections.Generic.Dictionary<int, string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 14, __binaryLastIndex, __tracker));
            _V4 = new CacheSegment<global::System.Collections.Generic.List<int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 15, __binaryLastIndex, __tracker));
            _V5 = new CacheSegment<global::System.Collections.Generic.HashSet<string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 16, __binaryLastIndex, __tracker));
            _V6 = new CacheSegment<global::System.Collections.Generic.KeyValuePair<int, string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 17, __binaryLastIndex, __tracker));
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
                offset += (8 + 4 * (17 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<short[]>(ref targetBytes, startOffset, offset, 0, _A1);
                offset += ObjectSegmentHelper.SerializeCacheSegment<int[]>(ref targetBytes, startOffset, offset, 1, _A2);
                offset += ObjectSegmentHelper.SerializeCacheSegment<long[]>(ref targetBytes, startOffset, offset, 2, _A3);
                offset += ObjectSegmentHelper.SerializeCacheSegment<ushort[]>(ref targetBytes, startOffset, offset, 3, _A4);
                offset += ObjectSegmentHelper.SerializeCacheSegment<uint[]>(ref targetBytes, startOffset, offset, 4, _A5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<ulong[]>(ref targetBytes, startOffset, offset, 5, _A6);
                offset += ObjectSegmentHelper.SerializeCacheSegment<float[]>(ref targetBytes, startOffset, offset, 6, _A7);
                offset += ObjectSegmentHelper.SerializeCacheSegment<double[]>(ref targetBytes, startOffset, offset, 7, _A8);
                offset += ObjectSegmentHelper.SerializeCacheSegment<bool[]>(ref targetBytes, startOffset, offset, 8, _A9);
                offset += ObjectSegmentHelper.SerializeCacheSegment<byte[]>(ref targetBytes, startOffset, offset, 9, _A10);
                offset += ObjectSegmentHelper.SerializeCacheSegment<sbyte[]>(ref targetBytes, startOffset, offset, 10, _A11);
                offset += ObjectSegmentHelper.SerializeCacheSegment<char[]>(ref targetBytes, startOffset, offset, 11, _A12);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::ZeroFormatter.Tests.MyVector[]>(ref targetBytes, startOffset, offset, 12, _V1);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::ZeroFormatter.Tests.MyVectorClass[]>(ref targetBytes, startOffset, offset, 13, _V2);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.Dictionary<int, string>>(ref targetBytes, startOffset, offset, 14, _V3);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.List<int>>(ref targetBytes, startOffset, offset, 15, _V4);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.HashSet<string>>(ref targetBytes, startOffset, offset, 16, _V5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.KeyValuePair<int, string>>(ref targetBytes, startOffset, offset, 17, _V6);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 17);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class CustomFormatFormatter : Formatter<global::Sandbox.Shared.CustomFormat>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.CustomFormat value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Guid>(ref bytes, startOffset, offset, 0, value.AllowGuid);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.CustomFormat Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new CustomFormatObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class CustomFormatObjectSegment : global::Sandbox.Shared.CustomFormat, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<global::System.Guid> _AllowGuid;

        // 0
        public override global::System.Guid AllowGuid
        {
            get
            {
                return _AllowGuid.Value;
            }
            set
            {
                _AllowGuid.Value = value;
            }
        }


        public CustomFormatObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _AllowGuid = new CacheSegment<global::System.Guid>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Guid>(ref targetBytes, startOffset, offset, 0, _AllowGuid);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class PersonFormatter : Formatter<global::Sandbox.Shared.Person>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Person value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Sandbox.Shared.Sex>(ref bytes, startOffset, offset, 3, value.Sex);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Sandbox.Shared.Person Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new PersonObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class PersonObjectSegment : global::Sandbox.Shared.Person, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _FirstName;
        readonly CacheSegment<string> _LastName;

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
        public override global::Sandbox.Shared.Sex Sex
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::Sandbox.Shared.Sex>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::Sandbox.Shared.Sex>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public PersonObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
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
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _LastName);
                offset += ObjectSegmentHelper.SerializeFixedLength<global::Sandbox.Shared.Sex>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _HugaHuga = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<byte[]>>(originalBytes, 0, __binaryLastIndex, __tracker);
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

                offset += (8 + 4 * (20 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<long>(ref bytes, startOffset, offset, 5, value.MyProperty5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<string>(ref bytes, startOffset, offset, 7, value.MyProperty6);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 10, value.MyProperty10);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 11, value.MyProperty11);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 13, value.MyProperty13);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 15, value.MyProperty15);
                offset += ObjectSegmentHelper.SerializeFromFormatter<int>(ref bytes, startOffset, offset, 20, value.MyProperty20);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 20);
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
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<string> _MyProperty6;
        global::System.Collections.Generic.IList<int> _MyProperty10;
        readonly CacheSegment<global::System.Linq.ILookup<bool, int>> _MyProperty11;
        global::System.Collections.Generic.IList<string> _MyProperty13;
        readonly CacheSegment<global::System.Collections.Generic.IDictionary<string, int>> _MyProperty15;

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

        // 7
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

        // 10
        public override global::System.Collections.Generic.IList<int> MyProperty10
        {
            get
            {
                return _MyProperty10;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty10 = value;
            }
        }

        // 11
        public override global::System.Linq.ILookup<bool, int> MyProperty11
        {
            get
            {
                return _MyProperty11.Value;
            }
            set
            {
                _MyProperty11.Value = value;
            }
        }

        // 13
        public override global::System.Collections.Generic.IList<string> MyProperty13
        {
            get
            {
                return _MyProperty13;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty13 = value;
            }
        }

        // 15
        public override global::System.Collections.Generic.IDictionary<string, int> MyProperty15
        {
            get
            {
                return _MyProperty15.Value;
            }
            set
            {
                _MyProperty15.Value = value;
            }
        }

        // 20
        public override int MyProperty20
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 20, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 20, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public LargeObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 20, __elementSizes);

            _MyProperty6 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 7, __binaryLastIndex, __tracker));
            _MyProperty10 = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<int>>(originalBytes, 10, __binaryLastIndex, __tracker);
            _MyProperty11 = new CacheSegment<global::System.Linq.ILookup<bool, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 11, __binaryLastIndex, __tracker));
            _MyProperty13 = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<string>>(originalBytes, 13, __binaryLastIndex, __tracker);
            _MyProperty15 = new CacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 15, __binaryLastIndex, __tracker));
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
                offset += (8 + 4 * (20 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<long>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 7, _MyProperty6);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 10, _MyProperty10);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 11, _MyProperty11);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 13, _MyProperty13);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 15, _MyProperty15);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 20, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 20);
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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class DataRootFormatter : Formatter<global::DataRoot>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::DataRoot value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::DataRoot.DataTypeVersion>(ref bytes, startOffset, offset, 0, value.DataType);
                offset += ObjectSegmentHelper.SerializeFromFormatter<byte[]>(ref bytes, startOffset, offset, 1, value.Data);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::MyGlobal>(ref bytes, startOffset, offset, 2, value.GB);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::DataRoot Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new DataRootObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class DataRootObjectSegment : global::DataRoot, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<byte[]> _Data;

        // 0
        public override global::DataRoot.DataTypeVersion DataType
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::DataRoot.DataTypeVersion>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::DataRoot.DataTypeVersion>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override byte[] Data
        {
            get
            {
                return _Data.Value;
            }
            set
            {
                _Data.Value = value;
            }
        }

        // 2
        public override global::MyGlobal GB
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<global::MyGlobal>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<global::MyGlobal>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public DataRootObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _Data = new CacheSegment<byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeFixedLength<global::DataRoot.DataTypeVersion>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<byte[]>(ref targetBytes, startOffset, offset, 1, _Data);
                offset += ObjectSegmentHelper.SerializeFixedLength<global::MyGlobal>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
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

        readonly CacheSegment<global::System.Collections.Generic.IDictionary<int, string>> _MyProperty1;
        global::System.Collections.Generic.IList<int> _MyProperty2;
        global::System.Collections.Generic.IList<string> _MyProperty3;
        readonly CacheSegment<global::System.Linq.ILookup<bool, int>> _MyProperty4;
        global::ZeroFormatter.Tests.MyFormatClass _MyProperty5;
        readonly CacheSegment<byte[]> _MyProperty6;
        readonly CacheSegment<string> _MyProperty7;
        readonly CacheSegment<global::System.Collections.Generic.IDictionary<string, int>> _MyProperty8;

        // 0
        public override global::System.Collections.Generic.IDictionary<int, string> MyProperty1
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
                return _MyProperty4.Value;
            }
            set
            {
                _MyProperty4.Value = value;
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
                return _MyProperty8.Value;
            }
            set
            {
                _MyProperty8.Value = value;
            }
        }


        public AllNullClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 7, __elementSizes);

            _MyProperty1 = new CacheSegment<global::System.Collections.Generic.IDictionary<int, string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _MyProperty2 = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<int>>(originalBytes, 1, __binaryLastIndex, __tracker);
            _MyProperty3 = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<string>>(originalBytes, 2, __binaryLastIndex, __tracker);
            _MyProperty4 = new CacheSegment<global::System.Linq.ILookup<bool, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _MyProperty5 = ObjectSegmentHelper.DeserializeSegment<global::ZeroFormatter.Tests.MyFormatClass>(originalBytes, 4, __binaryLastIndex, __tracker);
            _MyProperty6 = new CacheSegment<byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _MyProperty7 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
            _MyProperty8 = new CacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 7, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.IDictionary<int, string>>(ref targetBytes, startOffset, offset, 0, _MyProperty1);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 1, _MyProperty2);
                offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 2, _MyProperty3);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 3, _MyProperty4);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.Tests.MyFormatClass>(ref targetBytes, startOffset, offset, 4, _MyProperty5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<byte[]>(ref targetBytes, startOffset, offset, 5, _MyProperty6);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 6, _MyProperty7);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 7, _MyProperty8);

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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _MyList = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<int>>(originalBytes, 4, __binaryLastIndex, __tracker);
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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _MyProperty4 = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<int>>(originalBytes, 4, __binaryLastIndex, __tracker);
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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _Rec = ObjectSegmentHelper.DeserializeSegment<global::ZeroFormatter.Tests.RecMyClass>(originalBytes, 1, __binaryLastIndex, __tracker);
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

        readonly CacheSegment<global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>> _KeyTupleDictionary;

        // 0
        public override global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass> KeyTupleDictionary
        {
            get
            {
                return _KeyTupleDictionary.Value;
            }
            set
            {
                _KeyTupleDictionary.Value = value;
            }
        }


        public KeyTupleCheckObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _KeyTupleDictionary = new CacheSegment<global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>(ref targetBytes, startOffset, offset, 0, _KeyTupleDictionary);

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
        readonly CacheSegment<global::System.Collections.Generic.IDictionary<string, int>> _Dictionary;
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
                return _Dictionary.Value;
            }
            set
            {
                _Dictionary.Value = value;
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

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _Dummy2 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _VariableSizeList = ObjectSegmentHelper.DeserializeSegment<global::System.Collections.Generic.IList<string>>(originalBytes, 2, __binaryLastIndex, __tracker);
            _Dictionary = new CacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _ObjectProp = ObjectSegmentHelper.DeserializeSegment<global::ZeroFormatter.Tests.Offset2>(originalBytes, 4, __binaryLastIndex, __tracker);
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
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 3, _Dictionary);
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

    public class MyVectorClassFormatter : Formatter<global::ZeroFormatter.Tests.MyVectorClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyVectorClass value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<float>(ref bytes, startOffset, offset, 0, value.X);
                offset += ObjectSegmentHelper.SerializeFromFormatter<float>(ref bytes, startOffset, offset, 1, value.Y);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.MyVectorClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyVectorClassObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyVectorClassObjectSegment : global::ZeroFormatter.Tests.MyVectorClass, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override float X
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override float Y
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyVectorClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

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

                offset += ObjectSegmentHelper.SerializeFixedLength<float>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<float>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

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

    public class LazyFormatsFormatter : Formatter<global::ZeroFormatter.Tests.LazyFormats>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.LazyFormats value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 0, value.D0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.ILazyDictionary<string, int>>(ref bytes, startOffset, offset, 1, value.D1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 2, value.D2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::ZeroFormatter.ILazyLookup<bool, int>>(ref bytes, startOffset, offset, 3, value.D3);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::ZeroFormatter.Tests.LazyFormats Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LazyFormatsObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LazyFormatsObjectSegment : global::ZeroFormatter.Tests.LazyFormats, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        readonly CacheSegment<global::System.Collections.Generic.IDictionary<string, int>> _D0;
        global::ZeroFormatter.ILazyDictionary<string, int> _D1;
        readonly CacheSegment<global::System.Linq.ILookup<bool, int>> _D2;
        global::ZeroFormatter.ILazyLookup<bool, int> _D3;

        // 0
        public override global::System.Collections.Generic.IDictionary<string, int> D0
        {
            get
            {
                return _D0.Value;
            }
            set
            {
                _D0.Value = value;
            }
        }

        // 1
        public override global::ZeroFormatter.ILazyDictionary<string, int> D1
        {
            get
            {
                return _D1;
            }
            set
            {
                __tracker.Dirty();
                _D1 = value;
            }
        }

        // 2
        public override global::System.Linq.ILookup<bool, int> D2
        {
            get
            {
                return _D2.Value;
            }
            set
            {
                _D2.Value = value;
            }
        }

        // 3
        public override global::ZeroFormatter.ILazyLookup<bool, int> D3
        {
            get
            {
                return _D3;
            }
            set
            {
                __tracker.Dirty();
                _D3 = value;
            }
        }


        public LazyFormatsObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _D0 = new CacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _D1 = ObjectSegmentHelper.DeserializeSegment<global::ZeroFormatter.ILazyDictionary<string, int>>(originalBytes, 1, __binaryLastIndex, __tracker);
            _D2 = new CacheSegment<global::System.Linq.ILookup<bool, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _D3 = ObjectSegmentHelper.DeserializeSegment<global::ZeroFormatter.ILazyLookup<bool, int>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 0, _D0);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.ILazyDictionary<string, int>>(ref targetBytes, startOffset, offset, 1, _D1);
                offset += ObjectSegmentHelper.SerializeCacheSegment<global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 2, _D2);
                offset += ObjectSegmentHelper.SerializeSegment<global::ZeroFormatter.ILazyLookup<bool, int>>(ref targetBytes, startOffset, offset, 3, _D3);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class FooBarFormatter : Formatter<global::ZeroFormatter.Tests.FooBar>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.FooBar value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Sandbox.Shared.Foo.MyClass>(ref bytes, startOffset, offset, 0, value.FooMyClass);
                offset += ObjectSegmentHelper.SerializeFromFormatter<global::Sandbox.Shared.Bar.MyClass>(ref bytes, startOffset, offset, 1, value.BarMyClass);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.FooBar Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new FooBarObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class FooBarObjectSegment : global::ZeroFormatter.Tests.FooBar, IZeroFormatterSegment
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::Sandbox.Shared.Foo.MyClass _FooMyClass;
        global::Sandbox.Shared.Bar.MyClass _BarMyClass;

        // 0
        public override global::Sandbox.Shared.Foo.MyClass FooMyClass
        {
            get
            {
                return _FooMyClass;
            }
            set
            {
                __tracker.Dirty();
                _FooMyClass = value;
            }
        }

        // 1
        public override global::Sandbox.Shared.Bar.MyClass BarMyClass
        {
            get
            {
                return _BarMyClass;
            }
            set
            {
                __tracker.Dirty();
                _BarMyClass = value;
            }
        }


        public FooBarObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _FooMyClass = ObjectSegmentHelper.DeserializeSegment<global::Sandbox.Shared.Foo.MyClass>(originalBytes, 0, __binaryLastIndex, __tracker);
            _BarMyClass = ObjectSegmentHelper.DeserializeSegment<global::Sandbox.Shared.Bar.MyClass>(originalBytes, 1, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeSegment<global::Sandbox.Shared.Foo.MyClass>(ref targetBytes, startOffset, offset, 0, _FooMyClass);
                offset += ObjectSegmentHelper.SerializeSegment<global::Sandbox.Shared.Bar.MyClass>(ref targetBytes, startOffset, offset, 1, _BarMyClass);

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

    public class Vector3Formatter : Formatter<global::UnityEngine.Vector3>
    {
        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector3 value)
        {
            var startOffset = offset;
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.x);
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.y);
            offset += Formatter<float>.Default.Serialize(ref bytes, offset, value.z);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector3 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = Formatter<float>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::UnityEngine.Vector3(item0, item1, item2);
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
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class DataTypeVersionFormatter : Formatter<global::DataRoot.DataTypeVersion>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::DataRoot.DataTypeVersion value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::DataRoot.DataTypeVersion Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::DataRoot.DataTypeVersion)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableDataTypeVersionFormatter : Formatter<global::DataRoot.DataTypeVersion?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::DataRoot.DataTypeVersion? value)
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

        public override global::DataRoot.DataTypeVersion? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::DataRoot.DataTypeVersion)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class DataTypeVersionEqualityComparer : IEqualityComparer<global::DataRoot.DataTypeVersion>
    {
        public bool Equals(global::DataRoot.DataTypeVersion x, global::DataRoot.DataTypeVersion y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::DataRoot.DataTypeVersion x)
        {
            return (int)x;
        }
    }


    public class MyGlobalFormatter : Formatter<global::MyGlobal>
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MyGlobal value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::MyGlobal Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::MyGlobal)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableMyGlobalFormatter : Formatter<global::MyGlobal?>
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::MyGlobal? value)
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

        public override global::MyGlobal? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::MyGlobal)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }

    public class MyGlobalEqualityComparer : IEqualityComparer<global::MyGlobal>
    {
        public bool Equals(global::MyGlobal x, global::MyGlobal y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::MyGlobal x)
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
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class SexFormatter : Formatter<global::Sandbox.Shared.Sex>
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Sex value)
        {
            return BinaryUtil.WriteSByte(ref bytes, offset, (SByte)value);
        }

        public override global::Sandbox.Shared.Sex Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::Sandbox.Shared.Sex)BinaryUtil.ReadSByte(ref bytes, offset);
        }
    }

    public class NullableSexFormatter : Formatter<global::Sandbox.Shared.Sex?>
    {
        public override int? GetLength()
        {
            return 2;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Sex? value)
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

        public override global::Sandbox.Shared.Sex? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 2;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.Sex)BinaryUtil.ReadSByte(ref bytes, offset + 1);
        }
    }

    public class SexEqualityComparer : IEqualityComparer<global::Sandbox.Shared.Sex>
    {
        public bool Equals(global::Sandbox.Shared.Sex x, global::Sandbox.Shared.Sex y)
        {
            return (SByte)x == (SByte)y;
        }

        public int GetHashCode(global::Sandbox.Shared.Sex x)
        {
             return (int)(SByte)x ^ (int)(SByte)x << 8; 
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
