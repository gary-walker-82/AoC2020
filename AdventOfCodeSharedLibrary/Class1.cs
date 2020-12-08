using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeSharedLibrary
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<IEnumerable<string>> BatchOnEmptyLine(this IEnumerable<string> source)
		{
			var jump = 1;
			for (int i = 0; i < source.Count(); i = i + jump)
			{
				var batch = source.Skip(i).TakeWhile(x => !string.IsNullOrWhiteSpace(x));
				jump = batch.Count() + 1;
				yield return batch;
			}
		}
	}
}
