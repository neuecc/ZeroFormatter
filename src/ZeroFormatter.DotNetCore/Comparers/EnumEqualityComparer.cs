using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ZeroFormatter.DotNetCore.Comparers
{
    // Note:This hack does not work in UnityEditor.

    // same impl of ZeroFormatterEqualityComparers
    internal static class EnumEqualityComparerHelper
    {
        static int ByteGetHashCode(byte x) { return (int)x; }

        static bool ByteEquals(byte x, byte y) { return x == y; }

        static int SByteGetHashCode(sbyte x) { return (int)x ^ (int)x << 8; }

        static bool SByteEquals(sbyte x, sbyte y) { return x == y; }

        static int ShortGetHashCode(short x) { return (int)((ushort)x) | (int)x << 16; }

        static bool ShortEquals(short x, short y) { return x == y; }

        static int UShortGetHashCode(ushort x) { return x; }

        static bool UShortEquals(ushort x, ushort y) { return x == y; }

        static int UIntGetHashCode(uint x) { return (int)x; }

        static bool UIntEquals(uint x, uint y) { return x == y; }

        static int ULongGetHashCode(ulong x) { return (int)x ^ (int)(x >> 32); }

        static bool ULongEquals(ulong x, ulong y) { return x == y; }

        static int LongGetHashCode(long x) { return (int)x ^ (int)(x >> 32); }

        static bool LongEquals(long x, long y) { return x == y; }

        static int IntGetHashCode(int x) { return x; }

        static bool IntEquals(int x, int y) { return x == y; }

        public static class DelegateCache<T>
        {
            public static readonly Func<T, int> GetHashCodeDelegate;
            public static readonly Func<T, T, bool> EqualsDelegate;

            static DelegateCache()
            {
                // Delegate.CreateDelegate allows binding functions with Enum parameters to the enum base type.
                // https://connect.microsoft.com/VisualStudio/feedback/details/614234/delegate-createdelegate-allows-binding-functions-with-enum-parameters-to-the-enum-base-type

                var underlyingType = Enum.GetUnderlyingType(typeof(T));
                switch (Type.GetTypeCode(underlyingType))
                {
                    case TypeCode.SByte:
                        {
                            Func<sbyte, int> getHash = SByteGetHashCode;
                            Func<sbyte, sbyte, bool> eq = SByteEquals;

                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    case TypeCode.Byte:
                        {
                            Func<Byte, int> getHash = ByteGetHashCode;
                            Func<Byte, Byte, bool> eq = ByteEquals;

                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    case TypeCode.Int16:
                        {
                            Func<Int16, int> getHash = ShortGetHashCode;
                            Func<Int16, Int16, bool> eq = ShortEquals;
                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    case TypeCode.UInt16:
                        {
                            Func<UInt16, int> getHash = UShortGetHashCode;
                            Func<UInt16, UInt16, bool> eq = UShortEquals;
                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    case TypeCode.Int32:
                        {
                            Func<int, int> getHash = IntGetHashCode;
                            Func<int, int, bool> eq = IntEquals;
                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    case TypeCode.UInt32:
                        {
                            Func<UInt32, int> getHash = UIntGetHashCode;
                            Func<UInt32, UInt32, bool> eq = UIntEquals;
                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    case TypeCode.Int64:
                        {
                            Func<Int64, int> getHash = LongGetHashCode;
                            Func<Int64, Int64, bool> eq = LongEquals;
                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    case TypeCode.UInt64:
                        {
                            Func<UInt64, int> getHash = ULongGetHashCode;
                            Func<UInt64, UInt64, bool> eq = ULongEquals;
                            GetHashCodeDelegate = Expression.Lambda<Func<T, int>>(Expression.Call(getHash.GetMethodInfo())).Compile();
                            EqualsDelegate = Expression.Lambda<Func<T, T, bool>>(Expression.Call(eq.GetMethodInfo())).Compile();
                        }
                        break;
                    default:
                        throw new NotSupportedException("The underlying type is invalid.");
                }
            }
        }
    }

    public class EnumEqualityComparer<T> : IEqualityComparer<T>
    {
        public static IEqualityComparer<T> Default = new EnumEqualityComparer<T>();

        readonly Func<T, int> getHashCode;
        readonly Func<T, T, bool> equals;

        EnumEqualityComparer()
        {
            getHashCode = EnumEqualityComparerHelper.DelegateCache<T>.GetHashCodeDelegate;
            equals = EnumEqualityComparerHelper.DelegateCache<T>.EqualsDelegate;
        }

        public bool Equals(T x, T y)
        {
            return equals(x, y);
        }

        public int GetHashCode(T obj)
        {
            return getHashCode(obj);
        }
    }
}