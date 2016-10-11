using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;
using ZeroFormatter.Formatters;
using ZeroFormatter.Segments;

namespace Sandbox
{
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
        public virtual int HogeMoge { get; protected set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
       

            var t = DynamicObjectSegmentBuilder<MyClass>.Build();


            var hugahugahuga = t.GetConstructor(new[] { typeof(DirtyTracker), typeof(ArraySegment<byte>) });

            var array = new ArraySegment<byte>(new byte[] { 1, 2, 3, 4, 5 });
            var tracker = new DirtyTracker();
            var hoge = hugahugahuga.Invoke(new object[] { tracker, array });

            // test2

            var f = new DynamicObjectFormatter<MyClass>();

        }
    }
}
