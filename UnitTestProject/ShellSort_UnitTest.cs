using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace UnitTestProject
{
    [TestClass]
    public class ShellSort_UnitTest
    {
        [TestMethod]
        public void ShellSort_BasicTest()
        {
            string[] a = { "6", "7", "3", "2", "0" , "4" ,"8" ,"9"};
            Shell.Sort(a);
            for (int i = 1; i < a.Length; i++)
            {
                Assert.IsTrue(a[i].CompareTo(a[i - 1]) >= 0);
            }
        }
    }
}
