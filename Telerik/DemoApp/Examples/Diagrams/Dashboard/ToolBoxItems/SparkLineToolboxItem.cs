using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class SparkLineToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new SparkLineShape
			{
				Symbol = ImageToolboxItem.DefaultSymbol
			};
			return shape;
		}
	}
}