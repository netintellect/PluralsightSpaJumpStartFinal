using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Examples.ChartView.LargeData.Views;

namespace Telerik.Windows.Examples.ChartView.LargeData
{
    public class SeriesTypeToExampleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "Line")
                return new DowJonesView();
            else if (value.ToString() == "Scatter")
                return new PermitsView();
            else
                throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
