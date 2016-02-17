using System.Windows;
using System.Windows.Data;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.MultipleAxes
{
    public class EmptyValueToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dataPoint = value as CategoricalDataPoint;
            var dataItem = dataPoint.DataItem as GdpDetailsInfo;

            var series = dataPoint.Presenter as CategoricalSeries;
            string boundMemberName = (series.ValueBinding as PropertyNameDataPointBinding).PropertyName;

            switch (boundMemberName)
            {
                case "Savings":
                    return this.ConvertValueToVisibility(dataItem.Savings);
                case "Investment":
                    return this.ConvertValueToVisibility(dataItem.Investment);
                case "Inflation":
                    return this.ConvertValueToVisibility(dataItem.Inflation);
                case "TotalGovernmentNetDebt":
                    return this.ConvertValueToVisibility(dataItem.TotalGovernmentNetDebt);
                case "GeneralGovernmentRevenue":
                    return this.ConvertValueToVisibility(dataItem.GeneralGovernmentRevenue);
                case "GeneralGovernmentTotalExpenditure":
                    return this.ConvertValueToVisibility(dataItem.GeneralGovernmentTotalExpenditure);
                case "GdpGrowth":
                    return this.ConvertValueToVisibility(dataItem.GdpGrowth);
                case "AccountBalance":
                    return this.ConvertValueToVisibility(dataItem.AccountBalance);
                default:
                    return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        private Visibility ConvertValueToVisibility(double? value)
        {
            if (value == null)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }
    }
}
