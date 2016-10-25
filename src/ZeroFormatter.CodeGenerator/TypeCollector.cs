using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroFormatter.CodeGenerator
{
    public class TypeCollector
    {
        readonly string csProjPath;

        const string ZeroFormattableAttributeShortName = "ZeroFormattableAttribute";
        const string IndexAttributeShortName = "IndexAttribute";
        const string IgnoreAttributeShortName = "IgnoreFormatAttribute";

        static readonly SymbolDisplayFormat binaryWriteFormat = new SymbolDisplayFormat(
                genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                miscellaneousOptions: SymbolDisplayMiscellaneousOptions.ExpandNullable,
                typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly);

        ILookup<TypeKind, INamedTypeSymbol> targetTypes;

        public TypeCollector(string csProjPath)
        {
            this.csProjPath = csProjPath;

            // Collect immediate:)
            var compilation = RoslynExtensions.GetCompilationFromProject(csProjPath).GetAwaiter().GetResult();
            this.targetTypes = compilation.GetNamedTypeSymbols()
                .Where(x => (x.TypeKind == TypeKind.Enum)
                    || ((x.TypeKind == TypeKind.Class) && x.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) != null))
                .ToLookup(x => x.TypeKind);
        }

        public EnumGenerator[] CreateEnumGenerators()
        {
            var generator = targetTypes[TypeKind.Enum]
                .GroupBy(x => x.ContainingNamespace.ToDisplayString())
                .OrderBy(x => x.Key)
                .Select(x => new EnumGenerator
                {
                    Namespace = "ZeroFormatter.DynamicObjectSegments." + x.Key,
                    Types = x.Select(y => new EnumType
                    {
                        Name = y.Name,
                        FullName = y.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                        UnderlyingType = y.EnumUnderlyingType.ToDisplayString(binaryWriteFormat),
                        Length = GetEnumSize(y.EnumUnderlyingType)
                    })
                    .ToArray()
                })
                .ToArray();

            return generator;
        }

        public Tuple<ObjectGenerator[], GenericType[]> CreateObjectGenerators()
        {
            var container = new List<ObjectSegmentType>();
            var genericTypeContainer = new List<GenericType>();
            var alreadyCollected = new HashSet<string>();

            foreach (var item in targetTypes[TypeKind.Class])
            {
                CollectObjectSegment(item, container, genericTypeContainer, alreadyCollected);
            }

            var generator = container.GroupBy(x => x.Namespace)
                .Select(x => new ObjectGenerator
                {
                    Namespace = "ZeroFormatter.DynamicObjectSegments." + x.Key,
                    Types = x.ToArray(),
                })
                .ToArray();

            var t = Tuple.Create(generator, genericTypeContainer.Distinct().OrderBy(x => x.Type).ToArray());
            return t;
        }

        static int GetEnumSize(INamedTypeSymbol enumUnderlyingType)
        {
            switch (enumUnderlyingType.SpecialType)
            {
                case SpecialType.System_SByte:
                case SpecialType.System_Byte:
                    return 1;
                case SpecialType.System_Int16:
                case SpecialType.System_UInt16:
                    return 2;
                case SpecialType.System_Int32:
                case SpecialType.System_UInt32:
                    return 4;
                case SpecialType.System_Int64:
                case SpecialType.System_UInt64:
                    return 8;
                default:
                    throw new ArgumentException("UnderlyingType is not Enum. :" + enumUnderlyingType?.ToDisplayString());
            }
        }

        static void CollectObjectSegment(INamedTypeSymbol type, List<ObjectSegmentType> typeContainer, List<GenericType> genericTypeContainer, HashSet<string> alreadyCollected)
        {
            if (type == null)
            {
                return;
            }
            if (!alreadyCollected.Add(type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)))
            {
                return;
            }
            if (KnownFormatterSpec.IsPrimitive(type))
            {
                return;
            }
            if (type.TypeKind == TypeKind.Enum)
            {
                return;
            }
            if (type.IsGenericType)
            {
                var genericType = type.ConstructUnboundGenericType();
                var genericTypeString = genericType.ToDisplayString();

                if (genericTypeString == "T?")
                {
                    CollectObjectSegment(type.TypeArguments[0] as INamedTypeSymbol, typeContainer, genericTypeContainer, alreadyCollected);
                    return;
                }
                else if (genericTypeString == "System.Collections.Generic.List<>")
                {
                    throw new Exception($"List does not support in ZeroFormatter because List have to deserialize all objects. You can use IList<T> instead of List. {type.Name}.");
                }
                else if (genericTypeString == "System.Collections.Generic.Dictionary<,>")
                {
                    throw new Exception($"Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary. {type.Name}.");
                }
                else if (genericTypeString == "System.Collections.Generic.IList<>"
                      || genericTypeString == "System.Collections.Generic.IDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyList<>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyDictionary<,>"
                      || genericTypeString == "System.Linq.ILookup<,>"
                      || genericTypeString.StartsWith("ZeroFormatter.KeyTuple"))
                {
                    var elementTypes = string.Join(", ", type.TypeArguments.Select(x => x.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)));

                    if (genericTypeString == "System.Collections.Generic.IList<>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.List, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "System.Collections.Generic.IDictionary<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.Dictionary, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "System.Linq.ILookup<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.Lookup, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString.StartsWith("ZeroFormatter.KeyTuple"))
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.KeyTuple, ElementTypes = elementTypes });
                    }

                    foreach (var t in type.TypeArguments)
                    {
                        CollectObjectSegment(t as INamedTypeSymbol, typeContainer, genericTypeContainer, alreadyCollected);
                    }
                    return;
                }
            }

            if (type.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) == null)
            {
                throw new Exception($"Type must mark ZeroFormattableAttribute. {type.Name}.  Location:{type.Locations[0]}");
            }
            if (type.IsValueType)
            {
                throw new Exception($"Type must be class. {type.Name}. Location:{type.Locations[0]}");
            }
            if (!type.Constructors.Any(x => x.Parameters.Length == 0))
            {
                throw new Exception($"Type must needs parameterless constructor. {type.Name}. Location:{type.Locations[0]}");
            }


            var list = new List<ObjectSegmentType.PropertyTuple>();

            var definedIndexes = new HashSet<int>();

            foreach (var property in type.GetAllMembers().OfType<IPropertySymbol>())
            {
                if (property.DeclaredAccessibility != Accessibility.Public)
                {
                    continue;
                }

                var attributes = property.GetAttributes();
                if (attributes.FindAttributeShortName(IgnoreAttributeShortName) != null)
                {
                    continue;
                }

                if (!property.IsVirtual)
                {
                    throw new Exception($"Public property's accessor must be virtual. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                }

                var indexAttr = attributes.FindAttributeShortName(IndexAttributeShortName);
                if (indexAttr == null || indexAttr.ConstructorArguments.Length == 0)
                {
                    throw new Exception($"Public property must mark IndexAttribute or IgnoreFormatAttribute. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                }

                var index = indexAttr.ConstructorArguments[0];
                if (index.IsNull)
                {
                    continue; // null is normal compiler error.
                }

                if (!definedIndexes.Add((int)index.Value))
                {
                    throw new Exception($"IndexAttribute can not allow duplicate. {type.Name}.{property.Name}, Index:{index.Value} Location:{type.Locations[0]}");
                }

                if (property.GetMethod == null || property.SetMethod == null
                    || property.GetMethod.DeclaredAccessibility == Accessibility.Private
                    || property.SetMethod.DeclaredAccessibility == Accessibility.Private)
                {
                    throw new Exception($"Public property's accessor must needs both public/protected get and set. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                }

                if (property.Type.TypeKind == TypeKind.Array)
                {
                    var array = property.Type as IArrayTypeSymbol;
                    var t = array.ElementType;
                    if (t.SpecialType != SpecialType.System_Byte) // allows byte[]
                    {
                        throw new Exception($"Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[]. {type.Name}.{property.Name}.  Location:{type.Locations[0]}");
                    }
                }
                else
                {
                    var namedType = property.Type as INamedTypeSymbol;
                    if (namedType != null) // if <T> is unnamed type, it can't analyze.
                    {
                        // Recursive
                        CollectObjectSegment(namedType, typeContainer, genericTypeContainer, alreadyCollected);
                    }
                }

                var length = KnownFormatterSpec.GetLength(property.Type);
                var prop = new ObjectSegmentType.PropertyTuple
                {
                    Name = property.Name,
                    Type = property.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    Index = (int)index.Value,
                    IsGetProtected = property.GetMethod.DeclaredAccessibility == Accessibility.Protected,
                    IsSetProtected = property.SetMethod.DeclaredAccessibility == Accessibility.Protected,
                    FixedSize = length ?? 0,
                    IsCacheSegment = KnownFormatterSpec.CanAcceptCacheSegment(property.Type),
                    IsFixedSize = (length != null)
                };

                list.Add(prop);
            }

            typeContainer.Add(new ObjectSegmentType
            {
                Name = type.Name,
                FullName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                Namespace = type.ContainingNamespace.ToDisplayString(),
                LastIndex = list.Select(x => x.Index).DefaultIfEmpty(0).Max(),
                Properties = list.OrderBy(x => x.Index).ToArray(),
            });
        }
    }
}