using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter.Formatters;
using ZeroFormatter;

/*
namespace FsUnionTest

type Shape =
    | Circle of float
    | EquilateralTriangle of double
    | Square of double
    | Rectangle of double * double

type Tree =
    | Tip
    | Node of int * Tree * Tree

*/

namespace FSharpUnionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ZeroFormatter.ZeroFormatterSerializer.RegisterDynamicUnion<int>(x =>
            {
                var unionType = typeof(FsUnionTest.Tree);
                var nestedTypes = unionType.GetNestedTypes();
                var tags = nestedTypes.First(y => y.Name == "Tags");

                var fields = tags.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Static);
                foreach (var item in fields)
                {
                    var tag = (int)item.GetValue(null);
                    var t = nestedTypes.FirstOrDefault(y => y.Name == item.Name);
                    if (t == null)
                    {
                        x.Register(tag, unionType);
                    }
                    else
                    {
                        x.Register(tag, t);
                    }
                }

                return "FSharpUnion";
            });

            ZeroFormatter.Formatters.Formatter.AppendFormatterResolver(type =>
            {
                var mapping = type.GetCustomAttribute<Microsoft.FSharp.Core.CompilationMappingAttribute>();
                if (mapping != null && mapping.SourceConstructFlags == Microsoft.FSharp.Core.SourceConstructFlags.SumType)
                {
                    var properties = type.GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance)
                        .Where(x => x.Name.StartsWith("Item"))
                        .ToArray();
                    var formatter = DynamicStructFormatter.CreateStructFormatClass(type, properties.Select((x, i) => Tuple.Create(i, x)));
                    return formatter;
                }

                return null;
            });


            var circle = FsUnionTest.Tree.Node.NewNode(102, null, null);
            var bytes = ZeroFormatterSerializer.SerializeDynamicUnion("FSharpUnion", circle);
            var hugahuga = ZeroFormatterSerializer.DeserializeDynamicUnion("FSharpUnion", bytes);

        }
    }
}
