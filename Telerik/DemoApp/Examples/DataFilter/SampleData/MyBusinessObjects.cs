using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.DataFilter
{
	/// <summary>
	/// MyBusinessObjects.
	/// </summary>
	public class MyBusinessObjects
	{
		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <param name="maxItems">The max items.</param>
		/// <returns></returns>
		public IEnumerable<MyBusinessObject> GetData(int maxItems)
		{
			Random rnd = new Random();

			return from i in Enumerable.Range(1, maxItems)
				   select new MyBusinessObject(Names[rnd.Next(Names.Length - 1)]
					   , Quantities[rnd.Next(Quantities.Length - 1)]
					   , UnitPrices[rnd.Next(UnitPrices.Length - 1)]
					   , OrderDates[rnd.Next(OrderDates.Length - 1)]
					   , OrderTimes[rnd.Next(OrderTimes.Length - 1)]
					   , i % 2 == 0);
		}

		public static string[] Names = new string[] 
		{ 
			"Crab Meat"
			, "Beef meat"
			, "Pork Meat"
			, "Lamb meat"
			, "Chicken Meat"
			, "Turkey meat"
			, "Crab Soup"
			, "Beef soup"
			, "Pork Soup"
			, "Lamb soup"
			, "Chicken Soup"
			, "Turkey soup"
			, "Crab Pie"
			, "Beef pie"
			, "Pork Pie"
			, "Lamb pie"
			, "Chicken Pie"
			, "Turkey pie"
			, "Frozen Crab"
			, "frozen Beef"
			, "Frozen Pork"
			, "frozen Lamb"
			, "Frozen Chicken"
			, "frozen Turkey"
		};

		public static int[] Quantities = new int[] 
		{ 
			1
			, 3
			, 5
			, 9
			, 11
			, 13
			, 15
			, 19
			, 31
			, 33
			, 35
			, 39
			, 71
			, 73
			, 75
			, 79
			, 91
			, 93
			, 95
			, 99
		};

		public static double[] UnitPrices = new double[] 
		{ 
			3.99
			, 19.99
			, 45.45
			, 98.00
			, 13.99
			, 119.99
			, 145.45
			, 198.00
			, 33.99
			, 319.99
			, 345.45
			, 398.00
			, 73.99
			, 719.99
			, 745.45
			, 798.00
			, 93.99
			, 919.99
			, 945.45
			, 998.00
		};

		public static DateTime[] OrderDates = new DateTime[] 
		{ 
			new DateTime(2007, 4, 13)
			, new DateTime(2007, 5, 10)
			, new DateTime(2007, 7, 16) 
			, new DateTime(2007, 12, 5) 
			
			, new DateTime(2008, 1, 19)
			, new DateTime(2008, 5, 12)
			, new DateTime(2008, 7, 31)
			, new DateTime(2008, 8, 26)
			
			, new DateTime(2009, 1, 2)
			, new DateTime(2009, 3, 12)
			, new DateTime(2009, 6, 16)
			, new DateTime(2009, 8, 12)
		};
		
		public static DateTime[] OrderTimes = new DateTime[] 
		{ 
			new DateTime(1, 1, 1, 1, 2, 3)
			, new DateTime(1, 1, 1, 4, 5, 6)
			, new DateTime(1, 1, 1, 7, 8, 9) 
			, new DateTime(1, 1, 1, 10, 11, 12) 
			
			, new DateTime(1, 1, 1, 13, 14, 15)
			, new DateTime(1, 1, 1, 16, 17, 18)
			, new DateTime(1, 1, 1, 19, 20, 21)
			, new DateTime(1, 1, 1, 22, 23, 24)
			
			, new DateTime(1, 1, 1, 2, 31, 42)
			, new DateTime(1, 1, 1, 3, 42, 53)
			, new DateTime(1, 1, 1, 4, 53, 59)
			, new DateTime(1, 1, 1, 23, 59, 59)
		};
	}
}
