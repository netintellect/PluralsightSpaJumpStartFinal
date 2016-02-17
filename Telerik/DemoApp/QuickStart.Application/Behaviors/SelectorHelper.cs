using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Telerik.Windows.QuickStart
{
    public class SelectorHelper : DependencyObject
    {
        public static void OnSelectionChangedCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = d as Selector;
            ICommand command = e.NewValue as ICommand;

            if (selector != null)
            {
                SelectionChangedEventHandler selectionChangedHandler = (s, args) => 
                { 
                    command.Execute(selector.GetValue(SelectorHelper.SelectionChangedCommandParameterProperty)); 
                };

                RoutedEventHandler unloadedHandler = null;
                unloadedHandler = (s1, args1) => 
                {
                    // TODO: Uncomment this line but get rid of the bug with not being able to 
                    // navigate to example the 2nd time we land on SingleControlExamplesTouch view
                    //selector.SelectionChanged -= selectionChangedHandler;
                    selector.Unloaded -= unloadedHandler;
                };

                selector.SelectionChanged += selectionChangedHandler;
                selector.Unloaded += unloadedHandler;
            }
        }

        public static object GetSelectionChangedCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(SelectionChangedCommandParameterProperty);
        }

        public static void SetSelectionChangedCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(SelectionChangedCommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectionChangedCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionChangedCommandParameterProperty =
            DependencyProperty.RegisterAttached("SelectionChangedCommandParameter", typeof(object), typeof(SelectorHelper), new PropertyMetadata(null));

        public static ICommand GetSelectionChangedCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(SelectionChangedCommandProperty);
        }

        public static void SetSelectionChangedCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(SelectionChangedCommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectionChangedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached("SelectionChangedCommand", typeof(ICommand), typeof(SelectorHelper), new PropertyMetadata(null, OnSelectionChangedCommandPropertyChanged));


    }
}
