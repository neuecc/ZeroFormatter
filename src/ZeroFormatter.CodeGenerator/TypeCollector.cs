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

        const string CodegeneratorOnlyPreprocessorSymbol = "INCLUDE_ONLY_CODE_GENERATION";

        public const string ZeroFormattableAttributeShortName = "ZeroFormattableAttribute";
        public const string IndexAttributeShortName = "IndexAttribute";
        public const string IgnoreAttributeShortName = "IgnoreFormatAttribute";

        static readonly SymbolDisplayFormat binaryWriteFormat = new SymbolDisplayFormat(
                genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                miscellaneousOptions: SymbolDisplayMiscellaneousOptions.ExpandNullable,
                typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly);

        ILookup<TypeKind, INamedTypeSymbol> targetTypes;
        List<EnumType> enumContainer;
        List<ObjectSegmentType> structContainer;
        List<ObjectSegmentType> objectContainer;
        List<GenericType> genericTypeContainer;
        HashSet<string> alreadyCollected;

        public TypeCollector(string csProjPath)
        {
            this.csProjPath = csProjPath;

            var compilation = RoslynExtensions.GetCompilationFromProject(csProjPath, CodegeneratorOnlyPreprocessorSymbol).GetAwaiter().GetResult();
            targetTypes = compilation.GetNamedTypeSymbols()
                .Where(x => (x.TypeKind == TypeKind.Enum)
                    || ((x.TypeKind == TypeKind.Class) && x.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) != null)
                    || ((x.TypeKind == TypeKind.Struct) && x.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) != null)
                    )
                .ToLookup(x => x.TypeKind);
        }

        void Init()
        {
            enumContainer = new List<CodeGenerator.EnumType>();
            objectContainer = new List<CodeGenerator.ObjectSegmentType>();
            structContainer = new List<CodeGenerator.ObjectSegmentType>();
            genericTypeContainer = new List<CodeGenerator.GenericType>();
            alreadyCollected = new HashSet<string>();
        }

        public void Visit(out EnumGenerator[] enumGenerators, out ObjectGenerator[] objectGenerators, out StructGenerator[] structGenerators, out GenericType[] genericTypes)
        {
            Init(); // cleanup field.

            foreach (var item in targetTypes[TypeKind.Enum])
            {
                CollectEnum(item);
            }
            foreach (var item in targetTypes[TypeKind.Class])
            {
                CollectObjectSegment(item);
            }
            foreach (var item in targetTypes[TypeKind.Struct])
            {
                CollectObjectSegment(item);
            }

            enumGenerators = enumContainer.Distinct()
               .GroupBy(x => x.Namespace)
               .OrderBy(x => x.Key)
                .Select(x => new EnumGenerator
                {
                    Namespace = "ZeroFormatter.DynamicObjectSegments" + ((x.Key != null) ? ("." + x.Key) : ""),
                    Types = x.ToArray()
                })
                .ToArray();

            objectGenerators = objectContainer
               .GroupBy(x => x.Namespace)
               .Select(x => new ObjectGenerator
               {
                   Namespace = "ZeroFormatter.DynamicObjectSegments" + ((x.Key != null) ? ("." + x.Key) : ""),
                   Types = x.ToArray(),
               })
               .ToArray();

            structGenerators = structContainer
               .GroupBy(x => x.Namespace)
               .Select(x => new StructGenerator
               {
                   Namespace = "ZeroFormatter.DynamicObjectSegments" + ((x.Key != null) ? ("." + x.Key) : ""),
                   Types = x.ToArray(),
               })
               .ToArray();

            genericTypes = genericTypeContainer.Distinct().OrderBy(x => x).ToArray();
        }

        void CollectEnum(INamedTypeSymbol symbol)
        {
            var type = new EnumType
            {
                Name = symbol.Name,
                FullName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                Namespace = symbol.ContainingNamespace.IsGlobalNamespace ? null : symbol.ContainingNamespace.ToDisplayString(),
                UnderlyingType = symbol.EnumUnderlyingType.ToDisplayString(binaryWriteFormat),
                Length = GetEnumSize(symbol.EnumUnderlyingType)
            };

            enumContainer.Add(type);
        }

        void CollectObjectSegment(INamedTypeSymbol type)
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
                CollectEnum(type);
                return;
            }
            if (type.IsGenericType)
            {
                var genericType = type.ConstructUnboundGenericType();
                var genericTypeString = genericType.ToDisplayString();

                if (genericTypeString == "T?")
                {
                    CollectObjectSegment(type.TypeArguments[0] as INamedTypeSymbol);
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
                      || genericTypeString == "ZeroFormatter.ILazyDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyList<>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyDictionary<,>"
                      || genericTypeString == "ZeroFormatter.ILazyReadOnlyDictionary<,>"
                      || genericTypeString == "System.Linq.ILookup<,>"
                      || genericTypeString == "ZeroFormatter.ILazyLookup<,>"
                      || genericTypeString.StartsWith("ZeroFormatter.KeyTuple"))
                {
                    var elementTypes = string.Join(", ", type.TypeArguments.Select(x => x.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)));

                    if (genericTypeString == "System.Collections.Generic.IList<>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.List, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "System.Collections.Generic.IReadOnlyList<>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.ReadOnlyList, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "System.Collections.Generic.IDictionary<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.Dictionary, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "System.Collections.Generic.IReadOnlyDictionary<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.ReadOnlyDictionary, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "ZeroFormatter.ILazyDictionary<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.LazyDictionary, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "ZeroFormatter.ILazyReadOnlyDictionary<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.LazyReadOnlyDictionary, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString == "ZeroFormatter.ILazyLookup<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.LazyLookup, ElementTypes = elementTypes });
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
                        CollectObjectSegment(t as INamedTypeSymbol);
                    }
                    return;
                }
            }

            if (type.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) == null)
            {
                throw new Exception($"Type must mark ZeroFormattableAttribute. {type.Name}.  Location:{type.Locations[0]}");
            }

            if (!type.IsValueType)
            {
                if (!type.Constructors.Any(x => x.Parameters.Length == 0))
                {
                    throw new Exception($"Type must needs parameterless constructor. {type.Name}. Location:{type.Locations[0]}");
                }
            }
            else
            {
                var indexes = new List<Tuple<int, IPropertySymbol>>();
                foreach (var item in type.GetMembers().OfType<IPropertySymbol>())
                {
                    var indexAttr = item.GetAttributes().FindAttributeShortName(IndexAttributeShortName);
                    if (indexAttr != null)
                    {
                        var index = (int)indexAttr.ConstructorArguments[0].Value;
                        indexes.Add(Tuple.Create(index, item));
                    }
                }
                indexes = indexes.OrderBy(x => x.Item1).ToList();

                var expected = 0;
                foreach (var item in indexes)
                {
                    if (item.Item1 != expected)
                    {
                        throw new Exception($"Struct index must be started with 0 and be sequential. Type: {type.Name}, InvalidIndex: {item.Item1}");
                    }
                    expected++;
                }

                var foundConstructor = false;
                var ctors = (type as INamedTypeSymbol)?.Constructors;
                foreach (var ctor in ctors)
                {
                    var isMatch = indexes.Select(x => x.Item2.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat))
                        .SequenceEqual(ctor.Parameters.Select(x => x.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)));
                    if (isMatch)
                    {
                        foundConstructor = true;
                    }
                }
                if (!foundConstructor && indexes.Count != 0)
                {
                    throw new Exception($"Struct needs full parameter constructor of index property types. Type: {type.Name}");
                }
            }

            var list = new List<ObjectSegmentType.PropertyTuple>();

            var definedIndexes = new HashSet<int>();

            foreach (var property in type.GetAllMembers())
            {
                var propSymbol = property as IPropertySymbol;
                var fieldSymbol = property as IFieldSymbol;

                if ((propSymbol == null && fieldSymbol == null))
                {
                    continue;
                }

                if (property.DeclaredAccessibility != Accessibility.Public)
                {
                    continue;
                }

                var attributes = property.GetAttributes();
                if (attributes.FindAttributeShortName(IgnoreAttributeShortName) != null)
                {
                    continue;
                }

                if (!type.IsValueType)
                {
                    if (!property.IsVirtual)
                    {
                        throw new Exception($"Public property's accessor must be virtual. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                    }
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

                if (!type.IsValueType)
                {
                    if (propSymbol == null)
                    {
                        throw new Exception($"Class does not allow that field marks IndexAttribute. {type.Name }{property.Name}");
                    }

                    if (propSymbol.GetMethod == null || propSymbol.SetMethod == null
                     || propSymbol.GetMethod.DeclaredAccessibility == Accessibility.Private
                     || propSymbol.SetMethod.DeclaredAccessibility == Accessibility.Private)
                    {
                        throw new Exception($"Public property's accessor must needs both public/protected get and set. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                    }
                }

                var memberType = (propSymbol != null) ? propSymbol.Type : fieldSymbol.Type;

                if (memberType.TypeKind == TypeKind.Array)
                {
                    var array = memberType as IArrayTypeSymbol;
                    var t = array.ElementType;
                    if (t.SpecialType != SpecialType.System_Byte) // allows byte[]
                    {
                        throw new Exception($"Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[]. {type.Name}.{property.Name}.  Location:{type.Locations[0]}");
                    }
                }
                else
                {
                    var namedType = memberType as INamedTypeSymbol;
                    if (namedType != null) // if <T> is unnamed type, it can't analyze.
                    {
                        // Recursive
                        CollectObjectSegment(namedType);
                    }
                }

                var length = KnownFormatterSpec.GetLength(memberType);
                var prop = new ObjectSegmentType.PropertyTuple
                {
                    Name = property.Name,
                    Type = memberType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                    Index = (int)index.Value,
                    IsGetProtected = (propSymbol != null) ? propSymbol.GetMethod.DeclaredAccessibility == Accessibility.Protected : false,
                    IsSetProtected = (propSymbol != null) ? propSymbol.SetMethod.DeclaredAccessibility == Accessibility.Protected : false,
                    FixedSize = length ?? 0,
                    IsProperty = propSymbol != null,
                    IsCacheSegment = KnownFormatterSpec.CanAcceptCacheSegment(memberType),
                    IsFixedSize = (length != null)
                };

                list.Add(prop);
            }

            var segment = new ObjectSegmentType
            {
                Name = type.Name,
                FullName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                Namespace = type.ContainingNamespace.IsGlobalNamespace ? null : type.ContainingNamespace.ToDisplayString(),
                LastIndex = list.Select(x => x.Index).DefaultIfEmpty(0).Max(),
                Properties = list.OrderBy(x => x.Index).ToArray(),
            };

            if (type.IsValueType)
            {
                structContainer.Add(segment);
            }
            else
            {
                objectContainer.Add(segment);
            }
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
    }
}