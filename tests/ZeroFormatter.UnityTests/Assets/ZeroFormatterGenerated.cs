#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter
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
        static bool registered = false;

        public static void Register()
        {
            if(registered) return;
            registered = true;

            // Enums
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::DataRoot.DataTypeVersion>.Register(new ZeroFormatter.DynamicObjectSegments.DataRoot_DataTypeVersionFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::DataRoot.DataTypeVersion>.Register(new ZeroFormatter.DynamicObjectSegments.DataRoot_DataTypeVersionEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::DataRoot.DataTypeVersion?>.Register(new ZeroFormatter.DynamicObjectSegments.NullableDataRoot_DataTypeVersionFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::DataRoot.DataTypeVersion?>.Register(new NullableEqualityComparer<global::DataRoot.DataTypeVersion>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::MyGlobal>.Register(new ZeroFormatter.DynamicObjectSegments.MyGlobalFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::MyGlobal>.Register(new ZeroFormatter.DynamicObjectSegments.MyGlobalEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::MyGlobal?>.Register(new ZeroFormatter.DynamicObjectSegments.NullableMyGlobalFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::MyGlobal?>.Register(new NullableEqualityComparer<global::MyGlobal>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.StandardEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.StandardEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.StandardEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.StandardEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.StandardEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableStandardEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.StandardEnum?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.StandardEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InnerClassA.InnerEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InnerClassA_InnerEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.InnerClassA.InnerEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InnerClassA_InnerEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InnerClassA.InnerEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableInnerClassA_InnerEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.InnerClassA.InnerEnum?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.InnerClassA.InnerEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InnerClassB.InnerEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InnerClassB_InnerEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.InnerClassB.InnerEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InnerClassB_InnerEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InnerClassB.InnerEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableInnerClassB_InnerEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.InnerClassB.InnerEnum?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.InnerClassB.InnerEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.OutSideEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.OutSideEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.OutSideEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.OutSideEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.OutSideEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableOutSideEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.OutSideEnum?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.OutSideEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InsideEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InsideEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.InsideEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InsideEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InsideEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableInsideEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.InsideEnum?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.InsideEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Sex>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.SexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Sex>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.SexEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Sex?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableSexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Sex?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.Sex>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.CharacterType>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.CharacterTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.CharacterType>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.CharacterTypeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.CharacterType?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.NullableCharacterTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.CharacterType?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.CharacterType>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMogeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMogeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.MogeMoge?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.NullableMogeMogeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMoge2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MogeMoge2EqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.MogeMoge2?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.NullableMogeMoge2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge2?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.Bar.MogeMoge2>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Foo.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMogeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMogeEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Foo.MogeMoge?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.NullableMogeMogeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Foo.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMoge2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MogeMoge2EqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Foo.MogeMoge2?>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.NullableMogeMoge2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge2?>.Register(new NullableEqualityComparer<global::Sandbox.Shared.Foo.MogeMoge2>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::System.TypeCode>.Register(new ZeroFormatter.DynamicObjectSegments.System.TypeCodeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::System.TypeCode>.Register(new ZeroFormatter.DynamicObjectSegments.System.TypeCodeEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.IntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.IntEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.IntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.IntEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.IntEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableIntEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.IntEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.IntEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.UIntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UIntEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.UIntEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UIntEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.UIntEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableUIntEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.UIntEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.UIntEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.ShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ShortEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ShortEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.ShortEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableShortEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ShortEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.ShortEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.UShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UShortEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.UShortEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.UShortEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.UShortEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableUShortEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.UShortEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.UShortEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.ByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ByteEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ByteEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.ByteEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableByteEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ByteEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.ByteEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.SByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.SByteEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.SByteEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.SByteEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.SByteEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableSByteEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.SByteEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.SByteEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.LongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.LongEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.LongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.LongEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.LongEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableLongEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.LongEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.LongEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.ULongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ULongEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ULongEnum>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.ULongEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.ULongEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableULongEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ZeroFormatter.Tests.ULongEnum?>.Register(new NullableEqualityComparer<global::ZeroFormatter.Tests.ULongEnum>());
            
            // Objects
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyVectorClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyVectorClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyFormatClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyFormatClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.AllNullClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.AllNullClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.SkipIndex>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.SkipIndexFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.OtherSchema1>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OtherSchema1Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.OtherSchema2>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OtherSchema2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.OtherSchema3>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OtherSchema3Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.RecMyClass>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.RecMyClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.KeyTupleCheck>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.KeyTupleCheckFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.Offset2>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.Offset2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.OffsetType>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.OffsetTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.TestBase>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.TestBaseFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.Test2>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.Test2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.IncludeStruct>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.IncludeStructFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.LazyFormats>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.LazyFormatsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.FooBar>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.FooBarFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.NullableLazy>.Register(new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.NullableLazyFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.AllNewFormat>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.AllNewFormatFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.CustomFormat>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.CustomFormatFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.SequenceFormat>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.SequenceFormatFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.EnumGenChecker>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.EnumGenCheckerFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InnerClassA.InnerObject>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InnerClassA_InnerObjectFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InnerClassB.InnerObject>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InnerClassB_InnerObjectFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Person>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.PersonFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.InheritBase>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InheritBaseFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Inherit>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.InheritFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.FooBarBaz>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.FooBarBazFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Human>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.HumanFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Monster>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.MonsterFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.HasUnionKlass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.HasUnionKlassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.UnknownMessage1>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.UnknownMessage1Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.MessageA1>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.MessageA1Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.MessageB1>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.MessageB1Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.MessageA>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.MessageAFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.MessageB>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.MessageBFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.UnknownEvent>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.UnknownEventFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.EventA>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.EventAFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.EventB>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.EventBFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Standard>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.StandardFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Large>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.LargeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.ZeroClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.ZeroClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.DameClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.DameClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.StaticProperty>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.StaticPropertyFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MyClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.MyClass2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.MyClass2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Foo.MyClass>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MyClassFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Foo.MyClass2>.Register(new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Foo.MyClass2Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::DataRoot>.Register(new ZeroFormatter.DynamicObjectSegments.DataRootFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            // Structs
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyVectorFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyVector>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyVector?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyVector>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyStructFixedFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyStructFixed>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyStructFixed?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyStructFixed>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyStructVariableFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyStructVariable>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyStructVariable?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyStructVariable>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.ZeroFormatter.Tests.MyNonVectorFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyNonVector>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyNonVector?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyNonVector>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar.GetOnlyFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.GetOnly>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.GetOnly?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.GetOnly>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector2Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector2>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.UnityEngine.Vector3Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::UnityEngine.Vector3>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.ZeroStructFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.ZeroStruct>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.ZeroStruct?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.ZeroStruct>(structFormatter));
            }
            // Unions
            {
                var unionFormatter = new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.CharacterFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Character>.Register(unionFormatter);
            }
            {
                var unionFormatter = new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Union2Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Union2>.Register(unionFormatter);
            }
            {
                var unionFormatter = new ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.IStandardUnionFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.IStandardUnion>.Register(unionFormatter);
            }
            // Generics
            ZeroFormatter.Formatters.Formatter.RegisterKeyTuple<ZeroFormatter.Formatters.DefaultResolver, int, global::Sandbox.Shared.StandardEnum, string>();
            ZeroFormatter.Formatters.Formatter.RegisterKeyTuple<ZeroFormatter.Formatters.DefaultResolver, int, string>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, byte[]>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.MogeMoge>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Foo.MogeMoge>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.IEvent>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, int>();
            ZeroFormatter.Formatters.Formatter.RegisterList<ZeroFormatter.Formatters.DefaultResolver, string>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, int, int>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, int, string>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, string, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLazyDictionary<ZeroFormatter.Formatters.DefaultResolver, int?, string>();
            ZeroFormatter.Formatters.Formatter.RegisterLazyDictionary<ZeroFormatter.Formatters.DefaultResolver, string, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLookup<ZeroFormatter.Formatters.DefaultResolver, bool, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLazyLookup<ZeroFormatter.Formatters.DefaultResolver, bool, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLazyLookup<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.KeyTuple<int, global::Sandbox.Shared.StandardEnum, string>, int>();
            ZeroFormatter.Formatters.Formatter.RegisterLazyLookup<ZeroFormatter.Formatters.DefaultResolver, int?, string>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::Sandbox.Shared.Bar.DameClass>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyStructFixed>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyVector>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::ZeroFormatter.Tests.MyVectorClass>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, int, global::System.Collections.Generic.List<int>>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, string, global::System.Collections.Generic.HashSet<string>>();
            ZeroFormatter.Formatters.Formatter.RegisterInterfaceCollection<ZeroFormatter.Formatters.DefaultResolver, int>();
            ZeroFormatter.Formatters.Formatter.RegisterEnumerable<ZeroFormatter.Formatters.DefaultResolver, int>();
            ZeroFormatter.Formatters.Formatter.RegisterReadOnlyCollection<ZeroFormatter.Formatters.DefaultResolver, int>();
            ZeroFormatter.Formatters.Formatter.RegisterKeyValuePair<ZeroFormatter.Formatters.DefaultResolver, int, string>();
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

    public class MyVectorClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.MyVectorClass>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 0, value.X);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 1, value.Y);

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
            return new MyVectorClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyVectorClassObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.MyVectorClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override float Y
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyFormatClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.MyFormatClass>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty);

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
            return new MyFormatClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyFormatClassObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.MyFormatClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class AllNullClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.AllNullClass>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IDictionary<int, string>>(ref bytes, startOffset, offset, 0, value.MyProperty1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 1, value.MyProperty2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 2, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 3, value.MyProperty4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.MyFormatClass>(ref bytes, startOffset, offset, 4, value.MyProperty5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte[]>(ref bytes, startOffset, offset, 5, value.MyProperty6);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 6, value.MyProperty7);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 7, value.MyProperty8);

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
            return new AllNullClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class AllNullClassObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.AllNullClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<int, string>> _MyProperty1;
        global::System.Collections.Generic.IList<int> _MyProperty2;
        global::System.Collections.Generic.IList<string> _MyProperty3;
        CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>> _MyProperty4;
        global::ZeroFormatter.Tests.MyFormatClass _MyProperty5;
        CacheSegment<TTypeResolver, byte[]> _MyProperty6;
        CacheSegment<TTypeResolver, string> _MyProperty7;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>> _MyProperty8;

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

            _MyProperty1 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<int, string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _MyProperty2 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(originalBytes, 1, __binaryLastIndex, __tracker);
            _MyProperty3 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<string>>(originalBytes, 2, __binaryLastIndex, __tracker);
            _MyProperty4 = new CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _MyProperty5 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.Tests.MyFormatClass>(originalBytes, 4, __binaryLastIndex, __tracker);
            _MyProperty6 = new CacheSegment<TTypeResolver, byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _MyProperty7 = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
            _MyProperty8 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 7, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<int, string>>(ref targetBytes, startOffset, offset, 0, ref _MyProperty1);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 1, _MyProperty2);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 2, _MyProperty3);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 3, ref _MyProperty4);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.Tests.MyFormatClass>(ref targetBytes, startOffset, offset, 4, _MyProperty5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, byte[]>(ref targetBytes, startOffset, offset, 5, ref _MyProperty6);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 6, ref _MyProperty7);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 7, ref _MyProperty8);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 7);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.MyClass>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.HogeMoge);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 4, value.MyList);

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
            return new MyClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClassObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.MyClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _FirstName;
        CacheSegment<TTypeResolver, string> _LastName;
        global::System.Collections.Generic.IList<int> _MyList;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            protected set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

            _FirstName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _MyList = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(originalBytes, 4, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _LastName);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 4, _MyList);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SkipIndexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.SkipIndex>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.MyProperty1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.MyProperty2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 4, value.MyProperty4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 5, value.MyProperty5);

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
            return new SkipIndexObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SkipIndexObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.SkipIndex, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 4, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IList<int> _MyProperty4;
        CacheSegment<TTypeResolver, string> _MyProperty5;

        // 1
        public override int MyProperty1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int MyProperty2
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

            _MyProperty4 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(originalBytes, 4, __binaryLastIndex, __tracker);
            _MyProperty5 = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 4, _MyProperty4);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 5, ref _MyProperty5);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema1Formatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.OtherSchema1>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.MyProperty1);

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
            return new OtherSchema1ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema1ObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.OtherSchema1, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.OtherSchema2>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.MyProperty3);

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
            return new OtherSchema2ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema2ObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.OtherSchema2, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OtherSchema3Formatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.OtherSchema3>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, double>(ref bytes, startOffset, offset, 7, value.MyProperty7);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int?>(ref bytes, startOffset, offset, 8, value.MyProperty8);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 10, value.MyProperty10);

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
            return new OtherSchema3ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OtherSchema3ObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.OtherSchema3, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 7
        public override double MyProperty7
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, double>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, double>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 8
        public override int? MyProperty8
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int?>(__originalBytes, 8, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int?>(__originalBytes, 8, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 10
        public override int MyProperty10
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 10, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 10, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, double>(ref targetBytes, startOffset, offset, 7, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int?>(ref targetBytes, startOffset, offset, 8, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 10, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 10);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class RecMyClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.RecMyClass>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Hoge);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.RecMyClass>(ref bytes, startOffset, offset, 1, value.Rec);

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
            return new RecMyClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class RecMyClassObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.RecMyClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

            _Rec = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.Tests.RecMyClass>(originalBytes, 1, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.Tests.RecMyClass>(ref targetBytes, startOffset, offset, 1, _Rec);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class KeyTupleCheckFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.KeyTupleCheck>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>(ref bytes, startOffset, offset, 0, value.KeyTupleDictionary);

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
            return new KeyTupleCheckObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class KeyTupleCheckObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.KeyTupleCheck, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>> _KeyTupleDictionary;

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

            _KeyTupleDictionary = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<global::ZeroFormatter.KeyTuple<int, string>, global::ZeroFormatter.Tests.MyClass>>(ref targetBytes, startOffset, offset, 0, ref _KeyTupleDictionary);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class Offset2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.Offset2>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Prop1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.Prop2);

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
            return new Offset2ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class Offset2ObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.Offset2, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Prop2;

        // 0
        public override int Prop1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

            _Prop2 = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _Prop2);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class OffsetTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.OffsetType>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Dummy1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.Dummy2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 2, value.VariableSizeList);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 3, value.Dictionary);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.Offset2>(ref bytes, startOffset, offset, 4, value.ObjectProp);

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
            return new OffsetTypeObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class OffsetTypeObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.OffsetType, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Dummy2;
        global::System.Collections.Generic.IList<string> _VariableSizeList;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>> _Dictionary;
        global::ZeroFormatter.Tests.Offset2 _ObjectProp;

        // 0
        public override int Dummy1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

            _Dummy2 = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _VariableSizeList = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<string>>(originalBytes, 2, __binaryLastIndex, __tracker);
            _Dictionary = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _ObjectProp = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.Tests.Offset2>(originalBytes, 4, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _Dummy2);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 2, _VariableSizeList);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 3, ref _Dictionary);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.Tests.Offset2>(ref targetBytes, startOffset, offset, 4, _ObjectProp);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class TestBaseFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.TestBase>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty);

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
            return new TestBaseObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class TestBaseObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.TestBase, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class Test2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.Test2>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.MyProperty1);

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
            return new Test2ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class Test2ObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.Test2, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int MyProperty1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class IncludeStructFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.IncludeStruct>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.MyStructVariable>(ref bytes, startOffset, offset, 1, value.MyProperty1);

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
            return new IncludeStructObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class IncludeStructObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.IncludeStruct, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 16, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyStructVariable> _MyProperty1;

        // 0
        public override global::ZeroFormatter.Tests.MyStructFixed MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

            _MyProperty1 = new CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyStructVariable>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyStructVariable>(ref targetBytes, startOffset, offset, 1, ref _MyProperty1);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LazyFormatsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.LazyFormats>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 0, value.D0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.ILazyDictionary<string, int>>(ref bytes, startOffset, offset, 1, value.D1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 2, value.D2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.ILazyLookup<bool, int>>(ref bytes, startOffset, offset, 3, value.D3);

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
            return new LazyFormatsObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LazyFormatsObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.LazyFormats, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>> _D0;
        global::ZeroFormatter.ILazyDictionary<string, int> _D1;
        CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>> _D2;
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

            _D0 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _D1 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.ILazyDictionary<string, int>>(originalBytes, 1, __binaryLastIndex, __tracker);
            _D2 = new CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _D3 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.ILazyLookup<bool, int>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 0, ref _D0);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.ILazyDictionary<string, int>>(ref targetBytes, startOffset, offset, 1, _D1);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 2, ref _D2);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.ILazyLookup<bool, int>>(ref targetBytes, startOffset, offset, 3, _D3);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class FooBarFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.FooBar>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Foo.MyClass>(ref bytes, startOffset, offset, 0, value.FooMyClass);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Bar.MyClass>(ref bytes, startOffset, offset, 1, value.BarMyClass);

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
            return new FooBarObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class FooBarObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.FooBar, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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

            _FooMyClass = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Sandbox.Shared.Foo.MyClass>(originalBytes, 0, __binaryLastIndex, __tracker);
            _BarMyClass = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::Sandbox.Shared.Bar.MyClass>(originalBytes, 1, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Sandbox.Shared.Foo.MyClass>(ref targetBytes, startOffset, offset, 0, _FooMyClass);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::Sandbox.Shared.Bar.MyClass>(ref targetBytes, startOffset, offset, 1, _BarMyClass);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class NullableLazyFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.NullableLazy>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.NullableLazy value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.ILazyDictionary<int?, string>>(ref bytes, startOffset, offset, 0, value.A);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.ILazyLookup<int?, string>>(ref bytes, startOffset, offset, 1, value.B);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::ZeroFormatter.Tests.NullableLazy Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new NullableLazyObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class NullableLazyObjectSegment<TTypeResolver> : global::ZeroFormatter.Tests.NullableLazy, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::ZeroFormatter.ILazyDictionary<int?, string> _A;
        global::ZeroFormatter.ILazyLookup<int?, string> _B;

        // 0
        public override global::ZeroFormatter.ILazyDictionary<int?, string> A
        {
            get
            {
                return _A;
            }
            set
            {
                __tracker.Dirty();
                _A = value;
            }
        }

        // 1
        public override global::ZeroFormatter.ILazyLookup<int?, string> B
        {
            get
            {
                return _B;
            }
            set
            {
                __tracker.Dirty();
                _B = value;
            }
        }


        public NullableLazyObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _A = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.ILazyDictionary<int?, string>>(originalBytes, 0, __binaryLastIndex, __tracker);
            _B = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.ILazyLookup<int?, string>>(originalBytes, 1, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.ILazyDictionary<int?, string>>(ref targetBytes, startOffset, offset, 0, _A);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.ILazyLookup<int?, string>>(ref targetBytes, startOffset, offset, 1, _B);

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
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class AllNewFormatFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.AllNewFormat>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, short[]>(ref bytes, startOffset, offset, 0, value.A1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int[]>(ref bytes, startOffset, offset, 1, value.A2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, long[]>(ref bytes, startOffset, offset, 2, value.A3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort[]>(ref bytes, startOffset, offset, 3, value.A4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, uint[]>(ref bytes, startOffset, offset, 4, value.A5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ulong[]>(ref bytes, startOffset, offset, 5, value.A6);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float[]>(ref bytes, startOffset, offset, 6, value.A7);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, double[]>(ref bytes, startOffset, offset, 7, value.A8);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool[]>(ref bytes, startOffset, offset, 8, value.A9);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte[]>(ref bytes, startOffset, offset, 9, value.A10);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, sbyte[]>(ref bytes, startOffset, offset, 10, value.A11);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, char[]>(ref bytes, startOffset, offset, 11, value.A12);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.MyVector[]>(ref bytes, startOffset, offset, 12, value.V1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.MyVectorClass[]>(ref bytes, startOffset, offset, 13, value.V2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.Dictionary<int, string>>(ref bytes, startOffset, offset, 14, value.V3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<int>>(ref bytes, startOffset, offset, 15, value.V4);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.HashSet<string>>(ref bytes, startOffset, offset, 16, value.V5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.KeyValuePair<int, string>>(ref bytes, startOffset, offset, 17, value.V6);

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
            return new AllNewFormatObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class AllNewFormatObjectSegment<TTypeResolver> : global::Sandbox.Shared.AllNewFormat, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, short[]> _A1;
        CacheSegment<TTypeResolver, int[]> _A2;
        CacheSegment<TTypeResolver, long[]> _A3;
        CacheSegment<TTypeResolver, ushort[]> _A4;
        CacheSegment<TTypeResolver, uint[]> _A5;
        CacheSegment<TTypeResolver, ulong[]> _A6;
        CacheSegment<TTypeResolver, float[]> _A7;
        CacheSegment<TTypeResolver, double[]> _A8;
        CacheSegment<TTypeResolver, bool[]> _A9;
        CacheSegment<TTypeResolver, byte[]> _A10;
        CacheSegment<TTypeResolver, sbyte[]> _A11;
        CacheSegment<TTypeResolver, char[]> _A12;
        CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyVector[]> _V1;
        CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyVectorClass[]> _V2;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<int, string>> _V3;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<int>> _V4;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.HashSet<string>> _V5;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.KeyValuePair<int, string>> _V6;

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

            _A1 = new CacheSegment<TTypeResolver, short[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _A2 = new CacheSegment<TTypeResolver, int[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _A3 = new CacheSegment<TTypeResolver, long[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _A4 = new CacheSegment<TTypeResolver, ushort[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _A5 = new CacheSegment<TTypeResolver, uint[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _A6 = new CacheSegment<TTypeResolver, ulong[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _A7 = new CacheSegment<TTypeResolver, float[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
            _A8 = new CacheSegment<TTypeResolver, double[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 7, __binaryLastIndex, __tracker));
            _A9 = new CacheSegment<TTypeResolver, bool[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 8, __binaryLastIndex, __tracker));
            _A10 = new CacheSegment<TTypeResolver, byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 9, __binaryLastIndex, __tracker));
            _A11 = new CacheSegment<TTypeResolver, sbyte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 10, __binaryLastIndex, __tracker));
            _A12 = new CacheSegment<TTypeResolver, char[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 11, __binaryLastIndex, __tracker));
            _V1 = new CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyVector[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 12, __binaryLastIndex, __tracker));
            _V2 = new CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyVectorClass[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 13, __binaryLastIndex, __tracker));
            _V3 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<int, string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 14, __binaryLastIndex, __tracker));
            _V4 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 15, __binaryLastIndex, __tracker));
            _V5 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.HashSet<string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 16, __binaryLastIndex, __tracker));
            _V6 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.KeyValuePair<int, string>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 17, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, short[]>(ref targetBytes, startOffset, offset, 0, ref _A1);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, int[]>(ref targetBytes, startOffset, offset, 1, ref _A2);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, long[]>(ref targetBytes, startOffset, offset, 2, ref _A3);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, ushort[]>(ref targetBytes, startOffset, offset, 3, ref _A4);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, uint[]>(ref targetBytes, startOffset, offset, 4, ref _A5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, ulong[]>(ref targetBytes, startOffset, offset, 5, ref _A6);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, float[]>(ref targetBytes, startOffset, offset, 6, ref _A7);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, double[]>(ref targetBytes, startOffset, offset, 7, ref _A8);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, bool[]>(ref targetBytes, startOffset, offset, 8, ref _A9);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, byte[]>(ref targetBytes, startOffset, offset, 9, ref _A10);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, sbyte[]>(ref targetBytes, startOffset, offset, 10, ref _A11);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, char[]>(ref targetBytes, startOffset, offset, 11, ref _A12);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyVector[]>(ref targetBytes, startOffset, offset, 12, ref _V1);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyVectorClass[]>(ref targetBytes, startOffset, offset, 13, ref _V2);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<int, string>>(ref targetBytes, startOffset, offset, 14, ref _V3);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<int>>(ref targetBytes, startOffset, offset, 15, ref _V4);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.HashSet<string>>(ref targetBytes, startOffset, offset, 16, ref _V5);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.KeyValuePair<int, string>>(ref targetBytes, startOffset, offset, 17, ref _V6);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 17);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class CustomFormatFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.CustomFormat>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Guid>(ref bytes, startOffset, offset, 0, value.AllowGuid);

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
            return new CustomFormatObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class CustomFormatObjectSegment<TTypeResolver> : global::Sandbox.Shared.CustomFormat, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 16 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override global::System.Guid AllowGuid
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::System.Guid>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::System.Guid>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public CustomFormatObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::System.Guid>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SequenceFormatFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.SequenceFormat>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.SequenceFormat value)
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

                offset += (8 + 4 * (11 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed[]>(ref bytes, startOffset, offset, 0, value.ArrayFormat);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<int>>(ref bytes, startOffset, offset, 1, value.CollectionFormat);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.ObjectModel.ReadOnlyCollection<int>>(ref bytes, startOffset, offset, 2, value.ReadOnlyCollectionFormat);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.Dictionary<int, int>>(ref bytes, startOffset, offset, 3, value.DictionaryFormat);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IDictionary<int, int>>(ref bytes, startOffset, offset, 4, value.InterafceDictionaryFormat);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.ICollection<int>>(ref bytes, startOffset, offset, 5, value.InterfaceCollectionFormat);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IEnumerable<int>>(ref bytes, startOffset, offset, 6, value.InterfaceEnumerableFormat);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 11, value.LookupFormat);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 11);
            }
        }

        public override global::Sandbox.Shared.SequenceFormat Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SequenceFormatObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SequenceFormatObjectSegment<TTypeResolver> : global::Sandbox.Shared.SequenceFormat, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed[]> _ArrayFormat;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<int>> _CollectionFormat;
        CacheSegment<TTypeResolver, global::System.Collections.ObjectModel.ReadOnlyCollection<int>> _ReadOnlyCollectionFormat;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<int, int>> _DictionaryFormat;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<int, int>> _InterafceDictionaryFormat;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.ICollection<int>> _InterfaceCollectionFormat;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.IEnumerable<int>> _InterfaceEnumerableFormat;
        CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>> _LookupFormat;

        // 0
        public override global::ZeroFormatter.Tests.MyStructFixed[] ArrayFormat
        {
            get
            {
                return _ArrayFormat.Value;
            }
            set
            {
                _ArrayFormat.Value = value;
            }
        }

        // 1
        public override global::System.Collections.Generic.List<int> CollectionFormat
        {
            get
            {
                return _CollectionFormat.Value;
            }
            set
            {
                _CollectionFormat.Value = value;
            }
        }

        // 2
        public override global::System.Collections.ObjectModel.ReadOnlyCollection<int> ReadOnlyCollectionFormat
        {
            get
            {
                return _ReadOnlyCollectionFormat.Value;
            }
            set
            {
                _ReadOnlyCollectionFormat.Value = value;
            }
        }

        // 3
        public override global::System.Collections.Generic.Dictionary<int, int> DictionaryFormat
        {
            get
            {
                return _DictionaryFormat.Value;
            }
            set
            {
                _DictionaryFormat.Value = value;
            }
        }

        // 4
        public override global::System.Collections.Generic.IDictionary<int, int> InterafceDictionaryFormat
        {
            get
            {
                return _InterafceDictionaryFormat.Value;
            }
            set
            {
                _InterafceDictionaryFormat.Value = value;
            }
        }

        // 5
        public override global::System.Collections.Generic.ICollection<int> InterfaceCollectionFormat
        {
            get
            {
                return _InterfaceCollectionFormat.Value;
            }
            set
            {
                _InterfaceCollectionFormat.Value = value;
            }
        }

        // 6
        public override global::System.Collections.Generic.IEnumerable<int> InterfaceEnumerableFormat
        {
            get
            {
                return _InterfaceEnumerableFormat.Value;
            }
            set
            {
                _InterfaceEnumerableFormat.Value = value;
            }
        }

        // 11
        public override global::System.Linq.ILookup<bool, int> LookupFormat
        {
            get
            {
                return _LookupFormat.Value;
            }
            set
            {
                _LookupFormat.Value = value;
            }
        }


        public SequenceFormatObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 11, __elementSizes);

            _ArrayFormat = new CacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _CollectionFormat = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _ReadOnlyCollectionFormat = new CacheSegment<TTypeResolver, global::System.Collections.ObjectModel.ReadOnlyCollection<int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _DictionaryFormat = new CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<int, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _InterafceDictionaryFormat = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<int, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _InterfaceCollectionFormat = new CacheSegment<TTypeResolver, global::System.Collections.Generic.ICollection<int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _InterfaceEnumerableFormat = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IEnumerable<int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
            _LookupFormat = new CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 11, __binaryLastIndex, __tracker));
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
                offset += (8 + 4 * (11 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed[]>(ref targetBytes, startOffset, offset, 0, ref _ArrayFormat);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<int>>(ref targetBytes, startOffset, offset, 1, ref _CollectionFormat);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.ObjectModel.ReadOnlyCollection<int>>(ref targetBytes, startOffset, offset, 2, ref _ReadOnlyCollectionFormat);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<int, int>>(ref targetBytes, startOffset, offset, 3, ref _DictionaryFormat);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<int, int>>(ref targetBytes, startOffset, offset, 4, ref _InterafceDictionaryFormat);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.ICollection<int>>(ref targetBytes, startOffset, offset, 5, ref _InterfaceCollectionFormat);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IEnumerable<int>>(ref targetBytes, startOffset, offset, 6, ref _InterfaceEnumerableFormat);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 11, ref _LookupFormat);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 11);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class EnumGenCheckerFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.EnumGenChecker>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.EnumGenChecker value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::ZeroFormatter.ILazyLookup<global::ZeroFormatter.KeyTuple<int, global::Sandbox.Shared.StandardEnum, string>, int>>(ref bytes, startOffset, offset, 0, value.MyProperty);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.EnumGenChecker Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new EnumGenCheckerObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class EnumGenCheckerObjectSegment<TTypeResolver> : global::Sandbox.Shared.EnumGenChecker, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::ZeroFormatter.ILazyLookup<global::ZeroFormatter.KeyTuple<int, global::Sandbox.Shared.StandardEnum, string>, int> _MyProperty;

        // 0
        public override global::ZeroFormatter.ILazyLookup<global::ZeroFormatter.KeyTuple<int, global::Sandbox.Shared.StandardEnum, string>, int> MyProperty
        {
            get
            {
                return _MyProperty;
            }
            set
            {
                __tracker.Dirty();
                _MyProperty = value;
            }
        }


        public EnumGenCheckerObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _MyProperty = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::ZeroFormatter.ILazyLookup<global::ZeroFormatter.KeyTuple<int, global::Sandbox.Shared.StandardEnum, string>, int>>(originalBytes, 0, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::ZeroFormatter.ILazyLookup<global::ZeroFormatter.KeyTuple<int, global::Sandbox.Shared.StandardEnum, string>, int>>(ref targetBytes, startOffset, offset, 0, _MyProperty);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class InnerClassA_InnerObjectFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InnerClassA.InnerObject>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InnerClassA.InnerObject value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.InnerClassA.InnerObject Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new InnerClassA_InnerObjectObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class InnerClassA_InnerObjectObjectSegment<TTypeResolver> : global::Sandbox.Shared.InnerClassA.InnerObject, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public InnerClassA_InnerObjectObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class InnerClassB_InnerObjectFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InnerClassB.InnerObject>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InnerClassB.InnerObject value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.InsideEnum>(ref bytes, startOffset, offset, 1, value.MyProperty2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.TypeCode>(ref bytes, startOffset, offset, 2, value.MyProperty3);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Sandbox.Shared.InnerClassB.InnerObject Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new InnerClassB_InnerObjectObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class InnerClassB_InnerObjectObjectSegment<TTypeResolver> : global::Sandbox.Shared.InnerClassB.InnerObject, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int MyProperty
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Sandbox.Shared.InsideEnum MyProperty2
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Sandbox.Shared.InsideEnum>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Sandbox.Shared.InsideEnum>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override global::System.TypeCode MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::System.TypeCode>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::System.TypeCode>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public InnerClassB_InnerObjectObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Sandbox.Shared.InsideEnum>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::System.TypeCode>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class PersonFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Person>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Sex>(ref bytes, startOffset, offset, 3, value.Sex);

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
            return new PersonObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class PersonObjectSegment<TTypeResolver> : global::Sandbox.Shared.Person, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _FirstName;
        CacheSegment<TTypeResolver, string> _LastName;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Sandbox.Shared.Sex>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Sandbox.Shared.Sex>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public PersonObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _FirstName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _LastName);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Sandbox.Shared.Sex>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class InheritBaseFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InheritBase>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty0);

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
            return new InheritBaseObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class InheritBaseObjectSegment<TTypeResolver> : global::Sandbox.Shared.InheritBase, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class InheritFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Inherit>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.MyProperty1);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.TypeCode>(ref bytes, startOffset, offset, 2, value.MyProperty2);

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
            return new InheritObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class InheritObjectSegment<TTypeResolver> : global::Sandbox.Shared.Inherit, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int MyProperty1
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override global::System.TypeCode MyProperty2
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::System.TypeCode>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::System.TypeCode>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::System.TypeCode>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class FooBarBazFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.FooBarBaz>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<byte[]>>(ref bytes, startOffset, offset, 0, value.HugaHuga);

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
            return new FooBarBazObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class FooBarBazObjectSegment<TTypeResolver> : global::Sandbox.Shared.FooBarBaz, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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

            _HugaHuga = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<byte[]>>(originalBytes, 0, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<byte[]>>(ref targetBytes, startOffset, offset, 0, _HugaHuga);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class HumanFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Human>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Human value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.Name);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.Faith);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Sandbox.Shared.Human Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new HumanObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class HumanObjectSegment<TTypeResolver> : global::Sandbox.Shared.Human, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Name;

        // 0
        public override string Name
        {
            get
            {
                return _Name.Value;
            }
            set
            {
                _Name.Value = value;
            }
        }

        // 1
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int Faith
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public HumanObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _Name = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _Name);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MonsterFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Monster>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Monster value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.Race);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.Power);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.Magic);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::Sandbox.Shared.Monster Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MonsterObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MonsterObjectSegment<TTypeResolver> : global::Sandbox.Shared.Monster, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Race;

        // 0
        public override string Race
        {
            get
            {
                return _Race.Value;
            }
            set
            {
                _Race.Value = value;
            }
        }

        // 1
        public override int Power
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int Magic
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MonsterObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _Race = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _Race);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class HasUnionKlassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.HasUnionKlass>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.HasUnionKlass value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.IStandardUnion>(ref bytes, startOffset, offset, 0, value.A);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Character>(ref bytes, startOffset, offset, 1, value.B);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Sandbox.Shared.HasUnionKlass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new HasUnionKlassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class HasUnionKlassObjectSegment<TTypeResolver> : global::Sandbox.Shared.HasUnionKlass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Sandbox.Shared.IStandardUnion> _A;
        CacheSegment<TTypeResolver, global::Sandbox.Shared.Character> _B;

        // 0
        public override global::Sandbox.Shared.IStandardUnion A
        {
            get
            {
                return _A.Value;
            }
            set
            {
                _A.Value = value;
            }
        }

        // 1
        public override global::Sandbox.Shared.Character B
        {
            get
            {
                return _B.Value;
            }
            set
            {
                _B.Value = value;
            }
        }


        public HasUnionKlassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _A = new CacheSegment<TTypeResolver, global::Sandbox.Shared.IStandardUnion>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _B = new CacheSegment<TTypeResolver, global::Sandbox.Shared.Character>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Sandbox.Shared.IStandardUnion>(ref targetBytes, startOffset, offset, 0, ref _A);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Sandbox.Shared.Character>(ref targetBytes, startOffset, offset, 1, ref _B);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class UnknownMessage1Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.UnknownMessage1>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.UnknownMessage1 value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.UnknownMessage1 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new UnknownMessage1ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class UnknownMessage1ObjectSegment<TTypeResolver> : global::Sandbox.Shared.UnknownMessage1, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public UnknownMessage1ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MessageA1Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.MessageA1>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.MessageA1 value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.MessageA1 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MessageA1ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MessageA1ObjectSegment<TTypeResolver> : global::Sandbox.Shared.MessageA1, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public MessageA1ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MessageB1Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.MessageB1>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.MessageB1 value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.MessageB1 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MessageB1ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MessageB1ObjectSegment<TTypeResolver> : global::Sandbox.Shared.MessageB1, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public MessageB1ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MessageAFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.MessageA>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.MessageA value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.MessageA Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MessageAObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MessageAObjectSegment<TTypeResolver> : global::Sandbox.Shared.MessageA, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public MessageAObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MessageBFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.MessageB>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.MessageB value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.IEvent>>(ref bytes, startOffset, offset, 0, value.Events);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.MessageB Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MessageBObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MessageBObjectSegment<TTypeResolver> : global::Sandbox.Shared.MessageB, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::System.Collections.Generic.IList<global::Sandbox.Shared.IEvent> _Events;

        // 0
        public override global::System.Collections.Generic.IList<global::Sandbox.Shared.IEvent> Events
        {
            get
            {
                return _Events;
            }
            set
            {
                __tracker.Dirty();
                _Events = value;
            }
        }


        public MessageBObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Events = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.IEvent>>(originalBytes, 0, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.IEvent>>(ref targetBytes, startOffset, offset, 0, _Events);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class UnknownEventFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.UnknownEvent>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.UnknownEvent value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.UnknownEvent Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new UnknownEventObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class UnknownEventObjectSegment<TTypeResolver> : global::Sandbox.Shared.UnknownEvent, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public UnknownEventObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class EventAFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.EventA>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.EventA value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.EventA Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new EventAObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class EventAObjectSegment<TTypeResolver> : global::Sandbox.Shared.EventA, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public EventAObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class EventBFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.EventB>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.EventB value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.EventB Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new EventBObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class EventBObjectSegment<TTypeResolver> : global::Sandbox.Shared.EventB, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public EventBObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class StandardFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Standard>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.MyProperty3);

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
            return new StandardObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class StandardObjectSegment<TTypeResolver> : global::Sandbox.Shared.Standard, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LargeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Large>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.MyProperty0);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.MyProperty3);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, long>(ref bytes, startOffset, offset, 5, value.MyProperty5);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 7, value.MyProperty6);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref bytes, startOffset, offset, 10, value.MyProperty10);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref bytes, startOffset, offset, 11, value.MyProperty11);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<string>>(ref bytes, startOffset, offset, 13, value.MyProperty13);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref bytes, startOffset, offset, 15, value.MyProperty15);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 20, value.MyProperty20);

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
            return new LargeObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LargeObjectSegment<TTypeResolver> : global::Sandbox.Shared.Large, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _MyProperty6;
        global::System.Collections.Generic.IList<int> _MyProperty10;
        CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>> _MyProperty11;
        global::System.Collections.Generic.IList<string> _MyProperty13;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>> _MyProperty15;

        // 0
        public override int MyProperty0
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int MyProperty3
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override long MyProperty5
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, long>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, long>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 20, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 20, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public LargeObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 20, __elementSizes);

            _MyProperty6 = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 7, __binaryLastIndex, __tracker));
            _MyProperty10 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(originalBytes, 10, __binaryLastIndex, __tracker);
            _MyProperty11 = new CacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 11, __binaryLastIndex, __tracker));
            _MyProperty13 = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<string>>(originalBytes, 13, __binaryLastIndex, __tracker);
            _MyProperty15 = new CacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 15, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, long>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 7, ref _MyProperty6);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 10, _MyProperty10);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Linq.ILookup<bool, int>>(ref targetBytes, startOffset, offset, 11, ref _MyProperty11);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<string>>(ref targetBytes, startOffset, offset, 13, _MyProperty13);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.IDictionary<string, int>>(ref targetBytes, startOffset, offset, 15, ref _MyProperty15);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 20, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 20);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class ZeroClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.ZeroClass>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.ZeroClass value)
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

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.ZeroClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new ZeroClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class ZeroClassObjectSegment<TTypeResolver> : global::Sandbox.Shared.ZeroClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{  };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;



        public ZeroClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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


                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
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

    public class DameClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.DameClass>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.DameClass value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Ok);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::Sandbox.Shared.Bar.DameClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new DameClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class DameClassObjectSegment<TTypeResolver> : global::Sandbox.Shared.Bar.DameClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int Ok
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public DameClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class StaticPropertyFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.StaticProperty>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.StaticProperty value)
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Bar.DameClass[]>(ref bytes, startOffset, offset, 0, value.My2);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.HugaHuga);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Sandbox.Shared.Bar.StaticProperty Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new StaticPropertyObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class StaticPropertyObjectSegment<TTypeResolver> : global::Sandbox.Shared.Bar.StaticProperty, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Sandbox.Shared.Bar.DameClass[]> _My2;

        // 0
        public override global::Sandbox.Shared.Bar.DameClass[] My2
        {
            get
            {
                return _My2.Value;
            }
            set
            {
                _My2.Value = value;
            }
        }

        // 1
        public override int HugaHuga
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public StaticPropertyObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _My2 = new CacheSegment<TTypeResolver, global::Sandbox.Shared.Bar.DameClass[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Sandbox.Shared.Bar.DameClass[]>(ref targetBytes, startOffset, offset, 0, ref _My2);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.MyClass>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

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
            return new MyClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClassObjectSegment<TTypeResolver> : global::Sandbox.Shared.Bar.MyClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _FirstName;
        CacheSegment<TTypeResolver, string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClass2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.MyClass2>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

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
            return new MyClass2ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClass2ObjectSegment<TTypeResolver> : global::Sandbox.Shared.Bar.MyClass2, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _FirstName;
        CacheSegment<TTypeResolver, string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClass2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Bar.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

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

    public class MyClassFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Foo.MyClass>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

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
            return new MyClassObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClassObjectSegment<TTypeResolver> : global::Sandbox.Shared.Foo.MyClass, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _FirstName;
        CacheSegment<TTypeResolver, string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClassObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClass2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Foo.MyClass2>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref bytes, startOffset, offset, 3, value.List);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(ref bytes, startOffset, offset, 4, value.Mone);

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
            return new MyClass2ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MyClass2ObjectSegment<TTypeResolver> : global::Sandbox.Shared.Foo.MyClass2, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _FirstName;
        CacheSegment<TTypeResolver, string> _LastName;
        global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge> _List;

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MyClass2ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _FirstName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _LastName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _List = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(originalBytes, 3, __binaryLastIndex, __tracker);
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _FirstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _LastName);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::System.Collections.Generic.IList<global::Sandbox.Shared.Foo.MogeMoge>>(ref targetBytes, startOffset, offset, 3, _List);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

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

    public class DataRootFormatter<TTypeResolver> : Formatter<TTypeResolver, global::DataRoot>
        where TTypeResolver : ITypeResolver, new()
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
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::DataRoot.DataTypeVersion>(ref bytes, startOffset, offset, 0, value.DataType);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte[]>(ref bytes, startOffset, offset, 1, value.Data);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::MyGlobal>(ref bytes, startOffset, offset, 2, value.GB);

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
            return new DataRootObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class DataRootObjectSegment<TTypeResolver> : global::DataRoot, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, byte[]> _Data;

        // 0
        public override global::DataRoot.DataTypeVersion DataType
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::DataRoot.DataTypeVersion>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::DataRoot.DataTypeVersion>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
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
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::MyGlobal>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::MyGlobal>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public DataRootObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _Data = new CacheSegment<TTypeResolver, byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
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

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::DataRoot.DataTypeVersion>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, byte[]>(ref targetBytes, startOffset, offset, 1, ref _Data);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::MyGlobal>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

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

    public class MyVectorFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.MyVector>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public MyVectorFormatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyVector value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 8);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.X);
            offset += formatter1.Serialize(ref bytes, offset, value.Y);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyVector Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::ZeroFormatter.Tests.MyVector(item0, item1);
        }
    }

    public class MyStructFixedFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.MyStructFixed>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        readonly Formatter<TTypeResolver, long> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public MyStructFixedFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            formatter1 = Formatter<TTypeResolver, long>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 16;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyStructFixed value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 16);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.MyProperty1);
            offset += formatter1.Serialize(ref bytes, offset, value.MyProperty2);
            offset += formatter2.Serialize(ref bytes, offset, value.MyProperty3);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyStructFixed Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::ZeroFormatter.Tests.MyStructFixed(item0, item1, item2);
        }
    }

    public class MyStructVariableFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.MyStructVariable>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        readonly Formatter<TTypeResolver, string> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public MyStructVariableFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            formatter1 = Formatter<TTypeResolver, string>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyStructVariable value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.MyProperty1);
            offset += formatter1.Serialize(ref bytes, offset, value.MyProperty2);
            offset += formatter2.Serialize(ref bytes, offset, value.MyProperty3);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyStructVariable Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::ZeroFormatter.Tests.MyStructVariable(item0, item1, item2);
        }
    }

    public class MyNonVectorFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.MyNonVector>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, string> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public MyNonVectorFormatter()
        {
            formatter0 = Formatter<TTypeResolver, string>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ZeroFormatter.Tests.MyNonVector value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.X);
            offset += formatter1.Serialize(ref bytes, offset, value.Y);
            return offset - startOffset;
        }

        public override global::ZeroFormatter.Tests.MyNonVector Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
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
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class GetOnlyFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.GetOnly>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public GetOnlyFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Bar.GetOnly value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.X);
            return offset - startOffset;
        }

        public override global::Sandbox.Shared.Bar.GetOnly Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Sandbox.Shared.Bar.GetOnly(item0);
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

    public class Vector2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector2>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public Vector2Formatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 8;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector2 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 8);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.x);
            offset += formatter1.Serialize(ref bytes, offset, value.y);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::UnityEngine.Vector2(item0, item1);
        }
    }

    public class Vector3Formatter<TTypeResolver> : Formatter<TTypeResolver, global::UnityEngine.Vector3>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                ;
            }
        }

        public Vector3Formatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 12;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::UnityEngine.Vector3 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 12);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.x);
            offset += formatter1.Serialize(ref bytes, offset, value.y);
            offset += formatter2.Serialize(ref bytes, offset, value.z);
            return offset - startOffset;
        }

        public override global::UnityEngine.Vector3 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
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
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class ZeroStructFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.ZeroStruct>
        where TTypeResolver : ITypeResolver, new()
    {
        

        public ZeroStructFormatter()
        {
            
        }

        public override int? GetLength()
        {
            return 0;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.ZeroStruct value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 0);
            var startOffset = offset;
            return offset - startOffset;
        }

        public override global::Sandbox.Shared.ZeroStruct Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            
            return new global::Sandbox.Shared.ZeroStruct();
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

    public class CharacterFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Character>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly global::System.Collections.Generic.IEqualityComparer<global::Sandbox.Shared.CharacterType> comparer;
        readonly global::Sandbox.Shared.CharacterType[] unionKeys;
        
        public CharacterFormatter()
        {
            comparer = global::ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Sandbox.Shared.CharacterType>.Default;
            unionKeys = new global::Sandbox.Shared.CharacterType[2];
            unionKeys[0] = new global::Sandbox.Shared.Human().Type;
            unionKeys[1] = new global::Sandbox.Shared.Monster().Type;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Character value)
        {
            if (value == null)
            {
                return BinaryUtil.WriteInt32(ref bytes, offset, -1);
            }

            var startOffset = offset;

            offset += 4;
            offset += Formatter<TTypeResolver, global::Sandbox.Shared.CharacterType>.Default.Serialize(ref bytes, offset, value.Type);

            if (value is global::Sandbox.Shared.Human)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.Human>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.Human)value);
            }
            else if (value is global::Sandbox.Shared.Monster)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.Monster>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.Monster)value);
            }
            
            else
            {
                throw new Exception("Unknown subtype of Union:" + value.GetType().FullName);
            }
        
            var writeSize = offset - startOffset;
            BinaryUtil.WriteInt32(ref bytes, startOffset, writeSize);
            return writeSize;
        }

        public override global::Sandbox.Shared.Character Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            if ((byteSize = BinaryUtil.ReadInt32(ref bytes, offset)) == -1)
            {
                byteSize = 4;
                return null;
            }
        
            offset += 4;
            int size;
            var unionKey = Formatter<TTypeResolver, global::Sandbox.Shared.CharacterType>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;

            global::Sandbox.Shared.Character result;
            if (comparer.Equals(unionKey, unionKeys[0]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.Human>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else if (comparer.Equals(unionKey, unionKeys[1]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.Monster>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else
            {
                throw new Exception("Unknown unionKey type of Union: " + unionKey.ToString());
            }

            return result;
        }
    }

    public class Union2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Union2>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly global::System.Collections.Generic.IEqualityComparer<string> comparer;
        readonly string[] unionKeys;
        
        public Union2Formatter()
        {
            comparer = global::ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<string>.Default;
            unionKeys = new string[2];
            unionKeys[0] = new global::Sandbox.Shared.SubTest1().UnionKeyDayo;
            unionKeys[1] = new global::Sandbox.Shared.SubTest2().UnionKeyDayo;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.Union2 value)
        {
            if (value == null)
            {
                return BinaryUtil.WriteInt32(ref bytes, offset, -1);
            }

            var startOffset = offset;

            offset += 4;
            offset += Formatter<TTypeResolver, string>.Default.Serialize(ref bytes, offset, value.UnionKeyDayo);

            if (value is global::Sandbox.Shared.SubTest1)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.SubTest1>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.SubTest1)value);
            }
            else if (value is global::Sandbox.Shared.SubTest2)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.SubTest2>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.SubTest2)value);
            }
            
            else
            {
                throw new Exception("Unknown subtype of Union:" + value.GetType().FullName);
            }
        
            var writeSize = offset - startOffset;
            BinaryUtil.WriteInt32(ref bytes, startOffset, writeSize);
            return writeSize;
        }

        public override global::Sandbox.Shared.Union2 Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            if ((byteSize = BinaryUtil.ReadInt32(ref bytes, offset)) == -1)
            {
                byteSize = 4;
                return null;
            }
        
            offset += 4;
            int size;
            var unionKey = Formatter<TTypeResolver, string>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;

            global::Sandbox.Shared.Union2 result;
            if (comparer.Equals(unionKey, unionKeys[0]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.SubTest1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else if (comparer.Equals(unionKey, unionKeys[1]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.SubTest2>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else
            {
                throw new Exception("Unknown unionKey type of Union: " + unionKey.ToString());
            }

            return result;
        }
    }

    public class IStandardUnionFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.IStandardUnion>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly global::System.Collections.Generic.IEqualityComparer<int> comparer;
        readonly int[] unionKeys;
        
        public IStandardUnionFormatter()
        {
            comparer = global::ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<int>.Default;
            unionKeys = new int[4];
            unionKeys[0] = new global::Sandbox.Shared.UnknownMessage1().A;
            unionKeys[1] = new global::Sandbox.Shared.MessageA1().A;
            unionKeys[2] = new global::Sandbox.Shared.MessageB1().A;
            unionKeys[3] = new global::Sandbox.Shared.UnknownMessage1().A;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.IStandardUnion value)
        {
            if (value == null)
            {
                return BinaryUtil.WriteInt32(ref bytes, offset, -1);
            }

            var startOffset = offset;

            offset += 4;
            offset += Formatter<TTypeResolver, int>.Default.Serialize(ref bytes, offset, value.A);

            if (value is global::Sandbox.Shared.UnknownMessage1)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.UnknownMessage1>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.UnknownMessage1)value);
            }
            else if (value is global::Sandbox.Shared.MessageA1)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.MessageA1>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.MessageA1)value);
            }
            else if (value is global::Sandbox.Shared.MessageB1)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.MessageB1>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.MessageB1)value);
            }
            else if (value is global::Sandbox.Shared.UnknownMessage1)
            {
                offset += Formatter<TTypeResolver, global::Sandbox.Shared.UnknownMessage1>.Default.Serialize(ref bytes, offset, (global::Sandbox.Shared.UnknownMessage1)value);
            }
            
            else
            {
                throw new Exception("Unknown subtype of Union:" + value.GetType().FullName);
            }
        
            var writeSize = offset - startOffset;
            BinaryUtil.WriteInt32(ref bytes, startOffset, writeSize);
            return writeSize;
        }

        public override global::Sandbox.Shared.IStandardUnion Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            if ((byteSize = BinaryUtil.ReadInt32(ref bytes, offset)) == -1)
            {
                byteSize = 4;
                return null;
            }
        
            offset += 4;
            int size;
            var unionKey = Formatter<TTypeResolver, int>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;

            global::Sandbox.Shared.IStandardUnion result;
            if (comparer.Equals(unionKey, unionKeys[0]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.UnknownMessage1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else if (comparer.Equals(unionKey, unionKeys[1]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.MessageA1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else if (comparer.Equals(unionKey, unionKeys[2]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.MessageB1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else if (comparer.Equals(unionKey, unionKeys[3]))
            {
                result = Formatter<TTypeResolver, global::Sandbox.Shared.UnknownMessage1>.Default.Deserialize(ref bytes, offset, tracker, out size);
            }
            else
            {
                result = new global::Sandbox.Shared.UnknownMessage1();
            }

            return result;
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


    public class DataRoot_DataTypeVersionFormatter<TTypeResolver> : Formatter<TTypeResolver, global::DataRoot.DataTypeVersion>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableDataRoot_DataTypeVersionFormatter<TTypeResolver> : Formatter<TTypeResolver, global::DataRoot.DataTypeVersion?>
        where TTypeResolver : ITypeResolver, new()
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



    public class DataRoot_DataTypeVersionEqualityComparer : IEqualityComparer<global::DataRoot.DataTypeVersion>
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



    public class MyGlobalFormatter<TTypeResolver> : Formatter<TTypeResolver, global::MyGlobal>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableMyGlobalFormatter<TTypeResolver> : Formatter<TTypeResolver, global::MyGlobal?>
        where TTypeResolver : ITypeResolver, new()
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


    public class StandardEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.StandardEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.StandardEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.StandardEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.StandardEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableStandardEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.StandardEnum?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.StandardEnum? value)
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

        public override global::Sandbox.Shared.StandardEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.StandardEnum)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class StandardEnumEqualityComparer : IEqualityComparer<global::Sandbox.Shared.StandardEnum>
    {
        public bool Equals(global::Sandbox.Shared.StandardEnum x, global::Sandbox.Shared.StandardEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.StandardEnum x)
        {
            return (int)x;
        }
    }



    public class InnerClassA_InnerEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InnerClassA.InnerEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InnerClassA.InnerEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.InnerClassA.InnerEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.InnerClassA.InnerEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableInnerClassA_InnerEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InnerClassA.InnerEnum?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InnerClassA.InnerEnum? value)
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

        public override global::Sandbox.Shared.InnerClassA.InnerEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.InnerClassA.InnerEnum)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class InnerClassA_InnerEnumEqualityComparer : IEqualityComparer<global::Sandbox.Shared.InnerClassA.InnerEnum>
    {
        public bool Equals(global::Sandbox.Shared.InnerClassA.InnerEnum x, global::Sandbox.Shared.InnerClassA.InnerEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.InnerClassA.InnerEnum x)
        {
            return (int)x;
        }
    }



    public class InnerClassB_InnerEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InnerClassB.InnerEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InnerClassB.InnerEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.InnerClassB.InnerEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.InnerClassB.InnerEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableInnerClassB_InnerEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InnerClassB.InnerEnum?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InnerClassB.InnerEnum? value)
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

        public override global::Sandbox.Shared.InnerClassB.InnerEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.InnerClassB.InnerEnum)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class InnerClassB_InnerEnumEqualityComparer : IEqualityComparer<global::Sandbox.Shared.InnerClassB.InnerEnum>
    {
        public bool Equals(global::Sandbox.Shared.InnerClassB.InnerEnum x, global::Sandbox.Shared.InnerClassB.InnerEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.InnerClassB.InnerEnum x)
        {
            return (int)x;
        }
    }



    public class OutSideEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.OutSideEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.OutSideEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.OutSideEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.OutSideEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableOutSideEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.OutSideEnum?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.OutSideEnum? value)
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

        public override global::Sandbox.Shared.OutSideEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.OutSideEnum)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class OutSideEnumEqualityComparer : IEqualityComparer<global::Sandbox.Shared.OutSideEnum>
    {
        public bool Equals(global::Sandbox.Shared.OutSideEnum x, global::Sandbox.Shared.OutSideEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.OutSideEnum x)
        {
            return (int)x;
        }
    }



    public class InsideEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InsideEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InsideEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.InsideEnum Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.InsideEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableInsideEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.InsideEnum?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.InsideEnum? value)
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

        public override global::Sandbox.Shared.InsideEnum? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.InsideEnum)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class InsideEnumEqualityComparer : IEqualityComparer<global::Sandbox.Shared.InsideEnum>
    {
        public bool Equals(global::Sandbox.Shared.InsideEnum x, global::Sandbox.Shared.InsideEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.InsideEnum x)
        {
            return (int)x;
        }
    }



    public class SexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Sex>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableSexFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Sex?>
        where TTypeResolver : ITypeResolver, new()
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



    public class CharacterTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.CharacterType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.CharacterType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Sandbox.Shared.CharacterType Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Sandbox.Shared.CharacterType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableCharacterTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.CharacterType?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Sandbox.Shared.CharacterType? value)
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

        public override global::Sandbox.Shared.CharacterType? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::Sandbox.Shared.CharacterType)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class CharacterTypeEqualityComparer : IEqualityComparer<global::Sandbox.Shared.CharacterType>
    {
        public bool Equals(global::Sandbox.Shared.CharacterType x, global::Sandbox.Shared.CharacterType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Sandbox.Shared.CharacterType x)
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
namespace ZeroFormatter.DynamicObjectSegments.Sandbox.Shared.Bar
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class MogeMogeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableMogeMogeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge?>
        where TTypeResolver : ITypeResolver, new()
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



    public class MogeMoge2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge2>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableMogeMoge2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Bar.MogeMoge2?>
        where TTypeResolver : ITypeResolver, new()
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


    public class MogeMogeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableMogeMogeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge?>
        where TTypeResolver : ITypeResolver, new()
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



    public class MogeMoge2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge2>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableMogeMoge2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::Sandbox.Shared.Foo.MogeMoge2?>
        where TTypeResolver : ITypeResolver, new()
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


    public class TypeCodeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::System.TypeCode>
        where TTypeResolver : ITypeResolver, new()
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


    public class IntEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.IntEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableIntEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.IntEnum?>
        where TTypeResolver : ITypeResolver, new()
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



    public class UIntEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.UIntEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableUIntEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.UIntEnum?>
        where TTypeResolver : ITypeResolver, new()
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



    public class ShortEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.ShortEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableShortEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.ShortEnum?>
        where TTypeResolver : ITypeResolver, new()
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



    public class UShortEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.UShortEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableUShortEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.UShortEnum?>
        where TTypeResolver : ITypeResolver, new()
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



    public class ByteEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.ByteEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableByteEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.ByteEnum?>
        where TTypeResolver : ITypeResolver, new()
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



    public class SByteEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.SByteEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableSByteEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.SByteEnum?>
        where TTypeResolver : ITypeResolver, new()
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



    public class LongEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.LongEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableLongEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.LongEnum?>
        where TTypeResolver : ITypeResolver, new()
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



    public class ULongEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.ULongEnum>
        where TTypeResolver : ITypeResolver, new()
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


    public class NullableULongEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ZeroFormatter.Tests.ULongEnum?>
        where TTypeResolver : ITypeResolver, new()
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
