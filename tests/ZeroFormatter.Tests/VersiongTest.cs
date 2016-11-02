using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;
using ZeroFormatter.Segments;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class VersiongTest
    {

        [ZeroFormattable]
        public class Standard
        {
            [Index(0)]
            public virtual int MyProperty0 { get; set; }
            [Index(3)]
            public virtual int MyProperty3 { get; set; }
        }


        [ZeroFormattable]
        public class Large
        {
            [Index(0)]
            public virtual int MyProperty0 { get; set; }
            [Index(3)]
            public virtual int MyProperty3 { get; set; }
            [Index(4)]
            public virtual IList<string> MyProperty4 { get; set; }
            [Index(5)]
            public virtual long MyProperty5 { get; set; }
            [Index(6)]
            public virtual string MyProperty6 { get; set; }
        }

        public class SmallObjectSegment : global::Sandbox.Shared.Small, IZeroFormatterSegment
        {
            static readonly int[] __elementSizes = new int[] { 4, 0, 0, 4 };

            readonly ArraySegment<byte> __originalBytes;
            readonly DirtyTracker __tracker;
            readonly int __binaryLastIndex;
            readonly byte[] __extraFixedBytes;

            readonly CacheSegment<string> _MyProperty1;
            global::System.Collections.Generic.IList<int> _MyProperty2;

            // 0
            public override int MyProperty0
            {
                get
                {
                    return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
                }
                set
                {
                    ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
                }
            }

            // 1
            public override string MyProperty1
            {
                get
                {
                    return _MyProperty1.Value;
                }
                set
                {
                    _MyProperty1.Value = value;
                }
            }

            // 2
            public override global::System.Collections.Generic.IList<int> MyProperty2
            {
                get
                {
                    return _MyProperty2;
                }
                set
                {
                    __tracker.Dirty();
                    _MyProperty2 = value;
                }
            }

            // 3
            public override int MyProperty3
            {
                get
                {
                    return ObjectSegmentHelper.GetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
                }
                set
                {
                    ObjectSegmentHelper.SetFixedProperty<int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
                }
            }


            public SmallObjectSegment(DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
            {
                var __array = originalBytes.Array;
                int __out;

                this.__originalBytes = originalBytes;
                this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
                this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

                this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

                _MyProperty1 = new CacheSegment<string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
                _MyProperty2 = Formatter<global::System.Collections.Generic.IList<int>>.Default.Deserialize(ref __array, ObjectSegmentHelper.GetOffset(originalBytes, 2, __binaryLastIndex, __tracker), __tracker, out __out);
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
                if (__extraFixedBytes != null || __tracker.IsDirty)
                {
                    var startOffset = offset;
                    offset += (8 + 4 * (3 + 1));

                    offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                    offset += ObjectSegmentHelper.SerializeCacheSegment<string>(ref targetBytes, startOffset, offset, 1, _MyProperty1);
                    offset += ObjectSegmentHelper.SerializeSegment<global::System.Collections.Generic.IList<int>>(ref targetBytes, startOffset, offset, 2, _MyProperty2);
                    offset += ObjectSegmentHelper.SerializeFixedLength<int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                    return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
                }
                else
                {
                    return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
                }
            }
        }


        [TestMethod]
        public void MyTestMethod()
        {
            var standard = ZeroFormatterSerializer.Serialize(new Standard { MyProperty0 = 100, MyProperty3 = 300 });


            var hoge = new SmallObjectSegment(new DirtyTracker(0), new ArraySegment<byte>(standard));


            // var small = ZeroFormatterSerializer.Deserialize<Small>(standard);


            var large = ZeroFormatterSerializer.Deserialize<Large>(standard);


        }


    }
}
