using Sandbox.Shared;
using RuntimeUnitTestToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Formatters;
using ZeroFormatter.Segments;
using UnityEngine;

namespace ZeroFormatter.Tests
{
    public class UnionTest
    {
        public void UnionLike()
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
                        Assert.Fail("invalid");
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
                        Assert.Fail("invalid");
                        break;
                }
            }
        }


        public void StandardUnionWithFallback()
        {
            var uinon = ZeroFormatterSerializer.Serialize<Sandbox.Shared.IStandardUnion>(new Sandbox.Shared.MessageA1());
            var hogehoge = ZeroFormatterSerializer.Deserialize<Sandbox.Shared.IStandardUnion>(uinon);
            hogehoge.IsInstanceOf<Sandbox.Shared.MessageA1>();

            Internal.BinaryUtil.WriteInt32(ref uinon, 1, 212);
            var zzzzz = ZeroFormatterSerializer.Deserialize<Sandbox.Shared.IStandardUnion>(uinon);
            zzzzz.IsInstanceOf<Sandbox.Shared.UnknownMessage1>();
        }

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

    }
}
