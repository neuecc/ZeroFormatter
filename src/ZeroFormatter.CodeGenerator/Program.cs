using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZeroFormatter.CodeGenerator
{
    public partial class EnumGenerator
    {
        public string Namespace { get; set; }
        public EnumType[] Types { get; set; }
    }

    public class EnumType
    {
        public string Name { get; set; }
        public string UnderlyingType { get; set; }
        public int Length { get; set; }
    }


    public partial class ObjectGenerator
    {
        public string Namespace { get; set; }
        public ObjectSegmentType[] Types { get; set; }
    }

    public class ObjectSegmentType
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Namespace { get; set; }
        public int LastIndex { get; set; }
        public PropertyTuple[] Properties { get; set; }

        public class PropertyTuple
        {
            public int Index { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public bool IsCacheSegment { get; set; }
            public bool IsFixedSize { get; set; }
            public int FixedSize { get; set; }
        }

        public int[] ElementFixedSizes
        {
            get
            {
                var schemaLastIndex = Properties.Select(x => x.Index).LastOrDefault();
                var dict = Properties.Where(x => x.IsFixedSize).ToDictionary(x => x.Index, x => x.FixedSize);
                var elementSizes = new int[schemaLastIndex + 1];
                for (int i = 0; i < schemaLastIndex + 1; i++)
                {
                    if (!dict.TryGetValue(i, out elementSizes[i]))
                    {
                        elementSizes[i] = 0;
                    }
                }

                return elementSizes;
            }
        }
    }


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

            var tc = new TypeCollector(path);

            var sb = new StringBuilder();
            foreach(var item in tc.CreateObjectGenerators())
            {
                //Console.WriteLine(item.TransformText());
                sb.AppendLine(item.TransformText());
            }

            // System.IO.File.WriteAllText(@"C:\Users\y.kawai\Documents\neuecc\ZeroFormatter\src\ZeroFormatter.CodeGenerator\Test.cs", sb.ToString());

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
