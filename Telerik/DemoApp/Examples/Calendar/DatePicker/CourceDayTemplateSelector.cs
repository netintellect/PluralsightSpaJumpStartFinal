using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Calendar;

namespace Telerik.Windows.Examples.Calendar.DatePicker
{
	public class CourceDayTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			CalendarButtonContent content = item as CalendarButtonContent;

			foreach (Course cource in this.CourcesCollection.Where(c => c.Date.DayOfWeek == content.Date.DayOfWeek))
			{
				return this.CourceTemplate;
			}

			return DefaultTemplate;
		}

		private CourcesCollection courcesCollection;
		public CourcesCollection CourcesCollection
		{
			get
			{
				if (this.courcesCollection == null)
				{
					this.courcesCollection = new CourcesCollection();
				}
				return this.courcesCollection;
			}
		}

		private DataTemplate defaultTemplate;
		public DataTemplate DefaultTemplate
		{
			get
			{
				return this.defaultTemplate;
			}
			set
			{
				this.defaultTemplate = value;
			}
		}

		private DataTemplate courceTemplate;
		public DataTemplate CourceTemplate
		{
			get
			{
				return this.courceTemplate;
			}
			set
			{
				this.courceTemplate = value;
			}
		}
	}
}
