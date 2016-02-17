using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.InverseAxis.Converters
{
    public class ResourceTypeToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double opacity = 1;
			if (parameter != null)
			{
				Double.TryParse(parameter.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out opacity);
			}

			SolidColorBrush brush;
            string resourceType = (string)value;
            switch (resourceType)
			{
				case "Dry holes":
					brush = ChartPalettes.Windows8.GlobalEntries[0].Fill as SolidColorBrush;
					break;
				case "Natural gas":
					brush = ChartPalettes.Windows8.GlobalEntries[1].Fill as SolidColorBrush;
					break;
				case "Crude oil":
					brush = ChartPalettes.Windows8.GlobalEntries[2].Fill as SolidColorBrush;
					break;
                default:
                    return null;
            }

			if (brush != null)
			{
				return new SolidColorBrush() { Color = brush.Color, Opacity = opacity};
			}

			return brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
