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
}
