using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
    public static class RadSplitButtonExtensions
    {
        public static bool GetClosePopupOnDataContextChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(ClosePopupOnDataContextChangedProperty);
        }

        public static void SetClosePopupOnDataContextChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(ClosePopupOnDataContextChangedProperty, value);
        }

        public static readonly DependencyProperty ClosePopupOnDataContextChangedProperty =
            DependencyProperty.RegisterAttached("ClosePopupOnDataContextChanged", typeof(bool), typeof(RadSplitButtonExtensions), new PropertyMetadata(OnClosePopupOnDataContextChangedPropertyChanged));

        private static void OnClosePopupOnDataContextChangedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var radSplitButton = (RadSplitButton)sender;
            radSplitButton.DataContextChanged += (s, e) =>
                {
                    radSplitButton.IsOpen = false;
                };
        }
    }
}