using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.DragDrop;

namespace Telerik.Windows.Examples.TreeListView.TreeListViewDragAndDrop
{
	public partial class Example : UserControl
	{
        public int counter = 0;


		public Example()
		{
			InitializeComponent();

			this.deleteDropTarget.SetValue(AllowDropProperty, true);
			DragDropManager.AddDropHandler(this.deleteDropTarget, OnDeleteDrop);

			this.favoritesDropTarget.SetValue(AllowDropProperty, true);
			DragDropManager.AddDropHandler(this.favoritesDropTarget, OnFavoritesDrop);
		}

		private void OnDeleteDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
				Collection<Object> payload = DragDropPayloadManager.GetDataFromObject(e.Data, "DragData") as Collection<Object>;
				Folder droppedItem = (Folder)payload[0];

				var behavior = TreeListViewDragAndDrop.TreeViewDragDropBehavior.GetAttachedBehavior(this.treeListView);
				behavior.SourceCollection.Remove(droppedItem);

				imgRecycleEmpty.Visibility = Visibility.Collapsed;
				imgRecycleFull.Visibility = Visibility.Visible;
				txtDelete.Text = droppedItem.Name + " folder deleted";
				this.treeListView.ExpandAllHierarchyItems();
		}

		private void OnFavoritesDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			Collection<Object> payload = DragDropPayloadManager.GetDataFromObject(e.Data, "DragData") as Collection<Object>;
			Folder droppedItem = (Folder)payload[0];

			counter++;
			txtAdd.Text = droppedItem.Name + " folder added";
			brdCounter.Visibility = Visibility.Visible;
			txtCounter.Text = counter.ToString();
		}
	}
}
