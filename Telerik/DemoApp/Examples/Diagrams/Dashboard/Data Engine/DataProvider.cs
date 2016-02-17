
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public static class DataProvider
	{
		public static IDataProvider Current { get; set; }


		public static string FetchProfile(string symbol)
		{
			return Current.FetchProfile(symbol);
		}

		public static void Fetch(List<Quote> quotes)
		{
			Current.Fetch(quotes);
		}

		public static decimal? GetDecimal(string input)
		{
			if (input == null) return null;

			input = input.Replace("%", "");

			decimal value;

			if (Decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out value)) return value;
			return null;
		}

		public static DataAgent GetDataAgent(string symbol, int dataPoints = 30, int updateInterval = 1000)
		{
			return Current.GetDataAgent(symbol, dataPoints, updateInterval);
		}

		public static List<RssItem> FetchNews()
		{
			return Current.FetchNews(10);

		}
	}
}