using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public class LocationsToPathDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FlightPath flightPath = value as FlightPath;

            MapPathGeometry pathGeometry = new MapPathGeometry();

            var mapPathFigure = new MapPathFigure() { StartPoint = flightPath.DepartureLocation, IsClosed = false };

            Location controlPoint = new Location();
            controlPoint.Longitude = (flightPath.DepartureLocation.Longitude + flightPath.ArrivalLocation.Longitude) / 2;
            controlPoint.Latitude = Math.Max(flightPath.DepartureLocation.Latitude, flightPath.ArrivalLocation.Latitude) + Math.Abs(flightPath.DepartureLocation.Longitude - flightPath.ArrivalLocation.Longitude) / 8;

            mapPathFigure.Segments.Add(new MapQuadraticBezierSegment() { Point1 = controlPoint, Point2 = flightPath.ArrivalLocation });

            pathGeometry.Figures.Add(mapPathFigure);

            return pathGeometry;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
