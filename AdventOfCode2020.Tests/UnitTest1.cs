using adventofcode2020;
using NUnit.Framework;
using System.Linq;
using DayFive;

namespace AdventOfCode2020.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}


		[TestCase("BFFFBBFRRR", 70, 7,567)]
		[TestCase("FFFBBBFRRR", 14, 7,119)]
		[TestCase("BBFFBBFRLL", 102, 4,820)]
		public void PlanTicket(string boardingPass, int row, int seat, int seatId)
		{
			//act
			var actual = new PlaneTicket(boardingPass);

			//assert
			Assert.That(actual.Row , Is.EqualTo(row));
			Assert.That(actual.Seat , Is.EqualTo(seat));
			Assert.That(actual.SeatId , Is.EqualTo(seatId));
		}

		[Test]
		public void Test1()
		{
			//Arrange
			var enumerable = Enumerable.Range(1, 1);

			//Act
			var combinations = enumerable.GetCombinations(1);

			//Asset
			Assert.That(combinations.Count(), Is.EqualTo(1));
			Assert.That(combinations.First().Items, Has.Count.EqualTo(1));
			Assert.That(combinations.First().Items[0], Is.EqualTo(1));



		}

		[Test]
		public void Test2()
		{
			//Arrange
			var enumerable = Enumerable.Range(1, 5);

			//Act
			var combinations = enumerable.GetCombinations(1);

			//Asset
			Assert.That(combinations.Count(), Is.EqualTo(5));
			Assert.That(combinations.First().Items, Has.Count.EqualTo(1));
			Assert.That(combinations.First().Items[0], Is.EqualTo(1));

			Assert.That(combinations.Last().Items, Has.Count.EqualTo(1));
			Assert.That(combinations.Last().Items[0], Is.EqualTo(5));
		}

		[Test]
		public void Test3()
		{
			//Arrange
			var enumerable = Enumerable.Range(1, 2);

			//Act
			var combinations = enumerable.GetCombinations(2);

			//Asset
			Assert.That(combinations.Count(), Is.EqualTo(2));
			Assert.That(combinations.First().Items, Has.Count.EqualTo(2));
			Assert.That(combinations.First().Items[0], Is.EqualTo(2));
			Assert.That(combinations.First().Items[1], Is.EqualTo(1));

			Assert.That(combinations.Last().Items, Has.Count.EqualTo(2));
			Assert.That(combinations.Last().Items[0], Is.EqualTo(1));
			Assert.That(combinations.Last().Items[1], Is.EqualTo(2));
		}


		[Test]
		public void Test4()
		{
			//Arrange
			var enumerable = Enumerable.Range(1, 3);

			//Act
			var combinations = enumerable.GetCombinations(2);

			//Asset
			Assert.That(combinations.Count(), Is.EqualTo(6));
			Assert.That(combinations.First().Items, Has.Count.EqualTo(2));
			Assert.That(combinations.First().Items[0], Is.EqualTo(2));
			Assert.That(combinations.First().Items[1], Is.EqualTo(1));

			Assert.That(combinations.Last().Items, Has.Count.EqualTo(2));
			Assert.That(combinations.Last().Items[0], Is.EqualTo(2));
			Assert.That(combinations.Last().Items[1], Is.EqualTo(3));
		}

		[Test]
		public void Test5()
		{
			//Arrange
			var enumerable = Enumerable.Range(1, 4);

			//Act
			var combinations = enumerable.GetCombinations(2);

			//Asset
			Assert.That(combinations.Count(), Is.EqualTo(12));
			Assert.That(combinations.First().Items, Has.Count.EqualTo(2));
			Assert.That(combinations.First().Items[0], Is.EqualTo(2));
			Assert.That(combinations.First().Items[1], Is.EqualTo(1));

			Assert.That(combinations.Last().Items, Has.Count.EqualTo(2));
			Assert.That(combinations.Last().Items[0], Is.EqualTo(3));
			Assert.That(combinations.Last().Items[1], Is.EqualTo(4));
		}

		[Test]
		public void Test6()
		{
			//Arrange
			var enumerable = Enumerable.Range(1, 3);

			//Act
			var combinations = enumerable.GetCombinations(3);

			//Asset
			Assert.That(combinations.Count(), Is.EqualTo(6));
			Assert.That(combinations.First().Items, Has.Count.EqualTo(3));
			Assert.That(combinations.First().Items[0], Is.EqualTo(3));
			Assert.That(combinations.First().Items[1], Is.EqualTo(2));
			Assert.That(combinations.First().Items[2], Is.EqualTo(1));

			Assert.That(combinations.Last().Items, Has.Count.EqualTo(3));
			Assert.That(combinations.Last().Items[0], Is.EqualTo(1));
			Assert.That(combinations.Last().Items[1], Is.EqualTo(2));
			Assert.That(combinations.Last().Items[2], Is.EqualTo(3));
		}
	}



}