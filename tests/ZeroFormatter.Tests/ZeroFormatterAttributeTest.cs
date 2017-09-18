using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeroFormatter.Formatters;
using ZeroFormatter.Internal;

namespace ZeroFormatter.Tests
{
    [TestClass]
    public class ZeroFormatterAttributeTest
    {
        [TestMethod]
        public void Serialize()
        {
            var customClass = new CustomClass("Hello World");

            var data = ZeroFormatterSerializer.Serialize(customClass);
            var result = ZeroFormatterSerializer.Deserialize<CustomClass>(data);
            result.Test.Is(customClass.Test);
        }

        [ZeroFormattable(FormatterType = typeof(CustomClassFormatter<>))]
        public class CustomClass
        {
            public CustomClass(string test)
            {
                Test = test;
            }

            public string Test { get; }
        }

        public class CustomClassFormatter<TTypeResolver> : Formatter<TTypeResolver, CustomClass>
            where TTypeResolver : ITypeResolver, new()
        {
            public override int? GetLength()
            {
                return null;
            }

            public override int Serialize(ref byte[] bytes, int offset, CustomClass value)
            {
                var stringLength = BinaryUtil.WriteString(ref bytes, offset + 4, value.Test);
                BinaryUtil.WriteInt32Unsafe(ref bytes, offset, stringLength);
                return stringLength + 4;
            }

            public override CustomClass Deserialize(ref byte[] bytes, int offset, DirtyTracker tracker,
                out int byteSize)
            {
                var length = BinaryUtil.ReadInt32(ref bytes, offset);
                byteSize = 4 + length;
                return new CustomClass(BinaryUtil.ReadString(ref bytes, offset + 4, length));
            }
        }
    }
}