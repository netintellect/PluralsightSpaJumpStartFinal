using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;

namespace Telerik.Windows.QuickStart
{
	public class LayoutClipBox : Panel
	{

		public TimeSpan LayoutAnimationDuration
		{
			get { return (TimeSpan)GetValue(LayoutAnimationDurationProperty); }
			set { SetValue(LayoutAnimationDurationProperty, value); }
		}

		// Using a DependencyProperty as the backing store for LayoutAnimationDuration.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty LayoutAnimationDurationProperty =
			DependencyProperty.Register("LayoutAnimationDuration", typeof(TimeSpan), typeof(LayoutClipBox), new UIPropertyMetadata(new TimeSpan(0, 0, 0, 0, 330)));

		// Aoutside clipping
		public double LayoutScaleY
		{
			get { return (double)GetValue(LayoutScaleYProperty); }
			set { SetValue(LayoutScaleYProperty, value); }
		}

		// Using a DependencyProperty as the backing store for LayoutScaleY.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty LayoutScaleYProperty =
			DependencyProperty.Register("LayoutScaleY", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(1.0, OnLayoutScalePropertyChanged));

		public double LayoutScaleX
		{
			get { return (double)GetValue(LayoutScaleXProperty); }
			set { SetValue(LayoutScaleXProperty, value); }
		}

		// Using a DependencyProperty as the backing store for LayoutScaleX.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty LayoutScaleXProperty =
			DependencyProperty.Register("LayoutScaleX", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(1.0, OnLayoutScalePropertyChanged));


		// Inside autoanimation
		public double SelfLayoutScaleX
		{
			get { return (double)GetValue(SelfLayoutScaleXProperty); }
			private set { SetValue(SelfLayoutScaleXProperty, value); }
		}

		// TODO: Make ReadOnly
		public static readonly DependencyProperty SelfLayoutScaleXProperty =
			DependencyProperty.Register("SelfLayoutScaleX", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(0.0, OnInternalResizePropertyChanged));

		public double SelfLayoutScaleY
		{
			get { return (double)GetValue(SelfLayoutScaleYProperty); }
			set { SetValue(SelfLayoutScaleYProperty, value); }
		}

		// TODO: Make ReadOnly
		public static readonly DependencyProperty SelfLayoutScaleYProperty =
			DependencyProperty.Register("SelfLayoutScaleY", typeof(double), typeof(LayoutClipBox), new UIPropertyMetadata(0.0, OnInternalResizePropertyChanged));

		private static void OnLayoutScalePropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			LayoutClipBox cb = ((LayoutClipBox)sender);
			if (cb != null)
			{
				cb.QueueLayoutInvalidation();
			}
		}

		private static void OnInternalResizePropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			LayoutClipBox cb = ((LayoutClipBox)sender);
			if (cb != null)
			{
				cb.QueueLayoutInvalidation();
			}
		}

		private bool invalidationQueued = false;
		private void QueueLayoutInvalidation()
		{
			if (!this.invalidationQueued)
			{
				this.invalidationQueued = true;
				this.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() => { this.InvalidateMeasure(); this.invalidationQueued = false; }));
			}
		}

		private Storyboard selfscale;
		private Size? previousSize;

		protected override Size MeasureOverride(Size constraint)
		{
			Size size = new Size();
			foreach (UIElement child in this.Children)
			{
				child.Measure(constraint);
				size.Width = Math.Max(child.DesiredSize.Width, size.Width);
				size.Height = Math.Max(child.DesiredSize.Height, size.Height);
			}
			if (this.previousSize == null)
			{
				this.previousSize = size;
				this.SelfLayoutScaleX = size.Width;
				this.SelfLayoutScaleY = size.Height;
			}
			else
			{
				if (this.previousSize.HasValue && this.previousSize.Value != size)
				{
					Storyboard story = new Storyboard();
					DoubleAnimation doubleAnimation;
					doubleAnimation = new DoubleAnimation() { From = this.SelfLayoutScaleX, To = size.Width, Duration = new Duration(this.LayoutAnimationDuration), DecelerationRatio = 1 };
					Storyboard.SetTarget(doubleAnimation, this);
					Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(LayoutClipBox.SelfLayoutScaleXProperty));
					story.Children.Add(doubleAnimation);
					doubleAnimation = new DoubleAnimation() { From = this.SelfLayoutScaleY, To = size.Height, Duration = new Duration(this.LayoutAnimationDuration), DecelerationRatio = 1 };
					Storyboard.SetTarget(doubleAnimation, this);
					Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(LayoutClipBox.SelfLayoutScaleYProperty));
					story.Children.Add(doubleAnimation);
					if (this.selfscale != null)
					{
						this.selfscale.Pause();
						this.selfscale.Remove();
					}
					this.selfscale = story;
					this.selfscale.Begin();
					this.previousSize = size;
				}
			}
			return new Size(this.SelfLayoutScaleX * this.LayoutScaleX, this.SelfLayoutScaleY * this.LayoutScaleY);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			foreach (UIElement child in this.Children)
			{
				child.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
			}
			return finalSize;
		}
	}
}
