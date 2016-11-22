using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Shared;
using System.Collections.Generic;

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

        [TestMethod]
        public void DynamicUnionTest()
        {
            Formatters.Formatter.AppendDynamicUnionResolver((unionType, resolver) =>
            {
                if (unionType == typeof(MessageBase))
                {
                    resolver.RegisterUnionKeyType(typeof(string));
                    resolver.RegisterSubType("A", typeof(MessageA));
                    resolver.RegisterSubType("b", typeof(MessageB));
                    resolver.RegisterFallbackType(typeof(UnknownMessage));
                }
                else if (unionType == typeof(IEvent))
                {
                    resolver.RegisterUnionKeyType(typeof(byte));
                    resolver.RegisterSubType((byte)13, typeof(EventA));
                    resolver.RegisterSubType((byte)234, typeof(EventB));
                    resolver.RegisterFallbackType(typeof(UnknownEvent));
                }
            });


            {
                var union = ZeroFormatterSerializer.Serialize<IEvent>(new EventA());
                var aaa = ZeroFormatterSerializer.Deserialize<IEvent>(union);
                aaa.IsInstanceOf<EventA>();
                var bbbUnion = ZeroFormatterSerializer.Serialize<IEvent>(new EventB());
                var bbb = ZeroFormatterSerializer.Deserialize<IEvent>(bbbUnion);
                bbb.IsInstanceOf<EventB>();

                bbbUnion[4] = 24; // unknown
                var ccc = ZeroFormatterSerializer.Deserialize<IEvent>(bbbUnion);
                ccc.IsInstanceOf<UnknownEvent>();
            }

            {
                var union = ZeroFormatterSerializer.Serialize<MessageBase>(new MessageA());
                var aaa = ZeroFormatterSerializer.Deserialize<MessageBase>(union);
                aaa.IsInstanceOf<MessageA>();
                var bbbUnion = ZeroFormatterSerializer.Serialize<MessageBase>(new MessageB()
                {
                    Events = new List<IEvent> { (IEvent)new EventA(), (IEvent)new EventB(), (IEvent)new EventA() }
                });
                var bbb = ZeroFormatterSerializer.Deserialize<MessageBase>(bbbUnion);
                bbb.IsInstanceOf<MessageB>();

                bbbUnion[4] = 13;
                var ccc = ZeroFormatterSerializer.Deserialize<MessageBase>(bbbUnion);
                ccc.IsInstanceOf<UnknownMessage>();
            }
        }


        [TestMethod]
        public void StandardUnionWithFallback()
        {

            var uinon = ZeroFormatterSerializer.Serialize<IStandardUnion>(new MessageA1());
            var hogehoge = ZeroFormatterSerializer.Deserialize<IStandardUnion>(uinon);
            hogehoge.IsInstanceOf<MessageA1>();

            Internal.BinaryUtil.WriteInt32(ref uinon, 1, 212);
            var zzzzz = ZeroFormatterSerializer.Deserialize<IStandardUnion>(uinon);
            zzzzz.IsInstanceOf<UnknownMessage1>();
        }

        [TestMethod]
        public void IncludeWithFallback()
        {
            var huga = new Sandbox.Shared.IStandardUnion[]
            {
                (Sandbox.Shared.IStandardUnion)new Sandbox.Shared.MessageA1(),
                (Sandbox.Shared.IStandardUnion)new Sandbox.Shared.MessageB1(),
                (Sandbox.Shared.IStandardUnion)new Sandbox.Shared.MessageA1(),
                (Sandbox.Shared.IStandardUnion)new Sandbox.Shared.MessageB1(),
            };
            var ninon = ZeroFormatterSerializer.Serialize(huga);
            var hoge = ZeroFormatterSerializer.Deserialize<Sandbox.Shared.IStandardUnion[]>(ninon);

            hoge[0].IsInstanceOf<Sandbox.Shared.MessageA1>();
            hoge[1].IsInstanceOf<Sandbox.Shared.MessageB1>();
            hoge[2].IsInstanceOf<Sandbox.Shared.MessageA1>();
            hoge[3].IsInstanceOf<Sandbox.Shared.MessageB1>();

            Internal.BinaryUtil.WriteInt32(ref ninon, 28, 212);
            var hoge2 = ZeroFormatterSerializer.Deserialize<Sandbox.Shared.IStandardUnion[]>(ninon);
            hoge2[0].IsInstanceOf<Sandbox.Shared.MessageA1>();
            hoge2[1].IsInstanceOf<Sandbox.Shared.UnknownMessage1>();
            hoge2[2].IsInstanceOf<Sandbox.Shared.MessageA1>();
            hoge2[3].IsInstanceOf<Sandbox.Shared.MessageB1>();
        }


        [Union(new[] { typeof(UnknownMessage1), typeof(MessageA1), typeof(MessageB1) }, typeof(UnknownMessage1))]
        public interface IStandardUnion
        {
            [UnionKey]
            int A { get; }
        }

        [ZeroFormattable]
        public class UnknownMessage1 : IStandardUnion
        {
            [IgnoreFormat]
            public int A
            {
                get
                {
                    return -1;
                }
            }
        }

        [ZeroFormattable]
        public class MessageA1 : IStandardUnion
        {
            [IgnoreFormat]
            public int A
            {
                get
                {
                    return 1;
                }
            }
        }
        [ZeroFormattable]
        public class MessageB1 : IStandardUnion
        {
            [IgnoreFormat]
            public int A
            {
                get
                {
                    return 3;
                }
            }
        }


        [DynamicUnion]
        public class MessageBase { }

        public class UnknownMessage : MessageBase { }
        [ZeroFormattable]
        public class MessageA : MessageBase { }
        [ZeroFormattable]
        public class MessageB : MessageBase
        {
            [Index(0)]
            public virtual List<IEvent> Events { get; set; }
        }

        [DynamicUnion]
        public interface IEvent { }
        [ZeroFormattable]
        public class UnknownEvent : IEvent { }
        [ZeroFormattable]
        public class EventA : IEvent { }
        [ZeroFormattable]
        public class EventB : IEvent { }


        [ZeroFormattable]
        public class Hoge
        {

        }

        [ZeroFormattable]
        public class Huga
        {

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
