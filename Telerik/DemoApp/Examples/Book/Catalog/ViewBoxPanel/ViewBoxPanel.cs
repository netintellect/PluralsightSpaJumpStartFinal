using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Book.Catalog
{
	public class ViewBoxPanel : Panel
	{
		private ScaleTransform scale;
		private ScaleTransform Scale
		{
			get
			{
				return this.scale;
			}
			set
			{
				this.scale = value;
			}
		}

		public ViewBoxPanel()
		{
			this.Scale = new ScaleTransform();
		}

		private UIElement Child
		{
			get
			{
				if (this.Children.Count > 1)
				{
					throw new Exception("ViewBoxPanel can hold only 1 child");
				}
				else
				{
					UIElement _child = this.Children[0];
					_child.RenderTransform = this.Scale;
					return _child;
				}
			}
		}

		protected override Size MeasureOverride(Size panelAvailableSize)
		{
			Size size = new Size();
			if (Child != null)
			{
				this.Child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
				Size childDesiredSize = this.Child.DesiredSize;

				Size scale = this.GetScale(panelAvailableSize, childDesiredSize);

				size.Width = scale.Width * childDesiredSize.Width;
				size.Height = scale.Height * childDesiredSize.Height;
			}
			return size;
		}

		protected override Size ArrangeOverride(Size panelFinalSize)
		{
			if (Child != null)
			{
				Size childDesiredSize = this.Child.DesiredSize;
				Size scale = this.GetScale(panelFinalSize, childDesiredSize);

				this.Scale.ScaleX = scale.Width;
				this.Scale.ScaleY = scale.Height;

				Rect originalPosition = new Rect(0, 0, childDesiredSize.Width, childDesiredSize.Height);
				this.Child.Arrange(originalPosition);

				panelFinalSize.Width = scale.Width * childDesiredSize.Width;
				panelFinalSize.Height = scale.Height * childDesiredSize.Height;
			}
			return panelFinalSize;
		}

		private Size GetScale(Size panelSize, Size childSize)
		{
			double scaleX = panelSize.Width / childSize.Width;
			double scaleY = panelSize.Height / childSize.Height;

			double minScale = Math.Min(scaleX, scaleY);
			scaleX = minScale;
			scaleY = minScale;

			return new Size(scaleX, scaleY);
		}
	}
}
