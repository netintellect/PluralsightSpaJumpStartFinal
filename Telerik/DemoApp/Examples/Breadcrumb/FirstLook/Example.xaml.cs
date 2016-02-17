
using System.Windows.Controls;
using System;
using System.Windows;


namespace Telerik.Windows.Examples.Breadcrumb.FirstLook
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

		private void explorerBreadcrumb_CurrentItemChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
		{
			this.explorerTree.BringPathIntoView(this.explorerBreadcrumb.Path);
			this.explorerTree.SelectedItem = this.explorerBreadcrumb.CurrentItem;
		}

		private void explorerTree_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0 && this.explorerTree.ContainerFromItemRecursive(e.AddedItems[0]) != null)
			{
				this.explorerBreadcrumb.Path = this.explorerTree.ContainerFromItemRecursive(e.AddedItems[0]).FullPath;
			}
		}
	}
}