using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
