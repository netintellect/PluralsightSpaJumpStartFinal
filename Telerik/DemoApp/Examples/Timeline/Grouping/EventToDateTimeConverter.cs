using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.Grouping
{
    /// <summary>
    /// Converts <see cref="WorldWar2Event"/> to a <see cref="string"/>.
    /// </summary>
#if WPF
    [ValueConversion(typeof(WorldWar2Event), typeof(string))]
#endif
    public class EventToDateTimeConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is WorldWar2Event)
            {
                WorldWar2Event warEvent = value as WorldWar2Event;

                string dateInfo = warEvent.StartDate.ToString("MMMM dd, yyyy");

                if (warEvent.Duration > TimeSpan.Zero)
                {
                    dateInfo = string.Format("{0} - {1}", dateInfo, warEvent.EndDate.ToString("MMMM dd, yyyy"));
                }

                return dateInfo;
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
