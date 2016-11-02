using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter;

namespace Sandbox.Shared
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
    public class Small
    {
        [Index(0)]
        public virtual int MyProperty0 { get; set; }
        [Index(1)]
        public virtual string MyProperty1 { get; set; }

        [Index(2)]
        public virtual IList<int> MyProperty2 { get; set; }
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
}
