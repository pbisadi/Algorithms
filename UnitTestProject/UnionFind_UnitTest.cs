using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Algorithm;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public sealed class UnionFind_UnitTest
    {
        static string _baseAddress;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = Directory.GetParent(path).ToString();
            path = Directory.GetParent(path).ToString();
            _baseAddress = Path.Combine(path, "Tests\\UnionFind");
        }

        [TestMethod]
        public void BasicAPI_Test()
        {
            string path = Path.Combine(_baseAddress, "BasicAPI_Test_input.txt");
            StreamReader SR = new StreamReader(Path.Combine(_baseAddress, "BasicAPI_Test_input.txt"));
            int N = int.Parse(SR.ReadLine());
            UnionFind_QU UF = new UnionFind_QU(N);
            StringBuilder actual = new StringBuilder();
            while (!SR.EndOfStream)
            {
                string[] connect = SR.ReadLine().Split(' ');
                int p = int.Parse(connect[0]);
                int q = int.Parse(connect[1]);
                if (!UF.Connected(p, q))
                {
                    UF.Union(p, q);
                    actual.AppendLine(p + " " + q);
                }
            }

            SR = new StreamReader(Path.Combine(_baseAddress, "BasicAPI_Test_output.txt"));
            string expected = SR.ReadToEnd();
            Assert.AreEqual(expected, actual.ToString());
        }
    }
}
