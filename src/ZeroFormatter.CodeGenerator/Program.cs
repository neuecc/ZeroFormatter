using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Mono.Options;
using System.Collections.Generic;

namespace ZeroFormatter.CodeGenerator
{
    // zfc.exe

    class CommandlineArguments
    {
        public string InputPath { get; private set; }
        public string OutputPath { get; private set; }
        public bool UnuseUnityAttr { get; private set; }
        public List<string> AllowCustomTypes { get; private set; }
        public List<string> ConditionalSymbols { get; private set; }
        public bool IsSeparate { get; private set; }
        public string ResolverName { get; private set; }
        public bool DisallowInternalType { get; private set; }
        public bool PropertyEnumOnly { get; private set; }
        public bool DisallowInMetadata { get; private set; }
        public bool GenerateComparerKeyEnumOnly { get; private set; }
        public string NamespaceRoot { get; private set; }
        public bool ForceDefaultResolver { get; private set; }

        public bool IsParsed { get; set; }

        public CommandlineArguments(string[] args)
        {
            AllowCustomTypes = new List<string>();
            ConditionalSymbols = new List<string>();
            ResolverName = "ZeroFormatter.Formatters.DefaultResolver";
            NamespaceRoot = "ZeroFormatter";

            var option = new OptionSet()
            {
                { "i|input=", "[required]Input path of analyze csproj", x => { InputPath = x; } },
                { "o|output=", "[required]Output path(file) or directory base(in separated mode)", x => { OutputPath = x; } },
                { "s|separate", "[optional, default=false]Output files are separated", _ => { IsSeparate = true; } },
                { "u|unuseunityattr", "[optional, default=false]Unuse UnityEngine's RuntimeInitializeOnLoadMethodAttribute on ZeroFormatterInitializer", _ => { UnuseUnityAttr = true; } },
                { "t|customtypes=", "[optional, default=empty]comma separated allows custom types", x => { AllowCustomTypes.AddRange(x.Split(',')); } },
                { "c|conditionalsymbol=", "[optional, default=empty]conditional compiler symbol", x => { ConditionalSymbols.AddRange(x.Split(',')); } },
                { "r|resolvername=", "[optional, default=DefaultResolver]Register CustomSerializer target", x => { ResolverName = x; } },
                { "d|disallowinternaltype", "[optional, default=false]Don't generate internal type", x => { DisallowInternalType = true; } },
                { "e|propertyenumonly", "[optional, default=false]Generate only property enum type only", x => { PropertyEnumOnly = true; } },
                { "m|disallowinmetadata", "[optional, default=false]Don't generate in metadata type", x => { DisallowInMetadata = true; } },
                { "g|gencomparekeyonly", "[optional, default=false]Don't generate in EnumEqualityComparer except dictionary key", x => { GenerateComparerKeyEnumOnly = true; } },
                { "n|namespace=", "[optional, default=ZeroFormatter]Set namespace root name", x => { NamespaceRoot = x; } },
                { "f|forcedefaultresolver", "[optional, default=false]Force use DefaultResolver", x => { ForceDefaultResolver = true; } },
            };
            if (args.Length == 0)
            {
                goto SHOW_HELP;
            }
            else
            {
                option.Parse(args);

                if (InputPath == null || OutputPath == null)
                {
                    Console.WriteLine("Invalid Argument:" + string.Join(" ", args));
                    Console.WriteLine();
                    goto SHOW_HELP;
                }

                IsParsed = true;
                return;
            }

            SHOW_HELP:
            Console.WriteLine("zfc arguments help:");
            option.WriteOptionDescriptions(Console.Out);
            IsParsed = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Parse Argument...

            var cmdArgs = new CommandlineArguments(args);
            if (!cmdArgs.IsParsed)
            {
                return;
            }

            var csprojPath = cmdArgs.InputPath;
            var separate = cmdArgs.IsSeparate;
            var outputpath = cmdArgs.OutputPath;
            var unuse = cmdArgs.UnuseUnityAttr;

            // Generator Start...

            var sw = Stopwatch.StartNew();
            Console.WriteLine("Project Compilation Start:" + csprojPath);

            var tc = new TypeCollector(csprojPath, cmdArgs.ConditionalSymbols, cmdArgs.AllowCustomTypes, cmdArgs.DisallowInternalType, cmdArgs.PropertyEnumOnly, cmdArgs.DisallowInMetadata, cmdArgs.GenerateComparerKeyEnumOnly, cmdArgs.NamespaceRoot);

            Console.WriteLine("Project Compilation Complete:" + sw.Elapsed.ToString());
            Console.WriteLine();

            sw.Restart();
            Console.WriteLine("Type Collect Start");

            ObjectGenerator[] objectGen;
            EnumGenerator[] enumGen;
            GenericType[] genericTypes;
            StructGenerator[] structGen;
            UnionGenerator[] unionGen;
            tc.Visit(out enumGen, out objectGen, out structGen, out unionGen, out genericTypes);

            Console.WriteLine("Type Collect Complete:" + sw.Elapsed.ToString());
            Console.WriteLine();

            if (!separate)
            {
                Console.WriteLine("String Generation Start");
                sw.Restart();
                var sb = new StringBuilder();
                sb.AppendLine(new InitializerGenerator() { Objects = objectGen, Enums = enumGen, Structs = structGen, GenericTypes = genericTypes, UnuseUnityAttribute = unuse, Unions = unionGen, ResolverName = cmdArgs.ResolverName, Namespace = cmdArgs.NamespaceRoot, ForceDefaultResolver = cmdArgs.ForceDefaultResolver }.TransformText());

                foreach (var item in objectGen)
                {
                    item.ForceDefaultResolver = cmdArgs.ForceDefaultResolver;
                    sb.AppendLine(item.TransformText());
                }
                foreach (var item in structGen)
                {
                    item.ForceDefaultResolver = cmdArgs.ForceDefaultResolver;
                    sb.AppendLine(item.TransformText());
                }
                foreach (var item in unionGen)
                {
                    item.ForceDefaultResolver = cmdArgs.ForceDefaultResolver;
                    sb.AppendLine(item.TransformText());
                }
                foreach (var item in enumGen)
                {
                    item.ForceDefaultResolver = cmdArgs.ForceDefaultResolver;
                    sb.AppendLine(item.TransformText());
                }
                Console.WriteLine("String Generation Complete:" + sw.Elapsed.ToString());
                Console.WriteLine();

                Output(outputpath, sb.ToString());
            }
            else
            {
                Console.WriteLine("Output Generation Start");
                sw.Restart();

                var initializerPath = Path.Combine(outputpath, "ZeroFormatterInitializer.cs");
                Output(initializerPath, new InitializerGenerator() { Objects = objectGen, Enums = enumGen, Structs = structGen, GenericTypes = genericTypes, UnuseUnityAttribute = unuse, Unions = unionGen, ResolverName = cmdArgs.ResolverName, Namespace = cmdArgs.NamespaceRoot, ForceDefaultResolver = cmdArgs.ForceDefaultResolver }.TransformText());

                foreach (var item in objectGen.SelectMany(x => x.Types))
                {
                    var path = Path.Combine(outputpath, item.FullName.Replace(".", "\\") + ".cs");
                    var gen = new ObjectGenerator { Namespace = item.Namespace, Types = new[] { item }, ForceDefaultResolver = cmdArgs.ForceDefaultResolver };
                    Output(path, gen.TransformText());
                }

                foreach (var item in structGen.SelectMany(x => x.Types))
                {
                    var path = Path.Combine(outputpath, item.FullName.Replace(".", "\\") + ".cs");
                    var gen = new StructGenerator { Namespace = item.Namespace, Types = new[] { item }, ForceDefaultResolver = cmdArgs.ForceDefaultResolver };
                    Output(path, gen.TransformText());
                }

                foreach (var item in unionGen.SelectMany(x => x.Types))
                {
                    var path = Path.Combine(outputpath, item.FullName.Replace(".", "\\") + ".cs");
                    var gen = new UnionGenerator { Namespace = item.Namespace, Types = new[] { item }, ForceDefaultResolver = cmdArgs.ForceDefaultResolver };
                    Output(path, gen.TransformText());
                }

                foreach (var e in enumGen)
                {
                    foreach (var item in e.Types)
                    {
                        var path = Path.Combine(outputpath, item.FullName.Replace(".", "\\") + ".cs");
                        var gen = new EnumGenerator { Namespace = e.Namespace, Types = new[] { item }, ForceDefaultResolver = cmdArgs.ForceDefaultResolver };
                        Output(path, gen.TransformText());
                    }
                }
            }
        }

        static void Output(string path, string text)
        {
            path = path.Replace("global::", "");

            const string prefix = "[Out]";
            Console.WriteLine(prefix + path);

            var fi = new FileInfo(path);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }

            System.IO.File.WriteAllText(path, text);
        }
    }
}