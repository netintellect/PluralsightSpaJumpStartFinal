using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Calendar.DatePicker
{
	public class ViewModel : ViewModelBase
	{
		private DateTime selectedDate;
		private CollectionViewSource cources;
		private CourcesCollection collection;

		public ViewModel()
		{
			this.selectedDate = DateTime.Today;
			this.collection = new CourcesCollection();

			this.cources = new CollectionViewSource();
			this.cources.Source = collection;
			this.cources.Filter += this.EventsFilter;
		}

		public CollectionViewSource Cources
		{
			get { return cources; }
		}

		public ObservableCollection<string> Names
		{
			get
			{
				return new ObservableCollection<string>(this.collection.Select(c => c.Name).Distinct());
			}
		}

		public DateTime SelectedDate
		{
			get
			{
				return this.selectedDate;
			}
			set
			{
				if (this.selectedDate != value)
				{
					this.selectedDate = value;
					this.cources.View.Refresh();

					this.OnPropertyChanged(() => this.SelectedDate);
				}
			}
		}

		private void EventsFilter(object sender, FilterEventArgs e)
		{
			var cource = e.Item as Course;
			e.Accepted = cource != null && cource.Date.DayOfWeek == this.selectedDate.DayOfWeek;
		}
	}
}
