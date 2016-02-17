using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public static class SparklineUtils
    {
        public static readonly DependencyProperty SelectedDateProperty = DependencyPropertyExtensions.RegisterAttached("SelectedDate",
            typeof(DateTime),
            typeof(SparklineUtils),
            new PropertyMetadata(OnSelectedDateChanged));

        public static readonly DependencyProperty DateRangeProperty = DependencyPropertyExtensions.RegisterAttached("DateRange",
            typeof(SelectionRange<DateTime>),
            typeof(SparklineUtils),
            new PropertyMetadata(OnDateRangeChanged));

        public static readonly DependencyProperty DateProperty = DependencyPropertyExtensions.RegisterAttached("Date",
            typeof(double),
            typeof(SparklineUtils),
            new PropertyMetadata(OnDateChanged));

        public static readonly DependencyProperty ColorProperty = DependencyPropertyExtensions.RegisterAttached("Color",
            typeof(SolidColorBrush),
            typeof(SparklineUtils),
            new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedColorProperty = DependencyPropertyExtensions.RegisterAttached("SelectedColor",
            typeof(SolidColorBrush),
            typeof(SparklineUtils),
            new PropertyMetadata(null));

        public static DateTime GetSelectedDate(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(SelectedDateProperty);
        }

        public static void SetSelectedDate(DependencyObject obj, DateTime value)
        {
            obj.SetValue(SelectedDateProperty, value);
        }

        public static SelectionRange<DateTime> GetDateRange(DependencyObject obj)
        {
            return (SelectionRange<DateTime>)obj.GetValue(DateRangeProperty);
        }

        public static void SetDateRange(DependencyObject obj, SelectionRange<DateTime> value)
        {
            obj.SetValue(DateRangeProperty, value);
        }

        public static double GetDate(DependencyObject obj)
        {
            return (double)obj.GetValue(DateProperty);
        }

        public static void SetDate(DependencyObject obj, double value)
        {
            obj.SetValue(DateProperty, value);
        }

        public static SolidColorBrush GetSelectedColor(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(SelectedColorProperty);
        }

        public static void SetSelectedColor(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(SelectedColorProperty, value);
        }

        public static SolidColorBrush GetColor(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(ColorProperty);
        }

        public static void SetColor(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(ColorProperty, value);
        }

        private static void OnSelectedDateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateColumnColor(sender as Rectangle);
        }

        private static void OnDateRangeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateColumnColor(sender as Rectangle);
        }

        private static void OnDateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateColumnColor(sender as Rectangle);
        }

        private static void UpdateColumnColor(Rectangle column)
        {
            double date = GetDate(column);
            SelectionRange<DateTime> range = GetDateRange(column);

            var isColumnInRange = range.Start.Ticks <= date && date <= range.End.Ticks;

            if (isColumnInRange)
            {
                column.Fill = GetDate(column) == GetSelectedDate(column).Ticks ? GetSelectedColor(column) : GetColor(column);
            }
            else
            {
                column.Fill = GetColor(column);
            }
        }
    }
}
