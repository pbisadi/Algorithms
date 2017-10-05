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
		public static IList<T> WeightedSelect<T>(this IList<T> items, int select_count, Func<T, double> weight)
		{
			if (select_count < 1 || select_count > items.Count)
				throw new ArgumentOutOfRangeException("The size of the selection must be a positive number equal or less than the size of the list");
			items.Shuffle();
			double sum = items.Select(i => weight(i)).Sum();
			double chunk = sum / select_count;
			var result = new List<T>();

			for (int i = 0; i < items.Count(); i++)
			{
				if (rnd < weight(items[i]))
				{
					result.Add(items[i]);
				}
				rnd -= weight(items[i]);
			}
			return items;
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
