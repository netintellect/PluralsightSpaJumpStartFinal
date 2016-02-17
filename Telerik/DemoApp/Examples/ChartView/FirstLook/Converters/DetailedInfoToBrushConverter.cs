using System;
using System.Linq;
using System.Windows.Data;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.FirstLook
{
    public class DetailedInfoToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CategoricalDataPoint dataPoint = value as CategoricalDataPoint;
            int index = dataPoint.Index;

            BrushCollection brushes = parameter as BrushCollection;

            BarSeries series = (dataPoint as CategoricalDataPoint).Presenter as BarSeries;
            MonthRevenue dataItem = series.ItemsSource.Cast<object>().ElementAt(index) as MonthRevenue;

            if (dataItem.Actual < dataItem.Target)
                return brushes[1];

            return brushes[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
