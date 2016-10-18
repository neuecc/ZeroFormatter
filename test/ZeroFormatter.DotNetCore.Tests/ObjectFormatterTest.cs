using System;
using System.Collections.Generic;
using Xunit;
using ZeroFormatter.DotNetCore.Formatters;
using ZeroFormatter.DotNetCore.Internal;
using ZeroFormatter.DotNetCore.Segments;

namespace ZeroFormatter.DotNetCore.Tests
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


        [Index(4)]
        public virtual IList<int> MyList { get; set; }


        [IgnoreFormat]
        public int HugaHuga { get { return 100000; } }
    }

    public class MyClass_ObjectSegment : MyClass, IZeroFormatterSegment
    {
        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __lastIndex;

        // generated mutable segements
        readonly CacheSegment<string> _lastName;
        readonly CacheSegment<string> _firstName;
        readonly IList<int> _myList;

        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, value);
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
                return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 3, __tracker);
            }
            protected set
            {
                ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, value);
            }
        }

        public override IList<int> MyList
        {
            get
            {
                return base.MyList;
            }

            set
            {
                __tracker.Dirty();
                base.MyList = value;
            }
        }

        public MyClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__lastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            // Auto Generate Area
            _firstName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __lastIndex));
            _lastName = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __lastIndex));
            _myList = Formatter<IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4), __tracker, out __out);
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
                offset += (8 + 4 * (__lastIndex + 1));
                
                // Auto Generate Area
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __originalBytes);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _firstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 2, _lastName);
                offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __originalBytes);
                offset += ObjectSegmentHelper.SerializeSegment<IList<int>>(ref targetBytes, startOffset, offset, 4, _myList);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, __lastIndex);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClassFormatter : Formatter<MyClass>
    {
        readonly int lastIndex;

        public MyClassFormatter(int lastIndex) // generate
        {
            this.lastIndex = lastIndex;
        }

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
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;
                offset += (8 + 4 * (lastIndex + 1));

                BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * 0), offset);
                offset += Formatter<int>.Default.Serialize(ref bytes, offset, value.Age);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * 1), offset);
                offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.FirstName);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * 2), offset);
                offset += Formatter<string>.Default.Serialize(ref bytes, offset, value.LastName);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * 3), offset);
                offset += Formatter<int>.Default.Serialize(ref bytes, offset, value.HogeMoge);

                BinaryUtil.WriteInt32(ref bytes, startOffset + (8 + 4 * 4), offset);
                offset += Formatter<IList<int>>.Default.Serialize(ref bytes, offset, value.MyList);

                var writeSize = offset - startOffset;
                BinaryUtil.WriteInt32(ref bytes, startOffset, writeSize);
                BinaryUtil.WriteInt32(ref bytes, startOffset + 4, lastIndex);
                return writeSize;
            }
        }

        public override MyClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MyClass_ObjectSegment(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }


    public class ObjectFormatterTest
    {
        [Fact]
        public void ObjectFormatter()
        {
            var tracker = new DirtyTracker();
            var mc = new MyClass
            {
                Age = 999,
                FirstName = "hoge",
                LastName = "hugahgua",
                MyList = new List<int> { 1, 10, 100, 1000 }
            };

            Formatter<MyClass>.Register(new MyClassFormatter(4));

            byte[] bytes = null;
            int size;
            Formatter<MyClass>.Default.Serialize(ref bytes, 0, mc);
            var mc2 = Formatter<MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            var getAge = mc2.Age;

            mc2.Age.Is(mc.Age);
            mc2.FirstName.Is(mc.FirstName);
            mc2.LastName.Is(mc.LastName);

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

        [Fact]
        public void DynamicFormatterTest()
        {
            var dynamicFormatter = new DynamicObjectFormatter<MyClass>();

            byte[] bytes = null;
            var size = dynamicFormatter.Serialize(ref bytes, 0, new MyClass
            {
                Age = 999,
                FirstName = "hogehoge",
                LastName = "tako",
                MyList = new List<int> { 1, 10, 100, 1000 }
            });
            BinaryUtil.FastResize(ref bytes, size);


            var generatedFormatter = new MyClassFormatter(4);
            var mc2 = generatedFormatter.Deserialize(ref bytes, 0, new DirtyTracker(), out size);


            mc2.Age.Is(999);
            mc2.FirstName.Is("hogehoge");
            mc2.LastName.Is("tako");

            var mc3 = dynamicFormatter.Deserialize(ref bytes, 0, new DirtyTracker(), out size);
            mc3.Age.Is(999);
            mc3.FirstName.Is("hogehoge");
            mc3.LastName.Is("tako");

            mc3.Age = 9;
            mc3.LastName = "chop";
            mc3.MyList.Add(9999);

            bytes = null;
            dynamicFormatter.Serialize(ref bytes, 0, mc3);
            var mc4 = dynamicFormatter.Deserialize(ref bytes, 0, new DirtyTracker(), out size);

            mc4.Age.Is(9);
            mc4.LastName.Is("chop");
            mc4.MyList.Is(1, 10, 100, 1000, 9999);
        }
    }
}
