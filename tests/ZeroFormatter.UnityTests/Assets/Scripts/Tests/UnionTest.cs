using Sandbox.Shared;
using RuntimeUnitTestToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Formatters;
using ZeroFormatter.Segments;

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
    }
}
