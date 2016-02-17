using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.Breadcrumb.FirstLook
{
	public class ExplorerItem
	{
		public string Header { get; set; }
		public string PreviewHeader { get; set; }
		public ImageSource Image { get; set; }
		public ObservableCollection<ExplorerItem> Children { get; set; }

		public ExplorerItem()
		{
			this.Children = new ObservableCollection<ExplorerItem>();
		}
	}
}
