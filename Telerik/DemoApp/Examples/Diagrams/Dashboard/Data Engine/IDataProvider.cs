using System.Collections.Generic;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public interface IDataProvider
	{
		string FetchProfile(string symbol);

		void Fetch(List<Quote> quotes);

		DataAgent GetDataAgent(string symbol, int dataPoints, int updateInterval);

		List<RssItem> FetchNews(int count);
	}
}