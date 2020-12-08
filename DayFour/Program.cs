using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using AdventOfCodeSharedLibrary;
using MoreLinq;

namespace DayFour
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"day4input.txt");
			var validPassports =File.ReadAllLines(path).BatchOnEmptyLine().Select(x => new Passport(x))
				.Count(x => x.IsValid(false));

			Console.WriteLine($"valid Passports: { validPassports}");
			Console.ReadKey();
		}
	}

	public class Passport
	{
		public string BirthYear { get; set; }
		public string IssueYear { get; set; }
		public string ExpYear { get; set; }
		public string Height { get; set; }
		public string HairColour { get; set; }
		public string EyeColour { get; set; }
		public string PassportId { get; set; }
		public string CountryId { get; set; }

		public bool IsValid(bool includeCountry)
		{
			return !string.IsNullOrWhiteSpace(BirthYear) &&
			       !string.IsNullOrWhiteSpace(IssueYear) &&
			       !string.IsNullOrWhiteSpace(ExpYear) &&
			       !string.IsNullOrWhiteSpace(Height) &&
			       !string.IsNullOrWhiteSpace(HairColour) &&
			       !string.IsNullOrWhiteSpace(EyeColour) &&
			       !string.IsNullOrWhiteSpace(PassportId) &&
			       (!includeCountry || !string.IsNullOrWhiteSpace(CountryId));
		}
		public Passport(IEnumerable<string> passportInfo)
		{
			var selectMany = passportInfo.SelectMany(x => x.Split(" "));
			selectMany.ForEach(PopulateData);
		}

		public void PopulateData(string data)
		{
			var parts = data.Split(":");
			switch (parts[0].ToLower())
			{
				case "byr":
				{
					BirthYear = parts[1];
					break;
				}
				case "iyr":
				{
					IssueYear = parts[1];
					break;
				}
				case "eyr":
				{
					ExpYear = parts[1];
					break;
				}
				case "hgt":
				{
					Height = parts[1];
					break;
				}
				case "hcl":
				{
					HairColour = parts[1];
					break;
				}
				case "ecl":
				{
					EyeColour = parts[1];
					break;
				}
				case "pid":
				{
					PassportId = parts[1];
					break;
				}
				case "cid":
				{
					CountryId = parts[1];
					break;
				}

			}
		}

	}

}
