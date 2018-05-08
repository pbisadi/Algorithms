using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm.DataStructure;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject.DataStructureTests
{
	[TestClass]
	public class Trie_UnitTest
	{
		[TestMethod]
		public void Trie_Basic()
		{
			var T = new Trie<char, bool>();
			T.Add("Test", true);
			Assert.AreEqual(T.Find("Test"), true);
			Assert.AreEqual(T.Find("something else"), false);
		}

		[TestMethod]
		public void Trie_FindAllStartingWith()
		{
			var T = new Trie<char, bool>();
			T.Add("Test", true);
			T.Add("Tester", true);
			T.Add("Testee", true);
			var result = new List<bool>(T.FindAllStartingWith("Test"));
			Assert.AreEqual(result.Count, 3);

			result = new List<bool>(T.FindAllStartingWith("Tester"));
			Assert.AreEqual(result.Count, 1);

			result = new List<bool>(T.FindAllStartingWith("Something totally different"));
			Assert.AreEqual(result.Count, 0);
		}

		[TestMethod]
		public void Trie_Remove()
		{
			var T = new Trie<char, bool>();
			T.Add("Test", true);
			var result = new List<bool>(T.FindAllStartingWith("Test"));
			Assert.AreEqual(result.Count, 1);

			T.Remove("Test");
			result = new List<bool>(T.FindAllStartingWith("Test"));
			Assert.AreEqual(result.Count, 0);
		}
	}
}
