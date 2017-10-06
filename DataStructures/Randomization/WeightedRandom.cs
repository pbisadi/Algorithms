using Algorithm.Sort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Randomization
{
	public static class WeightedRandom
	{
		static System.Random _rnd = new System.Random();

		/// <summary>
		/// Randomly select specified number of items from the list.
		/// The items with higher weight are in the result with with higher probability
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <param name="weight"></param>
		/// <returns></returns>
		public static IList<T> WeightedSelect<T>(this IList<T> items, int selectCount, Func<T, double> weight)
		{
			if (selectCount < 1 || selectCount > items.Count)
				throw new ArgumentOutOfRangeException("The size of the selection must be a positive number equal or less than the size of the list");
			items.Shuffle();

			var result = new List<T>();
			var selected = new bool[items.Count];
			SelectItems(items, weight, selectCount, ref selected);

			for (int i = 0; i < items.Count(); i++)
			{
				if (selected[i]) result.Add(items[i]);
			}
			return result;
		}

		private static void SelectItems<T>(IList<T> items, Func<T, double> weight, int selectCount, ref bool[] selected)
		{
			if (selectCount == 0) return; //recursive base case

			if (selected == null) selected = new bool[items.Count];
			double sum = 0;
			for (int i = 0; i < items.Count; i++)
			{
				sum += (!selected[i]) ? weight(items[i]) : 0;
				if (selected[i]) selectCount--;
			}
			double chunk = sum / selectCount;
			double rnd = _rnd.NextDouble() * chunk;

			for (int i = 0; i < items.Count; i++)
			{
				if (rnd < weight(items[i]))
				{
					selected[i] = true;
					rnd += chunk;
				}
				else
				rnd -= weight(items[i]);
				if (rnd < 0) rnd += ((int)(-rnd / chunk) + 1) * chunk; // to skipp pieaces that are greater than chunk size
			}
			//TODO: It does not work this way :( if there are peices larger than chunk, we select less than desired count
			// and we need to do the selection again. The challenge is that the selected items must be removed from the list
			// to be able to converge to selecting desired count. If we remove items, then keeping that track of selected items
			// by a flag array is not straight forward. So, I think a structure must be designed to combine selection flag and item.
		}



		public static int WeightedPick<T>(this IList<T> items, Func<T,double> weight)
		{
			Debug.Assert(items.All(i => weight(i) >= 0), "All weights must be non-negative.");
			double sum = items.Select(i => weight(i)).Sum();
			if (sum == 0) return _rnd.Next(0, items.Count());

			double rnd = _rnd.NextDouble() * sum;

			for (int i = 0; i < items.Count(); i++)
			{
				if (rnd < weight(items[i]))
				{
					return i;
				}
				rnd -= weight(items[i]);
			}
			Debug.Assert(false, "should never get here");
			return -1;
		}

		public static int WeightedPick(this int[] weights)
		{
			Debug.Assert(!weights.Any(w => w < 0), "All weights must be non-negative.");
			int sum = weights.Sum();
			if (sum == 0) return _rnd.Next(0, weights.Length);

			int rnd = _rnd.Next(0, sum);
			for (int i = 0; i < weights.Length; i++)
			{
				if (rnd < weights[i])
				{
					return i;
				}
				rnd -= weights[i];
			}
			Debug.Assert(false, "should never get here");
			return -1;
		}

		public static int WeightedPick(this double[] weights)
		{
			Debug.Assert(!weights.Any(w => w < 0), "All weights must be non-negative.");
			double sum = weights.Sum();
			if (sum == 0) return _rnd.Next(0, weights.Length);

			double rnd = _rnd.NextDouble() * sum;
			for (int i = 0; i < weights.Length; i++)
			{
				if (rnd < weights[i])
				{
					return i;
				}
				rnd -= weights[i];
			}
			Debug.Assert(false, "should never get here");
			return -1;
		}
	}
}
