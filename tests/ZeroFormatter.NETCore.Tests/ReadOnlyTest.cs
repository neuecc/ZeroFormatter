using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ZeroFormatter.DotNetCore.Tests
{
    public class ReadOnly
    {
        [ZeroFormattable]
        public class MyClass
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

        [Fact]
        public void Direct()
        {
            {
                IReadOnlyList<int> list = new List<int> { 1, 10, 100, 1000 };
                var converted = ZeroFormatterSerializer.Convert(list);
                converted.Is(1, 10, 100, 1000);
            }
            {
                IReadOnlyDictionary<int, string> dict = new Dictionary<int, string>
                {
                    {1, "hoge" },
                    {100, "foo" },
                    {1000, "bar" },
                };
                var converted = ZeroFormatterSerializer.Convert(dict);
                var result = converted.OrderBy(x => x.Key).ToArray();
                result[0].Key.Is(1); result[0].Value.Is("hoge");
                result[1].Key.Is(100); result[1].Value.Is("foo");
                result[2].Key.Is(1000); result[2].Value.Is("bar");
            }
        }

        [Fact]
        public void Class()
        {
            var mc = new MyClass
            {
                MyReadOnlyListOne = new List<int> { 1, 10, 100, 1000 },
                MyReadOnlyListTwo = new string[] { "a", "bcde", "fghijklmnop" },
                MyReadOnlyDictOne = new Dictionary<int, string> { { 0, "a" }, { 100, "bcd" } },
                MyReadOnlyDictTwo = new Dictionary<KeyTuple<int, string>, string> { { KeyTuple.Create(10, "aiueo"), "AAA" }, { KeyTuple.Create(999, "nano"), "sa" } }
            };

            var converted = ZeroFormatterSerializer.Convert(mc);
            converted.MyReadOnlyListOne.Is(1, 10, 100, 1000);
            converted.MyReadOnlyListTwo.Is("a", "bcde", "fghijklmnop");
            var r1 = converted.MyReadOnlyDictOne.OrderBy(x => x.Key).ToArray();
            r1[0].Key.Is(0); r1[0].Value.Is("a");
            r1[1].Key.Is(100); r1[1].Value.Is("bcd");

            var r2 = converted.MyReadOnlyDictTwo.OrderBy(x => x.Key.Item1).ToArray();
            r2[0].Key.Is(KeyTuple.Create(10, "aiueo")); r2[0].Value.Is("AAA");
            r2[1].Key.Is(KeyTuple.Create(999, "nano")); r2[1].Value.Is("sa");
        }
    }
}