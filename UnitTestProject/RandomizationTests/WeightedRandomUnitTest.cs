using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithm.Randomization;

namespace UnitTestProject.RandomizationTests
{
	[TestClass]
	public class WeightedRandomUnitTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "The size of the selection cannot be more that the size of the list")]
		public void WeightedSelect_OverSelecting()
		{
			var items = new List<int>() { 1, 1, 1};
			items.WeightedSelect(4, i => i);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "The size of the selection cannot be less than 1")]
		public void WeightedSelect_UnderSelecting()
		{
			var items = new List<int>() { 1, 1, 1 };
			items.WeightedSelect(0, i => i);
		}
	}
}
