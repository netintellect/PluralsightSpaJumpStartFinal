using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Telerik.Windows.QuickStart
{
	public class ResultBoxItem : ContentControl, IHighlightable
	{
		public bool IsHighlighted
		{
			get { return (bool)GetValue(IsHighlightedProperty); }
			set { SetValue(IsHighlightedProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsHighlighted.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsHighlightedProperty =
			DependencyProperty.Register("IsHighlighted", typeof(bool), typeof(ResultBoxItem), new PropertyMetadata(false, OnIsHighlightedChanged));

		private static void OnIsHighlightedChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			ResultBoxItem resultBoxItem = (ResultBoxItem)sender;
			ResultBox resultBox = resultBoxItem.ParentResultBox;
			resultBox.NotifyHighlightedChanged(resultBoxItem, args);
		}

		internal ResultBox ParentResultBox
		{
			get
			{
				return ItemsControl.ItemsControlFromItemContainer(this) as ResultBox;
			}
		}

		static ResultBoxItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ResultBoxItem), new FrameworkPropertyMetadata(typeof(ResultBoxItem)));
		}

		protected override void OnMouseEnter(MouseEventArgs e)
		{
			this.IsHighlighted = true;
		}

		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			this.IsHighlighted = true;
			this.ParentResultBox.NotifyResultSelected(this);
		}
	}
}
