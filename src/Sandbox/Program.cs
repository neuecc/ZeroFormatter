using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;


[ZeroFormattable]
public class MyClass
{
    [Index(0)]
    public virtual int Age { get; set; }

    [Index(1)]
    public virtual string FirstName { get; set; }

    [Index(2)]
    public virtual string LastName { get; set; }

    [IgnoreFormat]
    public string FullName { get { return FirstName + LastName; } }

    [Index(3)]
    public virtual IList<int> List { get; set; }
}

namespace Sandbox
{



    class Program
    {
        static void Main(string[] args)
        {
            var mc = new MyClass
            {
                Age = 99,
                FirstName = "hoge",
                LastName = "huga",
                List = new List<int> { 1, 10, 100 }
            };

            var bytes = ZeroFormatter.ZeroFormatterSerializer.Serialize(mc);
            var mc2 = ZeroFormatter.ZeroFormatterSerializer.Deserialize<MyClass>(bytes);

            mc2.List.Add(999);

            var huga = ZeroFormatterSerializer.Serialize(mc2);

        }
    }
}
