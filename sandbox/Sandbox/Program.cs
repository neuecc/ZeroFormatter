using Sandbox;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;
using System.IO;
using ZeroFormatter.Segments;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using Sandbox.Shared;
using Sandbox.Shared.Bar;




namespace Sandbox
{


    [ZeroFormattable]
    public class Simple
    {
        [Index(0)]
        public virtual int I { get; set; }
    }

    public enum MogeMoge
    {
        Apple, Orange
    }



    public enum MyEnum
    {
        Furit, Alle
    }

    [ZeroFormattable]
    public class MyGuid
    {
        [Index(0)]
        public virtual Guid MyProperty { get; set; }
        [Index(1)]
        public virtual Uri MyProperty2 { get; set; }
        [Index(2)]
        public virtual KeyValuePair<string, int> MyProperty3 { get; set; }
    }

    [ZeroFormattable]
    public class Version1
    {
        [Index(0)]
        public virtual int Prop1 { get; set; }
        [Index(1)]
        public virtual int Prop2 { get; set; }
    }

    [ZeroFormattable]
    public class Version2
    {
        [Index(0)]
        public virtual int Prop1 { get; set; }
        [Index(1)]
        public virtual int Prop2 { get; set; }
        // You can add new property. If deserialize from old data, value is assigned default(T).
        [Index(2)]
        public virtual int NewType { get; set; }
    }


    [Serializable]
    [ZeroFormattable]
    public struct LargeStruct
    {
        private static void A(bool b)
        {
            if (!b)
                throw new Exception();
        }

        [Index(0)]
        private ulong m_val1;
        [Index(1)]
        private ulong m_val2;
        [Index(2)]
        private ulong m_val3;
        [Index(3)]
        private ulong m_val4;

        private static ulong counter;

        public LargeStruct(ulong m_val1, ulong m_val2, ulong m_val3, ulong m_val4)
        {
            this.m_val1 = m_val1;
            this.m_val2 = m_val2;
            this.m_val3 = m_val3;
            this.m_val4 = m_val4;
        }

        public static LargeStruct Create()
        {
            return new LargeStruct
            {
                m_val1 = counter++,
                m_val2 = ulong.MaxValue - counter++,
                m_val3 = counter++,
                m_val4 = ulong.MaxValue - counter++
            };
        }

        public static void Compare(LargeStruct a, LargeStruct b)
        {
            A(a.m_val1 == b.m_val1);
            A(a.m_val2 == b.m_val2);
            A(a.m_val3 == b.m_val3);
            A(a.m_val4 == b.m_val4);
        }
    }


    [ZeroFormattable]
    public class Abc
    {
        [Index(0)]
        public virtual int A { get; set; }
        [Index(1)]
        public virtual int BA { get; set; }
    }


    [DynamicUnion]
    public abstract class MyClass
    {

    }


    [DynamicUnion] // root of DynamicUnion
    public class MessageBase
    {

    }

    public class UnknownMessage : MessageBase { }

    [ZeroFormattable]
    public class MessageA : MessageBase { }

    [ZeroFormattable]
    public class MessageB : MessageBase
    {
        [Index(0)]
        public virtual IList<IEvent> Events { get; set; }
    }


    // If new type received, return new UnknownEvent()
    [Union(subTypes: new[] { typeof(MailEvent), typeof(NotifyEvent) }, fallbackType: typeof(UnknownEvent))]
    public interface IEvent
    {
        [UnionKey]
        byte Key { get; }
    }

    [ZeroFormattable]
    public class MailEvent : IEvent
    {
        [IgnoreFormat]
        public byte Key => 1;

        [Index(0)]
        public string Message { get; set; }
    }

    [ZeroFormattable]
    public class NotifyEvent : IEvent
    {
        [IgnoreFormat]
        public byte Key => 1;

        [Index(0)]
        public bool IsCritical { get; set; }
    }

    [ZeroFormattable]
    public class UnknownEvent : IEvent
    {
        [IgnoreFormat]
        public byte Key => 0;
    }




    public class CustomSerializationContext : ITypeResolver
    {
        public bool IsUseBuiltinSerializer
        {
            get
            {
                return true;
            }
        }

        public object ResolveFormatter(Type type)
        {
            // same as Formatter.AppendFormatResolver.
            return null;
        }

        public void RegisterDynamicUnion(Type unionType, DynamicUnionResolver resolver)
        {
            // same as Formatter.AppendDynamicUnionResolver
        }
    }


    [ZeroFormattable]
    public class ArrayDirty
    {
        public static ArrayDirty Instance { get; private set; }

        [Index(0)]
        public virtual Nest MyProperty { get; set; }

        public ArrayDirty()
        {
            Instance = this;
        }
    }

    [ZeroFormattable]
    public class Nest
    {
        [Index(0)]
        public virtual int[] MyProperty { get; set; }
    }


    [ZeroFormattable]
    public struct ZeroA
    {
    }

    [ZeroFormattable]
    public class StringZ
    {
        [Index(0)]
        public virtual string MyProp { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c = ZeroFormatterSerializer.Convert(new StringZ { MyProp = "a" });
            c.MyProp = "b";

            var re = ZeroFormatterSerializer.Convert(c);

            Console.WriteLine(re.MyProp);
        }
    }

    public interface Imessage
    {
    }


    [Union(new[] { typeof(Human), typeof(Monster) }, typeof(Unknown))]
    public abstract class Character
    {
        [UnionKey]
        public abstract CharacterType Type { get; }
    }

    public class Unknown : Character
    {
        public override CharacterType Type
        {
            get
            {
                return CharacterType.Unknown;
            }
        }
    }

    [ZeroFormattable]
    public class Human : Character
    {
        // UnionKey value must return constant value(Type is free, you can use int, string, enum, etc...)
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
        public virtual DateTime Birth { get; set; }

        [Index(2)]
        public virtual int Age { get; set; }

        [Index(3)]
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



    [ZeroFormattable]
    public struct MyStruct
    {
        [Index(0)]
        public int MyProperty1 { get; set; }
        [Index(1)]
        public int MyProperty2 { get; set; }
        public MyStruct(int x, int y)
        {
            MyProperty1 = x;
            MyProperty2 = y;
        }
    }

    [ZeroFormattable]
    public class ErrorClass
    {
        [Index(0)]
        public int MyProperty1;
    }

    public class UriFormatter<TTypeResolver> : Formatter<TTypeResolver, Uri>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            // If size is variable, return null.
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, Uri value)
        {
            // Formatter<T> can get child serializer
            return Formatter<TTypeResolver, string>.Default.Serialize(ref bytes, offset, value.ToString());
        }

        public override Uri Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            var uriString = Formatter<TTypeResolver, string>.Default.Deserialize(ref bytes, offset, tracker, out byteSize);
            return (uriString == null) ? null : new Uri(uriString);
        }
    }

}