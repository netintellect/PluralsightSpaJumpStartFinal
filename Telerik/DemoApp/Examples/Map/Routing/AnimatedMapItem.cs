using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.Routing
{
    public class AnimatedMapItem : DependencyObject, INotifyLocationChanged
    {
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
            "Caption",
            typeof(string),
            typeof(AnimatedMapItem),
            new PropertyMetadata(null));

        public static readonly DependencyProperty LocationProperty = DependencyProperty.Register(
            "Location",
            typeof(Location),
            typeof(AnimatedMapItem),
            new PropertyMetadata(LocationChangedHandler));

        public static readonly DependencyProperty PointProperty = DependencyProperty.Register(
            "Point",
            typeof(Point),
            typeof(AnimatedMapItem),
            new PropertyMetadata(PointChangedHandler));

        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public string Caption
        {
            get
            {
                return (string)this.GetValue(CaptionProperty);
            }

            set
            {
                this.SetValue(CaptionProperty, value);
            }
        }

        public Location Location
        {
            get
            {
                return (Location)this.GetValue(LocationProperty);
            }

            set
            {
                this.SetValue(LocationProperty, value);
            }
        }

        public Point Point
        {
            get
            {
                return (Point)this.GetValue(PointProperty);
            }

            set
            {
                this.SetValue(PointProperty, value);
            }
        }

        private static void LocationChangedHandler(DependencyObject source, DependencyPropertyChangedEventArgs eventArgs)
        {
            AnimatedMapItem item = source as AnimatedMapItem;
            if (item != null)
            {
                item.OnLocationChanged((Location)eventArgs.OldValue, (Location)eventArgs.NewValue);
            }
        }

        private static void PointChangedHandler(DependencyObject source, DependencyPropertyChangedEventArgs eventArgs)
        {
            AnimatedMapItem item = source as AnimatedMapItem;
            if (item != null)
            {
                Point point = (Point)eventArgs.NewValue;
                item.Location = new Location(point.Y, point.X);
            }
        }

        private void OnLocationChanged(Location oldValue, Location newValue)
        {
            if (this.LocationChanged != null)
            {
                this.LocationChanged(this, new LocationChangedEventArgs(oldValue, newValue));
            }
        }
    }
}
