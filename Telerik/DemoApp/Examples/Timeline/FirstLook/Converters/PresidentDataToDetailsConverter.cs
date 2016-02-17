using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.FirstLook
{
    /// <summary>
    /// Converts president data to a <seealso cref="string"/>.
    /// </summary>
#if WPF
    [ValueConversion(typeof(PresidentData), typeof(string))]
#endif
    public class PresidentDataToDetailsConverter : IValueConverter
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
                bool isLifeTime = (string)parameter == "LifeTime";

                PresidentData data = value as PresidentData;

                if (data != null)
                {
                    DateTime startDate = isLifeTime ? data.BirthDate : data.PresidentFrom;
                    DateTime endDate = isLifeTime ? data.DeathDate : data.PresidentUntil;

                    string endYearString = endDate.ToString("yyyy");

                    DateTime currentDate = DateTime.Now;
                    if (endDate.Year == currentDate.Year && endDate.Month == currentDate.Month)
                        endYearString = "...";

                    string details = String.Format("{0:yyyy} - {1}", startDate, endYearString);

                    if (isLifeTime)
                        details = String.Format("({0})", details);
                    else
                        details = String.Format("TERM AS PRESIDENT: {0}", details);

                    return details;
                }
            }

            return String.Empty;
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
