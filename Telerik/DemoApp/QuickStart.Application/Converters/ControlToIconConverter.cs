using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.QuickStart;

namespace Telerik.Windows.QuickStart
{
	public class ControlToIconConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string controlName = String.Empty;
			if (value is IControlInfo)
			{
				controlName = ((IControlInfo)value).Name;
			}
			else if (value != null)
			{
				controlName = value.ToString();
			}
			if (!String.IsNullOrEmpty(controlName))
			{
				string type = "24x24";
				if (!String.IsNullOrEmpty(parameter.ToString()))
				{
					type = parameter.ToString();
				}
				string iconPath = String.Format("/Application;component/Resources/Icons/{0}/Rad{1}_WPF.png", type, controlName);
				return new Uri(iconPath, UriKind.Relative);
			}
			return null;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
