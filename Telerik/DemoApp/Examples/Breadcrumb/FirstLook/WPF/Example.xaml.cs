using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.Breadcrumb.FirstLook.WPF
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new MainPageViewModel();
		}

		private void explorerBreadcrumb_CurrentItemChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
		{
			this.explorerTree.BringPathIntoView(this.explorerBreadcrumb.Path);
			this.explorerTree.SelectedItem = this.explorerBreadcrumb.CurrentItem;
		}

		private void explorerTree_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0 && this.explorerTree.ContainerFromItemRecursive(e.AddedItems[0]) != null)
			{
				this.explorerBreadcrumb.Path = this.explorerTree.ContainerFromItemRecursive(e.AddedItems[0]).FullPath;
			}
		}
	}
}
