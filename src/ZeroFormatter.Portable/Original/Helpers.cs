using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter
{
#if PORTABLE
    public enum TypeCode
    {
        Unknown,
        Boolean,
        Char,
        SByte,
        Byte,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        Single,
        Double,
        Decimal,
        DateTime,
        String,
        TimeSpan,
        ByteArray,
        Guid,
        Uri,
        Type
    }

    public static class Helpers
    {
        private static readonly Dictionary<Type, TypeCode> KnownTypes = new Dictionary<Type, TypeCode>
        {
            { typeof(bool), TypeCode.Boolean },
            { typeof(char), TypeCode.Char },
            { typeof(sbyte), TypeCode.SByte },
            { typeof(byte), TypeCode.Byte },
            { typeof(short), TypeCode.Int16 },
            { typeof(ushort), TypeCode.UInt16 },
            { typeof(int), TypeCode.Int32 },
            { typeof(uint), TypeCode.UInt32 },
            { typeof(long), TypeCode.Int64 },
            { typeof(ulong), TypeCode.UInt64 },
            { typeof(float), TypeCode.Single },
            { typeof(double), TypeCode.Double },
            { typeof(decimal), TypeCode.Decimal },
            { typeof(string), TypeCode.String },
            { typeof(DateTime), TypeCode.DateTime },
            { typeof(TimeSpan), TypeCode.TimeSpan },
            { typeof(Guid), TypeCode.Guid },
            { typeof(Uri), TypeCode.Uri },
            { typeof(byte[]), TypeCode.ByteArray },
            { typeof(Type), TypeCode.Type },
        };

        public static TypeCode GetTypeCode(Type type)
        {
            TypeCode code;
            return KnownTypes.TryGetValue(type, out code) ? code : TypeCode.Unknown;
        }
    }
#endif
}
