using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;
using System.Windows.Threading;
using System.Windows.Controls;

namespace Examples.TransitionControl.Common
{
	public static class RotatorExtensions
	{
		public static readonly DependencyProperty ItemsSourceProperty =
			DependencyProperty.RegisterAttached("ItemsSource", typeof(IEnumerable), typeof(RotatorExtensions), new PropertyMetadata(null,  OnItemsSourceChanged));

		public static readonly DependencyProperty ItemChangeDelayProperty =
			DependencyProperty.RegisterAttached("ItemChangeDelay", typeof(Duration), typeof(RotatorExtensions), new PropertyMetadata(new Duration(TimeSpan.FromSeconds(0.3))));

		public static readonly DependencyProperty CurrentSelectedIndexProperty =
			DependencyProperty.RegisterAttached("CurrentSelectedIndex", typeof(int), typeof(RotatorExtensions), new PropertyMetadata(-1, OnCurrentSelectedIndexChanged));

		private static readonly DependencyProperty TimerProperty =
			DependencyProperty.RegisterAttached("Timer", typeof(DispatcherTimer), typeof(RotatorExtensions), null);

		public static IEnumerable GetItemsSource(DependencyObject obj)
		{
			return (IEnumerable)obj.GetValue(ItemsSourceProperty);
		}

		public static void SetItemsSource(DependencyObject obj, IEnumerable value)
		{
			obj.SetValue(ItemsSourceProperty, value);
		}

		public static Duration GetItemChangeDelay(DependencyObject obj)
		{
			return (Duration)obj.GetValue(ItemChangeDelayProperty);
		}

		public static void SetItemChangeDelay(DependencyObject obj, Duration value)
		{
			obj.SetValue(ItemChangeDelayProperty, value);
		}

		public static int GetCurrentSelectedIndex(DependencyObject obj)
		{
			return (int)obj.GetValue(CurrentSelectedIndexProperty);
		}

		public static void SetCurrentSelectedIndex(DependencyObject obj, int value)
		{
			obj.SetValue(CurrentSelectedIndexProperty, value);
		}

		private static DispatcherTimer GetTimer(DependencyObject obj)
		{
			return (DispatcherTimer)obj.GetValue(TimerProperty);
		}

		private static void SetTimer(DependencyObject obj, DispatcherTimer value)
		{
			obj.SetValue(TimerProperty, value);
		}

		private static void OnCurrentSelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UpdateCurrentlySelectedItem(d);
		}

		private static void MoveToNextElement(DependencyObject element)
		{
			IEnumerable source = GetItemsSource(element);
			if (source != null)
			{
				IEnumerable<object> convertedSource = source.Cast<object>();
				int currentIndex = GetCurrentSelectedIndex(element);

				currentIndex = ++currentIndex % convertedSource.Count();
				SetCurrentSelectedIndex(element, currentIndex);
			}
		}

		private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement element = d as FrameworkElement;
			ItemsControl itemsControl = d as ItemsControl;

			IEnumerable oldValue = e.OldValue as IEnumerable;
			IEnumerable newValue = e.NewValue as IEnumerable;

			if (element != null)
			{
				if (oldValue != null)
				{
					// Detach the Ad Rotator functionality.
					element.Loaded -= OnElementLoaded;
					element.Unloaded -= OnElementUnloaded;

					// If there is a timer attached, stop it.
					DispatcherTimer timer = GetTimer(element);
					if (timer != null)
					{
						timer.Stop();
					}
				}

				if (newValue != null)
				{
					// Attach the Ad Rotator functionality.
					element.Loaded += OnElementLoaded;
					element.Unloaded += OnElementUnloaded;

					// If the target is an ItemsControl and its ItemsSource is not set, set it.
					if (itemsControl != null && itemsControl.ItemsSource == null && itemsControl.Items.Count == 0)
					{
						itemsControl.ItemsSource = newValue;
					}
				}
			}
		}

		private static DependencyObject element;

		private static void OnElementLoaded(object sender, RoutedEventArgs args)
		{
			 element = sender as DependencyObject;

			// Create the timer and hook-up to the events.
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = GetItemChangeDelay(element).TimeSpan;
			SetTimer(element, timer);

			timer.Tick += new EventHandler(timer_Tick);			

			timer.Start();

			// Make sure the currently pointed element is selected.
			UpdateCurrentlySelectedItem(element);
		}

		static void timer_Tick(object sender, EventArgs e)
		{
			MoveToNextElement(element);
		}

		private static void OnElementUnloaded(object sender, RoutedEventArgs args)
		{
			FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                DispatcherTimer timer = GetTimer(element);
                if (timer != null)
                {
                    timer.Stop();
                }
            }
		}

		private static void UpdateCurrentlySelectedItem(DependencyObject element)
		{
			ContentControl contentControl = element as ContentControl;

			IEnumerable source = GetItemsSource(element);

			// If there is no source we shouldn't do anything.
			if (source == null) return;

			// Find the actual index to be selected (if outside the boundaries of the collection)
			// and find the actual element to be selected.
			IEnumerable<object> convertedSource = source.Cast<object>();
			int currentIndex = GetCurrentSelectedIndex(element);
			object elementToSelect = convertedSource.ElementAtOrDefault(currentIndex);

			// Update the cotnent of the ContentControl if attached to a ContentControl.
			if (contentControl != null)
			{
				contentControl.Content = elementToSelect;
			}
		}
	}
}
