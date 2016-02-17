using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using System.Windows;

namespace Telerik.Windows.Examples.ContextMenu.FirstLook
{
    public class ExtendedContextMenu : RadContextMenu
    {
        public static readonly DependencyProperty ClickedListBoxItemProperty =
            DependencyProperty.Register("ClickedListBoxItem", typeof(System.Windows.Controls.ListBoxItem), typeof(ExtendedContextMenu), new PropertyMetadata(null));

        public System.Windows.Controls.ListBoxItem ClickedListBoxItem
        {
            get { return (System.Windows.Controls.ListBoxItem)GetValue(ClickedListBoxItemProperty); }
            set { SetValue(ClickedListBoxItemProperty, value); }
        }

        protected override void OnOpened(RadRoutedEventArgs e)
        {
            base.OnOpened(e);
            this.ClickedListBoxItem = null;
            this.ClickedListBoxItem = this.GetClickedElement<System.Windows.Controls.ListBoxItem>();
        }
    }  
}
