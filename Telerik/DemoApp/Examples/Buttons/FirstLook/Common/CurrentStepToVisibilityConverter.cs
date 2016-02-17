using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Buttons.FirstLook.Common
{
    public class CurrentStepToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var parameterString = parameter.ToString();
            var valueString = value.ToString();

            if (parameterString.Equals("BackButton"))
            {
                if (int.Parse(valueString) == 1)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
            if (parameterString.Equals("NextButton"))
            {
                if (int.Parse(valueString) == 3)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }
            if (parameterString.Equals("SubmitButton"))
            {
                if (int.Parse(valueString) == 3)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
            if (int.Parse(parameterString) == int.Parse(valueString))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
}