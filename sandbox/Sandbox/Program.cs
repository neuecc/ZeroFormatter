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


    class Program
    {
        static void Main(string[] args)
        {
            ZeroFormatter.Formatters.Formatter<Guid>.Register(new GuidFormatter());
            ZeroFormatter.Formatters.Formatter<Uri>.Register(new UriFormatter());


            ZeroFormatter.Formatters.Formatter.AppendFormatterResolver(t =>
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                {
                    var formatterType = typeof(KeyValuePairFormatter<,>).MakeGenericType(t.GetGenericArguments());
                    return Activator.CreateInstance(formatterType);
                }

                return null;
            });


            var my = new MyGuid()
            {
                MyProperty = Guid.NewGuid(),
                MyProperty2 = new Uri("http://hogehoge.com/hugahuga/takotako"),
                MyProperty3 = new KeyValuePair<string, int>("hugahugahugahuga", 10000)
            };
            var huga = ZeroFormatterSerializer.Convert(my);

            Console.WriteLine(my.MyProperty);
            Console.WriteLine(huga.MyProperty);
            Console.WriteLine(huga.MyProperty3);
            Console.WriteLine(my.MyProperty2);
            Console.WriteLine(huga.MyProperty2);
            Console.WriteLine(huga.MyProperty3);
        }
    }

    public class GuidFormatter : Formatter<Guid>
    {
        public override int? GetLength()
        {
            return 16;
        }

        public override int Serialize(ref byte[] bytes, int offset, Guid value)
        {
            return BinaryUtil.WriteBytes(ref bytes, offset, value.ToByteArray());
        }

        public override Guid Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 16;
            var guidBytes = BinaryUtil.ReadBytes(ref bytes, offset, 16);
            return new Guid(guidBytes);
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

    public class KeyValuePairFormatter<TKey, TValue> : Formatter<KeyValuePair<TKey, TValue>>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, KeyValuePair<TKey, TValue> value)
        {
            var startOffset = offset;
            offset += Formatter<TKey>.Default.Serialize(ref bytes, offset, value.Key);
            offset += Formatter<TValue>.Default.Serialize(ref bytes, offset, value.Value);
            return offset - startOffset;
        }

        public override KeyValuePair<TKey, TValue> Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            int size;
            byteSize = 0;

            var key = Formatter<TKey>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            var value = Formatter<TValue>.Default.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;

            return new KeyValuePair<TKey, TValue>(key, value);
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

