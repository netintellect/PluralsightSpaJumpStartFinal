using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class ChartToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new ChartShape
			{
				Symbol = ImageToolboxItem.DefaultSymbol
			};
			return shape;
		}
	}
}