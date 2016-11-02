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
    class Program
    {
        static int IntGetHashCode(int x) { return x; }
        static Int32 Identity(Int32 x) { return x; }

        static void Hoge<T>(T t)
        {

            Func<int, int> getHash = IntGetHashCode;

            //
            var aaa = getHash.GetMethodInfo().CreateDelegate(typeof(Func<T, int>));
            //var GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();



            Func<Int32, Int32> identity = Identity;
            var serializeCast = identity.GetMethodInfo().CreateDelegate(typeof(Func<T, Int32>)) as Func<T, Int32>;



            Console.WriteLine(serializeCast(t));

        }

        static byte[] Huga<T>(T obj)
        {
            return null;
        }

        static void HUga<T>()
        {
            //Func<T, byte[]> invoke = Huga<T>;
            //Func<object, byte[]> invoke2 = invoke;



        }


        static void Main(string[] args)
        {
            // var xs = ZeroFormatterSerializer.Serialize(1000);

//            Encoding.UTF8.GetByteCount();

            var f = ZeroFormatter.Formatters.Formatter<IList<MyStruct>>.Default;

            Console.WriteLine(f.GetLength());
            byte[] bytes = null;
            f.Serialize(ref bytes, 0,new[] { new MyStruct { MyProperty1 = 10, MyProperty2 = 99 } });
            Console.WriteLine(bytes.Length);
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
}

