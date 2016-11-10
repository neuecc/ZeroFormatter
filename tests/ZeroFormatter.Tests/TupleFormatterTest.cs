using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class TupleFormatterTest
    {
        [TestMethod]
        public void KeyTupleTest()
        {
            {
                var t1 = KeyTuple.Create(100, 200, 300);
                var t2 = ZeroFormatterSerializer.Convert(t1);

                t2.Item1.Is(t1.Item1);
                t2.Item2.Is(t1.Item2);
                t2.Item3.Is(t1.Item3);
            }
            {
                var t1 = KeyTuple.Create(100, 200, 300, "aaa", "bbb", MyEnum.Fruit);
                var t2 = ZeroFormatterSerializer.Convert(t1);

                t2.Item1.Is(t1.Item1);
                t2.Item2.Is(t1.Item2);
                t2.Item3.Is(t1.Item3);
                t2.Item4.Is(t1.Item4);
                t2.Item5.Is(t1.Item5);
                t2.Item6.Is(t1.Item6);
            }
        }


        [TestMethod]
        public void TupleTest()
        {
            {
                var t1 = Tuple.Create(100, 200, 300);
                var t2 = ZeroFormatterSerializer.Convert(t1);

                t2.Item1.Is(t1.Item1);
                t2.Item2.Is(t1.Item2);
                t2.Item3.Is(t1.Item3);
            }
            {
                var t1 = Tuple.Create(100, 200, 300, "aaa", "bbb", MyEnum.Fruit);
                var t2 = ZeroFormatterSerializer.Convert(t1);

                t2.Item1.Is(t1.Item1);
                t2.Item2.Is(t1.Item2);
                t2.Item3.Is(t1.Item3);
                t2.Item4.Is(t1.Item4);
                t2.Item5.Is(t1.Item5);
                t2.Item6.Is(t1.Item6);
            }
        }


        [TestMethod]
        public void KVPTest()
        {
            {
                var t1 = new KeyValuePair<int,int>(100, 300);
                var t2 = ZeroFormatterSerializer.Convert(t1);

                t2.Key.Is(t1.Key);
                t2.Value.Is(t1.Value);
            }
        }

        public enum MyEnum
        {
            Fruit, Apple
        }
    }


}