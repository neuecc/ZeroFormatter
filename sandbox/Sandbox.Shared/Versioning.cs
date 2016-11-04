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
    public class Large
    {
        [Index(0)]
        public virtual int MyProperty0 { get; set; }
        [Index(3)]
        public virtual int MyProperty3 { get; set; }


        [Index(5)]
        public virtual long MyProperty5 { get; set; }
        [Index(7)]
        public virtual string MyProperty6 { get; set; }
        [Index(10)]
        public virtual IList<int> MyProperty10 { get; set; }
        [Index(11)]
        public virtual ILookup<bool, int> MyProperty11 { get; set; }
        [Index(13)]
        public virtual IList<string> MyProperty13 { get; set; }
        [Index(15)]
        public virtual IDictionary<string, int> MyProperty15 { get; set; }
        [Index(20)]
        public virtual int MyProperty20 { get; set; }
    }
}
