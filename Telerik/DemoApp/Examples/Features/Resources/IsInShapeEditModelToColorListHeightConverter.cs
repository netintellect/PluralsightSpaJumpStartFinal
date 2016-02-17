using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Telerik.Windows.Diagrams.Features
{
	public class IsInShapeEditModelToColorListHeightConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
			{
				return 175;
			}
			return 150;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
