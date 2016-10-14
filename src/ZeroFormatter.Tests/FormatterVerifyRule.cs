using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFormatter.Tests
{

    public struct Ng_NoClass
    {

    }

    public class Ng_NonZeroFormattable
    {
        [Index(0)]
        public int MyProperty { get; set; }
    }


    [ZeroFormattable]
    public class Ng2
    {
        [Index(0)]
        public int MyProperty { get; set; }
    }




    [TestClass]
    public class FormatterVerifyRule
    {
        [TestMethod]
        public void MogeMoge()
        {
            

        }
    }
}
