using Sandbox.Shared;
using System;
using RuntimeUnitTestToolkit;

using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    public class ZeroArgumentTest
    {
        public void Class()
        {
            var c = ZeroFormatterSerializer.Convert(new ZeroClass());
            (c is ZeroClass).IsTrue();
        }

        public void Struct()
        {
            var bytes = ZeroFormatterSerializer.Serialize(new ZeroStruct());
            bytes.Length.Is(0);
            ZeroFormatterSerializer.Deserialize<ZeroStruct>(bytes);

            var len = ZeroFormatter.Formatters.Formatter<DefaultResolver, ZeroStruct>.Default.GetLength();
            len.IsNotNull();
            len.Is(0);
        }
    }
}
