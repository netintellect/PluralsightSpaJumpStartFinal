using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class NameToStripLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Transparent);

            List<string> alternateColorNames = new List<string>(){ "Wessex", "Blois", "York", "Stuart", "Plantagenet", "Saxe-Coburg-Gotha" };
            var name = (string)value;

            if (alternateColorNames.Contains(name))
            {
#if WPF
                brush = new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFEDEDED"));
#else
                brush = new SolidColorBrush(Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#FFEDEDED"));
#endif
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
