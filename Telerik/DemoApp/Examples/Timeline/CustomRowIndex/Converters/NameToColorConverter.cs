using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class NameToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string colorString = string.Empty;
            var name = (string)value;
            switch (name)
            {
                case "Wessex":
                    colorString = "#FF8EC441";
                    break;
                case "Normandy":
                    colorString = "#FF1B9DDE";
                    break;
                case "Plantagenet":
                    colorString = "#FFF59700";
                    break;
                case "Tudor":
                    colorString = "#FFD4DF32";
                    break;
                case "Lancaster":
                    colorString = "#FF339933";
                    break;
                case "Stuart":
                    colorString = "#FF00ABA9";
                    break;
                case "Hanover":
                    colorString = "#FFDC5B20";
                    break;
                case "Windsor":
                    colorString = "#FFE8BC34";
                    break;
                default:
                    if (parameter != null && parameter is Brush)
                    {
                        return parameter;
                    }
                    colorString = "#FF999999";
                    break;
            }
            SolidColorBrush brush;

#if WPF
            brush = new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString(colorString));
#else
            brush = new SolidColorBrush(Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString(colorString));
#endif

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
