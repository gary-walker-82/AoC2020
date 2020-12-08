using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using AdventOfCodeSharedLibrary;

namespace DaySix
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"day6input.txt");
			var validPassports = File.ReadAllLines(path).BatchOnEmptyLine().Select(x => new Group(x));
			var sum = validPassports.Sum(x => x.UniqueYesAnswers.Count);
			var allYes = validPassports.Sum(x => x.EveryOneAnsweredYes.Count);
			Console.WriteLine($"valid Passports: {allYes}");
			Console.ReadKey();
		}
	}

	public class Group
	{
		private List<Person> _members;

		public List<string> UniqueYesAnswers => _members.SelectMany(x => x._yesAnswers).Distinct().ToList();

		public List<string> EveryOneAnsweredYes
		{
			get
			{
				var yesAnswers = _members.First()._yesAnswers;
				_members.Skip(1).Aggregate(yesAnswers, (current, person)=>yesAnswers = person._yesAnswers.Intersect(yesAnswers).ToList());
				return yesAnswers;
			}
		}
		public Group(IEnumerable<string> users)
		{
			_members = users.ToList().Select(x=>new Person(x)).ToList();
		}
	}

	public class Person
	{
		public List<string> _yesAnswers;

		public Person(string answers)
		{
			_yesAnswers = answers.Select(x=>x.ToString()).ToList();
		}


	}
}
