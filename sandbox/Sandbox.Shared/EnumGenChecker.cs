using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter;

namespace Sandbox.Shared
{
    public enum StandardEnum
    {
        A, B, C
    }

    [ZeroFormattable]
    public class EnumGenChecker
    {
        [Index(0)]
        public virtual ILazyLookup<KeyTuple<int, StandardEnum, string>, int> MyProperty { get; set; }
        //[Index(1)]
        //public virtual StandardEnum MyProperty2 { get; set; }
    }
}
