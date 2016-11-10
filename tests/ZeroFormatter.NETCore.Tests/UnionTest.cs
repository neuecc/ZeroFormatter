using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ZeroFormatter.Internal;

namespace ZeroFormatter.DotNetCore.Tests
{
    public enum CharacterType
    {
        Human, Monster
    }

    [Union(typeof(Human), typeof(Monster))]
    public abstract class Character
    {
        [UnionKey]
        public abstract CharacterType Type { get; }
    }

    [ZeroFormattable]
    public class Human : Character
    {
        [IgnoreFormat]
        public override CharacterType Type
        {
            get
            {
                return CharacterType.Human;
            }
        }

        [Index(0)]
        public virtual string Name { get; set; }

        [Index(1)]
        public virtual int Age { get; set; }

        [Index(2)]
        public virtual int Faith { get; set; }
    }

    [ZeroFormattable]
    public class Monster : Character
    {
        [IgnoreFormat]
        public override CharacterType Type
        {
            get
            {
                return CharacterType.Monster;
            }
        }

        [Index(0)]
        public virtual string Race { get; set; }

        [Index(1)]
        public virtual int Power { get; set; }

        [Index(2)]
        public virtual int Magic { get; set; }
    }

    public class UnionTest
    {
        [Fact]
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
                        throw new Exception("fail");
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
                        throw new Exception("fail");
                }
            }
        }
    }
}
