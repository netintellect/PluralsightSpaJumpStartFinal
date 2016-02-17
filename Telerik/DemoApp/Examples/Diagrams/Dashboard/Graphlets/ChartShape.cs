using System;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class ChartShape : FinancialShape
	{
		//public ChartShape()
		//{
		//	this.DefaultStyleKey = typeof(ChartShape);
		//}

		protected override void UpdateData()
		{
			try
			{
				this.Content = DataProvider.Current.GetDataAgent(this.Symbol, 100, 1000);
			}
			catch (Exception)
			{
				RadWindow.Alert("Invalid symbol or the data service is not responding.");
			}
		}
	}
}