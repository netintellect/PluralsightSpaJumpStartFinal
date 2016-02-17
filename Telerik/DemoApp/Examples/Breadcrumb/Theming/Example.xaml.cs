
using System.Windows.Controls;
using System;
using System.Windows;
using Telerik.Windows.Examples.Breadcrumb.FirstLook;


namespace Telerik.Windows.Examples.Breadcrumb.Theming
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new MainPageViewModel();

			this.Loaded += this.Example_Loaded;
		}

		private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			this.explorerBreadcrumb.Path = @"Desktop\Computer\Local Disk (C:)\Personal Folders";
		}
	}
}