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

        internal static readonly DiagnosticDescriptor TypeMustBeZeroFormattable = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(TypeMustBeZeroFormattable), title: Title, category: Category,
            messageFormat: "Type must mark ZeroFormattableAttribute. {0}.", // type.Name
            description: "Type must mark ZeroFormattableAttribute.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyNeedsIndex = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(PublicPropertyNeedsIndex), title: Title, category: Category,
            messageFormat: "Public property must mark IndexAttribute or IgnoreFormatAttribute. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property must mark IndexAttribute or IgnoreFormatAttribute.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyNeedsGetAndSetAccessor = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(PublicPropertyNeedsGetAndSetAccessor), title: Title, category: Category,
            messageFormat: "Public property's accessor must needs both public/protected get and set. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property's accessor must needs both public/protected get and set.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyMustBeVirtual = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(PublicPropertyMustBeVirtual), title: Title, category: Category,
            messageFormat: "Public property's accessor must be virtual. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property's accessor must be virtual.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor IndexAttributeDuplicate = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(IndexAttributeDuplicate), title: Title, category: Category,
            messageFormat: "IndexAttribute can not allow duplicate. {0}.{1}, Index:{2}", // type.Name, item.Name index.Index
            description: "IndexAttribute can not allow duplicate.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor DictionaryNotSupport = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(DictionaryNotSupport), title: Title, category: Category,
            messageFormat: "Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary. {0}.{1}.", // type.Name + "." + property.Name 
            description: "Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor ListNotSupport = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(ListNotSupport), title: Title, category: Category,
            messageFormat: "List does not support in ZeroFormatter because List have to deserialize all objects. You can use IList<T> instead of List. {0}.{1}.", // type.Name + "." + property.Name 
            description: "List does not support in ZeroFormatter because List have to deserialize all objects. You can use IList<T> instead of List.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor ArrayNotSupport = new DiagnosticDescriptor(
            id: DiagnosticIdBase + "_" + nameof(ArrayNotSupport), title: Title, category: Category,
            messageFormat: "Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[]. {0}.{1}.", // type.Name + "." + property.Name 
            description: "Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[].",
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

        static readonly ImmutableArray<DiagnosticDescriptor> supportedDiagnostics = ImmutableArray.Create(
            TypeMustBeZeroFormattable,
            PublicPropertyNeedsIndex,
            PublicPropertyNeedsGetAndSetAccessor,
            PublicPropertyMustBeVirtual,
            IndexAttributeDuplicate,
            DictionaryNotSupport,
            ListNotSupport,
            ArrayNotSupport,
            IndexIsTooLarge,
            TypeMustNeedsParameterlessConstructor,
            StructIndexMustBeStartedWithZeroAndSequential,
            StructMustNeedsSameConstructorWithIndexes
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
            context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.ClassDeclaration, SyntaxKind.StructDeclaration);
        }

        static void Analyze(SyntaxNodeAnalysisContext context)
        {
            var model = context.SemanticModel;

            var typeDeclaration = context.Node as TypeDeclarationSyntax;
            if (typeDeclaration == null) return;

            var declaredSymbol = model.GetDeclaredSymbol(typeDeclaration);
            if (declaredSymbol == null) return;

            // Analysing Target is only [ZeroFormattable] class, allows ShortName
            if (declaredSymbol.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) == null)
            {
                return;
            }

            var reportContext = new DiagnosticsReportContext(context);

            // Start RootType
            VerifyType(reportContext, typeDeclaration.GetLocation(), declaredSymbol, new HashSet<ITypeSymbol>(), null);

            reportContext.ReportAll();
        }

        static void VerifyType(DiagnosticsReportContext context, Location callerLocation, ITypeSymbol type, HashSet<ITypeSymbol> alreadyAnalyzed, IPropertySymbol callFromProperty)
        {
            if (!alreadyAnalyzed.Add(type))
            {
                return;
            }

            if (AllowTypes.Contains(type.ToDisplayString()))
            {
                return; // it is primitive...
            }

            if (type.TypeKind == TypeKind.Enum)
            {
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
                else if (genericTypeString == "System.Collections.Generic.List<>")
                {
                    context.Add(Diagnostic.Create(ListNotSupport, callerLocation, callFromProperty.ContainingType?.Name, callFromProperty.Name));
                    return;
                }
                else if (genericTypeString == "System.Collections.Generic.Dictionary<,>")
                {
                    context.Add(Diagnostic.Create(DictionaryNotSupport, callerLocation, callFromProperty.ContainingType?.Name, callFromProperty.Name));
                    return;
                }
                else if (genericTypeString == "System.Collections.Generic.IList<>"
                      || genericTypeString == "System.Collections.Generic.IDictionary<,>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyList<>"
                      || genericTypeString == "System.Collections.Generic.IReadOnlyDictionary<,>"
                      || genericTypeString == "System.Linq.ILookup<,>"
                      || genericTypeString.StartsWith("ZeroFormatter.KeyTuple"))
                {
                    foreach (var t in namedType.TypeArguments)
                    {
                        VerifyType(context, callerLocation, t, alreadyAnalyzed, callFromProperty);
                    }
                    return;
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

                if (type.IsValueType && context.Diagnostics.Count == 0)
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
                            context.Add(Diagnostic.Create(StructIndexMustBeStartedWithZeroAndSequential, callerLocation, type.Locations, type.Name, item.Item1));
                            return;
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
                        context.Add(Diagnostic.Create(StructMustNeedsSameConstructorWithIndexes, callerLocation, type.Locations, type.Name));
                        return;
                    }

                    return;
                }
            }
        }

        static void VerifyProperty(DiagnosticsReportContext context, IPropertySymbol property, HashSet<ITypeSymbol> alreadyAnalyzed, HashSet<int> definedIndexes)
        {
            if (property.DeclaredAccessibility != Accessibility.Public)
            {
                return;
            }

            var attributes = property.GetAttributes();
            if (attributes.FindAttributeShortName(IgnoreShortName) != null)
            {
                return;
            }

            if (!property.IsVirtual && !property.ContainingType.IsValueType)
            {
                context.Add(Diagnostic.Create(PublicPropertyMustBeVirtual, property.Locations[0], property.ContainingType?.Name, property.Name));
                return;
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

            if (property.Type.TypeKind == TypeKind.Array)
            {
                var array = property.Type as IArrayTypeSymbol;
                var t = array.ElementType;
                if (t.SpecialType == SpecialType.System_Byte) // allows byte[]
                {
                    return;
                }

                context.Add(Diagnostic.Create(ArrayNotSupport, property.Locations[0], property.ContainingType?.Name, property.Name));
                return;
            }

            var namedType = property.Type as INamedTypeSymbol;
            if (namedType != null) // if <T> is unnamed type, it can't analyze.
            {
                VerifyType(context, property.Locations[0], property.Type, alreadyAnalyzed, property);
            }
        }
    }
}