using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter;

namespace Sandbox.Shared
{
    [ZeroFormattable]
    public class InheritBase
    {
        [Index(0)]
        public virtual int MyProperty0 { get; set; }
    }

    [ZeroFormattable]
    public class Inherit : InheritBase
    {
        [Index(1)]
        public virtual int MyProperty1 { get; set; }


        [Index(2)]
        public virtual TypeCode MyProperty2 { get; set; }
    }


    [ZeroFormattable]
    public class FooBarBaz
    {
        [Index(0)]
        public virtual IList<byte[]> HugaHuga { get; set; }
    }



}
