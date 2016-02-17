using System.Collections.Generic;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class GridShape : FinancialShape
	{
		protected override void UpdateData()
		{
			var list = new List<Quote> { new Quote("XOM"), new Quote("AAPL"), new Quote("GOOG"), new Quote("BP"), new Quote("DELL") };
			DataProvider.Fetch(list);
			this.Content = list;
		}
	}
}