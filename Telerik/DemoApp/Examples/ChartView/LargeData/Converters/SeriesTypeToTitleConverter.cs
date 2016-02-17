using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Examples.ChartView.LargeData.Views;

namespace Telerik.Windows.Examples.ChartView.LargeData
{
    public class SeriesTypeToTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "Line")
                return "Dow Jones Industrial Average";
            else if (value.ToString() == "Scatter")
                return "Estimated Building Cost vs Building Permit Fee";
            else
                throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
