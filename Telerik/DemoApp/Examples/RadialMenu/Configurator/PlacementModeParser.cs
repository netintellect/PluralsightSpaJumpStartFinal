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
        public static System.Windows.Controls.Primitives.PlacementMode CastPlacementMode(object selectedMode)
        {
            return (System.Windows.Controls.Primitives.PlacementMode)selectedMode;
        }
    }
}