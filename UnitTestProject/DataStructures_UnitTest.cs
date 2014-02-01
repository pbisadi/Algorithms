using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm.DataStructure;

namespace UnitTestProject
{
    [TestClass]
    public class DataStructures_UnitTest
    {
        [TestMethod]
        public void MaxPQ_Basic()
        {
            var pq = new MaxPriorityQueue<int>();
            pq.Insert(2, null);
            pq.Insert(6, null);
            pq.Insert(1, null);
            Assert.AreEqual(6, (int)(pq.DelMax().Item1));
            pq.Insert(9, null);
            pq.Insert(7, null);
            pq.Insert(1, null);
            Assert.AreEqual(9, (int)(pq.DelMax().Item1));
            pq.Insert(2, null);
            pq.Insert(6, null);
            pq.Insert(1, null);
            Assert.AreEqual(7, (int)(pq.DelMax().Item1));
            Assert.AreEqual(6, (int)(pq.Max().Item1));
            Assert.AreEqual(6, (int)(pq.DelMax().Item1));
            Assert.AreEqual(2, (int)(pq.DelMax().Item1));
            Assert.AreEqual(2, (int)(pq.DelMax().Item1));
        }

        [TestMethod]
        public void MinPQ_Basic()
        {
            var pq = new MinPriorityQueue<int>();
            pq.Insert(2, null);
            pq.Insert(6, null);
            pq.Insert(1, null);
            Assert.AreEqual(1, (int)(pq.DelMax().Item1));
            pq.Insert(9, null);
            pq.Insert(7, null);
            pq.Insert(1, null);
            Assert.AreEqual(1, (int)(pq.DelMax().Item1));
            pq.Insert(2, null);
            pq.Insert(6, null);
            pq.Insert(1, null);
            Assert.AreEqual(1, (int)(pq.DelMax().Item1));
            Assert.AreEqual(2, (int)(pq.Max().Item1));
            Assert.AreEqual(2, (int)(pq.DelMax().Item1));
            Assert.AreEqual(2, (int)(pq.DelMax().Item1));
            Assert.AreEqual(6, (int)(pq.DelMax().Item1));
        }

        [TestMethod]
        public void SymbolTable_Basic()
        {
            string input = "SEARCH EXAMPLE";
            var ST = new SymbolTable<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!ST.Contains(c)) ST[c] = i;
                else ST[input[c]] = (int)ST[input[c]] + 1;
            }

            char max = '\b';
            ST[max] = 0;
            foreach (var c in ST.Keys())
            {
                if ((int)ST[c] > (int)ST[max]) max = c;
            }

            Assert.AreEqual('E', max);
        }

    }
}
