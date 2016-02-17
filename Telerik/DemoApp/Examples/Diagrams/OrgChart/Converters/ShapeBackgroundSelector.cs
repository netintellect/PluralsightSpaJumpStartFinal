using System;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls.ColorEditor;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.Converters
{
	public class ShapeBackgroundSelector : IValueConverter
	{
		public Brush ManagementBrush
		{
			get;
			set;
		}

		public Brush DevelopmentBrush
		{
			get;
			set;
		}

		public Brush MarketingBrush
		{
			get;
			set;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Branch branch = (Branch)value;
			switch (branch)
			{
				case Branch.Management:
					return this.ManagementBrush;
				case Branch.Development:
					return this.DevelopmentBrush;
				case Branch.Marketing:
                    return this.MarketingBrush;
				default:
					return null;
			}	
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
