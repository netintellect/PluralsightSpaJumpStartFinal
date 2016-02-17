using System;
using Telerik.Windows.Controls;
using System.Windows;

namespace Telerik.Windows.Examples.TreeView.CustomContextMenu
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private readonly MainViewModel mainViewModel = new MainViewModel();

		public Example()
		{
			this.MergeResourceDictionaries();
			InitializeComponent();
			this.DataContext = this.mainViewModel;
		}

		private void MergeResourceDictionaries()
		{
			try
			{
				ResourceDictionary dict1 = new ResourceDictionary();
				ResourceDictionary dict2 = new ResourceDictionary();
#if WPF
				dict1.Source = new Uri("TreeView;component/CustomContextMenu/Resources.xaml", UriKind.RelativeOrAbsolute);
				dict2.Source = new Uri("TreeView;component/CustomContextMenu/TreeViewTemplates_WPF.xaml", UriKind.RelativeOrAbsolute);
#else
				Application.LoadComponent(dict1, new Uri("TreeView;component/CustomContextMenu/Resources.xaml", UriKind.RelativeOrAbsolute));
				Application.LoadComponent(dict2, new Uri("TreeView;component/CustomContextMenu/TreeViewTemplates_SL.xaml", UriKind.RelativeOrAbsolute));
#endif
				this.Resources.MergedDictionaries.Add(dict1);
				this.Resources.MergedDictionaries.Add(dict2);
			}
			catch
			{
			}
		}

		private void RadContextMenu_Opened(object sender, RoutedEventArgs e)
		{
			RadTreeViewItem clickedItemContainer = radContextMenu.GetClickedElement<RadTreeViewItem>();
			if (clickedItemContainer != null)
			{
				var clickedItem = clickedItemContainer.Item as SolutionItem;

				if (clickedItem != null)
				{
					this.mainViewModel.PreapreContextOperationsForItem(clickedItem);
				}
			}
			else
			{
				this.mainViewModel.PreapreContextOperationsForItem(null);
			}
		}
	}
}
