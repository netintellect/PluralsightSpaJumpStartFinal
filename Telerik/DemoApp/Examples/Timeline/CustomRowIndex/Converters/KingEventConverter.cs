using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class KingEventConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            King king = new King();
            if (value.GetType() == typeof(King))
            {
                king = (King)value;
            }
            else
            {
                king = ((KingEvent)value).Ruler;
            }
            if (parameter != null)
	        {
                Type kingType = typeof(King);
                return kingType.GetProperty(parameter.ToString()).GetValue(king, null);
            }

            return king;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
