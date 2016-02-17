using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public abstract class GeometryToolboxItem : GeometryControl, IToolboxItem
	{
		public string Address { get; set; }
		public abstract RadDiagramShape CreateShape();
		public string Header { get; set; }
	}
}