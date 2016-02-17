namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class StockChartToolboxItem : GeometryToolboxItem
	{		
		public ImageLocation ImageLocation { get; set; }

		public override Windows.Controls.RadDiagramShape CreateShape()
		{
			var shape = new ChartShape 
			{
				Symbol = ImageToolboxItem.DefaultSymbol
			};
			return shape;
		}
	}
}