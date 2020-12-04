using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DayTwo
{
	class Program
	{

		static void Main(string[] args)
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"day2input.txt");
			var validPassword = File.ReadAllLines(path).Select(x => new DayTwoInputStarTwo(x)).Count(x => x.IsValid);

			Console.WriteLine($"Valid Password: {validPassword}");
			Console.ReadKey();
		}

	}

	public class DayTwoInputStarOne
	{
		public int MinOccurrences { get; set; }
		public int MaxOccurrences { get; set; }
		public string RequiredLetter { get; set; }
		public string Password { get; set; }
		public int Occurrences => Password.Count(x => x.ToString() == RequiredLetter);
		public bool IsValid => Occurrences >= MinOccurrences && Occurrences <= MaxOccurrences;

		public DayTwoInputStarOne(string input)
		{
			var strings = input.Split(" ");
			var occurrences = strings[0].Split("-");
			MinOccurrences = int.Parse(occurrences[0]);
			MaxOccurrences = int.Parse(occurrences[1]);
			RequiredLetter = strings[1].Substring(0, 1);
			Password = strings[2];
		}
	}

	public class DayTwoInputStarTwo
	{
		public List<int> ValidationIndexes { get; set; } = new List<int>();

		public string RequiredLetter { get; set; }
		public string Password { get; set; }

		public bool IsValid => ValidationIndexes
			.Select(x => Password.Length >= x && Password[x - 1].ToString() == RequiredLetter)
			.Count(x => x == true) == 1;



		public DayTwoInputStarTwo(string input)
		{
			var strings = input.Split(" ");
			var occurrences = strings[0].Split("-");
			ValidationIndexes.Add(int.Parse(occurrences[0]));
			ValidationIndexes.Add(int.Parse(occurrences[1]));
			RequiredLetter = strings[1].Substring(0, 1);
			Password = strings[2];
		}
	}
}
