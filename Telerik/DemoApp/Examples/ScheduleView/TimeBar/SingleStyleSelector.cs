using System.Windows;
using System.Windows.Markup;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	[ContentProperty("DefaultStyle")]
	public class SingleStyleSelector : ScheduleViewStyleSelector
	{
		private Style defaultStyle;
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

		public override Style SelectStyle(object item, DependencyObject container, ViewDefinitionBase activeViewDefinition)
		{
			return this.DefaultStyle;
		}
	}
}
