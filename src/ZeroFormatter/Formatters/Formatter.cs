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
            else if (t == typeof(decimal))
            {
                formatter = new DecimalFormatter();
            }
            else if (t == typeof(TimeSpan))
            {
                formatter = new TimeSpanFormatter();
            }
            else if (t == typeof(DateTime))
            {
                formatter = new DateTimeFormatter();
            }
            else if (t == typeof(DateTimeOffset))
            {
                formatter = new DateTimeOffsetFormatter();
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
            else if (t == typeof(Nullable<decimal>))
            {
                formatter = new NullableDecimalFormatter();
            }
            else if (t == typeof(Nullable<TimeSpan>))
            {
                formatter = new NullableTimeSpanFormatter();
            }
            else if (t == typeof(Nullable<DateTime>))
            {
                formatter = new NullableDateTimeFormatter();
            }
            else if (t == typeof(Nullable<DateTimeOffset>))
            {
                formatter = new NullableDateTimeOffsetFormatter();
            }

            // Others
            else if (t == typeof(String))
            {
                formatter = new StringFormatter();
            }
            else if (t == typeof(Char))
            {
                formatter = new CharFormatter();
            }
            else if (t == typeof(Char?))
            {
                formatter = new NullableCharFormatter();
            }
            else if (t == typeof(byte[]))
            {
                formatter = new ByteArrayFormatter();
            }

            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>))
            {
                var formatterType = typeof(ListFormatter<>).MakeGenericType(t.GetGenericArguments());
                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
            }

            else if (t.IsEnum)
            {
                var underlyingType = Enum.GetUnderlyingType(t);
                switch (Type.GetTypeCode(underlyingType))
                {
                    case TypeCode.SByte:
                        formatter = new SByteEnumFormatter<T>();
                        break;
                    case TypeCode.Byte:
                        formatter = new ByteEnumFormatter<T>();
                        break;
                    case TypeCode.Int16:
                        formatter = new Int16EnumFormatter<T>();
                        break;
                    case TypeCode.UInt16:
                        formatter = new UInt16EnumFormatter<T>();
                        break;
                    case TypeCode.Int32:
                        formatter = new Int32EnumFormatter<T>();
                        break;
                    case TypeCode.UInt32:
                        formatter = new UInt32EnumFormatter<T>();
                        break;
                    case TypeCode.Int64:
                        formatter = new Int64EnumFormatter<T>();
                        break;
                    case TypeCode.UInt64:
                        formatter = new UInt64EnumFormatter<T>();
                        break;
                    default:
                        throw new Exception();
                }
            }

            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>) && t.GetGenericArguments()[0].IsEnum)
            {
                var underlyingType = Enum.GetUnderlyingType(t.GetGenericArguments()[0]);
                switch (Type.GetTypeCode(underlyingType))
                {
                    case TypeCode.SByte:
                        {
                            var formatterType = typeof(NullableSByteEnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Byte:
                        {
                            var formatterType = typeof(NullableByteEnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Int16:
                        {
                            var formatterType = typeof(NullableInt16EnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.UInt16:
                        {
                            var formatterType = typeof(NullableUInt16EnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Int32:
                        {
                            var formatterType = typeof(NullableInt32EnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.UInt32:
                        {
                            var formatterType = typeof(NullableUInt32EnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.Int64:
                        {
                            var formatterType = typeof(NullableInt64EnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    case TypeCode.UInt64:
                        {
                            var formatterType = typeof(NullableUInt64EnumFormatter<>).MakeGenericType(t.GetGenericArguments()[0]);
                            formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            // TODO:Dictionary, Lookup, KeyTuple...

            else if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>))
            {
                var formatterType = typeof(DictionaryFormatter<,>).MakeGenericType(t.GetGenericArguments());
                formatter = (Formatter<T>)Activator.CreateInstance(formatterType);
            }

            // TODO:make the object formatter...

            else if (t.IsArray)
            {
                throw new InvalidOperationException("Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[].");
            }
            else
            {
                // TODO:more details exception message.
                throw new InvalidOperationException("Type is not supported, please register,");
            }

            Default = (Formatter<T>)formatter;
        }

        public abstract int? GetLength();

        public abstract int Serialize(ref byte[] bytes, int offset, T value);
        public abstract T Deserialize(ref byte[] bytes, int offset);
    }
}