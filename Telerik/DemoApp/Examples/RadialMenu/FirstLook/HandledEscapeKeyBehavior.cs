using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RadialMenu
{
    public static class HandledEscapeKeyBehavior
    {
        public static bool GetHandleEscapeKey(DependencyObject obj)
        {
            return (bool)obj.GetValue(HandleEscapeKeyProperty);
        }

        public static void SetHandleEscapeKey(DependencyObject obj, bool value)
        {
            obj.SetValue(HandleEscapeKeyProperty, value);
        }

        public static readonly DependencyProperty HandleEscapeKeyProperty =
            DependencyProperty.RegisterAttached("HandleEscapeKey", typeof(bool), typeof(HandledEscapeKeyBehavior), new PropertyMetadata(OnHandleEscapeKey));

        private static void OnHandleEscapeKey(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element != null && (bool)e.NewValue)
            {
                element.AddHandler(FrameworkElement.KeyDownEvent, new KeyEventHandler(Element_KeyDown), true);
                var userControl = element.ParentOfType<UserControl>();
                if (userControl != null)
                {
                    userControl.AddHandler(UserControl.KeyDownEvent, new KeyEventHandler(Element_KeyDown), true);
                }
            }
        }

        private static void Element_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                RadialMenuCommands.Hide.Execute(null, sender as UIElement);
            }
        }
    }
}
