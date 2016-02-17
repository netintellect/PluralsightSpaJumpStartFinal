using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Timeline.FirstLook
{
    /// <summary>
    /// Converts political party to a <seealso cref="Color"/>.
    /// </summary>
#if WPF
    [ValueConversion(typeof(string), typeof(Color))]
#endif
    public class PartyToColorConverter : IValueConverter
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
            Color color = Colors.Transparent;

            if (value != null && value is string)
            {
                string party = (string)value;

                switch (party)
                {
                    case "Independent":
                        color = this.ColorFromString("#FFDBDBDB");
                        break;
                    case "Federalist":
                        color = Colors.Black;
                        break;
                    case "Democratic-Republican":
                        color = this.ColorFromString("#FFCC99FF");
                        break;
                    case "Democratic":
                        color = this.ColorFromString("#FF3379EE");
                        break;
                    case "Whig":
                        color = this.ColorFromString("#FFF5CF26");
                        break;
                    case "Republican":
                        color = this.ColorFromString("#FFFF2222");
                        break;
                    default:
                        color = Colors.Transparent;
                        break;
                }
            }

            return color;
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

        private Color ColorFromString(string color)
        {
#if WPF
            return (Color)ColorConverter.ConvertFromString(color);
#else

            int argb = Int32.Parse(color.Replace("#", ""), NumberStyles.HexNumber);

            return Color.FromArgb((byte)((argb & -16777216) >> 0x18),
                            (byte)((argb & 0xff0000) >> 0x10), 
                            (byte)((argb & 0xff00) >> 8), 
                            (byte)(argb & 0xff));
#endif
        }
    }
}
