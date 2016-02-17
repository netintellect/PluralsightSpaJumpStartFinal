using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
	public class FriendlyExampleNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value != null)
			{
				string name = value.ToString();
				int lastSeparatorIndex = name.LastIndexOf(@"\");
				bool isCodeBehind = name.EndsWith(".xaml.cs") || name.EndsWith(".xaml.vb");
				string friendlyName = (isCodeBehind ? "     " : "") + name.Substring(lastSeparatorIndex + 1);
				return friendlyName;
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
