using Microsoft.CodeAnalysis;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System;

namespace ZeroFormatter.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ZeroFormatterAnalyzer : DiagnosticAnalyzer
    {
        const string DiagnosticIdBase = "ZeroFormatterAnalyzer";

        internal const string Title = "Lint of ZeroFormattable Type.";
        internal const string Category = "Usage";

        internal const string ZeroFormattableAttributeShortName = "ZeroFormattableAttribute";
        internal const string IndexAttributeShortName = "IndexAttribute";
        internal const string IgnoreShortName = "IgnoreFormatAttribute";
        internal const string UnionAttributeShortName = "UnionAttribute";
        internal const string DynamicUnionAttributeShortName = "DynamicUnionAttribute";
        internal const string UnionKeyAttributeShortName = "UnionKeyAttribute";

        internal static readonly DiagnosticDescriptor TypeMustBeZeroFormattable = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(TypeMustBeZeroFormattable), title: Title, category: Category,
            messageFormat: "Type must be marked with ZeroFormattableAttribute. {0}.", // type.Name
            description: "Type must be marked with ZeroFormattableAttribute.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyNeedsIndex = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(PublicPropertyNeedsIndex), title: Title, category: Category,
            messageFormat: "Public property must be marked with IndexAttribute or IgnoreFormatAttribute. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property must be marked with IndexAttribute or IgnoreFormatAttribute.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyNeedsGetAndSetAccessor = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(PublicPropertyNeedsGetAndSetAccessor), title: Title, category: Category,
            messageFormat: "Public property must needs both public/protected get and set accessor. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property must needs both public/protected get and set accessor.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyMustBeVirtual = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(PublicPropertyMustBeVirtual), title: Title, category: Category,
            messageFormat: "Public property's accessor must be virtual. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property's accessor must be virtual.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor ClassNotSupportPublicField = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(ClassNotSupportPublicField), title: Title, category: Category,
            messageFormat: "Class's public field is not supported. {0}.{1}.", // type.Name + "." + item.Name
            description: "Class's public field is not supported.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor IndexAttributeDuplicate = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(IndexAttributeDuplicate), title: Title, category: Category,
            messageFormat: "IndexAttribute is not allow duplicate number. {0}.{1}, Index:{2}", // type.Name, item.Name index.Index
            description: "IndexAttribute is not allow duplicate number.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor IndexIsTooLarge = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(IndexIsTooLarge), title: Title, category: Category,
            messageFormat: "MaxIndex is {0}, it is large. Index is size of binary, recommended to small. {1}", // index, type.Name
            description: "MaxIndex is large. Index is size of binary, recommended to small.",
            defaultSeverity: DiagnosticSeverity.Warning, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor TypeMustNeedsParameterlessConstructor = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(TypeMustNeedsParameterlessConstructor), title: Title, category: Category,
            messageFormat: "Type must needs parameterless constructor. {0}", //  type.Name
            description: "Type must needs parameterless constructor.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor StructIndexMustBeStartedWithZeroAndSequential = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(StructIndexMustBeStartedWithZeroAndSequential), title: Title, category: Category,
            messageFormat: "Struct index must be started with 0 and be sequential. Type: {0}, InvalidIndex: {1}", //  type.Name, index
            description: "Struct index must be started with 0 and be sequential.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor StructMustNeedsSameConstructorWithIndexes = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(StructIndexMustBeStartedWithZeroAndSequential), title: Title, category: Category,
            messageFormat: "Struct needs full parameter constructor of index property types. Type: {0}", //  type.Name
            description: "Struct needs full parameter constructor of index property types.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor UnionTypeRequiresUnionKey = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(UnionTypeRequiresUnionKey), title: Title, category: Category,
            messageFormat: "Union class requires abstract [UnionKey]property. Type: {0}", //  type.Name
            description: "Union class requires abstract [UnionKey]property.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor UnionKeyDoesNotAllowMultipleKey = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(UnionKeyDoesNotAllowMultipleKey), title: Title, category: Category,
            messageFormat: "[UnionKey]property does not allow multiple key. Type: {0}", //  type.Name
            description: "[UnionKey]property does not allow multiple key.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor AllUnionSubTypesMustBeInheritedType = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(UnionKeyDoesNotAllowMultipleKey), title: Title, category: Category,
            messageFormat: "All Union subTypes must be inherited type. Type: {0}, SubType: {1}", //  type.Name subType.Name
            description: "All Union subTypes must be inherited type.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        static readonly ImmutableArray<DiagnosticDescriptor> supportedDiagnostics = ImmutableArray.Create(
            TypeMustBeZeroFormattable,
            PublicPropertyNeedsIndex,
            PublicPropertyNeedsGetAndSetAccessor,
            PublicPropertyMustBeVirtual,
            ClassNotSupportPublicField,
            IndexAttributeDuplicate,
            IndexIsTooLarge,
            TypeMustNeedsParameterlessConstructor,
            StructIndexMustBeStartedWithZeroAndSequential,
            StructMustNeedsSameConstructorWithIndexes,
            UnionTypeRequiresUnionKey,
            UnionKeyDoesNotAllowMultipleKey,
            AllUnionSubTypesMustBeInheritedType
            );

        static readonly HashSet<string> AllowTypes = new HashSet<string>
        {
            "short",
            "int",
            "long",
            "ushort",
            "uint",
            "ulong",
            "float",
            "double",
            "bool",
            "byte",
            "sbyte",
            "decimal",
            "char",
            "string",
            "System.Guid",
            "System.TimeSpan",
            "System.DateTime",
            "System.DateTimeOffset"
        };

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return supportedDiagnostics;
            }
        }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.ClassDeclaration, SyntaxKind.StructDeclaration, SyntaxKind.InterfaceDeclaration);
        }

        static void Analyze(SyntaxNodeAnalysisContext context)
        {
            var model = context.SemanticModel;

            var typeDeclaration = context.Node as TypeDeclarationSyntax;
            if (typeDeclaration == null) return;

            var declaredSymbol = model.GetDeclaredSymbol(typeDeclaration);
            if (declaredSymbol == null) return;

            var isUnion = declaredSymbol.GetAttributes().FindAttributeShortName(UnionAttributeShortName) != null;
            var isZeroFormattable = declaredSymbol.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) != null;

            if (!isUnion && !isZeroFormattable)
            {
                return;
            }

            var reportContext = new DiagnosticsReportContext(context);
            if (isUnion)
            {
                VerifyUnion(reportContext, typeDeclaration.GetLocation(), declaredSymbol);
            }
            if (isZeroFormattable)
            {
                VerifyType(reportContext, typeDeclaration.GetLocation(), declaredSymbol, new HashSet<ITypeSymbol>(), null);
            }

            reportContext.ReportAll();
        }

        static void VerifyType(DiagnosticsReportContext context, Location callerLocation, ITypeSymbol type, HashSet<ITypeSymbol> alreadyAnalyzed, ISymbol callFromProperty)
        {
            if (!alreadyAnalyzed.Add(type))
            {
                return;
            }

            var displayString = type.ToDisplayString();
            if (AllowTypes.Contains(displayString))
            {
                return; // it is primitive...
            }
            else if (context.AdditionalAllowTypes.Contains(displayString))
            {
                return;
            }

            if (type.GetAttributes().FindAttributeShortName(UnionAttributeShortName) != null)
            {
                return;
            }

            if (type.GetAttributes().FindAttributeShortName(DynamicUnionAttributeShortName) != null)
            {
                return;
            }

            if (type.TypeKind == TypeKind.Enum)
            {
                return;
            }
            if (type.TypeKind == TypeKind.Array)
            {
                var array = type as IArrayTypeSymbol;
                var t = array.ElementType;
                VerifyType(context, callerLocation, t, alreadyAnalyzed, callFromProperty);
                return;
            }

            var namedType = type as INamedTypeSymbol;
            if (namedType != null && namedType.IsGenericType && callFromProperty != null)
            {
                var genericType = namedType.ConstructUnboundGenericType();
                var genericTypeString = genericType.ToDisplayString();

                if (genericTypeString == "T?")
                {
                    VerifyType(context, callerLocation, namedType.TypeArguments[0], alreadyAnalyzed, callFromProperty);
                    return;
                }
                else if (genericTypeString == "System.Collections.Generic.IList<>"
                      || genericTypeString == "System.Collections.Generic.IDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.Dictionary<,>"
                      || genericTypeString == "ZeroFormatter.ILazyDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyList<>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyCollection<>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.ICollection<>"
                      || genericTypeString == "System.Collections.Generic.IEnumerable<>"
                      || genericTypeString == "System.Collections.Generic.ISet<>"
                      || genericTypeString == "System.Collections.ObjectModel.ReadOnlyCollection<>"
                      || genericTypeString == "System.Collections.ObjectModel.ReadOnlyDictionary<,>"
                      || genericTypeString == "ZeroFormatter.ILazyReadOnlyDictionary<,>"
                      || genericTypeString == "System.Linq.ILookup<,>"
                      || genericTypeString == "ZeroFormatter.ILazyLookup<,>"
                      || genericTypeString.StartsWith("System.Collections.Generic.KeyValuePair")
                      || genericTypeString.StartsWith("System.Tuple")
                      || genericTypeString.StartsWith("ZeroFormatter.KeyTuple")
                      || context.AdditionalAllowTypes.Contains(genericTypeString)
                      )
                {
                    foreach (var t in namedType.TypeArguments)
                    {
                        VerifyType(context, callerLocation, t, alreadyAnalyzed, callFromProperty);
                    }
                    return;
                }
                else
                {
                    if (namedType.AllInterfaces.Any(x => (x.IsGenericType ? x.ConstructUnboundGenericType().ToDisplayString() : "") == "System.Collections.Generic.ICollection<>"))
                    {
                        foreach (var t in namedType.TypeArguments)
                        {
                            VerifyType(context, callerLocation, t, alreadyAnalyzed, callFromProperty);
                        }
                        return;
                    }
                }
            }

            if (type.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) == null)
            {
                context.Add(Diagnostic.Create(TypeMustBeZeroFormattable, callerLocation, type.Locations, type.Name));
                return;
            }

            if (namedType != null && !namedType.IsValueType)
            {
                if (!namedType.Constructors.Any(x => x.Parameters.Length == 0))
                {
                    context.Add(Diagnostic.Create(TypeMustNeedsParameterlessConstructor, callerLocation, type.Locations, type.Name));
                    return;
                }
            }

            // If in another project, we can not report so stop analyze.
            if (callFromProperty == null)
            {
                var definedIndexes = new HashSet<int>();
                foreach (var member in type.GetAllMembers().OfType<IPropertySymbol>())
                {
                    VerifyProperty(context, member, alreadyAnalyzed, definedIndexes);
                }
                foreach (var member in type.GetAllMembers().OfType<IFieldSymbol>())
                {
                    VerifyField(context, member, alreadyAnalyzed, definedIndexes);
                }

                if (type.IsValueType && context.Diagnostics.Count == 0)
                {
                    var indexes = new List<Tuple<int, ITypeSymbol>>();
                    foreach (var item in type.GetMembers())
                    {
                        var propSymbol = item as IPropertySymbol;
                        var fieldSymbol = item as IFieldSymbol;
                        if ((propSymbol == null && fieldSymbol == null))
                        {
                            continue;
                        }

                        var indexAttr = item.GetAttributes().FindAttributeShortName(IndexAttributeShortName);
                        if (indexAttr != null)
                        {
                            var index = (int)indexAttr.ConstructorArguments[0].Value;
                            indexes.Add(Tuple.Create(index, (propSymbol != null) ? propSymbol.Type : fieldSymbol.Type));
                        }
                    }
                    indexes = indexes.OrderBy(x => x.Item1).ToList();

                    var expected = 0;
                    foreach (var item in indexes)
                    {
                        if (item.Item1 != expected)
                        {
                            context.Add(Diagnostic.Create(StructIndexMustBeStartedWithZeroAndSequential, callerLocation, type.Locations, type.Name, item.Item1));
                            return;
                        }
                        expected++;
                    }

                    var foundConstructor = false;
                    var ctors = (type as INamedTypeSymbol)?.Constructors;
                    foreach (var ctor in ctors)
                    {
                        var isMatch = indexes.Select(x => x.Item2.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat))
                            .SequenceEqual(ctor.Parameters.Select(x => x.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)));
                        if (isMatch)
                        {
                            foundConstructor = true;
                        }
                    }
                    if (!foundConstructor && indexes.Count != 0)
                    {
                        context.Add(Diagnostic.Create(StructMustNeedsSameConstructorWithIndexes, callerLocation, type.Locations, type.Name));
                        return;
                    }

                    return;
                }
            }
        }

        static void VerifyProperty(DiagnosticsReportContext context, IPropertySymbol property, HashSet<ITypeSymbol> alreadyAnalyzed, HashSet<int> definedIndexes)
        {
            if (property.IsStatic)
            {
                return;
            }

            if (property.DeclaredAccessibility != Accessibility.Public)
            {
                return;
            }

            var attributes = property.GetAttributes();
            if (attributes.FindAttributeShortName(IgnoreShortName) != null)
            {
                return;
            }

            if (property.FindAttributeIncludeBasePropertyShortName(UnionKeyAttributeShortName) != null)
            {
                return;
            }

            if (!property.IsVirtual && !property.ContainingType.IsValueType)
            {
                if (property.IsOverride && !property.IsSealed)
                {
                    // ok, base type's override property.
                }
                else
                {
                    context.Add(Diagnostic.Create(PublicPropertyMustBeVirtual, property.Locations[0], property.ContainingType?.Name, property.Name));
                    return;
                }
            }

            var indexAttr = attributes.FindAttributeShortName(IndexAttributeShortName);
            if (indexAttr == null || indexAttr.ConstructorArguments.Length == 0)
            {
                context.Add(Diagnostic.Create(PublicPropertyNeedsIndex, property.Locations[0], property.ContainingType?.Name, property.Name));
                return;
            }

            var index = indexAttr.ConstructorArguments[0];
            if (index.IsNull)
            {
                return; // null is normal compiler error.
            }

            if (!definedIndexes.Add((int)index.Value))
            {
                context.Add(Diagnostic.Create(IndexAttributeDuplicate, property.Locations[0], property.ContainingType?.Name, property.Name, index.Value));
                return;
            }

            if ((int)index.Value >= 100)
            {
                context.Add(Diagnostic.Create(IndexIsTooLarge, property.Locations[0], index.Value, property.Name));
            }

            if (!property.ContainingType.IsValueType)
            {
                if (property.GetMethod == null || property.SetMethod == null
                    || property.GetMethod.DeclaredAccessibility == Accessibility.Private
                    || property.SetMethod.DeclaredAccessibility == Accessibility.Private)
                {
                    context.Add(Diagnostic.Create(PublicPropertyNeedsGetAndSetAccessor, property.Locations[0], property.ContainingType?.Name, property.Name));
                    return;
                }
            }

            var namedType = property.Type as INamedTypeSymbol;
            if (namedType != null) // if <T> is unnamed type, it can't analyze.
            {
                VerifyType(context, property.Locations[0], property.Type, alreadyAnalyzed, property);
                return;
            }

            if (property.Type.TypeKind == TypeKind.Array)
            {
                var array = property.Type as IArrayTypeSymbol;
                var t = array.ElementType;
                VerifyType(context, property.Locations[0], property.Type, alreadyAnalyzed, property);
                return;
            }
        }

        static void VerifyField(DiagnosticsReportContext context, IFieldSymbol field, HashSet<ITypeSymbol> alreadyAnalyzed, HashSet<int> definedIndexes)
        {
            if (field.IsStatic)
            {
                return;
            }

            if (field.DeclaredAccessibility != Accessibility.Public)
            {
                return;
            }

            var attributes = field.GetAttributes();
            if (attributes.FindAttributeShortName(IgnoreShortName) != null)
            {
                return;
            }

            if (!field.ContainingType.IsValueType)
            {
                context.Add(Diagnostic.Create(ClassNotSupportPublicField, field.Locations[0], field.ContainingType?.Name, field.Name));
                return;
            }

            var indexAttr = attributes.FindAttributeShortName(IndexAttributeShortName);
            if (indexAttr == null || indexAttr.ConstructorArguments.Length == 0)
            {
                context.Add(Diagnostic.Create(PublicPropertyNeedsIndex, field.Locations[0], field.ContainingType?.Name, field.Name));
                return;
            }

            var index = indexAttr.ConstructorArguments[0];
            if (index.IsNull)
            {
                return; // null is normal compiler error.
            }

            if (!definedIndexes.Add((int)index.Value))
            {
                context.Add(Diagnostic.Create(IndexAttributeDuplicate, field.Locations[0], field.ContainingType?.Name, field.Name, index.Value));
                return;
            }

            if ((int)index.Value >= 100)
            {
                context.Add(Diagnostic.Create(IndexIsTooLarge, field.Locations[0], index.Value, field.Name));
            }

            var namedType = field.Type as INamedTypeSymbol;
            if (namedType != null) // if <T> is unnamed type, it can't analyze.
            {
                VerifyType(context, field.Locations[0], field.Type, alreadyAnalyzed, field);
            }
        }

        static void VerifyUnion(DiagnosticsReportContext context, Location callerLocation, ITypeSymbol type)
        {
            var unionKeys = type.GetMembers().OfType<IPropertySymbol>().Where(x => x.GetAttributes().FindAttributeShortName(UnionKeyAttributeShortName) != null).ToArray();
            if (unionKeys.Length == 0)
            {
                context.Add(Diagnostic.Create(UnionTypeRequiresUnionKey, callerLocation, type.Locations, type.Name));
                return;
            }
            else if (unionKeys.Length != 1)
            {
                context.Add(Diagnostic.Create(UnionKeyDoesNotAllowMultipleKey, callerLocation, type.Locations, type.Name));
                return;
            }

            var unionKeyProperty = unionKeys[0];
            if (type.TypeKind != TypeKind.Interface && !unionKeyProperty.GetMethod.IsAbstract)
            {
                context.Add(Diagnostic.Create(UnionTypeRequiresUnionKey, callerLocation, type.Locations, type.Name));
                return;
            }

            var ctorArguments = type.GetAttributes().FindAttributeShortName(UnionAttributeShortName)?.ConstructorArguments;
            var firstArguments = ctorArguments?.FirstOrDefault();

            if (firstArguments == null) return;

            TypedConstant fallbackType = default(TypedConstant);
            if (ctorArguments.Value.Length == 2)
            {
                fallbackType = ctorArguments.Value[1];
            }

            if (type.TypeKind != TypeKind.Interface)
            {
                foreach (var item in firstArguments.Value.Values.Concat(new[] { fallbackType }).Where(x => !x.IsNull).Select(x => x.Value).OfType<ITypeSymbol>())
                {
                    var found = item.FindBaseTargetType(type.ToDisplayString());

                    if (found == null)
                    {
                        context.Add(Diagnostic.Create(AllUnionSubTypesMustBeInheritedType, callerLocation, type.Locations, type.Name, item.Name));
                        return;
                    }
                }
            }
            else
            {
                foreach (var item in firstArguments.Value.Values.Concat(new[] { fallbackType }).Where(x => !x.IsNull).Select(x => x.Value).OfType<ITypeSymbol>())
                {
                    var typeString = type.ToDisplayString();
                    if (!(item as INamedTypeSymbol).AllInterfaces.Any(x => x.OriginalDefinition?.ToDisplayString() == typeString))
                    {
                        context.Add(Diagnostic.Create(AllUnionSubTypesMustBeInheritedType, callerLocation, type.Locations, type.Name, item.Name));
                        return;
                    }
                }
            }
        }
    }
}