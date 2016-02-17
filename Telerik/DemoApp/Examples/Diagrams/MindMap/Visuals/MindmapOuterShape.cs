using System.Windows;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Examples.Diagrams.MindMap
{
	public class MindmapOuterShape : MindmapShapeBase
	{
		public MindmapOuterShape()
		{
			this.DefaultStyleKey = typeof(MindmapOuterShape);

			this.Connectors.Add(new RadDiagramConnector() { Offset = new Point(0, 1), Name = "subItemItemLeft" });
			this.Connectors.Add(new RadDiagramConnector() { Offset = new Point(1, 1), Name = "subItemItemRight" });
		}
	}
}
