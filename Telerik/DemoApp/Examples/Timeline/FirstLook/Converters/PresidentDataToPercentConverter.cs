using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.FirstLook
{
    /// <summary>
    /// Converts political party to a <seealso cref="double"/>.
    /// </summary>
#if WPF
    [ValueConversion(typeof(PresidentData), typeof(double))]
#endif
    public class PresidentDataToPercentConverter : IValueConverter
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
            if (parameter != null && parameter is string)
            {
                PresidentData data = value as PresidentData;

                if (data != null)
                {
                    DateTime percentData = (string)parameter == "PresidentFrom" ? data.PresidentFrom : data.PresidentUntil;

                    double min = data.BirthDate.Ticks;
                    double max = data.DeathDate.Ticks;
                    double percentValue = percentData.Ticks;

                    return (percentValue - min) / (max - min);
                }
            }

            return 0d;
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
