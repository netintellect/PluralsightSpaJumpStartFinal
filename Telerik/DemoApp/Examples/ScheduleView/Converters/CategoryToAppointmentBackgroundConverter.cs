using System;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView
{
	public class CategoryToAppointmentBackgroundConverter : IValueConverter
	{
		private ImageBrush oceanBrush;
		private ImageBrush harmonyBrush;
		private ImageBrush discoBrush;
		private ImageBrush orangeBrush;
		private ImageBrush relaxBrush;

		public ImageBrush OceanBrush
		{
			get
			{
				return this.oceanBrush;
			}
			set
			{
				this.oceanBrush = value;
			}
		}

		public ImageBrush HarmonyBrush
		{
			get
			{
				return this.harmonyBrush;
			}
			set
			{
				this.harmonyBrush = value;
			}
		}

		public ImageBrush DiscoBrush
		{
			get
			{
				return this.discoBrush;
			}
			set
			{
				this.discoBrush = value;
			}
		}

		public ImageBrush OrangeBrush
		{
			get
			{
				return this.orangeBrush;
			}
			set
			{
				this.orangeBrush = value;
			}
		}

		public ImageBrush RelaxBrush
		{
			get
			{
				return this.relaxBrush;
			}
			set
			{
				this.relaxBrush = value;
			}
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value != null && value is Category)
			{
				switch ((value as Category).CategoryName)
				{
					case "Ocean": return this.OceanBrush;
					case "Orange": return this.OrangeBrush;
					case "Relax": return this.RelaxBrush;
					case "Disco": return this.DiscoBrush;
					case "Harmony": return this.HarmonyBrush;
					default: return this.HarmonyBrush;
				}
			}
			return this.HarmonyBrush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}