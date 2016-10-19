using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.CodeGenerator
{



    // zfc.exe
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new EnumGenerator
            {
                Namespace = "ZeroFormatter.Generator.GeneratedFormatters",
                Types = new[]
                {
                    new EnumType
                    {
                        Name = nameof(MyFruit),
                        UnderlyingType = "Int32",
                        Length = 4
                    }
                }
            };

            var gen2 = new ObjectGenerator
            {
                Namespace = "ZeroFormatter.Generator.GeneratedFormatters",
                Types = new[]
                {
                    new ObjectSegmentType
                    {
                        Name = "HogeHoge",
                        FullName= "Hoge.Huga.HogeHoge",
                        LastIndex = 3,
                        Properties = new CodeGenerator.ObjectSegmentType.PropertyTuple[]
                        {
                            new ObjectSegmentType.PropertyTuple
                            {
                                Index = 0,
                                Name = "Age",
                                Type = "System.Int32",
                                FixedSize = 4,
                                IsCacheSegment = false,
                                IsFixedSize = true,
                            },
                            new ObjectSegmentType.PropertyTuple
                            {
                                Index = 1,
                                Name = "FirstName",
                                Type = "System.String",
                                FixedSize = 0,
                                IsCacheSegment = true,
                                IsFixedSize = false,
                            },
                            new ObjectSegmentType.PropertyTuple
                            {
                                Index = 2,
                                Name = "LastName",
                                Type = "System.String",
                                FixedSize = 0,
                                IsCacheSegment = true,
                                IsFixedSize = false,
                            },
                            new ObjectSegmentType.PropertyTuple
                            {
                                Index = 3,
                                Name = "HogeMoge",
                                Type = "System.Int32",
                                FixedSize = 4,
                                IsCacheSegment = false,
                                IsFixedSize = true,
                            },
                            new ObjectSegmentType.PropertyTuple
                            {
                                Index = 4,
                                Name = "MyList",
                                Type = "System.Collections.Generics.IList<int>",
                                FixedSize = 0,
                                IsCacheSegment = false,
                                IsFixedSize = false,
                            },
                        }
                    }
                }
            };



            //Console.WriteLine(gen2.TransformText());

            //Console.WriteLine(gen.TransformText());

            var path = @"C:\Users\y.kawai\Documents\neuecc\ZeroFormatter\src\ZeroFormatter.CodeGenerator\ZeroFormatter.CodeGenerator.csproj";

            path = @"C:\Users\y.kawai\Documents\neuecc\ZeroFormatter\src\ZeroFormatter.Tests\ZeroFormatter.Tests.csproj";

            path = @"C:\Users\y.kawai\Documents\neuecc\ZeroFormatter\sandbox\Sandbox.Shared\Sandbox.Shared.csproj";


            var sw = Stopwatch.StartNew();
            Console.WriteLine("Project Compilation Start:" + path);

            var tc = new TypeCollector(path);

            Console.WriteLine("Project Compilation Complete:" + sw.Elapsed.ToString());

            sw.Restart();
            Console.WriteLine("Type Collect Start");
            ObjectGenerator[] objectGen = tc.CreateObjectGenerators();
            EnumGenerator[] enumGen = tc.CreateEnumGenerators();
            Console.WriteLine("Type Collect Complete:" + sw.Elapsed.ToString());

            Console.WriteLine("String Generation Start");
            sw.Restart();
            var sb = new StringBuilder();
            sb.AppendLine(new InitializerGenerator() { Objects = objectGen, Enums = enumGen }.TransformText());

            foreach (var item in tc.CreateObjectGenerators())
            {
                sb.AppendLine(item.TransformText());
            }
            foreach (var item in tc.CreateEnumGenerators())
            {
                sb.AppendLine(item.TransformText());
            }
            Console.WriteLine("String Generation Complete:" + sw.Elapsed.ToString());

            System.IO.File.WriteAllText(@"C:\Users\y.kawai\Documents\neuecc\ZeroFormatter\tests\ZeroFormatter.UnityTests\Assets\ZeroFormatterGenerated.cs", sb.ToString());
        }
    }

    public enum MyFruit
    {
        Apple, Orange, Pine
    }

    // We need to use Analyazer so can't use DataContractAttribute.
    // Analyzer detect attribtues by "short" name.
    // Short name means does not needs reference ZeroFormatter so create no dependent libraries.

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ZeroFormattableAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IndexAttribute : Attribute
    {
        public int Index { get; private set; }

        public IndexAttribute(int index)
        {
            this.Index = index;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IgnoreFormatAttribute : Attribute
    {
    }

    [ZeroFormattable]
    public class MyTest
    {
        [Index(0)]
        public virtual int MyProperty0 { get; set; }
        [Index(1)]
        public virtual string MyProperty1 { get; set; }

    }
}
