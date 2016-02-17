using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Calendar;
using System.Windows.Data;
#if !SILVERLIGHT
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
using DataTemplateSelector = System.Windows.Controls.DataTemplateSelector;
#endif

namespace Telerik.Windows.Examples.Calendar.FirstLook
{
    public partial class Example : System.Windows.Controls.UserControl
	{
        private ViewModel ViewModel
        {
            get
            {
                return this.DataContext as ViewModel;
            }
        }

        public Example()
        {
            InitializeComponent();

            this.DataContext = new ViewModel();
            
            calendar.SelectedDate = DateTime.Today;
        }

        private void calendar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as RadCalendar;

            if (calendar.SelectedDates.Count > 0)
            {
                this.ViewModel.FilterByDate(calendar.SelectedDates);
                this.EmptyContent.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                this.ViewModel.FilteredEventsCollection.Clear();
                this.EmptyContent.Visibility = System.Windows.Visibility.Visible;
            }
        }
	}
}
