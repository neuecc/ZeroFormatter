using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Shared;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class UnionTest
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Union()
        {
            {
                var demon = new Monster { Race = "Demon", Power = 9999, Magic = 1000 };

                var data = ZeroFormatterSerializer.Serialize<Character>(demon);

                var union = ZeroFormatterSerializer.Deserialize<Character>(data);
                switch (union.Type)
                {
                    case CharacterType.Monster:
                        var demon2 = (Monster)union;
                        demon2.Race.Is("Demon");
                        demon2.Power.Is(9999);
                        demon2.Magic.Is(1000);
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }

            {
                var human = new Human { Name = "Tokugawa", Age = 32, Faith = 9999 };

                var data = ZeroFormatterSerializer.Serialize<Character>(human);

                var union = ZeroFormatterSerializer.Deserialize<Character>(data);
                switch (union.Type)
                {
                    case CharacterType.Human:
                        var human2 = (Human)union;
                        human2.Name.Is("Tokugawa");
                        human2.Age.Is(32);
                        human2.Faith.Is(9999);
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }
        }

        [Union(typeof(MyA), typeof(MyB))]
        public abstract class MyUnion
        {
            [UnionKey]
            public abstract string Key { get; }
        }

        [ZeroFormattable]
        public class MyA : MyUnion
        {
            [IgnoreFormat]
            public override string Key
            {
                get
                {
                    return "takotako";
                }
            }

            [Index(0)]
            public virtual int Age { get; set; }
        }

        [ZeroFormattable]
        public class MyB : MyUnion
        {
            [IgnoreFormat]
            public override string Key
            {
                get
                {
                    return "hogehoge";
                }
            }

            [Index(0)]
            public virtual string Name { get; set; }
        }


        [TestMethod]
        public void StringUnion()
        {
            {
                var a = new MyA { Age = 9999 };

                var data = ZeroFormatterSerializer.Serialize<MyUnion>(a);

                var union = ZeroFormatterSerializer.Deserialize<MyUnion>(data);
                union.Key.Is("takotako");
                (union as MyA).Age.Is(9999);
            }

            {

                var b = new MyB { Name = "nano" };

                var data = ZeroFormatterSerializer.Serialize<MyUnion>(b);

                var union = ZeroFormatterSerializer.Deserialize<MyUnion>(data);
                union.Key.Is("hogehoge");
                (union as MyB).Name.Is("nano");
            }
        }
    }
}
