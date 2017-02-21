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

    [ZeroFormattable]
    public class WhatC
    {
        [Index(0)]
        public virtual IReadOnlyList<int> MyReadOnlyListOne { get; set; }
        [Index(1)]
        public virtual IReadOnlyList<string> MyReadOnlyListTwo { get; set; }
        [Index(2)]
        public virtual IReadOnlyDictionary<int, string> MyReadOnlyDictOne { get; set; }
        [Index(3)]
        public virtual IReadOnlyDictionary<KeyTuple<int, string>, string> MyReadOnlyDictTwo { get; set; }
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
            var mc = new WhatC
            {
                MyReadOnlyListOne = new List<int> { 1, 10, 100, 1000 },
                MyReadOnlyListTwo = new string[] { "a", "bcde", "fghijklmnop" },
                MyReadOnlyDictOne = new Dictionary<int, string> { { 0, "a" }, { 100, "bcd" } },
                MyReadOnlyDictTwo = new Dictionary<KeyTuple<int, string>, string> { { KeyTuple.Create(10, "aiueo"), "AAA" }, { KeyTuple.Create(999, "nano"), "sa" } }
            };

            var converted = ZeroFormatterSerializer.Convert(mc);
            var huga = converted.MyReadOnlyListOne;
            Console.WriteLine(huga[0]);
        }
    }
}
