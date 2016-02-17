using System;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Diagrams.Features
{
	public sealed class SampleItem
	{
		public string Title { get; set; }
		public ImageSource Icon { get; set; }
		public string Description { get; set; }
		public Action<RadDiagram> Run { get; set; }
		public DelegateCommand RunCommand { get; internal set; }
	}
}