using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public static class TimelineCustomSelection
    {
        public static readonly DependencyProperty IsTwoWayBindingEnabledProperty = DependencyProperty.RegisterAttached("IsTwoWayBindingEnabled",
            typeof(bool), typeof(TimelineCustomSelection), new PropertyMetadata(OnIsTwoWayBindingEnabledChanged));

        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.RegisterAttached("SelectedItems",
            typeof(IList), typeof(TimelineCustomSelection), new PropertyMetadata(OnSelectedItemsChanged));

        public static bool GetIsTwoWayBindingEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsTwoWayBindingEnabledProperty);
        }

        public static void SetIsTwoWayBindingEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsTwoWayBindingEnabledProperty, value);
        }

        public static IList GetSelectedItems(DependencyObject obj)
        {
            return (IList)obj.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(DependencyObject obj, IList value)
        {
            obj.SetValue(SelectedItemsProperty, value);
        }

        private static void OnIsTwoWayBindingEnabledChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RadTimeline timeline = sender as RadTimeline;
            if (timeline == null)
                return;

            if ((bool)e.NewValue)
                timeline.SelectionChanged += RadTimeline_SelectionChanged;
            else
                timeline.SelectionChanged -= RadTimeline_SelectionChanged;
        }

        private static void OnSelectedItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RadTimeline timeline = sender as RadTimeline;
            if (timeline == null)
                return;

            IList newSelectedItems = e.NewValue as IList;

            timeline.Tag = "SuppressSelectionChangedHandling";

            timeline.SelectedItems.Clear();
            foreach (var item in newSelectedItems)
            {
                timeline.SelectedItems.Add(item);
            }

            timeline.Tag = null;
        }

        private static void RadTimeline_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            RadTimeline timeline = sender as RadTimeline;

            if (timeline.Tag == "SuppressSelectionChangedHandling")
                return;

            List<object> newSelectedItems = null;

            if (e.AddedItems.Count > 0)
            {
                newSelectedItems = new List<object>(e.AddedItems);
            }
            else if (e.RemovedItems.Count > 0)
            {
                newSelectedItems = new List<object>()
                {
                    timeline.SelectedItem,
                    e.RemovedItems.First()
                };
            }

            if (newSelectedItems != null && newSelectedItems.Count < 2)
            {
                object firstSelectedItem = newSelectedItems.First();

                if (firstSelectedItem is King)
                {
                    King selectedKing = firstSelectedItem as King;
                    ExampleViewModel viewModel = timeline.DataContext as ExampleViewModel;

                    newSelectedItems.Add(viewModel.Events.FirstOrDefault(kingEvent => kingEvent.Ruler == selectedKing));
                }
                else if (firstSelectedItem is KingEvent)
                {
                    KingEvent selectedKingEvent = firstSelectedItem as KingEvent;

                    newSelectedItems.Add(selectedKingEvent.Ruler);
                }
            }

            timeline.Dispatcher.BeginInvoke(new Action(() =>
            {
                SetSelectedItems(timeline, newSelectedItems);
            }));
        }
    }
}
