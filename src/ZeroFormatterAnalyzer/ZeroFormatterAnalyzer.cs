using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ZeroFormatter.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ZeroFormatterAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "ZeroFormatterAnalyzer";

        internal const string Title = "Lint of ZeroFormattable Type.";
        internal const string Category = "Usage";

        internal const string ZeroFormattableAttributeShortName = "ZeroFormattableAttribute";
        internal const string IndexAttributeShortName = "IndexAttribute";
        internal const string IgnoreShortName = "IgnoreFormatAttribute";

        internal static readonly DiagnosticDescriptor TypeMustBeClass = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(TypeMustBeClass) , title: Title, category: Category,
            messageFormat: "Type must be class. {0}.", // type.Name
            description: "Type must be class.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor TypeMustBeZeroFormattable = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(TypeMustBeZeroFormattable), title: Title, category: Category,
            messageFormat: "Type must mark ZeroFormattableAttribute. {0}.", // type.Name
            description: "Type must mark ZeroFormattableAttribute.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyNeedsIndex = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(PublicPropertyNeedsIndex), title: Title, category: Category,
            messageFormat: "Public property must mark IndexAttribute or IgnoreFormatAttribute. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property must mark IndexAttribute or IgnoreFormatAttribute.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyNeedsGetAndSetAccessor = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(PublicPropertyNeedsGetAndSetAccessor), title: Title, category: Category,
            messageFormat: "Public property's accessor must needs both public/protected get and set. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property's accessor must needs both public/protected get and set.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor PublicPropertyMustBeVirtual = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(PublicPropertyMustBeVirtual), title: Title, category: Category,
            messageFormat: "Public property's accessor must be virtual. {0}.{1}.", // type.Name + "." + item.Name
            description: "Public property's accessor must be virtual.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor IndexAttributeDuplicate = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(IndexAttributeDuplicate), title: Title, category: Category,
            messageFormat: "IndexAttribute can not allow duplicate. {0}.{1}, Index:{2}", // type.Name, item.Name index.Index
            description: "IndexAttribute can not allow duplicate.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor DictionaryNotSupport = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(DictionaryNotSupport), title: Title, category: Category,
            messageFormat: "Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary. {0}.{1}.", // type.Name + "." + property.Name 
            description: "Dictionary does not support in ZeroFormatter because Dictionary have to deserialize all objects. You can use IDictionary<TK, TV> instead of Dictionary.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor ListNotSupport = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(ListNotSupport), title: Title, category: Category,
            messageFormat: "List does not support in ZeroFormatter because List have to deserialize all objects. You can use IList<T> instead of List. {0}.{1}.", // type.Name + "." + property.Name 
            description: "List does not support in ZeroFormatter because List have to deserialize all objects. You can use IList<T> instead of List.",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor ArrayNotSupport = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(ArrayNotSupport), title: Title, category: Category,
            messageFormat: "Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[]. {0}.{1}.", // type.Name + "." + property.Name 
            description: "Array does not support in ZeroFormatter(except byte[]) because Array have to deserialize all objects. You can use IList<T> instead of T[].",
            defaultSeverity: DiagnosticSeverity.Error, isEnabledByDefault: true);

        internal static readonly DiagnosticDescriptor IndexIsTooLarge = new DiagnosticDescriptor(
            id: DiagnosticId + "_" + nameof(IndexIsTooLarge), title: Title, category: Category,
            messageFormat: "MaxIndex is {0}, it is large. Index is size of binary, recommended to small. {1}", // index, type.Name
            description: "MaxIndex is large. Index is size of binary, recommended to small.",
            defaultSeverity: DiagnosticSeverity.Warning, isEnabledByDefault: true);

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
                return ImmutableArray.Create(TypeMustBeClass, TypeMustBeZeroFormattable, PublicPropertyNeedsIndex, PublicPropertyNeedsGetAndSetAccessor, PublicPropertyMustBeVirtual, IndexAttributeDuplicate);
            }
        }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.ClassDeclaration);
        }

        static void Analyze(SyntaxNodeAnalysisContext context)
        {
            var model = context.SemanticModel;

            var classDeclaration = context.Node as ClassDeclarationSyntax;
            if (classDeclaration == null) return;

            var declaredSymbol = model.GetDeclaredSymbol(classDeclaration);
            if (declaredSymbol == null) return;

            // Analysing Target is only [ZeroFormattable] class, allows ShortName
            if (declaredSymbol.GetAttributes().FindAttributeShortName(ZeroFormattableAttributeShortName) == null)
            {
                return;
            }

            var reportContext = new DiagnosticsReportContext(context);

            // Start RootType
            VerifyType(reportContext, classDeclaration.GetLocation(), declaredSymbol, new HashSet<ITypeSymbol>(), null);

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

            if (type.IsValueType)
            {
                context.Add(Diagnostic.Create(TypeMustBeClass, callerLocation, type.Locations, type.Name));
                return;
            }

            // If in another project, we can not report so stop analyze.
            if (callFromProperty == null)
            {
                var definedIndexes = new HashSet<int>();
                foreach (var member in type.GetMembers().OfType<IPropertySymbol>())
                {
                    VerifyProperty(context, member, alreadyAnalyzed, definedIndexes);
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

            if (!property.IsVirtual)
            {
                context.Add(Diagnostic.Create(PublicPropertyMustBeVirtual, property.Locations[0], property.ContainingType?.Name, property.Name));
                return;
            }

            var indexAttr = attributes.FindAttributeShortName(IndexAttributeShortName);
            if (indexAttr == null)
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

            if (property.GetMethod == null || property.SetMethod == null
                || property.GetMethod.DeclaredAccessibility == Accessibility.Private
                || property.SetMethod.DeclaredAccessibility == Accessibility.Private)
            {
                context.Add(Diagnostic.Create(PublicPropertyNeedsGetAndSetAccessor, property.Locations[0], property.ContainingType?.Name, property.Name));
                return;
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