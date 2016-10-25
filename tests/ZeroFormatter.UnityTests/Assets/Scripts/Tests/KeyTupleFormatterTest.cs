using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using RuntimeUnitTestToolkit;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class KeyTupleFormatterTest
    {
      
        [TestMethod]
        public void KeyTupleFormatter()
        {
            var kc = new KeyTupleCheck();
            kc.KeyTupleDictionary = new Dictionary<KeyTuple<int, string>, MyClass>
            {
                { KeyTuple.Create(1, "aaa"), new MyClass { Age = 10, FirstName = "hoge", LastName = "huga", MyList = new [] {1,10,100 } } },
                { KeyTuple.Create(9, "zzz"), new MyClass { Age = 20, FirstName = "hage", LastName = "hnga", MyList = new [] {3,44,200 } } },
                { KeyTuple.Create(4, "vda"), new MyClass { Age = 30, FirstName = "hbge", LastName = "hzga", MyList = new [] {4,33,300 } } }
            };

            var converted = ZeroFormatterSerializer.Convert(kc);

            converted.KeyTupleDictionary.Count.Is(3);

            var a = converted.KeyTupleDictionary[KeyTuple.Create(1, "aaa")];
            var b = converted.KeyTupleDictionary[KeyTuple.Create(9, "zzz")];
            var c = converted.KeyTupleDictionary[KeyTuple.Create(4, "vda")];

            a.Age.Is(10); a.FirstName.Is("hoge"); a.LastName.Is("huga"); a.MyList.IsCollection(1, 10, 100);
            b.Age.Is(20); b.FirstName.Is("hage"); b.LastName.Is("hnga"); b.MyList.IsCollection(3, 44, 200);
            c.Age.Is(30); c.FirstName.Is("hbge"); c.LastName.Is("hzga"); c.MyList.IsCollection(4, 33, 300);
        }
    }
}