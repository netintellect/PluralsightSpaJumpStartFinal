using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System;
using System.Collections.Specialized;

namespace Telerik.Windows.QuickStart
{
	public class ResultBox : ItemsControl
	{
		public int HighlightedIndex
		{
			get { return (int)GetValue(HighlightedIndexProperty); }
			set { SetValue(HighlightedIndexProperty, value); }
		}

		// Using a DependencyProperty as the backing store for HighlightedIndex.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty HighlightedIndexProperty =
			DependencyProperty.Register("HighlightedIndex", typeof(int), typeof(ResultBox), new PropertyMetadata(-1, OnHighlightedIndexChanged, CoerceHighlightedIndex));

		private static object CoerceHighlightedIndex(DependencyObject d, object value)
		{
			ResultBox resultBox = (ResultBox)d;
			int index = (int)value;
			if (index < -1)
			{
				index = -1;
			}
			if (index >= resultBox.Items.Count)
			{
				index = resultBox.Items.Count - 1;
			}
			if (index >= 0)
			{
				resultBox.HighlightedItem = resultBox.Items[index];
			}
			else
			{
				resultBox.HighlightedItem = null;
			}
			return index;
		}

		private static void OnHighlightedIndexChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
		}

		internal void NotifyHighlightedChanged(ResultBoxItem item, DependencyPropertyChangedEventArgs args)
		{
			if ((bool)args.NewValue && !this.ignoreHighlightNotification)
			{
				this.HighlightedItem = this.ItemContainerGenerator.ItemFromContainer(item);
			}
		}

		public object HighlightedItem
		{
			get { return (object)GetValue(HighlightedItemProperty); }
			set { SetValue(HighlightedItemProperty, value); }
		}

		// Using a DependencyProperty as the backing store for HighlightedItem.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty HighlightedItemProperty =
			DependencyProperty.Register("HighlightedItem", typeof(object), typeof(ResultBox), new UIPropertyMetadata(null, OnHighlightedItemChanged, CoerceHighlihgtedItem));

		
		private static object CoerceHighlihgtedItem(DependencyObject d, object value)
		{
			ResultBox resultBox = (ResultBox)d;
			if (resultBox.Items.Contains(value))
			{
				return value;
			}
			else
			{
				return null;
			}
		}

		private bool ignoreHighlightNotification;
		private static void OnHighlightedItemChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			ResultBox resultBox = (ResultBox)sender;
			IHighlightable oldItem = resultBox.ItemContainerGenerator.ContainerFromItem(args.OldValue) as IHighlightable;
			if (oldItem != null)
			{
				oldItem.IsHighlighted = false;
			}
			IHighlightable newItem = resultBox.ItemContainerGenerator.ContainerFromItem(args.NewValue) as IHighlightable;
			if (newItem != null)
			{
				resultBox.ignoreHighlightNotification = true;
				newItem.IsHighlighted = true;
				resultBox.ignoreHighlightNotification = false;
			}
			resultBox.HighlightedIndex = resultBox.Items.IndexOf(args.NewValue);
		}

		static ResultBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ResultBox), new FrameworkPropertyMetadata(typeof(ResultBox)));
		}

		public void ScrollIntoView(object item)
		{
			FrameworkElement o = this.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
			if (o != null)
			{
				o.BringIntoView();
			}
		}

		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is ResultBoxItem;
		}

		protected override DependencyObject GetContainerForItemOverride()
		{
			return new ResultBoxItem();
		}

		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			base.PrepareContainerForItemOverride(element, item);
			(element as IHighlightable).IsHighlighted = item == this.HighlightedItem;
		}

		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
		}

		public event SearchSelectionEventHandler SearchSelection;

		internal void NotifyResultSelected(ResultBoxItem resultBoxItem)
		{
			if (this.SearchSelection != null)
			{
				this.SearchSelection.Invoke(this, new SearchSelectionEventArgs(this.ItemContainerGenerator.ItemFromContainer(resultBoxItem)));
			}
		}
	}
}
