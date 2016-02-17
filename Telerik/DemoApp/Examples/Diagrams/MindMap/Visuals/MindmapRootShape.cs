using System.Windows;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.MindMap
{
	public class MindmapRootShape : MindmapShapeBase
	{
		public MindmapRootShape()
		{
			this.DefaultStyleKey = typeof(MindmapRootShape);

			this.Connectors.Add(new RadDiagramConnector() { Offset = new Point(0.4, 0.5), Name = "rootLeft" });
			this.Connectors.Add(new RadDiagramConnector() { Offset = new Point(0.6, 0.5), Name = "rootRight" });
		}
	}
}
