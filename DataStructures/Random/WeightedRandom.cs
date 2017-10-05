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
