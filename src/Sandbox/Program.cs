using Sandbox;
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
    public virtual IList<MogeMoge> List { get; set; }
}

namespace Sandbox
{
    public enum MogeMoge
    {
        Apple, Orange
    }



    class Program
    {
        static void Main(string[] args)
        {
            var mc = new MyClass
            {
                Age = 99,
                FirstName = "hoge",
                LastName = "huga",
                List = new List<MogeMoge> { MogeMoge.Apple, MogeMoge.Orange, MogeMoge.Apple }
            };

            var bytes = ZeroFormatter.ZeroFormatterSerializer.Serialize(mc);
            var mc2 = ZeroFormatter.ZeroFormatterSerializer.Deserialize<MyClass>(bytes);


            var huga = ZeroFormatterSerializer.Serialize(mc2);

        }
    }
}
