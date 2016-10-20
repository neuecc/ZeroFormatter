using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ZeroFormatter.CodeGenerator
{
    // zfc.exe
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(@"[csproj path] [output path] [-unuseunityattr]");
                return;
            }

            var unuse = args.FirstOrDefault(x => x.StartsWith("-")) != null; // -*** everything
            var csprojPath = args.Where(x => !x.StartsWith("-")).First();
            var outputpath = args.Where(x => !x.StartsWith("-")).Last();

            if (csprojPath == outputpath)
            {
                throw new Exception("invalid argument.");
            }

            var sw = Stopwatch.StartNew();
            Console.WriteLine("Project Compilation Start:" + csprojPath);

            var tc = new TypeCollector(csprojPath);

            Console.WriteLine("Project Compilation Complete:" + sw.Elapsed.ToString());
            Console.WriteLine();

            sw.Restart();
            Console.WriteLine("Type Collect Start");
            var objectGen = tc.CreateObjectGenerators();
            EnumGenerator[] enumGen = tc.CreateEnumGenerators();
            Console.WriteLine("Type Collect Complete:" + sw.Elapsed.ToString());
            Console.WriteLine();

            Console.WriteLine("String Generation Start");
            sw.Restart();
            var sb = new StringBuilder();
            sb.AppendLine(new InitializerGenerator() { Objects = objectGen.Item1, Enums = enumGen, GenericTypes = objectGen.Item2, UnuseUnityAttribute = unuse }.TransformText());

            foreach (var item in objectGen.Item1)
            {
                sb.AppendLine(item.TransformText());
            }
            foreach (var item in enumGen)
            {
                sb.AppendLine(item.TransformText());
            }
            Console.WriteLine("String Generation Complete:" + sw.Elapsed.ToString());
            Console.WriteLine();

            Console.WriteLine("Output to:" + outputpath);
            System.IO.File.WriteAllText(outputpath, sb.ToString());
        }
    }
}