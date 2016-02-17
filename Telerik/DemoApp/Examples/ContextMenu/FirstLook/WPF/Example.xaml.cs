using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ContextMenu.FirstLook
{
    public partial class Example : UserControl
    {

        public Example()
        {
            InitializeComponent();
        }

        // Configurator Events
        private void ModifierKey_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            switch (Convert.ToString(radioButton.Content))
            {
                case "ALT":
                    contextMenu.ModifierKey = ModifierKeys.Alt;
                    break;
                case "Control":
                    contextMenu.ModifierKey = ModifierKeys.Control;
                    break;
                case "None":
                    contextMenu.ModifierKey = ModifierKeys.None;
                    break;
                case "Shift":
                    contextMenu.ModifierKey = ModifierKeys.Shift;
                    break;
                case "Windows":
                    contextMenu.ModifierKey = ModifierKeys.Windows;
                    break;
                default:
                    break;
            }
        }

        private void EventName_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            switch (radioButton.Content.ToString())
            {
                case "MouseLeftButtonUp":
                    contextMenu.EventName = "MouseLeftButtonUp";
                    break;
                case "MouseRightButtonUp":
                    contextMenu.ClearValue(RadContextMenu.EventNameProperty);
                    break;
                default:
                    break;
            }
        }

        private void FlagsListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }

    
}
