using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.TileView.Common
{
	public class NationalityToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string nationality = (string)value;
			return new Uri(string.Format("../../Images/TileView/Integration/CountryFlags/{0}.png", nationality), UriKind.RelativeOrAbsolute);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
