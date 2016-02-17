using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
#if WPF
            string path = "/Timeline;component/Images/Timeline/KingsPictures/";
#else
            string path = "../../Images/Timeline/KingsPictures/";
#endif

            string kingName = "Default";

            if (value != null)
            {
                King king = value as King;

                if (!king.Name.Equals("Aethelbert"))
                {
                    kingName = king.Name;
                }
            }

            return String.Format("{0}{1}.jpg", path, kingName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}