using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ZeroFormatter.Collections
{
    public static class ZeroFormatterEqualityComparer
    {
        // static readonly System.RuntimeTypeHandle StringTypeHandle = typeof(string).TypeHandle;

        static readonly ConcurrentDictionary<Type, object> comparers = new ConcurrentDictionary<Type, object>();

        static ZeroFormatterEqualityComparer()
        {
            comparers[typeof(short)] = new Int16EqualityComparer();
            comparers[typeof(ushort)] = new UInt16EqualityComparer();
            comparers[typeof(int)] = new Int32EqualityComparer();
            comparers[typeof(uint)] = new UInt32EqualityComparer();
            comparers[typeof(long)] = new Int64EqualityComparer();
            comparers[typeof(ulong)] = new UInt64EqualityComparer();
            comparers[typeof(float)] = new SingleEqualityComparer();
            comparers[typeof(double)] = new DoubleEqualityComparer();
            comparers[typeof(byte)] = new ByteEqualityComparer();
            comparers[typeof(sbyte)] = new SByteEqualityComparer();
            comparers[typeof(char)] = new CharEqualityComparer();
            comparers[typeof(bool)] = new BoolEqualityComparer();
            comparers[typeof(string)] = new StringEqualityComparer();

        }

        public static IEqualityComparer<T> GetDefault<T>()
        {
            var t = typeof(T);
            object o;
            if (comparers.TryGetValue(t, out o))
            {
                return (IEqualityComparer<T>)o;
            }
            else
            {
                if (t.IsEnum)
                {
                    var c = EnumEqualityComparer<T>.Default;
                    comparers[t] = c;
                    return c;
                }
            }

            throw new InvalidOperationException("does not registered type. Type:" + t.Name);
        }

        public static void Register<T>(IEqualityComparer<T> equalityComparer)
        {
            comparers[typeof(T)] = equalityComparer;
        }
    }
}