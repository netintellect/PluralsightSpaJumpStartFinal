using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Telerik.Windows.QuickStart
{
	public class AnimatedScrollPanel : Panel, IScrollInfo
	{

		private double AnimationHorizontalOffset
		{
			get { return (double)GetValue(AnimationHorizontalOffsetProperty); }
			set { SetValue(AnimationHorizontalOffsetProperty, value); }
		}

		// Using a DependencyProperty as the backing store for AnimationHorizontalOffset.  This enables animation, styling, binding, etc...
		private static readonly DependencyProperty AnimationHorizontalOffsetProperty =
			DependencyProperty.Register("AnimationHorizontalOffset", typeof(double), typeof(AnimatedScrollPanel), new PropertyMetadata(OnScrollChanged));

		private double AnimationVerticalOffset
		{
			get { return (double)GetValue(AnimationVerticalOffsetProperty); }
			set { SetValue(AnimationVerticalOffsetProperty, value); }
		}

		// Using a DependencyProperty as the backing store for AnimationVerticalOffset.  This enables animation, styling, binding, etc...
		private static readonly DependencyProperty AnimationVerticalOffsetProperty =
			DependencyProperty.Register("AnimationVerticalOffset", typeof(double), typeof(AnimatedScrollPanel), new PropertyMetadata(OnScrollChanged));

		private static void OnScrollChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			AnimatedScrollPanel animatedScrolling = sender as AnimatedScrollPanel;
			animatedScrolling.InvalidateArrange();
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			Size size = new Size();
			foreach(UIElement child in Children)
			{
				child.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
			}
			size.Width = Children.OfType<UIElement>().Max<UIElement, double>(c => c.DesiredSize.Width);
 			size.Height = Children.OfType<UIElement>().Max<UIElement, double>(c => c.DesiredSize.Height);
			
			viewportWidth = availableSize.Width;
			viewportHeight = availableSize.Height;
			extentWidth = size.Width;
			extentHeight = size.Height;

			if (this.ScrollOwner != null)
			{
				this.ScrollOwner.InvalidateScrollInfo();
			}

			size.Width = Math.Min(availableSize.Width, size.Width);
			size.Height = Math.Min(availableSize.Height, size.Height);

			this.SetVerticalOffset(this.VerticalOffset);
			this.SetHorizontalOffset(this.HorizontalOffset);

			return size;
		}
		protected override Size ArrangeOverride(Size finalSize)
		{
			foreach (UIElement child in Children)
			{
				child.Arrange(new Rect(-this.AnimationHorizontalOffset, -this.AnimationVerticalOffset, Math.Max(extentWidth, finalSize.Width), Math.Max(extentHeight, finalSize.Height)));
			}
			return base.ArrangeOverride(finalSize);
		}

		private bool canHorizontallyScroll;
		public bool CanHorizontallyScroll
		{
			get
			{
				return canHorizontallyScroll;
			}
			set
			{
				canHorizontallyScroll = value;
			}
		}
		private bool canVerticallyScroll;
		public bool CanVerticallyScroll
		{
			get
			{
				return canVerticallyScroll;
			}
			set
			{
				canVerticallyScroll = value;
			}
		}

		private double extentHeight;
		public double ExtentHeight
		{
			get { return extentHeight; }
		}
		private double extentWidth;
		public double ExtentWidth
		{
			get { return extentWidth; }
		}

		private double horizontalOffset;
		public double HorizontalOffset
		{
			get { return horizontalOffset; }
		}

		public void LineDown()
		{
			this.SetVerticalOffset(this.VerticalOffset + 0.1 * this.ViewportHeight);
		}
		public void LineLeft()
		{
			this.SetHorizontalOffset(this.HorizontalOffset - 0.1 * this.ViewportWidth);
		}
		public void LineRight()
		{
			this.SetHorizontalOffset(this.HorizontalOffset + 0.1 * this.ViewportWidth);
		}
		public void LineUp()
		{
			this.SetVerticalOffset(this.VerticalOffset - 0.1 * this.ViewportHeight);
		}

		public Rect MakeVisible(UIElement visual, Rect rectangle)
		{

			return rectangle;
		}

		public void MouseWheelDown()
		{
			this.SetVerticalOffset(this.VerticalOffset + 0.3 * this.ViewportHeight);
		}
		public void MouseWheelLeft()
		{
			this.SetHorizontalOffset(this.HorizontalOffset - 0.3 * this.ViewportWidth);
		}
		public void MouseWheelRight()
		{
			this.SetHorizontalOffset(this.HorizontalOffset + 0.3 * this.ViewportWidth);
		}
		public void MouseWheelUp()
		{
			this.SetVerticalOffset(this.VerticalOffset - 0.3 * this.ViewportHeight);
		}
		public void PageDown()
		{
			this.SetVerticalOffset(this.VerticalOffset + this.ViewportHeight);
		}
		public void PageLeft()
		{
			this.SetHorizontalOffset(this.HorizontalOffset - this.ViewportHeight);
		}
		public void PageRight()
		{
			this.SetHorizontalOffset(this.HorizontalOffset + this.ViewportHeight);
		}
		public void PageUp()
		{
			this.SetVerticalOffset(this.VerticalOffset - this.ViewportHeight);
		}

		public ScrollViewer ScrollOwner { get; set; }

		public void SetHorizontalOffset(double offset)
		{
			this.horizontalOffset = Math.Max(0, Math.Min(this.ExtentWidth - this.ViewportWidth, offset));
			UpdateScrollAnimation();
			this.ScrollOwner.InvalidateScrollInfo();
		}
		public void SetVerticalOffset(double offset)
		{
			this.verticalOffset = Math.Max(0, Math.Min(this.ExtentHeight - this.ViewportHeight, offset));
			UpdateScrollAnimation();
			this.ScrollOwner.InvalidateScrollInfo();
		}

		public TimeSpan Duration
		{
			get { return (TimeSpan)GetValue(DurationProperty); }
			set { SetValue(DurationProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Duration.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DurationProperty =
			DependencyProperty.Register("Duration", typeof(TimeSpan), typeof(AnimatedScrollPanel), new PropertyMetadata(new TimeSpan(0, 0, 0, 1)));

		//public IEasingFunction Easing
		//{
		//    get { return (IEasingFunction)GetValue(EasingProperty); }
		//    set { SetValue(EasingProperty, value); }
		//}

		//// Using a DependencyProperty as the backing store for Easing.  This enables animation, styling, binding, etc...
		//public static readonly DependencyProperty EasingProperty =
		//    DependencyProperty.Register("Easing", typeof(IEasingFunction), typeof(AnimatedScrollPanel), null);

		private Storyboard storyBoard;
		private void UpdateScrollAnimation()
		{
			DoubleAnimation horizontalAnimation;
			DoubleAnimation verticalAnimation;

			if (storyBoard != null)
			{
				storyBoard.Pause();
				horizontalAnimation = storyBoard.Children[0] as DoubleAnimation;
				verticalAnimation = storyBoard.Children[1] as DoubleAnimation;
			}
			else
			{
				storyBoard = new Storyboard();
				horizontalAnimation = new DoubleAnimation();
				verticalAnimation = new DoubleAnimation();

				storyBoard.Children.Add(horizontalAnimation);
				storyBoard.Children.Add(verticalAnimation);

				Storyboard.SetTarget(horizontalAnimation, this);
				Storyboard.SetTargetProperty(horizontalAnimation, new PropertyPath(AnimatedScrollPanel.AnimationHorizontalOffsetProperty));
				Storyboard.SetTarget(verticalAnimation, this);
				Storyboard.SetTargetProperty(verticalAnimation, new PropertyPath(AnimatedScrollPanel.AnimationVerticalOffsetProperty));
			}

			storyBoard.Duration = this.Duration;
			horizontalAnimation.Duration = this.Duration;
			verticalAnimation.Duration = this.Duration;

			//horizontalAnimation.EasingFunction = this.Easing;
			//verticalAnimation.EasingFunction = this.Easing;

			horizontalAnimation.To = this.HorizontalOffset;
			verticalAnimation.To = this.VerticalOffset;

			storyBoard.Begin();
		}

		private double verticalOffset;
		public double VerticalOffset
		{
			get { return verticalOffset; }
		}
		private double viewportHeight;
		public double ViewportHeight
		{
			get { return viewportHeight; }
		}
		private double viewportWidth;
		public double ViewportWidth
		{
			get { return viewportWidth; }
		}

		public Rect MakeVisible(Visual visual, Rect rectangle)
		{
			GeneralTransform transform = visual.TransformToVisual(this);
			Rect scrollRect = new Rect(transform.Transform(new Point(rectangle.Left, rectangle.Top)), transform.Transform(new Point(rectangle.Right, rectangle.Bottom)));
			scrollRect.X += this.HorizontalOffset;
			scrollRect.Y += this.VerticalOffset;
			
			double newHorizontallOffset = this.HorizontalOffset;
			double newVerticalOffset = this.VerticalOffset;

			if (newHorizontallOffset + this.ViewportWidth < scrollRect.Right)
			{
				newHorizontallOffset = scrollRect.Right - this.ViewportWidth;
			}
			if (newVerticalOffset + this.ViewportHeight < scrollRect.Bottom)
			{
				newVerticalOffset = scrollRect.Bottom - this.ViewportHeight;
			}
			if (newHorizontallOffset > scrollRect.Left)
			{
				newHorizontallOffset = scrollRect.Left;
			}
			if (newVerticalOffset > scrollRect.Top)
			{
				newVerticalOffset = scrollRect.Top;
			}

			this.SetVerticalOffset(newVerticalOffset);
			this.SetHorizontalOffset(newHorizontallOffset);

			return scrollRect;
		}
	}
}
