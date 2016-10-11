using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [ZeroFormattable]
    public class MyClass
    {
        [Index(0)]
        public virtual int Age { get; set; }

        [Index(1)]
        public virtual string FirstName { get; set; }

        [Index(2)]
        public virtual string LastName { get; set; }

        [IgnoreFormat]
        public string FullName { get { return FirstName + LastName; } }

        [Index(3)]
        public virtual int HogeMoge { get; protected set; }
    }

    public class MyClass_ObjectSegment : MyClass, IZeroFormatterSegment
    {
        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;

        // generated mutable segements
        readonly StringSegment _lastName;
        readonly StringSegment _firstName;

        public override int Age
        {
            get
            {
                var array = __originalBytes.Array;
                return BinaryUtil.ReadInt32(ref array, ObjectSegmentHelper.GetOffset(__originalBytes, 0));
            }
            set
            {
                var array = __originalBytes.Array;
                BinaryUtil.WriteInt32(ref array, ObjectSegmentHelper.GetOffset(__originalBytes, 0), value);
            }
        }

        public override string FirstName
        {
            get
            {
                return _firstName.Value;
            }

            set
            {
                _firstName.Value = value;
            }
        }

        public override string LastName
        {
            get
            {
                return _lastName.Value;
            }

            set
            {
                _lastName.Value = value;
            }
        }

        public override int HogeMoge
        {
            get
            {
                var array = __originalBytes.Array;
                return BinaryUtil.ReadInt32(ref array, ObjectSegmentHelper.GetOffset(__originalBytes, 3));
            }

            protected set
            {
                var array = __originalBytes.Array;
                BinaryUtil.WriteInt32(ref array, ObjectSegmentHelper.GetOffset(__originalBytes, 3), value);
            }
        }

        public MyClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            var __array = originalBytes.Array;

            // Auto Generate Area
            _firstName = new StringSegment(__tracker, new ArraySegment<byte>(originalBytes.Array, ObjectSegmentHelper.GetOffset(originalBytes, 1), 0));
            _lastName = new StringSegment(__tracker, new ArraySegment<byte>(originalBytes.Array, ObjectSegmentHelper.GetOffset(originalBytes, 2), 0));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (4 + 4 * 4);

                // Auto Generate Area
                BinaryUtil.WriteInt32(ref targetBytes, startOffset + (4 + 4 * 0), offset);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, offset, __originalBytes, 0);

                BinaryUtil.WriteInt32(ref targetBytes, startOffset + (4 + 4 * 1), offset);
                offset += ObjectSegmentHelper.SerializeSegment<string>(ref targetBytes, offset, _firstName);

                BinaryUtil.WriteInt32(ref targetBytes, startOffset + (4 + 4 * 2), offset);
                offset += ObjectSegmentHelper.SerializeSegment<string>(ref targetBytes, offset, _lastName);

                BinaryUtil.WriteInt32(ref targetBytes, startOffset + (4 + 4 * 3), offset);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, offset, __originalBytes, 3);

                var writeSize = offset - startOffset;
                BinaryUtil.WriteInt32(ref targetBytes, startOffset, writeSize);

                return writeSize;
            }
            else
            {
                var array = __originalBytes.Array;
                var copyCount = BinaryUtil.ReadInt32(ref array, __originalBytes.Offset);
                BinaryUtil.EnsureCapacity(ref targetBytes, offset, copyCount);
                Buffer.BlockCopy(__originalBytes.Array, __originalBytes.Offset, targetBytes, offset, copyCount);

                return copyCount;
            }
        }
    }

    public class MyClassFormatter : Formatter<MyClass>
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, MyClass value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else
            {
                var startOffset = offset;
                offset += (4 + 4 * 4);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (4 + 4 * 0), offset);
                offset += Formatter<int>.Default.Serialize(ref bytes, offset, value.Age);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (4 + 4 * 1), offset);
                offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.FirstName);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (4 + 4 * 2), offset);
                offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.LastName);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (4 + 4 * 3), offset);
                offset += Formatter<int>.Default.Serialize(ref bytes, offset, value.HogeMoge);

                var writeSize = offset - startOffset;
                BinaryUtil.WriteInt32(ref bytes, startOffset, writeSize);

                return writeSize;
            }
        }

        public override MyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            return new MyClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }


    [TestClass]
    public class ObjectFormatterTest
    {
        [TestMethod]
        public void ObjectFormatter()
        {
            var tracker = new DirtyTracker();
            var mc = new MyClass
            {
                Age = 999,
                FirstName = "hoge",
                LastName = "hugahgua",
                // HogeMoge = 10000
            };

            Formatter<MyClass>.Register(new MyClassFormatter());

            byte[] bytes = null;
            int size;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc);
            var mc2 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc.Age.Is(mc2.Age);
            mc.FirstName.Is(mc2.FirstName);
            mc.LastName.Is(mc2.LastName);

            bytes = null;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc2);
            var mc3 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc3.Age.Is(mc.Age);
            mc3.FirstName.Is(mc.FirstName);
            mc3.LastName.Is(mc.LastName);

            mc3.Age = 99999;
            mc3.FirstName = "aiueokakikukekosasisuseso";

            bytes = null;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc3);
            var mc4 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc4.Age.Is(99999);
            mc4.FirstName.Is("aiueokakikukekosasisuseso");
            mc4.LastName.Is("hugahgua");


            mc4.LastName = null;

            bytes = null;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc4);
            var mc5 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc5.Age.Is(99999);
            mc5.FirstName.Is("aiueokakikukekosasisuseso");
            mc5.LastName.IsNull();
        }

        [TestMethod]
        public void DynamicFormatterTest()
        {
            var dynamicFormatter = new DynamicObjectFormatter<MyClass>();

            byte[] bytes = null;
            int size;
            dynamicFormatter.Serialize(ref bytes, 0, new MyClass
            {
                Age = 999,
                FirstName = "hogehoge",
                LastName = "tako"
            });

            var generatedFormatter = new MyClassFormatter();
            var mc2 = generatedFormatter.Deserialize(ref bytes, 0, new DirtyTracker(), out size);


            mc2.Age.Is(999);
            mc2.FirstName.Is("hogehoge");
            mc2.LastName.Is("tako");
        }

        [TestMethod]
        public void DynamicSegmentTest()
        {
            var t = DynamicObjectSegmentBuilder<MyClass>.Build();


            var hugahugahuga = t.GetConstructor(new[] { typeof(DirtyTracker), typeof(ArraySegment<byte>) });

            var array = new ArraySegment<byte>(new byte[] { 1, 2, 3, 4, 5 });
            var tracker = new DirtyTracker();
            var hoge = hugahugahuga.Invoke(new object[] { tracker, array });


        }
    }
}
