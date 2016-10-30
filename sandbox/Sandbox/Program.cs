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

            var ff = ZeroFormatter.Formatters.Formatter<MyClass>.Default;

            var rrrr = typeof(Console).GetMethods().Where(x=>x.Name == "WriteLine");


            
            Console.WriteLine(ff.GetType().FullName);


            var bs = ZeroFormatter.ZeroFormatterSerializer.Serialize(new MyClass
            {
                Age = 1,
                FirstName = "hoge",
                LastName = "tako",
                List = new List<MogeMoge>(),
                Mone = MogeMoge.Orange
            });

            //var bs = Enumerable.Range(1, 100).Select(x => (byte)x).ToArray();

            bs = ZeroFormatterSerializer.Serialize(new Simple { I = 9999 });

            //bs = ZeroFormatterSerializer.Serialize((Simple)null);

            //var f = ZeroFormatter.ZeroFormatterSerializer.Deserialize<Simple>(bs);


            var simpleFormatter = ZeroFormatter.Formatters.Formatter<Simple>.Default;
            var size = 0;


            var ___ = simpleFormatter.Deserialize(ref bs, 0, new DirtyTracker(0), out size);


            //var huga = f.GetType().GetConstructors()[0].Invoke(new object[] { new DirtyTracker(0), new ArraySegment<byte>(bs) });

            //Console.WriteLine(f.FirstName);
            //ZeroFormatter.ZeroFormatterSerializer.Deserialize<MyStruct?>(f);


            //var d = ZeroFormatter.Formatters.Formatter<MyStruct>.Default;

            //var ff = ZeroFormatter.Formatters.Formatter<MyStruct?>.Default;

            //Console.WriteLine(ff.GetLength());
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

