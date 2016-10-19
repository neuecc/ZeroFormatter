using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ZeroFormatter.DotNetCore.Tests
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




    public class FormatterVerifyRule
    {
        [Fact]
        public void MogeMoge()
        {
            

        }
    }
}
