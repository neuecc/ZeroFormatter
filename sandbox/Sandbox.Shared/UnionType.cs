
using System;
using ZeroFormatter;
#pragma warning disable ZeroFormatterAnalyzer_PublicPropertyNeedsIndex // Lint of ZeroFormattable Type.
#pragma warning disable ZeroFormatterAnalyzer_PublicPropertyMustBeVirtual // Lint of ZeroFormattable Type.

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


    [Union(typeof(SubTest1), typeof(SubTest2))]
    public abstract class Union2
    {
        [UnionKey]
        public abstract string UnionKeyDayo { get; }
    }

    public class SubTest1 : Union2
    {
        public override string UnionKeyDayo
        {
            get
            {
                return "AAA";
            }
        }
    }

    public class SubTest2 : Union2
    {
        public override string UnionKeyDayo
        {
            get
            {
                return "BBB";
            }
        }
    }
}


#pragma warning restore ZeroFormatterAnalyzer_PublicPropertyNeedsIndex // Lint of ZeroFormattable Type.
#pragma warning restore ZeroFormatterAnalyzer_PublicPropertyMustBeVirtual // Lint of ZeroFormattable Type.