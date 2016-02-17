using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
    class ControlOverviewOpacityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double offset = (double) value;
            if (parameter.ToString() == "translate")
            {
                //if (offset < 20)
                //{
                //    return -offset;
                //}
                //else
                //{
                //    return -50 + (offset) + offset * 0.5;
                //}
            }
            
            return 1 - (offset * 0.005);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
