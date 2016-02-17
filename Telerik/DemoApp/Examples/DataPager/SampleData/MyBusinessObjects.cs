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

namespace Telerik.Windows.Examples.DataPager
{
	/// <summary>
	/// MyBusinessObjects.
	/// </summary>
	public class MyBusinessObjects
	{
		string[] names = new string[] { "Côte de Blaye", "Boston Crab Meat", 
            "Singaporean Hokkien Fried Mee", "Gula Malacca", "Rogede sild", 
            "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa" };
		double[] prizes = new double[] { 23.2500, 9.0000, 45.6000, 32.0000, 
            14.0000, 19.0000, 263.5000, 18.4000, 3.0000, 14.0000 };
		DateTime[] dates = new DateTime[] { new DateTime(2007, 5, 10), new DateTime(2008, 9, 13), 
            new DateTime(2008, 2, 22), new DateTime(2009, 1, 2), new DateTime(2007, 4, 13), 
            new DateTime(2008, 5, 12), new DateTime(2008, 1, 19), new DateTime(2008, 8, 26), 
            new DateTime(2008, 7, 31), new DateTime(2007, 7, 16) };
		bool[] bools = new bool[] { true, false, true, false, true, false, true, false, true, false };

		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <param name="maxItems">The max items.</param>
		/// <returns></returns>
		public IEnumerable<MyBusinessObject> GetData(int maxItems)
		{
			Random rnd = new Random();

			return from i in Enumerable.Range(1, maxItems)
				   select new MyBusinessObject(i
					   , names[rnd.Next(9)]
					   , prizes[rnd.Next(9)]
					   , dates[rnd.Next(9)]
					   , bools[rnd.Next(9)]);
		}

		/// <summary>
		/// Generates the random business object.
		/// </summary>
		/// <param name="random">The random.</param>
		/// <returns></returns>
		public MyBusinessObject GenerateRandomBusinessObject(Random random)
		{
			return new MyBusinessObject(random.Next(0, 100)
				, names[random.Next(9)]
				, prizes[random.Next(9)]
				, dates[random.Next(9)]
				, bools[random.Next(9)]);
		}
	}
}
