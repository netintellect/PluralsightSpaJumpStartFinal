using System.Windows;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Examples.Diagrams.MindMap
{
	public class MindmapFirstLevelShape : MindmapShapeBase
	{
		public MindmapFirstLevelShape()
		{
			this.DefaultStyleKey = typeof(MindmapFirstLevelShape);

			this.Connectors.Add(new RadDiagramConnector() { Offset = new Point(0.4, 0.5), Name = "firstLevelItemLeft" });
			this.Connectors.Add(new RadDiagramConnector() { Offset = new Point(0.6, 0.5), Name = "firstLevelItemRight" });
		}
	}
}
