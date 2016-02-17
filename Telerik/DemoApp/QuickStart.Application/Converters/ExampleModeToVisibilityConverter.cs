using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
    public class ExampleModeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var exampleInfo = value as IExampleInfo;
            if (exampleInfo == null)
            {
                return Visibility.Collapsed;
            }

            switch(parameter.ToString())
            {
                case "ToTouch":
                    return ModelExtensions.IsTouchExample(exampleInfo) ? Visibility.Visible : Visibility.Collapsed;
                case "ToDesktop":
                    return ModelExtensions.IsDesktopExample(exampleInfo) ? Visibility.Visible : Visibility.Collapsed;
                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
