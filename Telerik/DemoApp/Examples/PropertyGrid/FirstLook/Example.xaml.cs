using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.PropertyGrid.FirstLook
{
    public partial class Example
    {
        public Example()
        { 
            InitializeComponent();
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value as SolidColorBrush != null ? (value as SolidColorBrush).Color : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }
    }

    public class ThicknessToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Thickness)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return new Thickness(Double.Parse(value.ToString().Split(',')[0]), Double.Parse(value.ToString().Split(',')[1]), Double.Parse(value.ToString().Split(',')[2]), Double.Parse(value.ToString().Split(',')[3]));
            }
            catch
            {
                MessageBox.Show("Please, format the input value like this: \"number,number,number,number\".");
                return new Thickness(0);                
            }
        }
    }

}
