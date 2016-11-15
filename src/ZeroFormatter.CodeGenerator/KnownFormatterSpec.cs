using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace ZeroFormatter.CodeGenerator
{
    public static class KnownFormatterSpec
    {
        static readonly Dictionary<string, int> AllowTypesAndSize = new Dictionary<string, int>
        {
            { "short",                  2 },
            { "int",                    4 },
            { "long",                   8 },
            { "ushort",                 2 },
            { "uint",                   4 },
            { "ulong",                  8 },
            { "float",                  4 },
            { "double",                 8 },
            { "bool",                   1 },
            { "byte",                   1 },
            { "sbyte",                  1 },
            { "decimal",               16 },
            { "char",                   2 },
            { "System.Guid",           16 },
            { "System.TimeSpan",       12 },
            { "System.DateTime",       12 },
            { "System.DateTimeOffset", 12 },
        };

        public static bool IsPrimitive(ITypeSymbol symbol)
        {
            if (symbol == null) return false;
            var namedSymbol = symbol as INamedTypeSymbol;
            if (namedSymbol == null) return false;

            if (namedSymbol.IsNullable())
            {
                return IsPrimitive(namedSymbol.TypeArguments[0]);
            }

            var str = namedSymbol.ToDisplayString();
            if (str == "string") return true;
            return AllowTypesAndSize.ContainsKey(str);
        }

        public static bool AllowArrayType(ITypeSymbol elementType)
        {
            var str = elementType.ToDisplayString();
            return AllowTypesAndSize.ContainsKey(str)
                && str != "decimal"
                && str != "System.Guid"
                && str != "System.TimeSpan"
                && str != "System.DateTime"
                && str != "System.DateTimeOffset";
        }

        public static int? GetLength(ITypeSymbol symbol)
        {
            if (symbol == null) return null;
            var namedSymbol = symbol as INamedTypeSymbol;
            if (namedSymbol == null) return null;

            if (namedSymbol.IsNullable())
            {
                return GetLength(namedSymbol.TypeArguments[0]) + 1;
            }

            int x;
            if (AllowTypesAndSize.TryGetValue(symbol.ToDisplayString(), out x))
            {
                return x;
            }

            if (namedSymbol.TypeKind == TypeKind.Enum)
            {
                return GetLength(namedSymbol.EnumUnderlyingType);
            }

            if (namedSymbol.IsValueType)
            {
                var sum = 0;
                foreach (var member in namedSymbol.GetMembers().OfType<IPropertySymbol>())
                {
                    var attr = member.GetAttributes().FindAttributeShortName(TypeCollector.IndexAttributeShortName);
                    if (attr == null) continue;

                    var size = GetLength(member.Type);
                    if (size == null)
                    {
                        return null;
                    }
                    sum += size.Value;
                }
                if (sum == 0)
                {
                    return null;
                }
                return sum;
            }

            return null;
        }

        public static bool IsLazySegment(ITypeSymbol symbol)
        {
            // ObjectSegment
            if (!symbol.IsValueType && symbol.GetAttributes().FindAttributeShortName("ZeroFormattableAttribute") != null)
            {
                return true;
            }

            var named = symbol as INamedTypeSymbol;

            if (named != null && named.IsGenericType)
            {
                var genType = named.ConstructUnboundGenericType().ToDisplayString();
                // ListSegment

                if (genType == "System.Collections.Generic.IList<>")
                {
                    return true;
                }
                else if (genType == "ZeroFormatter.ILazyLookup<,>")
                {
                    return true;
                }
                else if (genType == "ZeroFormatter.ILazyDictionary<,>")
                {
                    return true;
                }
                else if (genType == "ZeroFormatter.ILazyReadOnlyDictionary<,>")
                {
                    return true;
                }
            }

            return false;
        }
    }
}