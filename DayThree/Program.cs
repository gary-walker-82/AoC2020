using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DayThree
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"day3input.txt");
			var skiSloop = new SkiSloop(File.ReadAllLines(path));
			var routes = new List<Tuple<int,int>> {

				new Tuple<int,int>(1,1),
				new Tuple<int,int>(1,3),
				new Tuple<int,int>(1,5),
				new Tuple<int,int>(1,7),
				new Tuple<int,int>(2,1)};

			var counter = 1L;
			foreach (var (speed, direction) in routes)
			{
				var hitTrees =skiSloop.Navigate(speed, direction);
				Console.WriteLine($"Speed: {speed} Direction: {direction} Trees Hit: {hitTrees}");
				counter *= hitTrees;
			}	
			Console.WriteLine($"Total Hit Trees:  {counter}");
			Console.ReadKey();
		}
	}

	public class SkiSloop
	{
		private List<Row> _rows;

		public SkiSloop(string[] lines)
		{
			_rows = lines.Select(x=> new Row(x)).ToList();
		}

		public int Navigate(int speed, int direction)
		{
			var startPoint = 0;
			var treesHit = 0;
			for (int i = 0; i < _rows.Count; i= i+ speed)
			{
				if (_rows[i].GetSquare(startPoint) == Square.Tree)
				{
					++treesHit;
				}

				startPoint += direction;
			}

			return treesHit;
		}
	}

	public class Row
	{
		private List<Square> _squares;
		
		public Row(string line)
		{
			_squares = line.Select(x => x.ToString() == "." ? Square.Space : Square.Tree).ToList();
		}

		public Square GetSquare(int location)
		{
			location = location % (_squares.Count);
			return _squares[location];
		}
	}

	public enum Square
	{
		Space,
		Tree
	}
	
}
