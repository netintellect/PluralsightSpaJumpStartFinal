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

namespace Telerik.Windows.Examples.RadialMenu.Configurator
{
    public static class PlacementModeParser
    {
        public static Telerik.Windows.Controls.PlacementMode CastPlacementMode(object selectedMode)
        {
            return (Telerik.Windows.Controls.PlacementMode)selectedMode;
        }
    }
}