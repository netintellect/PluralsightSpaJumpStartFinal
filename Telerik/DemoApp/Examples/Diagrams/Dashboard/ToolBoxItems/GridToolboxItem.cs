using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class GridToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new GridShape()
			{
				Symbol = ImageToolboxItem.DefaultSymbol,
				Width = 300,
				Height = 100
			};
			return shape;
		}
	}
}