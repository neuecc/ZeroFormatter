using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFormatter.Tests
{
    public enum IntEnum : int
    {
        Orange, Apple, Grape
    }

    public enum UIntEnum : uint
    {
        Orange, Apple, Grape
    }

    public enum ShortEnum : short
    {
        Orange, Apple, Grape
    }

    public enum UShortEnum : ushort
    {
        Orange, Apple, Grape
    }

    public enum ByteEnum : byte
    {
        Orange, Apple, Grape
    }

    public enum SByteEnum : sbyte
    {
        Orange, Apple, Grape
    }

    public enum LongEnum : long
    {
        Orange, Apple, Grape
    }

    public enum ULongEnum : ulong
    {
        Orange, Apple, Grape
    }

    [ZeroFormattable]
    public class MyFormatClass
    {
        [Index(0)]
        public virtual int MyProperty { get; set; }
    }


    [ZeroFormattable]
    public class AllNullClass
    {
        [Index(0)]
        public virtual IDictionary<int, string> MyProperty1 { get; set; }
        [Index(1)]
        public virtual IList<int> MyProperty2 { get; set; }
        [Index(2)]
        public virtual IList<string> MyProperty3 { get; set; }
        [Index(3)]
        public virtual ILookup<bool, int> MyProperty4 { get; set; }
        [Index(4)]
        public virtual MyFormatClass MyProperty5 { get; set; }
        [Index(5)]
        public virtual byte[] MyProperty6 { get; set; }
        [Index(6)]
        public virtual string MyProperty7 { get; set; }
        [Index(7)]
        public virtual IDictionary<string, int> MyProperty8 { get; set; }
    }

    [ZeroFormattable]
    public class MyClass
    {
        [Index(0)]
        public virtual int Age { get; set; }

        [Index(1)]
        public virtual string FirstName { get; set; }

        [Index(2)]
        public virtual string LastName { get; set; }

        [IgnoreFormat]
        public string FullName { get { return FirstName + LastName; } }

        [Index(3)]
        public virtual int HogeMoge { get; protected set; }

        [Index(4)]
        public virtual IList<int> MyList { get; set; }

        [IgnoreFormat]
        public int HugaHuga { get { return 100000; } }
    }

    [ZeroFormattable]
    public class SkipIndex
    {
        [Index(1)]
        public virtual int MyProperty1 { get; set; }
        [Index(2)]
        public virtual int MyProperty2 { get; set; }

        [Index(3)]
        public virtual int MyProperty3 { get; set; }
        [Index(4)]
        public virtual IList<int> MyProperty4 { get; set; }
        [Index(5)]
        public virtual string MyProperty5 { get; set; }
    }

    [ZeroFormattable]
    public class OtherSchema1
    {
        [Index(1)]
        public virtual int MyProperty1 { get; set; }
    }

    [ZeroFormattable]
    public class OtherSchema2
    {
        [Index(3)]
        public virtual int MyProperty3 { get; set; }
    }

    [ZeroFormattable]
    public class OtherSchema3
    {
        [Index(3)]
        public virtual int MyProperty3 { get; set; }

        [Index(7)]
        public virtual double MyProperty7 { get; set; }

        [Index(8)]
        public virtual int? MyProperty8 { get; set; }

        [Index(10)]
        public virtual int MyProperty10 { get; set; }
    }

    [ZeroFormattable]
    public class RecMyClass
    {
        [Index(0)]
        public virtual int Hoge { get; set; }
        [Index(1)]
        public virtual RecMyClass Rec { get; set; }
    }

    [ZeroFormattable]
    public class KeyTupleCheck
    {
        [Index(0)]
        public virtual IDictionary<KeyTuple<int, string>, MyClass> KeyTupleDictionary { get; set; }
    }

    [ZeroFormattable]
    public class OffsetType
    {
        [Index(0)]
        public virtual int Dummy1 { get; set; }
        [Index(1)]
        public virtual string Dummy2 { get; set; }
        [Index(2)]
        public virtual IList<string> VariableSizeList { get; set; }
        [Index(3)]
        public virtual IDictionary<string, int> Dictionary { get; set; }
        [Index(4)]
        public virtual Offset2 ObjectProp { get; set; }
    }

    [ZeroFormattable]
    public class Offset2
    {
        [Index(0)]
        public virtual int Prop1 { get; set; }
        [Index(1)]
        public virtual string Prop2 { get; set; }
    }


    [ZeroFormattable]
    public class TestBase
    {
        [Index(0)]
        public virtual int MyProperty { get; set; }
    }

    [ZeroFormattable]
    public class Test2 : TestBase
    {
        [Index(1)]
        public virtual int MyProperty1 { get; set; }
    }

    [ZeroFormattable]
    public struct MyVector
    {
        [Index(0)]
        public float X { get; private set; }
        [Index(1)]
        public float Y { get; private set; }

        public MyVector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    [ZeroFormattable]
    public class MyVectorClass
    {
        [Index(0)]
        public virtual float X { get; set; }
        [Index(1)]
        public virtual float Y { get; set; }

        public MyVectorClass()
        {

        }

        public MyVectorClass(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

    }

    [ZeroFormattable]
    public struct MyNonVector
    {
        [Index(0)]
        public string X { get; private set; }
        [Index(1)]
        public float Y { get; private set; }

        public MyNonVector(string x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    [ZeroFormattable]
    public struct MyStructFixed
    {
        [Index(0)]
        public int MyProperty1 { get; private set; }
        [Index(1)]
        public long MyProperty2 { get; private set; }
        [Index(2)]
        public float MyProperty3 { get; private set; }

        public MyStructFixed(int x, long y, float z)
        {
            MyProperty1 = x;
            MyProperty2 = y;
            MyProperty3 = z;
        }
    }

    [ZeroFormattable]
    public struct MyStructVariable
    {
        [Index(0)]
        public int MyProperty1 { get; private set; }
        [Index(1)]
        public string MyProperty2 { get; private set; }
        [Index(2)]
        public float MyProperty3 { get; private set; }

        public MyStructVariable(int x, string y, float z)
        {
            MyProperty1 = x;
            MyProperty2 = y;
            MyProperty3 = z;
        }
    }

    [ZeroFormattable]
    public class IncludeStruct
    {
        [Index(0)]
        public virtual MyStructFixed MyProperty0 { get; set; }
        [Index(1)]
        public virtual MyStructVariable MyProperty1 { get; set; }
    }

    [ZeroFormattable]
    public class LazyFormats
    {
        [Index(0)]
        public virtual IDictionary<string, int> D0 { get; set; }
        [Index(1)]
        public virtual ILazyDictionary<string, int> D1 { get; set; }
        [Index(2)]
        public virtual ILookup<bool, int> D2 { get; set; }
        [Index(3)]
        public virtual ILazyLookup<bool, int> D3 { get; set; }
    }

    [ZeroFormattable]
    public class FooBar
    {
        [Index(0)]
        public virtual global::Sandbox.Shared.Foo.MyClass FooMyClass { get; set; }
        [Index(1)]
        public virtual global::Sandbox.Shared.Bar.MyClass BarMyClass { get; set; }
    }

    [ZeroFormattable]
    public class NullableLazy
    {
        [Index(0)]
        public virtual ILazyDictionary<int?, string> A { get; set; }
        [Index(1)]
        public virtual ILazyLookup<int?, string> B { get; set; }
    }
}
