using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class GaugeToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new GaugeShape()
			{
				Symbol = ImageToolboxItem.DefaultSymbol
			};
			return shape;
		}
	}
}