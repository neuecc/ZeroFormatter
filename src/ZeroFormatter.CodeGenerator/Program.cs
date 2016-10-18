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
                // TODO:Calcularte sizes
                return new[] { 1, 2, 3, 4, 325 };
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

            Console.WriteLine(gen2.TransformText());

            //Console.WriteLine(gen.TransformText());



        }
    }

    public enum MyFruit
    {
        Apple, Orange, Pine
    }
}
