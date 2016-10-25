using Sandbox;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;
using System.IO;

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

            var mc = new MyClass
            {
                Age = 222,
                FirstName = "a",
                LastName = "bbb",
                List = new [] { MogeMoge.Orange, MogeMoge.Apple },
                Mone = MogeMoge.Apple
            };

            var bytes= ZeroFormatterSerializer.Serialize(mc);
            var ms = new MemoryStream();
            ms.WriteByte(0);
            ms.WriteByte(0);
            ms.Write(bytes, 0, bytes.Length);

            var hogehoge = ms.ToArray();

            int size;
            var r = ZeroFormatter.Formatters.Formatter<MyClass>.Default.Deserialize(ref hogehoge, 2, new ZeroFormatter.Segments.DirtyTracker(2), out size);




            

        }
    }
}

