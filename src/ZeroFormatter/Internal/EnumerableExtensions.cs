using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFormatter
{
    internal static class EnumerableExtensions
    {
        public static T[] StartsWith<T>(this T[] array, T firstValue)
        {
            var dest = new T[array.Length + 1];
            dest[0] = firstValue;
            Array.Copy(array, 0, dest, 1, array.Length);
            return dest;
        }
    }
}