using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sandbox.DotNetCore
{
    public enum MyEnum
    {
        Furit, Alle
    }

    public class Program
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

        public static void Main(string[] args)
        {
            /*
            var e = ZeroFormatter.DotNetCore.Comparers.ZeroFormatterEqualityComparer<MyEnum>.Default;

            Console.WriteLine(e.GetType().Name);
            */

            Hoge<MyEnum>(MyEnum.Alle);

        }
    }
}
