using System;
using System.Collections.Generic;
using System.Linq;


public static partial class AssertEx
{
    public static void IsZero<T>(this IEnumerable<T> source)
    {
        source.Any().IsFalse();
    }
}
