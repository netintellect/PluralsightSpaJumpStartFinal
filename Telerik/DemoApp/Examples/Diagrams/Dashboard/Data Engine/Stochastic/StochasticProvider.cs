
using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class StochasticProvider : IDataProvider
	{
		public string FetchProfile(string symbol)
		{
			return string.Format("Profile of '{0}': {1}", symbol, DataGenerator.RandomTextVariation(TextSamples.FinanceProfile));
		}

		public void Fetch(List<Quote> quotes)
		{
			foreach (var quote in quotes)
			{
				var q = quote;
				DataGenerator.RandomQuote(ref q);
			}
		}

		public DataAgent GetDataAgent(string symbol, int dataPoints, int updateInterval)
		{
			return StochasticEngine.GetDataAgent(symbol, dataPoints, updateInterval);
		}

		public List<RssItem> FetchNews(int count=10)
		{
			var list = new List<RssItem>();
			var headlines = DataGenerator.RandomFinanceHeadlineCollection(count);
			for (var i = 0; i < count; i++)
			{
				var item = new RssItem
					{
						Title = headlines[i],
						Description = DataGenerator.RandomTextVariation(TextSamples.Finance,200),
						PublicationDate = DataGenerator.RandomDate(DateTime.Now.AddDays(-2), DateTime.Now.AddMinutes(-10))
					};
					list.Add(item);
			}
			return list;
		}
	}
}