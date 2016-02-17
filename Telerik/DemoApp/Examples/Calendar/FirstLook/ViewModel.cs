using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Calendar.FirstLook
{
    public class ViewModel : ViewModelBase
    {
        private ObservableCollection<Event> eventsCollection;
        public ObservableCollection<Event> EventsCollection
        {
            get
            {
                return this.eventsCollection;
            }
            set
            {
                this.eventsCollection = value;
                OnPropertyChanged(() => this.EventsCollection);
            }
        }

        private ObservableCollection<Event> filteredEventsCollection;
        public ObservableCollection<Event> FilteredEventsCollection
        {
            get
            {
                return this.filteredEventsCollection;
            }
            set
            {
                this.filteredEventsCollection = value;
                this.NotifyCollectionChanged();
            }
        }

        public ViewModel()
        {
            this.eventsCollection = this.GetCollection();
        }

        public void FilterByDate(IList<DateTime> dates)
        {
            if (this.filteredEventsCollection == null)
            {
                this.filteredEventsCollection = new ObservableCollection<Event>();
            }
            else
            {
                this.filteredEventsCollection.Clear();
            }

            foreach (var date in dates)
            {
                foreach (var evnt in eventsCollection.Where(e => e.Date == date))
                {
                    this.filteredEventsCollection.Add(evnt);
                }
            }

            this.NotifyCollectionChanged();
        }

        private void NotifyCollectionChanged()
        {
            OnPropertyChanged(() => this.FilteredEventsCollection);
        }

        private ObservableCollection<Event> GetCollection()
        {
            var collection = new ObservableCollection<Event>();

            collection.Add(new Event { Day = 2, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 2, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Texas, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });
            collection.Add(new Event { Day = 2, Title = "Integrating WPF and WCF", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Wildermuth; Start Time - 1.00 PM" });

            collection.Add(new Event { Day = 3, Title = "What's new in WCF 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Grace Becerra; Start Time - 10.00 AM" });
            collection.Add(new Event { Day = 3, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 3, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 4, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Grace Becerra; Start Time - 10.00 AM" });
            collection.Add(new Event { Day = 4, Title = "What's new in WCF 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 4, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 5, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 5, Title = "Multimedia in Silverlight 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Jeremy Boatner; Start Time - 2.00 PM" });
            collection.Add(new Event { Day = 5, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 8, Title = "Integrating WPF and WCF", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 8, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Texas, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });
            collection.Add(new Event { Day = 8, Title = "Multimedia in Silverlight 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Wildermuth; Start Time - 1.00 PM" });

            collection.Add(new Event { Day = 11, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Grace Becerra; Start Time - 10.00 AM" });
            collection.Add(new Event { Day = 11, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });

            collection.Add(new Event { Day = 14, Title = "Integrating WPF and WCF", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Grace Becerra; Start Time - 10.00 AM" });
            collection.Add(new Event { Day = 14, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 14, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 15, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 15, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Texas, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 17, Title = "What's new in WCF 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Grace Becerra; Start Time - 10.00 AM" });
            collection.Add(new Event { Day = 17, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 17, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 24, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Grace Becerra; Start Time - 10.00 AM" });
            collection.Add(new Event { Day = 24, Title = "What's new in WCF 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 24, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 25, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 25, Title = "Multimedia in Silverlight 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Jeremy Boatner; Start Time - 2.00 PM" });
            collection.Add(new Event { Day = 25, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });

            collection.Add(new Event { Day = 27, Title = "Integrating WPF and WCF", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });
            collection.Add(new Event { Day = 27, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Texas, USA", Description = "Speaker: Tom Black; Start Time - 4.00 PM" });
            collection.Add(new Event { Day = 27, Title = "Multimedia in Silverlight 4", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Wildermuth; Start Time - 1.00 PM" });

            collection.Add(new Event { Day = 28, Title = "The Future Of Web Development", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Grace Becerra; Start Time - 10.00 AM" });
            collection.Add(new Event { Day = 28, Title = "Blend For Silverlight Developers", Company = "Telerik Inc - Boston, USA", Description = "Speaker: Tom Black; Start Time - 11.15 AM" });

            return collection;
        }
    }
}
