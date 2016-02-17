using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;

namespace Telerik.Windows.Examples.TreeListView.TreeListViewDragAndDrop
{
	public class TreeViewDragDropBehavior
	{
		private object originalSource = null;
		private IList sourceCollection = null;
		private IList destinationCollection = null;

		private RadTreeListView _associatedObject;
		
		public IList SourceCollection
		{
			get
			{
				return this.sourceCollection;
			}
			set
			{
				this.sourceCollection = value;
			}
		}

		/// <summary>
		/// AssociatedObject Property
		/// </summary>
		public RadTreeListView AssociatedObject
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

		private static Dictionary<RadTreeListView, TreeViewDragDropBehavior> instances;

		static TreeViewDragDropBehavior()
		{
			instances = new Dictionary<RadTreeListView, TreeViewDragDropBehavior>();
		}

		public static bool GetIsEnabled(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsEnabledProperty);
		}

		public static void SetIsEnabled(DependencyObject obj, bool value)
		{
			TreeViewDragDropBehavior behavior = GetAttachedBehavior(obj as RadTreeListView);

			behavior.AssociatedObject = obj as RadTreeListView;

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
			#if !SILVERLIGHT
			SetIsEnabled(dependencyObject, (bool)e.NewValue);
			#endif
		}

		public static TreeViewDragDropBehavior GetAttachedBehavior(RadTreeListView gridview)
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
			DragDropManager.AddDragInitializeHandler(this.AssociatedObject, OnDragInitialize, true);
			DragDropManager.AddDropHandler(this.AssociatedObject, OnDrop, true);
			DragDropManager.AddDragDropCompletedHandler(this.AssociatedObject, OnDragDropCompleted, true);
			DragDropManager.AddDragOverHandler(this.AssociatedObject, OnDragOver, true);

			this.AssociatedObject.DataLoaded += RadTreeListView1_DataLoaded;
		}

		protected virtual void CleanUp()
		{
			DragDropManager.RemoveDragInitializeHandler(this.AssociatedObject, OnDragInitialize);
			DragDropManager.RemoveDropHandler(this.AssociatedObject, OnDrop);
			DragDropManager.RemoveDragDropCompletedHandler(this.AssociatedObject, OnDragDropCompleted);
			DragDropManager.RemoveDragOverHandler(this.AssociatedObject, OnDragOver);

			this.AssociatedObject.DataLoaded -= RadTreeListView1_DataLoaded;
		}

		private void OnDragInitialize(object sender, DragInitializeEventArgs e)
		{
			var sourceRow = (e.OriginalSource as TreeListViewRow) ?? (e.OriginalSource as FrameworkElement).ParentOfType<TreeListViewRow>();

			if (sourceRow != null)
			{
				var dataObject = DragDropPayloadManager.GeneratePayload(null);

				var draggedItem = sourceRow.Item;

				DragDropPayloadManager.SetData(dataObject, "DragData", new Collection<object>() { draggedItem });
				e.Data = dataObject;

				var screenshotVisualProvider = new ScreenshotDragVisualProvider();
				e.DragVisual = screenshotVisualProvider.CreateDragVisual(new DragVisualProviderState(e.RelativeStartPoint, new List<object>() { draggedItem }, new List<DependencyObject>() { sourceRow }, sender as FrameworkElement));
				e.DragVisualOffset = new Point(0, 0);
				this.originalSource = sourceRow.Item;
				this.sourceCollection = sourceRow.ParentRow != null ? (IList)sourceRow.ParentRow.Items.SourceCollection : (IList)sourceRow.GridViewDataControl.ItemsSource;
			}
		}

		private void OnDragDropCompleted(object sender, DragDropCompletedEventArgs e)
		{
		}

		private void OnDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			if (e.Data != null && e.AllowedEffects != DragDropEffects.None)
			{
				Collection<Object> payload = DragDropPayloadManager.GetDataFromObject(e.Data, "DragData") as Collection<Object>;
				if (payload != null)
				{
					Folder droppedItem = (Folder)payload[0];
					var destinationRow = e.OriginalSource as TreeListViewRow ?? (e.OriginalSource as FrameworkElement).ParentOfType<TreeListViewRow>();
					if (destinationRow != null)
					{
						Folder targetItem = destinationRow.DataContext as Folder;
						TreeListViewDropPosition relativeDropPosition = (TreeListViewDropPosition)destinationRow.GetValue(RadTreeListView.DropPositionProperty);
						this.destinationCollection = relativeDropPosition == TreeListViewDropPosition.Inside ? (IList)destinationRow.Items.SourceCollection :
																																							 destinationRow.ParentRow != null ? (IList)destinationRow.ParentRow.Items.SourceCollection : (IList)destinationRow.GridViewDataControl.ItemsSource;
						MoveItem(droppedItem, targetItem, relativeDropPosition);
					}
					else
					{
						this.destinationCollection = (IList)(sender as RadTreeListView).ItemsSource;
						MoveItemToRoot(droppedItem);
					}
				}
			}
		}

		private void OnDragOver(object sender, Telerik.Windows.DragDrop.DragEventArgs e)
		{
			var dropTarget = e.OriginalSource as TreeListViewRow ?? (e.OriginalSource as FrameworkElement).ParentOfType<TreeListViewRow>();
			if (this.IsChildOf(dropTarget, this.originalSource))
			{
				e.Effects = DragDropEffects.None;
			}

			e.Handled = true;
		}

		private bool IsChildOf(TreeListViewRow dropTarget, object originalSource)
		{
			var currentElement = dropTarget;
			while (currentElement != null)
			{
				if (currentElement.Item == originalSource)
				{
					return true;
				}

				currentElement = currentElement.ParentRow;
			}

			return false;
		}

		void RadTreeListView1_DataLoaded(object sender, EventArgs e)
		{
			this.AssociatedObject.DataLoaded -= new EventHandler<EventArgs>(RadTreeListView1_DataLoaded);
			this.AssociatedObject.ExpandAllHierarchyItems();
		}

		private void MoveItemToRoot(Folder droppedItem)
		{
			var parentCollection = sourceCollection;
			parentCollection.Remove(droppedItem);
			droppedItem.ParentFolder = null;
			(destinationCollection).Add(droppedItem);

			this.AssociatedObject.ExpandAllHierarchyItems();
		}

		private void MoveItem(Folder droppedItem, Folder targetItem, TreeListViewDropPosition relativeDropPosition)
		{
			if (droppedItem == targetItem)
				return;

			var parentCollection = this.sourceCollection;

			parentCollection.Remove(droppedItem);

			if (relativeDropPosition == TreeListViewDropPosition.Inside)
			{
				destinationCollection.Add(droppedItem);
			}
			else if (relativeDropPosition == TreeListViewDropPosition.Before)
			{
				destinationCollection.Insert(destinationCollection.IndexOf(targetItem), droppedItem);
			}
			else if (relativeDropPosition == TreeListViewDropPosition.After)
			{
				destinationCollection.Insert(destinationCollection.IndexOf(targetItem) + 1, droppedItem);
			}

			this.AssociatedObject.ExpandAllHierarchyItems();
		}
	}
}