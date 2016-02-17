using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public class NameToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
#if WPF
            string path = "/TimeBar;component/Images/TimeBar/SpecialSlots/";
#else
            string path = "../../Images/TimeBar/SpecialSlots/";
#endif

            return String.Format("{0}{1}.jpg", path, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}