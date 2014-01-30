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
    }
}
