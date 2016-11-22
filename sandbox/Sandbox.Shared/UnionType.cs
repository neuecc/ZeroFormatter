
using System;
using System.Collections.Generic;
using ZeroFormatter;
#pragma warning disable ZeroFormatterAnalyzer_PublicPropertyNeedsIndex // Lint of ZeroFormattable Type.
#pragma warning disable ZeroFormatterAnalyzer_PublicPropertyMustBeVirtual // Lint of ZeroFormattable Type.
#pragma warning disable ZeroFormatterAnalyzer_TypeMustBeZeroFormattable // Lint of ZeroFormattable Type.

namespace Sandbox.Shared
{
    public enum CharacterType
    {
        Human, Monster, Unknown
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

    [ZeroFormattable]
    public class HasUnionKlass
    {
        [Index(0)]
        public virtual IStandardUnion A { get; set; }
        [Index(1)]
        public virtual Character B { get; set; }
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

        public virtual IList<IEvent> Events { get; set; }
    }

    [DynamicUnion]
    public interface IEvent { }
    [ZeroFormattable]
    public class UnknownEvent : IEvent { }
    [ZeroFormattable]
    public class EventA : IEvent { }
    [ZeroFormattable]
    public class EventB : IEvent { }

}


#pragma warning restore ZeroFormatterAnalyzer_PublicPropertyNeedsIndex // Lint of ZeroFormattable Type.
#pragma warning restore ZeroFormatterAnalyzer_PublicPropertyMustBeVirtual // Lint of ZeroFormattable Type.
#pragma warning restore ZeroFormatterAnalyzer_TypeMustBeZeroFormattable // Lint of ZeroFormattable Type.
