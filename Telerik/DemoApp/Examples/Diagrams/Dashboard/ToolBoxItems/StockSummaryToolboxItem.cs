using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class StockSummaryToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new StockSummaryShape
			{
				Symbol = DataGenerator.RandomString(4, CharType.UpperCaseLetters)
			};
			return shape;
		}
	}
}