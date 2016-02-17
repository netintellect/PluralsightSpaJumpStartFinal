using System;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
{
    /// <summary>
    /// Gets the Fill color for the specified series from the chart palette.
    /// </summary>
    public class PaletteExtractorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CartesianSeries series = value as CartesianSeries;
            RadCartesianChart chart = series.Chart as RadCartesianChart;
            int seriesIndex = chart.Series.IndexOf(series);
            if (seriesIndex == 0)
            {
                return chart.Palette.GlobalEntries[seriesIndex].Fill;
            }
            else if (seriesIndex == 1)
            {
                return new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0x9D, 0xDE));
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
