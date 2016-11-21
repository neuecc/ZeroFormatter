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
        internal const string UnionAttributeShortName = "UnionAttribute";
        internal const string UnionKeyAttributeShortName = "UnionKeyAttribute";

        static readonly SymbolDisplayFormat binaryWriteFormat = new SymbolDisplayFormat(
                genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters,
                miscellaneousOptions: SymbolDisplayMiscellaneousOptions.ExpandNullable,
                typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly);

        ILookup<TypeKind, INamedTypeSymbol> targetTypes;
        List<EnumType> enumContainer;
        List<ObjectSegmentType> structContainer;
        List<ObjectSegmentType> objectContainer;
        List<GenericType> genericTypeContainer;
        List<UnionType> unionTypeContainer;
        HashSet<string> alreadyCollected;

        HashSet<string> allowCustomTypes;

        public TypeCollector(string csProjPath, IEnumerable<string> conditinalSymbols, IEnumerable<string> allowCustomTypes)
        {
            this.csProjPath = csProjPath;
            this.allowCustomTypes = new HashSet<string>(allowCustomTypes);

            var compilation = RoslynExtensions.GetCompilationFromProject(csProjPath, conditinalSymbols.Concat(new[] { CodegeneratorOnlyPreprocessorSymbol }).ToArray()).GetAwaiter().GetResult();
            targetTypes = compilation.GetNamedTypeSymbols()
                .Where(x => (x.TypeKind == TypeKind.Enum)
                    || ((x.TypeKind == TypeKind.Class) && x.GetAttributes().FindAttributeShortName(UnionAttributeShortName) != null)
                    || ((x.TypeKind == TypeKind.Interface) && x.GetAttributes().FindAttributeShortName(UnionAttributeShortName) != null)
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
            unionTypeContainer = new List<CodeGenerator.UnionType>();
            alreadyCollected = new HashSet<string>();
        }

        public void Visit(out EnumGenerator[] enumGenerators, out ObjectGenerator[] objectGenerators, out StructGenerator[] structGenerators, out UnionGenerator[] unionGenerators, out GenericType[] genericTypes)
        {
            Init(); // cleanup field.

            foreach (var item in targetTypes[TypeKind.Enum])
            {
                CollectEnum(item);
            }
            foreach (var item in targetTypes[TypeKind.Class])
            {
                if (item.GetAttributes().FindAttributeShortName(UnionAttributeShortName) != null)
                {
                    CollectUnion(item);
                }
                else
                {
                    CollectObjectSegment(item);
                }
            }
            foreach (var item in targetTypes[TypeKind.Interface])
            {
                CollectUnion(item);
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

            unionGenerators = unionTypeContainer
               .GroupBy(x => x.Namespace)
               .Select(x => new UnionGenerator
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
            if (allowCustomTypes.Contains(type.ToDisplayString()))
            {
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
                else if (allowCustomTypes.Contains(genericTypeString))
                {
                    foreach (var t in type.TypeArguments)
                    {
                        CollectObjectSegment(t as INamedTypeSymbol);
                    }
                    return;
                }
                else if (genericTypeString == "System.Collections.Generic.IList<>"
                      || genericTypeString == "System.Collections.Generic.IDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.Dictionary<,>"
                      || genericTypeString == "ZeroFormatter.ILazyDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyList<>"
                      || genericTypeString == "System.Collections.Generic.ICollection<>"
                      || genericTypeString == "System.Collections.Generic.IEnumerable<>"
                      || genericTypeString == "System.Collections.Generic.ISet<>"
                      || genericTypeString == "ZeroFormatter.ILazyReadOnlyDictionary<,>"
                      || genericTypeString == "System.Collections.ObjectModel.ReadOnlyCollection<>"
                      || genericTypeString == "System.Linq.ILookup<,>"
                      || genericTypeString == "ZeroFormatter.ILazyLookup<,>"
                      || genericTypeString.StartsWith("System.Collections.Generic.KeyValuePair")
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
                    else if (genericTypeString == "System.Collections.Generic.IDictionary<,>" || genericTypeString == "System.Collections.Generic.Dictionary<,>")
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.Dictionary, ElementTypes = elementTypes });
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
                    else if (genericTypeString.StartsWith("System.Collections.Generic.KeyValuePair"))
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.KeyValuePair, ElementTypes = elementTypes });
                    }

                    else if (genericTypeString.StartsWith("System.Collections.Generic.ICollection<>"))
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.InterfaceCollection, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString.StartsWith("System.Collections.Generic.IEnumerable<>"))
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.Enumerable, ElementTypes = elementTypes });
                    }
                    else if (genericTypeString.StartsWith("System.Collections.ObjectModel.ReadOnlyCollection<>"))
                    {
                        genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.ReadOnlyCollection, ElementTypes = elementTypes });
                    }

                    foreach (var t in type.TypeArguments)
                    {
                        CollectObjectSegment(t as INamedTypeSymbol);
                    }
                    return;
                }
                else if (type.AllInterfaces.Any(x => (x.IsGenericType ? x.ConstructUnboundGenericType().ToDisplayString() : "") == "System.Collections.Generic.ICollection<>"))
                {
                    var elementTypes = string.Join(", ", type.TypeArguments.Select(x => x.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat))) + ", " + type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.Collection, ElementTypes = elementTypes });

                    foreach (var t in type.TypeArguments)
                    {
                        CollectObjectSegment(t as INamedTypeSymbol);
                    }
                    return;
                }
            }

            if (type.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) == null)
            {
                throw new Exception($"Type must be marked with ZeroFormattableAttribute. {type.Name}.  Location:{type.Locations[0]}");
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

            var distinctName = new HashSet<string>();
            foreach (var property in type.GetAllMembers())
            {
                if (!distinctName.Add(property.Name)) continue;

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
                        if (property.IsOverride && !property.IsSealed)
                        {
                            // okay, it is override property.
                        }
                        else
                        {
                            throw new Exception($"Public property's accessor must be virtual. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                        }
                    }
                }

                if (propSymbol != null && propSymbol.FindAttributeIncludeBasePropertyShortName(UnionKeyAttributeShortName) != null)
                {
                    continue;
                }

                var indexAttr = attributes.FindAttributeShortName(IndexAttributeShortName);
                if (indexAttr == null || indexAttr.ConstructorArguments.Length == 0)
                {
                    throw new Exception($"Public property must be marked with IndexAttribute or IgnoreFormatAttribute. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                }

                var index = indexAttr.ConstructorArguments[0];
                if (index.IsNull)
                {
                    continue; // null is normal compiler error.
                }

                if (!definedIndexes.Add((int)index.Value))
                {
                    throw new Exception($"IndexAttribute is not allow duplicate number. {type.Name}.{property.Name}, Index:{index.Value} Location:{type.Locations[0]}");
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
                        throw new Exception($"Public property must needs both public/protected get and set accessor. {type.Name}.{property.Name}. Location:{type.Locations[0]}");
                    }
                }

                var memberType = (propSymbol != null) ? propSymbol.Type : fieldSymbol.Type;

                if (memberType.TypeKind == TypeKind.Array)
                {
                    var array = memberType as IArrayTypeSymbol;
                    while (array != null)
                    {
                        var t = array.ElementType;
                        if (!KnownFormatterSpec.AllowArrayType(t))
                        {
                            genericTypeContainer.Add(new GenericType { TypeKind = GenericTypeKind.Array, ElementTypes = t.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) });
                        }

                        var namedType = memberType as INamedTypeSymbol;
                        if (namedType != null) // if <T> is unnamed type, it can't analyze.
                        {
                            // Recursive
                            CollectObjectSegment(namedType);
                            break;
                        }
                        array = t as IArrayTypeSymbol;
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
                    IsCacheSegment = !KnownFormatterSpec.IsLazySegment(memberType),
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

        void CollectUnion(INamedTypeSymbol type)
        {
            var unionKeys = type.GetMembers().OfType<IPropertySymbol>().Where(x => x.GetAttributes().FindAttributeShortName(UnionKeyAttributeShortName) != null).ToArray();
            if (unionKeys.Length == 0)
            {
                throw new Exception($"Union class requires abstract [UnionKey]property. Type: {type.Name}. Location:{type.Locations[0]}");
            }
            else if (unionKeys.Length != 1)
            {
                throw new Exception($"[UnionKey]property does not allow multiple key. Type: {type.Name}. Location:{type.Locations[0]}");
            }

            var unionKeyProperty = unionKeys[0];
            if (type.TypeKind != TypeKind.Interface)
            {
                if (!unionKeyProperty.GetMethod.IsAbstract)
                {
                    throw new Exception($"Union class requires abstract [UnionKey]property. Type: {type.Name}. Location:{type.Locations[0]}");
                }
            }

            var constructorArguments = type.GetAttributes().FindAttributeShortName(UnionAttributeShortName)?.ConstructorArguments.FirstOrDefault();

            if (constructorArguments == null) return;

            var subTypList = new List<string>();
            if (type.TypeKind != TypeKind.Interface)
            {
                foreach (var item in constructorArguments.Value.Values.Select(x => x.Value).OfType<ITypeSymbol>())
                {
                    var found = item.FindBaseTargetType(type.ToDisplayString());

                    if (found == null)
                    {
                        throw new Exception($"All Union subTypes must be inherited type. Type: {type.Name}, SubType: {item.Name}. Location:{type.Locations[0]}");
                    }
                    subTypList.Add(item.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));
                }
            }
            else
            {
                foreach (var item in constructorArguments.Value.Values.Select(x => x.Value).OfType<ITypeSymbol>())
                {
                    var typeString = type.ToDisplayString();
                    if (!(item as INamedTypeSymbol).AllInterfaces.Any(x => x.OriginalDefinition?.ToDisplayString() == typeString))
                    {
                        throw new Exception($"All Union subTypes must be inherited type. Type: {type.Name}, SubType: {item.Name}. Location:{type.Locations[0]}");
                    }

                    subTypList.Add(item.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));
                }
            }

            unionTypeContainer.Add(new UnionType
            {
                Name = type.Name,
                FullName = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                Namespace = type.ContainingNamespace.IsGlobalNamespace ? null : type.ContainingNamespace.ToDisplayString(),
                UnionKeyTypeName = unionKeyProperty.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
                UnionKeyPropertyName = unionKeyProperty.Name,
                SubTypeNames = subTypList.ToArray(),
            });
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



