using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	public class GroupItemStyleSelector : ScheduleViewStyleSelector
	{
		private Style groupItemStyle;
		private Style defaultStyle;
		private Style timeRulerLineStyle;

		public Style GroupItemStyle
		{
			get
			{
				return this.groupItemStyle;
			}
			set
			{
				this.groupItemStyle = value;
			}
		}
		public Style DefaultStyle
		{
			get
			{
				return this.defaultStyle;
			}
			set
			{
				this.defaultStyle = value;
			}
		}
		public Style TimeRulerLineStyle
		{
			get
			{
				return this.timeRulerLineStyle;
			}
			set
			{
				this.timeRulerLineStyle = value;
			}
		}

		public override Style SelectStyle(object item, DependencyObject container, ViewDefinitionBase activeViewDefinition)
		{
			if (container is TimeRulerGroupItem)
			{
				return this.GroupItemStyle;
			}
			else if (container is TimeRulerLine)
			{
				return this.TimeRulerLineStyle;
			}
			return this.DefaultStyle;
		}
	}
}