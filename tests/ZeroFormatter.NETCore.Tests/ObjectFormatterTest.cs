using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ZeroFormatter;
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

        [Index(4)]
        public virtual IList<int> MyList { get; set; }

        [IgnoreFormat]
        public int HugaHuga { get { return 100000; } }
    }

    public class MyClass_ObjectSegment : MyClass, IZeroFormatterSegment
    {
        readonly ArraySegment<byte> __originalBytes;
        readonly DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        // generated mutable segements
        CacheSegment<DefaultResolver, string> _lastName;
        CacheSegment<DefaultResolver, string> _firstName;
        IList<int> _myList; // no readonly

        // 0
        public override int Age
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<DefaultResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<DefaultResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
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

        // 2
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

        // 3
        public override int HogeMoge
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<DefaultResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            protected set
            {
                ObjectSegmentHelper.SetFixedProperty<DefaultResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override IList<int> MyList
        {
            get
            {
                return this._myList;
            }

            set
            {
                __tracker.Dirty();
                this._myList = value;
            }
        }

        public MyClass_ObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;
            int __out;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, new[] { 4, 4 }); // embed schemaLastIndex, elementSizeSum = should calcurate

            // Auto Generate Area
            _firstName = new CacheSegment<DefaultResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _lastName = new CacheSegment<DefaultResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _myList = Formatter<DefaultResolver, IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 4, __binaryLastIndex, __tracker), __tracker, out __out);

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
                var lastIndex = 4; // schemaLastIndex
                var startOffset = offset;
                offset += (8 + 4 * (lastIndex + 1));

                // Auto Generate Area(incr index...)
                offset += ObjectSegmentHelper.SerializeFixedLength<DefaultResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<DefaultResolver, string>(ref targetBytes, startOffset, offset, 1, ref _firstName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<DefaultResolver, string>(ref targetBytes, startOffset, offset, 2, ref _lastName);
                offset += ObjectSegmentHelper.SerializeFixedLength<DefaultResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<DefaultResolver, IList<int>>(ref targetBytes, startOffset, offset, 4, _myList);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, lastIndex);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MyClassFormatter : Formatter<DefaultResolver, MyClass>
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
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var lastIndex = 4;
                var startOffset = offset;

                offset += (8 + 4 * (lastIndex + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<DefaultResolver, int>(ref bytes, startOffset, offset, 0, value.Age);
                offset += ObjectSegmentHelper.SerializeFromFormatter<DefaultResolver, string>(ref bytes, startOffset, offset, 1, value.FirstName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<DefaultResolver, string>(ref bytes, startOffset, offset, 2, value.LastName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<DefaultResolver, int>(ref bytes, startOffset, offset, 3, value.HogeMoge);
                offset += ObjectSegmentHelper.SerializeFromFormatter<DefaultResolver, IList<int>>(ref bytes, startOffset, offset, 4, value.MyList);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, lastIndex);
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

            Formatter<DefaultResolver, MyClass>.Register(new MyClassFormatter());

            byte[] bytes = null;
            int size;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc);
            var mc2 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            var getAge = mc2.Age;

            mc2.Age.Is(mc.Age);
            mc2.FirstName.Is(mc.FirstName);
            mc2.LastName.Is(mc.LastName);

            bytes = null;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc2);
            var mc3 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc3.Age.Is(mc.Age);
            mc3.FirstName.Is(mc.FirstName);
            mc3.LastName.Is(mc.LastName);

            mc3.Age = 99999;
            mc3.FirstName = "aiueokakikukekosasisuseso";

            bytes = null;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc3);
            var mc4 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc4.Age.Is(99999);
            mc4.FirstName.Is("aiueokakikukekosasisuseso");
            mc4.LastName.Is("hugahgua");


            mc4.LastName = null;

            bytes = null;
            Formatter<DefaultResolver, MyClass>.Default.Serialize(ref bytes, 0, mc4);
            var mc5 = Formatter<DefaultResolver, MyClass>.Default.Deserialize(ref bytes, 0, tracker, out size);

            mc5.Age.Is(99999);
            mc5.FirstName.Is("aiueokakikukekosasisuseso");
            mc5.LastName.IsNull();
        }

        [Fact]
        public void DynamicFormatterTest()
        {
            var dynamicFormatter = Formatters.Formatter<DefaultResolver, MyClass>.Default;

            byte[] bytes = null;
            var size = dynamicFormatter.Serialize(ref bytes, 0, new MyClass
            {
                Age = 999,
                FirstName = "hogehoge",
                LastName = "tako",
                MyList = new List<int> { 1, 10, 100, 1000 }
            });
            BinaryUtil.FastResize(ref bytes, size);


            var generatedFormatter = new MyClassFormatter();
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


        [ZeroFormattable]
        public class SkipIndex
        {
            [Index(1)]
            public virtual int MyProperty1 { get; set; }
            [Index(2)]
            public virtual int MyProperty2 { get; set; }

            [Index(3)]
            public virtual int MyProperty3 { get; set; }
            [Index(4)]
            public virtual IList<int> MyProperty4 { get; set; }
            [Index(5)]
            public virtual string MyProperty5 { get; set; }
        }

        [ZeroFormattable]
        public class OtherSchema1
        {
            [Index(1)]
            public virtual int MyProperty1 { get; set; }
        }

        [ZeroFormattable]
        public class OtherSchema2
        {
            [Index(3)]
            public virtual int MyProperty3 { get; set; }
        }

        [ZeroFormattable]
        public class OtherSchema3
        {
            [Index(3)]
            public virtual int MyProperty3 { get; set; }

            [Index(7)]
            public virtual double MyProperty7 { get; set; }

            [Index(8)]
            public virtual int? MyProperty8 { get; set; }

            [Index(10)]
            public virtual int MyProperty10 { get; set; }
        }

        [Fact]
        public void SkipIndexTest()
        {
            var c = new SkipIndex
            {
                MyProperty1 = 1111,
                MyProperty2 = 9999,
                MyProperty3 = 500,
                MyProperty5 = "ほぐあｈｚｇっｈれあｇはえ"
            };


            var bytes = ZeroFormatterSerializer.Serialize(c);
            var r = ZeroFormatterSerializer.Deserialize<SkipIndex>(bytes);

            r.MyProperty1.Is(1111);
            r.MyProperty2.Is(9999);
            r.MyProperty3.Is(500);
            r.MyProperty5.Is("ほぐあｈｚｇっｈれあｇはえ");

            var r_b = ZeroFormatterSerializer.Convert<SkipIndex>(r);

            r_b.MyProperty1.Is(1111);
            r_b.MyProperty2.Is(9999);
            r_b.MyProperty3.Is(500);
            r_b.MyProperty5.Is("ほぐあｈｚｇっｈれあｇはえ");



            var r2 = ZeroFormatterSerializer.Deserialize<OtherSchema1>(bytes);
            r2.MyProperty1.Is(1111);

            var r3 = ZeroFormatterSerializer.Deserialize<OtherSchema2>(bytes);
            r3.MyProperty3.Is(500);

            var r4 = ZeroFormatterSerializer.Deserialize<OtherSchema3>(bytes);
            r4.MyProperty7.Is(0);
            r4.MyProperty8.IsNull();
            r4.MyProperty10 = 0;

            r4.MyProperty3 = 3;
            r4.MyProperty8 = 99999999;
            r4.MyProperty7 = 12345.12345;

            r4.MyProperty10 = 54321;

            var moreBytes = ZeroFormatterSerializer.Serialize<OtherSchema3>(r4);
            var r5 = ZeroFormatterSerializer.Deserialize<OtherSchema3>(moreBytes);
            r5.MyProperty3.Is(3);
            r5.MyProperty7.Is(12345.12345);
            r5.MyProperty8.Value.Is(99999999);
            r5.MyProperty10.Is(54321);
        }

        [Fact]
        public void BinaryDoubleWrite()
        {
            byte[] bytes = null;

            BinaryUtil.WriteDouble(ref bytes, 0, 12345.12345);
            var newDouble = BinaryUtil.ReadDouble(ref bytes, 0);
            newDouble.Is(12345.12345);


            var newBytes = new byte[bytes.Length];
            Buffer.BlockCopy(bytes, 0, newBytes, 0, bytes.Length);
            var newDouble2 = BinaryUtil.ReadDouble(ref newBytes, 0);

            newBytes = null;
            Formatter<DefaultResolver, double>.Default.Serialize(ref newBytes, 0, 12345.12345);


            var pureBytes = new byte[bytes.Length];
            var hogehogehoge = BinaryUtil.ReadDouble(ref pureBytes, 0);

        }
    }
}
