using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class NewsToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new NewsShape();
			return shape;
		}
	}
}