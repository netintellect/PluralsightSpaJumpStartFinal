using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Timeline;

namespace Telerik.Windows.Examples.Timeline.Grouping
{
    public static class RadListBoxItemUtils
    {
        public static readonly DependencyProperty ActiveItemsProperty = DependencyProperty.RegisterAttached("ActiveItems",
            typeof(IEnumerable<string>), typeof(RadListBoxItemUtils), new PropertyMetadata(OnActiveItemsChanged));

        public static IEnumerable<string> GetActiveItems(DependencyObject obj)
        {
            return (IEnumerable<string>)obj.GetValue(ActiveItemsProperty);
        }

        public static void SetActiveItems(DependencyObject obj, IEnumerable<string> value)
        {
            obj.SetValue(ActiveItemsProperty, value);
        }

        private static void OnActiveItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RadListBoxItem item = sender as RadListBoxItem;
            if (item == null)
                return;

            if (e.NewValue == null)
            {
                item.IsEnabled = false;
            }
            else
            {
                item.IsEnabled = ((IEnumerable<string>)e.NewValue).Contains(item.Content);
            }
        }
    }
}
