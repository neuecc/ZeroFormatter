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
                return sum;
            }

            return null;
        }

        public static bool CanAcceptCacheSegment(ITypeSymbol symbol)
        {
            var str = symbol.ToDisplayString();

            if (str == "string")
            {
                return true;
            }
            else if (str == "byte[]")
            {
                return true;
            }
            else if (symbol.AllInterfaces.Any(x => x.ToDisplayString() == "IKeyTuple"))
            {
                return true;
            }
            else if ((symbol as INamedTypeSymbol)?.IsNullable() ?? false)
            {
                return CanAcceptCacheSegment((symbol as INamedTypeSymbol).TypeArguments[0]);
            }
            else if (symbol.IsValueType)
            {
                return true;
            }

            return false;
        }
    }
}
