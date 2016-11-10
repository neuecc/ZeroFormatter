
using System;
using ZeroFormatter;

namespace Sandbox.Shared
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
}
