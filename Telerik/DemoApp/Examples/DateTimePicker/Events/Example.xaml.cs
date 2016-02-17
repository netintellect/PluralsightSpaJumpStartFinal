using System;
using System.Collections;
using System.Linq;
using Telerik.Windows.Controls;

#if !SILVERLIGHT
using System.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.DateTimePicker.Events
{		 	
	public partial class Example
	{
		public Example()
		{
			InitializeComponent();
        }

        private EnumDataSource GetEnumItemsSource(Type enumType)
        {
            EnumDataSource source = new EnumDataSource();
            source.EnumType = enumType;
            return source;
        }

		private object GetFirstOrDefault(IList list)
		{
			return list == null ? null : list.Cast<object>().FirstOrDefault();
		}

		private void LogEvent(string eventName, string message)
		{
            Message item = new Message();
            item.EventName = eventName;
            item.Text = message;

			EventsLog.Items.Add(item);

			EventsLog.ScrollIntoView(item);
		}

		private void dateTimePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.LogEvent("SelectionChanged", string.Format("{0} -> {1}", GetFirstOrDefault(e.RemovedItems) ?? "Null", GetFirstOrDefault(e.AddedItems)));
		}

		private void dateTimePicker_ParseDateTimeValue(object sender, ParseDateTimeEventArgs args)
		{
			this.LogEvent("ParseDateTimeValue", args.IsParsingSuccessful ? "Successfull" : "Unsuccessfull");
		}

		private void dateTimePicker_DropDownOpened(object sender, System.Windows.RoutedEventArgs e)
		{
			this.LogEvent("DropDownOpened", "");
		}

		private void dateTimePicker_DropDownClosed(object sender, System.Windows.RoutedEventArgs e)
		{
			this.LogEvent("DropDownClosed", "");
		}

		public class Message
		{
            private string eventName;

            public string EventName
            {
                get { return eventName; }
                set { eventName = value; }
            }

            private string text;

            public string Text
            {
                get { return text; }
                set { text = value; }
            }          
		}
	}	
}
