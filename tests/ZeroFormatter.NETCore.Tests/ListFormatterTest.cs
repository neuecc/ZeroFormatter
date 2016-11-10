using System;
using System.Collections.Generic;
using Xunit;

namespace ZeroFormatter.DotNetCore.Tests
{
    public class ListFormatterTest
    {
        [Fact]
        public void FixedList()
        {
            {
                IList<int> xs = new[] { 12, 431, 426, 76, 373, 7, 53, 563, 563 };
                var result = ZeroFormatterSerializer.Serialize(xs);
                ZeroFormatterSerializer.Deserialize<IList<int>>(result).Is(12, 431, 426, 76, 373, 7, 53, 563, 563);
            }
            {
                IList<int?> xs = new int?[] { 12, 431, 426, null, 76, 373, 7, 53, 563, 563 };
                var result = ZeroFormatterSerializer.Serialize(xs);
                ZeroFormatterSerializer.Deserialize<IList<int?>>(result).Is(12, 431, 426, null, 76, 373, 7, 53, 563, 563);
            }

            {
                IList<double> xs = new[] { 12.32, 43.1, 4.26, 76, 0.373, 7.3, 0.53, 56.3, 5.63 };
                var result = ZeroFormatterSerializer.Serialize(xs);
                ZeroFormatterSerializer.Deserialize<IList<double>>(result).Is(12.32, 43.1, 4.26, 76, 0.373, 7.3, 0.53, 56.3, 5.63);
            }

            {
                IList<double?> xs = new double?[] { 12.32, 43.1, 4.26, 76, 0.373, 7.3, null, 0.53, 56.3, null, 5.63 };
                var result = ZeroFormatterSerializer.Serialize(xs);
                ZeroFormatterSerializer.Deserialize<IList<double?>>(result).Is(12.32, 43.1, 4.26, 76, 0.373, 7.3, null, 0.53, 56.3, null, 5.63);
            }

            {
                IList<int> xs = new int[0];
                var result = ZeroFormatterSerializer.Serialize(xs);
                ZeroFormatterSerializer.Deserialize<IList<int>>(result).IsZero();
            }
        }

        [Fact]
        public void VariableList()
        {
            {
                IList<string> xs = new[] { "aaa", "あいうえお", "hogehoge", "hugahugahugahugahuga" };
                var result = ZeroFormatterSerializer.Serialize(xs);
                var ds = ZeroFormatterSerializer.Deserialize<IList<string>>(result);
                ds.Is("aaa", "あいうえお", "hogehoge", "hugahugahugahugahuga");
            }
            {
                IList<string> xs = new[] { "aaa", "あいうえお", "hogehoge", null, "hugahugahugahugahuga" };
                var result = ZeroFormatterSerializer.Serialize(xs);
                ZeroFormatterSerializer.Deserialize<IList<string>>(result).Is("aaa", "あいうえお", "hogehoge", null, "hugahugahugahugahuga");
            }
        }
    }
}
