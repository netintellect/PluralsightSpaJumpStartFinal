using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class TextToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new TextShape
			{
				Text = "Double-click to edit."
			};

			return shape;
		}
	}
}