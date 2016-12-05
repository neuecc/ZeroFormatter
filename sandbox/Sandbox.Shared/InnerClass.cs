using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeroFormatter;

namespace Sandbox.Shared
{
    public class InnerClassA
    {
        public enum InnerEnum
        {
            A, B, C
        }

        [ZeroFormattable]
        public class InnerObject
        {
            [Index(0)]
            public virtual int MyProperty { get; set; }
        }
    }

    public class InnerClassB
    {
        public enum InnerEnum
        {
            A, B, C
        }

        private enum NgGenerateEnum
        {
            A, B, C
        }

        enum NgGenerateEnum2
        {
            Z
        }

        [ZeroFormattable]
        public class InnerObject
        {
            [Index(0)]
            public virtual int MyProperty { get; set; }


            [Index(1)]
            public virtual InsideEnum MyProperty2 { get; set; }


            [Index(2)]
            public virtual TypeCode MyProperty3 { get; set; }
        }
    }

    [ZeroFormattable]
    class InternalOkGenerateType
    {
        [Index(0)]
        public virtual int MyProperty { get; set; }
    }

    public enum OutSideEnum
    {
        A, B, C
    }

    public enum InsideEnum
    {
        A, B, C
    }
}