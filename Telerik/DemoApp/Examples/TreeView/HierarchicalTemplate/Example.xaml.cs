using System;
using System.Linq;
using System.Windows;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.TreeView.HierarchicalTemplate
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			this.MergeResourceDictionaries();
			InitializeComponent();
		}

		private void MergeResourceDictionaries()
		{
			try
			{
				ResourceDictionary dict1 = new ResourceDictionary();
				ResourceDictionary dict2 = new ResourceDictionary();
#if WPF
				dict1.Source = new Uri("TreeView;component/HierarchicalTemplate/DetailsTemplates.xaml", UriKind.RelativeOrAbsolute);
				dict2.Source = new Uri("TreeView;component/HierarchicalTemplate/TreeViewTemplates_WPF.xaml", UriKind.RelativeOrAbsolute);
#else
				Application.LoadComponent(dict1, new Uri("TreeView;component/HierarchicalTemplate/DetailsTemplates.xaml", UriKind.RelativeOrAbsolute));
				Application.LoadComponent(dict2, new Uri("TreeView;component/HierarchicalTemplate/TreeViewTemplates_SL.xaml", UriKind.RelativeOrAbsolute));
#endif
				this.Resources.MergedDictionaries.Add(dict1);
				this.Resources.MergedDictionaries.Add(dict2);
			}
			catch
			{
			}
		}

		private void TreeView_PreviewSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var isSelectedItemNotOlympicGame = e.AddedItems.OfType<OlympicGame>().Count() == 0;
			if (isSelectedItemNotOlympicGame)
			{
				e.Handled = true;

				var selectedContainer = this.xTreeView.SelectedContainer;
				if (selectedContainer != null) selectedContainer.Focus();
			}
		}
	}
}

