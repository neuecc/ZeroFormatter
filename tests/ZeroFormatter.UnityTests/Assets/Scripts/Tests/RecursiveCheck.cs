using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroFormatter.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class RecursiveCheck
    {
        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            var test = new RecursiveCheck();

            UnitTestRoot.AddTest("RecursiveCheck", "RecCheck", test.RecCheck);
        }

        [TestMethod]
        public void RecCheck()
        {
            AssertEx.Throws<InvalidOperationException>(() =>
                ZeroFormatter.ZeroFormatterSerializer.Serialize(new RecMyClass() { Hoge = 10, Rec = new RecMyClass { Hoge = 100, Rec = null } }))
                .Message.Contains("Circular reference").IsTrue();
        }
    }
}
