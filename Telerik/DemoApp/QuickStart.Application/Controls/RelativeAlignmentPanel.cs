using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Telerik.Windows.QuickStart
{
	public class RelativeAlignmentPanel : Panel
	{
		public static double GetHorizontalAlignment(DependencyObject obj)
		{
			return (double)obj.GetValue(HorizontalAlignmentProperty);
		}

		public static void SetHorizontalAlignment(DependencyObject obj, double value)
		{
			obj.SetValue(HorizontalAlignmentProperty, value);
		}

		// Using a DependencyProperty as the backing store for HorizontalAlignment.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty HorizontalAlignmentProperty =
			DependencyProperty.RegisterAttached("HorizontalAlignment", typeof(double), typeof(RelativeAlignmentPanel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentArrange));

		public static double GetVerticalAlignment(DependencyObject obj)
		{
			return (double)obj.GetValue(VerticalAlignmentProperty);
		}

		public static void SetVerticalAlignment(DependencyObject obj, double value)
		{
			obj.SetValue(VerticalAlignmentProperty, value);
		}

		// Using a DependencyProperty as the backing store for VerticalAlignment.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty VerticalAlignmentProperty =
			DependencyProperty.RegisterAttached("VerticalAlignment", typeof(double), typeof(RelativeAlignmentPanel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentArrange));

		protected override Size MeasureOverride(Size availableSize)
		{
			Size s = availableSize;
			foreach (UIElement child in this.Children)
			{
				child.Measure(availableSize);
				s.Width = Math.Min(s.Width, child.DesiredSize.Width);
				s.Height = Math.Min(s.Height, child.DesiredSize.Height);
			}
			return s;
		}
		protected override Size ArrangeOverride(Size finalSize)
		{
			foreach (UIElement child in this.Children)
			{
				double xPos = (finalSize.Width - child.DesiredSize.Width) * GetHorizontalAlignment(child);
				double yPos = (finalSize.Height - child.DesiredSize.Height) * GetHorizontalAlignment(child);
				child.Arrange(new Rect(xPos, yPos, child.DesiredSize.Width, child.DesiredSize.Height));
			}
			return finalSize;
		}
	}
}
