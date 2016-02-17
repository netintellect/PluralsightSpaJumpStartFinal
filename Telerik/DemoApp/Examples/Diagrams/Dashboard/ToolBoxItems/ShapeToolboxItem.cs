using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class ShapeToolboxItem : RadDiagramShape, IToolboxItem
	{
		public RadDiagramShape CreateShape()
		{
			var shape = new RadDiagramShape
				{
					Geometry = this.Geometry,
					BorderThickness = new Thickness(0.7)
				};
			return shape;
		}

		public string Header { get; set; }
	}
}