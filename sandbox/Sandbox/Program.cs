using Sandbox;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;
using System.IO;
using ZeroFormatter.Segments;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using Sandbox.Shared;

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
    public virtual IList<MogeMoge> List { get; set; }

    [Index(4)]
    public virtual MogeMoge Mone { get; set; }
}



namespace Sandbox
{


    [ZeroFormattable]
    public class Simple
    {
        [Index(0)]
        public virtual int I { get; set; }
    }

    public enum MogeMoge
    {
        Apple, Orange
    }



    public enum MyEnum
    {
        Furit, Alle
    }

    [ZeroFormattable]
    public class MyGuid
    {
        [Index(0)]
        public virtual Guid MyProperty { get; set; }
        [Index(1)]
        public virtual Uri MyProperty2 { get; set; }
        [Index(2)]
        public virtual KeyValuePair<string, int> MyProperty3 { get; set; }
    }

    [ZeroFormattable]
    public class Version1
    {
        [Index(0)]
        public virtual int Prop1 { get; set; }
        [Index(1)]
        public virtual int Prop2 { get; set; }
    }

    [ZeroFormattable]
    public class Version2
    {
        [Index(0)]
        public virtual int Prop1 { get; set; }
        [Index(1)]
        public virtual int Prop2 { get; set; }
        // You can add new property. If deserialize from old data, value is assigned default(T).
        [Index(2)]
        public virtual int NewType { get; set; }
    }


    [Serializable]
    [ZeroFormattable]
    public struct LargeStruct
    {
        private static void A(bool b)
        {
            if (!b)
                throw new Exception();
        }

        [Index(0)]
        private ulong m_val1;
        [Index(1)]
        private ulong m_val2;
        [Index(2)]
        private ulong m_val3;
        [Index(3)]
        private ulong m_val4;

        private static ulong counter;

        public LargeStruct(ulong m_val1, ulong m_val2, ulong m_val3, ulong m_val4)
        {
            this.m_val1 = m_val1;
            this.m_val2 = m_val2;
            this.m_val3 = m_val3;
            this.m_val4 = m_val4;
        }

        public static LargeStruct Create()
        {
            return new LargeStruct
            {
                m_val1 = counter++,
                m_val2 = ulong.MaxValue - counter++,
                m_val3 = counter++,
                m_val4 = ulong.MaxValue - counter++
            };
        }

        public static void Compare(LargeStruct a, LargeStruct b)
        {
            A(a.m_val1 == b.m_val1);
            A(a.m_val2 == b.m_val2);
            A(a.m_val3 == b.m_val3);
            A(a.m_val4 == b.m_val4);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = null;
            var len = BinaryUtil.WriteDouble(ref bytes, 0, 3.14d);

            //Console.WriteLine(BinaryUtil.ReadDouble(ref bytes, 0));

            foreach (var item in bytes)
            {
                Console.WriteLine(item);
            }

        }
    }

    public class UriFormatter : Formatter<Uri>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Uri value)
        {
            return Formatter<string>.Default.Serialize(ref bytes, offset, value.ToString());
        }

        public override Uri Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var uriString = Formatter<string>.Default.Deserialize(ref bytes, offset, tracker, out byteSize);
            return (uriString == null) ? null : new Uri(uriString);
        }
    }


    [ZeroFormattable]
    public struct MyStruct
    {
        [Index(0)]
        public int MyProperty1 { get; set; }
        [Index(1)]
        public int MyProperty2 { get; set; }
        public MyStruct(int x, int y)
        {
            MyProperty1 = x;
            MyProperty2 = y;
        }
    }

    [ZeroFormattable]
    public class ErrorClass
    {
        [Index(0)]
        public int MyProperty1;
    }



}