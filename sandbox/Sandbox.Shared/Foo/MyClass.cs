using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter;

namespace Sandbox.Shared.Foo
{
    [ZeroFormattable]
    public class MyClass
    {
        [Index(0)]
        public virtual int Age { get; set; }

        [Index(1)]
        public virtual string FirstName { get; set; }

        [Index(2)]
        public virtual string LastName { get; set; }

        [IgnoreFormat]
        public string FullName { get { return FirstName + LastName; } }

        [Index(3)]
        public virtual IList<MogeMoge> List { get; set; }

        [Index(4)]
        public virtual MogeMoge Mone { get; set; }
    }


    [ZeroFormattable]
    public class MyClass2
    {
        [Index(0)]
        public virtual int Age { get; set; }

        [Index(1)]
        public virtual string FirstName { get; set; }

        [Index(2)]
        public virtual string LastName { get; set; }

        [IgnoreFormat]
        public string FullName { get { return FirstName + LastName; } }

        [Index(3)]
        public virtual IList<MogeMoge> List { get; set; }

        [Index(4)]
        public virtual MogeMoge Mone { get; set; }
    }


    public enum MogeMoge
    {
        Apple, Orange
    }

    public enum MogeMoge2
    {
        Apple, Orange
    }
}
