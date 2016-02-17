using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Examples.ChartView.LargeData.Views;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.LargeData
{
    public class YearToLegendSettingsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SeriesLegendSettings() { Title = value.ToString() };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
