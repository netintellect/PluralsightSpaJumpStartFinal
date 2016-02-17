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

namespace Telerik.Windows.Examples.OutlookBar.Title
{
	public class DataItem
	{
		public ImageSource TitleIcon { get; set; }
		public string Title { get; set; }
		public ImageSource HeaderIcon { get; set; }
		public string Header { get; set; }
		public ImageSource MinimizedIcon { get; set; }
		public object Content { get; set; }
	}
}
