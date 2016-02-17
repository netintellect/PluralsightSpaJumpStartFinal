using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.Map;
using System.Windows;
using Telerik.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.HeatMap.Selection.Utilities
{
    public static class MapUtilities
    {
        public static Location GetCenter(DependencyObject obj)
        {
            return (Location)obj.GetValue(CenterProperty);
        }

        public static void SetCenter(DependencyObject obj, Location value)
        {
            obj.SetValue(CenterProperty, value);
        }

        public static readonly DependencyProperty CenterProperty = DependencyProperty.RegisterAttached(
            "Center", 
            typeof(Location), 
            typeof(MapUtilities), 
            new PropertyMetadata(CenterChanged));

        private static void CenterChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            RadMap map = target as RadMap;
            if(map != null && args.NewValue is Location)
            {
                Location location = (Location)args.NewValue;
                if (location.Latitude != 0 && location.Longitude != 0)
                {
                    map.Center = location;
                }
            }
        }
    }
}
