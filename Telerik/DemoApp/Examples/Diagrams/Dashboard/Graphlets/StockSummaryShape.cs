using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class StockSummaryShape : FinancialShape
	{
		protected override void UpdateData()
		{
			if (string.IsNullOrEmpty(this.Symbol)) return;
			var quote = new Quote(this.Symbol);
			DataProvider.Fetch(new List<Quote> { quote });
			if (string.IsNullOrEmpty(quote.Name)) RadWindow.Alert("The provided symbol could not be resoled by Yahoo Finance. The shape has been added nevertheless.");
			this.Content = quote;
		}
	}
}