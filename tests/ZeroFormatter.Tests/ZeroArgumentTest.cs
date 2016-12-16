using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;

namespace ZeroFormatter.Tests
{
    [ZeroFormattable]
    public class ZeroClass
    {

    }

    [ZeroFormattable]
    public struct ZeroStruct
    {

    }

    [TestClass]
    public class ZeroArgumentTest
    {
        [TestMethod]
        public void Class()
        {
            ZeroFormatterSerializer.Convert(new ZeroClass()).IsInstanceOf<ZeroClass>();
        }

        [TestMethod]
        public void Struct()
        {
            ZeroFormatterSerializer.Convert(new ZeroStruct()).IsInstanceOf<ZeroStruct>();
            var len = ZeroFormatter.Formatters.Formatter<DefaultResolver, ZeroStruct>.Default.GetLength();
            len.IsNotNull();
            len.Is(0);
        }
    }
}
