using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class KeyTupleFormatterTest
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            var test = new KeyTupleFormatterTest();

            UnitTestRoot.AddTest("KeyTupleFormatterTest", "KeyTupleTest", test.KeyTupleTest);
        }


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
                var t1 = KeyTuple.Create(100, 200, 300, "aaa", "bbb", IntEnum.Orange);
                var t2 = ZeroFormatterSerializer.Convert(t1);

                t2.Item1.Is(t1.Item1);
                t2.Item2.Is(t1.Item2);
                t2.Item3.Is(t1.Item3);
                t2.Item4.Is(t1.Item4);
                t2.Item5.Is(t1.Item5);
                t2.Item6.Is(t1.Item6);
            }
        }
    }
}