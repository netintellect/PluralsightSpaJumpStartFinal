using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Calendar;

namespace Telerik.Windows.Examples.Calendar.FirstLook
{
    public class EventDayTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CalendarButtonContent content = item as CalendarButtonContent;

            var dates = (container.ParentOfType<RadCalendar>().DataContext as ViewModel).EventsCollection.Select(e => e.Date);

            foreach (var date in dates.Where(d => d.Date == content.Date))
            {
                return this.EventTemplate;
            }

            return DefaultTemplate;
        }

        private DataTemplate _defaultTemplate;
        public DataTemplate DefaultTemplate
        {
            get
            {
                return this._defaultTemplate;
            }
            set
            {
                this._defaultTemplate = value;
            }
        }

        private DataTemplate _eventTemplate;
        public DataTemplate EventTemplate
        {
            get
            {
                return this._eventTemplate;
            }
            set
            {
                this._eventTemplate = value;
            }
        }
    }
}
