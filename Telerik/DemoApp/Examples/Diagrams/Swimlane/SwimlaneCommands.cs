using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public static class SwimlaneCommands
    {
        private static RoutedUICommand addCommand;
        private static RoutedUICommand removeCommand;
        public static RoutedUICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                    removeCommand = new RoutedUICommand("Remove Command", "RemoveCommand", typeof(SwimlaneCommands));
                return removeCommand;
            }
        }

        public static RoutedUICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RoutedUICommand("Add Command", "AddCommand", typeof(SwimlaneCommands));
                return addCommand;
            }
        }
    }
}
