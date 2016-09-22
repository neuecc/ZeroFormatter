using System;
using System.Collections.Generic;
using System.IO;

namespace ZeroFormatter.Formatters
{
    // raw layer of serialization.

    public abstract class Formatter<T>
    {
        public static Formatter<T> Default;

        static Formatter()
        {
            try
            {
                object formatter = null;

                var t = typeof(T);

                // Primitive
                if (t == typeof(Int16))
                {
                    formatter = new Int16Formatter();
                }
                else if (t == typeof(Int32))
                {
                    formatter = new Int32Formatter();
                }
                else if (t == typeof(Int64))
                {
                    formatter = new Int64Formatter();
                }
                else if (t == typeof(UInt16))
                {
                    formatter = new UInt16Formatter();
                }
                else if (t == typeof(UInt32))
                {
                    formatter = new UInt32Formatter();
                }
                else if (t == typeof(UInt64))
                {
                    formatter = new UInt64Formatter();
                }
                else if (t == typeof(Single))
                {
                    formatter = new SingleFormatter();
                }
                else if (t == typeof(Double))
                {
                    formatter = new DoubleFormatter();
                }
                else if (t == typeof(bool))
                {
                    formatter = new BooleanFormatter();
                }
                else if (t == typeof(byte))
                {
                    formatter = new ByteFormatter();
                }
                else if (t == typeof(sbyte))
                {
                    formatter = new SByteFormatter();
                }
                // Nulllable
                else if (t == typeof(Nullable<Int16>))
                {
                    formatter = new NullableInt16Formatter();
                }
                else if (t == typeof(Nullable<Int32>))
                {
                    formatter = new NullableInt32Formatter();
                }
                else if (t == typeof(Nullable<Int64>))
                {
                    formatter = new NullableInt64Formatter();
                }
                else if (t == typeof(Nullable<UInt16>))
                {
                    formatter = new NullableUInt16Formatter();
                }
                else if (t == typeof(Nullable<UInt32>))
                {
                    formatter = new NullableUInt32Formatter();
                }
                else if (t == typeof(Nullable<UInt64>))
                {
                    formatter = new NullableUInt64Formatter();
                }
                else if (t == typeof(Nullable<Single>))
                {
                    formatter = new NullableSingleFormatter();
                }
                else if (t == typeof(Nullable<Double>))
                {
                    formatter = new NullableDoubleFormatter();
                }
                else if (t == typeof(Nullable<bool>))
                {
                    formatter = new NullableBooleanFormatter();
                }
                else if (t == typeof(Nullable<byte>))
                {
                    formatter = new NullableByteFormatter();
                }
                else if (t == typeof(Nullable<sbyte>))
                {
                    formatter = new NullableSByteFormatter();
                }

                // Others
                else if (t == typeof(String))
                {
                    formatter = new StringFormatter();
                }
                else if (t == typeof(byte[]))
                {
                    formatter = new ByteArrayFormatter();
                }


                else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var formatterType = typeof(ListFormatter<>).MakeGenericType(t.GetGenericArguments());
                    Default = (Formatter<T>)Activator.CreateInstance(formatterType);
                }

                // TODO:....

                // TODO:make the object formatter...


                // TODO:make enum, nullable enum, and enum array...

                Default = (Formatter<T>)formatter;

            }
            catch
            {
                // TODO:should avoid exception in static constructor
            }
        }

        public abstract int? GetLength();

        public abstract int Serialize(ref byte[] bytes, int offset, T value);
        public abstract T Deserialize(ref byte[] bytes, int offset);
    }
}