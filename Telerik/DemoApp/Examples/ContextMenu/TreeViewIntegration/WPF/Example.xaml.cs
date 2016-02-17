using System.Linq;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.ContextMenu.TreeViewIntegration
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		private RadTreeViewItem ClickedTreeViewItem
		{
			get
			{
				return this.ContextMenu.GetClickedElement<RadTreeViewItem>();
			}
		}

		private void ContextMenuOpened(object sender, RoutedEventArgs e)
		{
			if (this.ClickedTreeViewItem != null)
			{
				DataItem dataItem = this.ClickedTreeViewItem.DataContext as DataItem;

				// We will disable the "New Sibling" and "Delete" context menu 
				// items if the clicked treeview item is a root item
				bool isRootItem = dataItem.Parent == null;

				(this.ContextMenu.Items[1] as RadMenuItem).IsEnabled = !isRootItem; // New Sibling
				(this.ContextMenu.Items[4] as RadMenuItem).IsEnabled = !isRootItem; // Delete
			}
		}

		private void ContextMenuClick(object sender, RoutedEventArgs e)
		{
			if (this.ClickedTreeViewItem == null) return;

			DataItem item = this.ClickedTreeViewItem.DataContext as DataItem;

			if (item == null) return;

			string header = (e.OriginalSource as RadMenuItem).Header as string;
			switch (header)
			{
                case "New Child":
                    DataItem newChild = new DataItem();
                    newChild.Text = "New Child";
                    item.Items.Add(newChild);
                    item.IsExpanded = true; // Ensure that the new child is visible
                    break;
                case "New Sibling":
                    DataItem newSibling = new DataItem();
                    newSibling.Text = "New Sibling";
                    item.Parent.Items.Add(newSibling);
                    break;
				case "Delete":
					item.Parent.Items.Remove(item);
					break;
				case "Edit":
					this.ClickedTreeViewItem.IsInEditMode = true;
					break;
				case "Select":
					this.ClickedTreeViewItem.IsSelected = true;
					break;
			}
		}
	}
}
