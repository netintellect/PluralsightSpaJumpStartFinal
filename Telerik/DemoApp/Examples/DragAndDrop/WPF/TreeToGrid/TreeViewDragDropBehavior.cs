using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.DragDrop;

namespace Telerik.Windows.Examples.DragAndDrop.WPF.TreeToGrid
{
	public class TreeViewDragDropBehavior
	{
		public double TreeViewItemHeight { get; set; }
		private bool isTreeSource = false;

		private RadTreeView _associatedObject;
		/// <summary>
		/// AssociatedObject Property
		/// </summary>
		public RadTreeView AssociatedObject
		{
			get
			{
				return _associatedObject;
			}
			set
			{
				_associatedObject = value;
			}
		}

		private static Dictionary<RadTreeView, TreeViewDragDropBehavior> instances;

		static TreeViewDragDropBehavior()
		{
			instances = new Dictionary<RadTreeView, TreeViewDragDropBehavior>();
		}

		public static bool GetIsEnabled(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsEnabledProperty);
		}

		public static void SetIsEnabled(DependencyObject obj, bool value)
		{
			TreeViewDragDropBehavior behavior = GetAttachedBehavior(obj as RadTreeView);

			behavior.AssociatedObject = obj as RadTreeView;

			if (value)
			{
				behavior.Initialize();
			}
			else
			{
				behavior.CleanUp();
			}
			obj.SetValue(IsEnabledProperty, value);
		}

		// Using a DependencyProperty as the backing store for IsEnabled.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsEnabledProperty =
			DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(TreeViewDragDropBehavior),
				new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

		public static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			SetIsEnabled(dependencyObject, (bool)e.NewValue);
		}

		private static TreeViewDragDropBehavior GetAttachedBehavior(RadTreeView gridview)
		{
			if (!instances.ContainsKey(gridview))
			{
				instances[gridview] = new TreeViewDragDropBehavior();
				instances[gridview].AssociatedObject = gridview;
			}

			return instances[gridview];
		}

		protected virtual void Initialize()
		{
			DragDropManager.AddDragInitializeHandler(this.AssociatedObject, OnDragInitialize);
			DragDropManager.AddGiveFeedbackHandler(this.AssociatedObject, OnGiveFeedback);
			DragDropManager.AddDragDropCompletedHandler(this.AssociatedObject, OnDragDropCompleted);
			DragDropManager.AddDropHandler(this.AssociatedObject, OnDrop);
			this.TreeViewItemHeight = 24.0;

			this.AssociatedObject.ItemPrepared += AssociatedObject_ItemPrepared;
		}

		protected virtual void CleanUp()
		{
			DragDropManager.RemoveDragInitializeHandler(this.AssociatedObject, OnDragInitialize);
			DragDropManager.RemoveGiveFeedbackHandler(this.AssociatedObject, OnGiveFeedback);
			DragDropManager.RemoveDragDropCompletedHandler(this.AssociatedObject, OnDragDropCompleted);
			DragDropManager.RemoveDropHandler(this.AssociatedObject, OnDrop);
		}

		void AssociatedObject_ItemPrepared(object sender, RadTreeViewItemPreparedEventArgs e)
		{
			DragDropManager.RemoveDragOverHandler(e.PreparedItem, OnItemDragOver);
			DragDropManager.AddDragOverHandler(e.PreparedItem, OnItemDragOver);
		}

		private IList sourceItems = null;
		private IList destinationItems = null;
		private object sourceItem = null;


		private void OnDragInitialize(object sender, DragInitializeEventArgs e)
		{
			var treeViewItem = e.OriginalSource as RadTreeViewItem ?? (e.OriginalSource as FrameworkElement).ParentOfType<RadTreeViewItem>();
			var data = treeViewItem != null ? treeViewItem.Item : (sender as RadTreeView).SelectedItem;

			var payload = DragDropPayloadManager.GeneratePayload(null);

			var dropDetails = new DropIndicationDetails();
			dropDetails.CurrentDraggedItem = data;

			DragVisual visual = new DragVisual()
			{
				Content = dropDetails,
				ContentTemplate = data is CategoryViewModel ? this.AssociatedObject.Resources["CategoryDragTemplate"] as DataTemplate : this.AssociatedObject.Resources["ProductDragTemplate"] as DataTemplate
			};

			payload.SetData("DraggedData", data);
			payload.SetData("DropDetails", dropDetails);

			e.DragVisual = visual;
			e.DragVisualOffset = e.RelativeStartPoint;
			e.Data = payload;
			e.AllowedEffects = DragDropEffects.All;

			FrameworkElement sourceItem = e.OriginalSource as RadTreeViewItem ?? (e.OriginalSource as FrameworkElement).ParentOfType<RadTreeViewItem>();
			if (sourceItem == null)
			{
				this.sourceItems = (IList)this.AssociatedObject.ItemsSource;
			}
			else
			{
				this.sourceItems = (sourceItem as RadTreeViewItem).ParentItem != null ?
					(IList)(sourceItem as RadTreeViewItem).ParentItem.ItemsSource : (IList)this.AssociatedObject.ItemsSource;
			}

			this.sourceItem = sourceItem.DataContext;
			this.destinationItems = this.AssociatedObject.ItemsSource as IList;
			this.isTreeSource = true;
		}

		private void OnGiveFeedback(object sender, Telerik.Windows.DragDrop.GiveFeedbackEventArgs e)
		{
			e.SetCursor(Cursors.Arrow);
			e.Handled = true;
		}

		private void OnDragDropCompleted(object sender, DragDropCompletedEventArgs e)
		{
			if (e.Effects != DragDropEffects.None && this.isTreeSource)
			{
				var data = DragDropPayloadManager.GetDataFromObject(e.Data, "DraggedData");

				this.sourceItems.Remove(data);
			}
		}

		private void OnDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			if (this.isTreeSource)
			{
				var data = DragDropPayloadManager.GetDataFromObject(e.Data, "DraggedData");

				this.sourceItems.Remove(data);
			}

			if (e.Effects != DragDropEffects.None)
			{
				var destinationItem = (e.OriginalSource as FrameworkElement).ParentOfType<RadTreeViewItem>();
				var dropDetails = DragDropPayloadManager.GetDataFromObject(e.Data, "DropDetails") as DropIndicationDetails;
				var data = DragDropPayloadManager.GetDataFromObject(e.Data, "DraggedData");

				if (destinationItems != null)
				{
					int dropIndex = dropDetails.DropIndex >= destinationItems.Count ? destinationItems.Count :
						dropDetails.DropIndex < 0 ? 0 : dropDetails.DropIndex;

					this.destinationItems.Insert(dropIndex, data);
				}
			}

			var source = this.AssociatedObject.ItemsSource;
			this.AssociatedObject.ItemsSource = null;
			this.AssociatedObject.ItemsSource = source;

			if (this.isTreeSource)
			{
				this.isTreeSource = false;
				this.sourceItem = null;
				this.sourceItems = null;
				this.destinationItems = null;
			}
		}

		private void OnItemDragOver(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			var draggedData = DragDropPayloadManager.GetDataFromObject(e.Data, "DraggedData");
			var dropDetails = DragDropPayloadManager.GetDataFromObject(e.Data, "DropDetails") as DropIndicationDetails;
			var item = (e.OriginalSource as FrameworkElement).ParentOfType<RadTreeViewItem>();

			var position = GetPosition(item, e.GetPosition(item));
			if (position != DropPosition.Inside)
			{
				e.Effects = DragDropEffects.All;
				this.destinationItems = item.Level > 0 ? (IList)item.ParentItem.ItemsSource : (IList)this.AssociatedObject.ItemsSource;
				//(IList)item.ParentItem.ItemsSource != null ? (IList)item.ParentItem.ItemsSource : (IList)this.AssociatedObject.ItemsSource;
				int index = this.destinationItems.IndexOf(item.Item);
				dropDetails.DropIndex = position == DropPosition.Before ? index : index + 1;
			}
			else
			{
				this.destinationItems = (IList)item.ItemsSource;
				int index = 0;

				if (destinationItems == null)
				{
					e.Effects = DragDropEffects.None;
				}
				else
				{
					e.Effects = DragDropEffects.All;
					dropDetails.DropIndex = index;
				}
			}

			dropDetails.CurrentDraggedOverItem = item.Item;
			dropDetails.CurrentDropPosition = position;

			if (this.isTreeSource && this.IsChildOfSource(item))
			{
				e.Effects = DragDropEffects.None;
			}

			e.Handled = true;
		}

		private bool IsChildOfSource(FrameworkElement item)
		{
			var currentItem = item;

			while (currentItem != null)
			{
				if ((currentItem as RadTreeViewItem).Item == this.sourceItem)
				{
					return true;
				}

				currentItem = currentItem.ParentOfType<RadTreeViewItem>();
			}

			return false;
		}

		private DropPosition GetPosition(RadTreeViewItem item, Point point)
		{
			if (point.Y < this.TreeViewItemHeight / 4)
			{
				return DropPosition.Before;
			}
			else if (point.Y > this.TreeViewItemHeight * 3 / 4)
			{
				return DropPosition.After;
			}

			return DropPosition.Inside;
		}

	}
}
