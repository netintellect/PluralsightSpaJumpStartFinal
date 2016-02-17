using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// Defines a toolbox item.
	/// </summary>
	public interface IToolboxItem
	{
		RadDiagramShape CreateShape();		
		string Header { get; set; }
	}
}