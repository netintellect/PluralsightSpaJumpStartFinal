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
using System.Windows.Data;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
{
    public class SeriesTypeToLegendGeometryConverter : IValueConverter
    {
        public Geometry PointGeometry { get; set; }
        public Geometry LineGeometry { get; set; }
        public Geometry AreaGeometry { get; set; }

#if SILVERLIGHT
        private GeometryCloneConverter cloner = new GeometryCloneConverter();
#endif

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Geometry geometry = null;

            if (value is ScatterAreaSeries || value is ScatterSplineAreaSeries)
            {
                geometry = this.AreaGeometry;
            }
            else if (value is ScatterLineSeries || value is ScatterSplineSeries)
            {
                geometry = this.LineGeometry;
            }
            else if (value is ScatterPointSeries)
            {
                var series = (ScatterPointSeries)value;
                geometry = series.LegendSettings.MarkerGeometry ?? this.PointGeometry;
            }

#if SILVERLIGHT
            geometry = cloner.Convert(geometry, null, null, null) as Geometry;
#endif

            return geometry;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
