using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapDemoApp.Models
{
	public class Valuation
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[Indexed]
		public int StockId { get; set; }
		public DateTime Time { get; set; }
		public decimal Price { get; set; }
	}
}
