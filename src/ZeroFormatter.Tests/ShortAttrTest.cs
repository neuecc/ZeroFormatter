using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace AnotherNamespace
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal class ZeroFormattableAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class IndexAttribute : Attribute
    {
        public int Index { get; private set; }

        public IndexAttribute(int index)
        {
            this.Index = index;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class IgnoreFormatAttribute : Attribute
    {
    }
}

namespace ZeroFormatter.Tests
{
    [AnotherNamespace.ZeroFormattable]
    public class AttrSerializableTarget
    {
        [AnotherNamespace.Index(0)]
        public virtual int MyProperty0 { get; set; }
        [AnotherNamespace.IgnoreFormat]
        public virtual int MyProperty_ { get; set; }
        [AnotherNamespace.Index(1)]
        public virtual string MyProperty1 { get; set; }
    }


    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ShortAttrTest
    {
        [TestMethod]
        public void ShortAttrSerialize()
        {
            var c = new AttrSerializableTarget { MyProperty0 = 100, MyProperty_ = 9999, MyProperty1 = "aaa" };
            var v = ZeroFormatterSerializer.Convert(c);

            v.MyProperty0.Is(100);
            v.MyProperty_.Is(0);
            v.MyProperty1.Is("aaa");
        }
    }

    public enum MyFruit
    {

    }

    public class MyFruitFormatter : Formatter<MyFruit>
    {
        public override int? GetLength()
        {
            return sizeof(Int32);
        }

        public override int Serialize(ref byte[] bytes, int offset, MyFruit value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override MyFruit Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = sizeof(Int32);
            return (MyFruit)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }

    public class NullableMyFruitFormatter : Formatter<MyFruit?>
    {
        public override int? GetLength()
        {
            return sizeof(Int32) + 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, MyFruit? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override MyFruit? Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (MyFruit)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class MyFruitEqualityComparer<T> : IEqualityComparer<MyFruit>
    {
        public bool Equals(MyFruit x, MyFruit y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(MyFruit obj)
        {
            return (Int32)obj;
        }
    }
}
