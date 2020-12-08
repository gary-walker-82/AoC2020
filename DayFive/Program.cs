using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DayFive
{
	static class Program
	{
		private static void Main ()
		{
			var path = Path.Combine( Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location ), @"day5input.txt" );
			var planeTickets = File.ReadAllLines( path ).Select( x => new PlaneTicket( x ) );
			var maxSeatId = planeTickets.Max( x => x.SeatId );
			var except = Enumerable.Range( 0, maxSeatId )
				.Except( planeTickets.Select( x => x.SeatId ) ).ToList();
			var mySeatId = except
				.Where( (item, index) => index > 0 && item - 1 != except[index - 1] )
				.FirstOrDefault();

			Console.WriteLine( $"Max Seat Id : { mySeatId}" );
			Console.ReadKey();
		}
	}

	public enum RowCode
	{
		F,
		B
	}

	public enum SeatCode
	{
		L,
		R
	}

	public class PlaneTicket
	{
		private readonly string _boardingPassCode;
		private readonly List<RowCode> _rowCodes;
		private readonly List<SeatCode> _seatCodes;
		public int SeatId => Row * 8 + Seat;
		public int Row =>
			_rowCodes.Select( (item, index) => ((int)item << _rowCodes.Count) - (index + 1) )
				.Sum();

		public int Seat => _seatCodes.Select( (item, index) => ((int)item << _seatCodes.Count) - (index + 1) ).Sum();


		public PlaneTicket (string boardingPassCode)
		{
			_boardingPassCode = boardingPassCode;
			_rowCodes = _boardingPassCode.Take( 7 ).Select( x => Enum.Parse<RowCode>( x.ToString() ) ).ToList();
			_seatCodes = _boardingPassCode.Skip( 7 ).Take( 3 ).Select( x => Enum.Parse<SeatCode>( x.ToString() ) ).ToList();
		}
	}
}
