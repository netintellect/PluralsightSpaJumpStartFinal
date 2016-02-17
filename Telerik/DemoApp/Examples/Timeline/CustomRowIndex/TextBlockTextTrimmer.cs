using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public static class TextBlockTextTrimmer
    {
        public static readonly DependencyProperty RelativeWidthProperty = DependencyPropertyExtensions.RegisterAttached("RelativeWidth",
            typeof(double),
            typeof(TextBlockTextTrimmer),
            new PropertyMetadata(OnRelativeWidthChanged));

        public static readonly DependencyProperty OptimumWidthProperty = DependencyPropertyExtensions.RegisterAttached("OptimumWidth",
            typeof(double),
            typeof(TextBlockTextTrimmer),
            new PropertyMetadata(-1d));

        public static readonly DependencyProperty AbbreviatedWidthProperty = DependencyPropertyExtensions.RegisterAttached("AbbreviatedWidth",
            typeof(double),
            typeof(TextBlockTextTrimmer),
            new PropertyMetadata(-1d));

        public static readonly DependencyProperty TextProperty = DependencyPropertyExtensions.RegisterAttached("Text",
            typeof(string),
            typeof(TextBlockTextTrimmer));

        public static readonly DependencyProperty AlternateTextProperty = DependencyPropertyExtensions.RegisterAttached("AlternateText",
            typeof(string),
            typeof(TextBlockTextTrimmer));

        public static readonly DependencyProperty AbbreviatedTextProperty = DependencyPropertyExtensions.RegisterAttached("AbbreviatedText",
            typeof(string),
            typeof(TextBlockTextTrimmer));

        public static double GetRelativeWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(RelativeWidthProperty);
        }

        public static void SetRelativeWidth(DependencyObject obj, double value)
        {
            obj.SetValue(RelativeWidthProperty, value);
        }

        public static double GetOptimumWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(OptimumWidthProperty);
        }

        public static void SetOptimumWidth(DependencyObject obj, double value)
        {
            obj.SetValue(OptimumWidthProperty, value);
        }

        public static double GetAbbreviatedWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(AbbreviatedWidthProperty);
        }

        public static void SetAbbreviatedWidth(DependencyObject obj, double value)
        {
            obj.SetValue(AbbreviatedWidthProperty, value);
        }

        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        public static string GetAlternateText(DependencyObject obj)
        {
            return (string)obj.GetValue(AlternateTextProperty);
        }

        public static void SetAlternateText(DependencyObject obj, string value)
        {
            obj.SetValue(AlternateTextProperty, value);
        }

        public static string GetAbbreviatedText(DependencyObject obj)
        {
            return (string)obj.GetValue(AbbreviatedTextProperty);
        }

        public static void SetAbbreviatedText(DependencyObject obj, string value)
        {
            obj.SetValue(AbbreviatedTextProperty, value);
        }

        private static void OnRelativeWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            if (GetOptimumWidth(textBlock) == -1d)
            {
                SetOptimumWidth(textBlock, textBlock.ActualWidth);
            }

            if (GetAbbreviatedWidth(textBlock) == -1d)
            {
                textBlock.Text = GetAlternateText(textBlock);
                textBlock.UpdateLayout();
                SetAbbreviatedWidth(textBlock, textBlock.ActualWidth);
            }

            if (GetOptimumWidth(textBlock) == -1d)
            {
                SetOptimumWidth(textBlock, textBlock.ActualWidth);
            }

            if (GetOptimumWidth(textBlock) <= (double)e.NewValue)
            {
                textBlock.Text = GetText(textBlock);
            }
            else if (GetAbbreviatedWidth(textBlock) > (double)e.NewValue)
            {
                textBlock.Text = GetAbbreviatedText(textBlock);
            }
            else
            {
                textBlock.Text = GetAlternateText(textBlock);
            }
        }
    }
}
