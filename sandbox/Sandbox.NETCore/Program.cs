using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZeroFormatter.Comparers;
using ZeroFormatter;

namespace Sandbox.DotNetCore
{
    public enum MyEnum
    {
        Furit, Alle
    }

    [ZeroFormattable]
    public class Test
    {
        [Index(0)]
        public virtual int MyProperty1 { get; set; }
        [Index(1)]
        public virtual IList<int> MyProperty2 { get; set; }
        [Index(2)]
        public virtual IDictionary<KeyTuple<int, string>, int> MyProperty3 { get; set; }
        [Index(3)]
        public virtual string MyProperty4 { get; set; }
    }

    public class Program
    {
        static int IntGetHashCode(int x) { return x; }
        static Int32 Identity(Int32 x) { return x; }

        static void Hoge<T>(T t)
        {

            Func<int, int> getHash = IntGetHashCode;

            //
            var e = ZeroFormatterEqualityComparer<MyEnum>.Default;



            Console.WriteLine(e.Equals(MyEnum.Alle, MyEnum.Alle));

        }

        public static void Main(string[] args)
        {
            var methods = typeof(ZeroFormatterSerializer).GetTypeInfo().GetMethods();

            foreach (var item in methods)
            {
                Console.WriteLine(item.Name + ":" + string.Join(", ", item.GetParameters().Select(x => x.Name)));
            }

        }
    }
}
