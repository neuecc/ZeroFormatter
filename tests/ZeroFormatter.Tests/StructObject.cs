using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.Tests
{
    [ZeroFormattable]
    public class MyClass5
    {
        [Index(0)]
        public virtual string Dame { get; set; }
    }

    [TestClass]
    public class StructObject
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var mc1 = ZeroFormatterSerializer.Convert(new MyClass5() { Dame = "hoge" });

            mc1.Dame = "hoge";
        }
    }
}
