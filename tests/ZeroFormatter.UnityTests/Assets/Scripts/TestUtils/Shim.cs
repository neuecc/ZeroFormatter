using System;
using System.Collections;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    public class TestClassAttribute : Attribute
    {
    }
    public class TestMethodAttribute : Attribute
    {
    }

    public class AssertFailedException : Exception
    {
        public AssertFailedException(string message)
            : base(message)
        {

        }
    }
}
