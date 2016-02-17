using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public class ExampleViewModel : ViewModelBase
    {
        private List<Ticket> departureTickets;
        private List<Ticket> returnTickets;
        private int selectedSearchRange;
        private int departureLowestPrice;
        private int returnLowestPrice;
        private DateTime departureDate;
        private DateTime actualDepartureDate;
        private DateTime returnDate;
        private DateTime actualReturnDate;
        private SelectionRange<DateTime> departureDateVisiblePeriod;
        private SelectionRange<DateTime> returnDateVisiblePeriod;
        private SelectionRange<DateTime> departureDateSearchRange;
        private SelectionRange<DateTime> returnDateSearchRange;
        private Airport departureCity;
        private Airport arrivalCity;
        private List<Ticket> allTickets = new List<Ticket>();
        private List<Airport> departureCities;
        private List<Airport> arrivalCities;
        private List<Airport> airports;
        FlightPath flightPath;

        private bool timeBarUpdatesSuspended = false;

        private ICommand searchFlightsCommand;

        public event EventHandler<EventArgs> InformationLayerItemsSourceChanged;
        public event EventHandler<EventArgs> InvalidRangeSelected;

        public ExampleViewModel()
        {
            DateTime start = new DateTime(2013, 1, 1, 0, 0, 0);
            DateTime end = new DateTime(2014, 1, 1, 0, 0, 0);
            Random rand = new Random((int)DateTime.Now.Ticks);

            this.airports = new List<Airport>()
            {
                new Airport("Sofia", new Location(42.698397,23.318174)),
                new Airport("Paris", new Location(48.86324843747856, 2.343200000000003)),
                new Airport("Rome", new Location(41.89363932192129, 12.500399999999999)),
                new Airport("Bern", new Location(46.96525, 7.42675)),
                new Airport("London", new Location(51.51916693151067, -0.1022499999999904)),
                new Airport("Vienna", new Location(48.2125716583318, 16.3686)),
                new Airport("Madrid", new Location(40.418791766421336, -3.7057499999999965))
            };

            for (DateTime i = start; i < end; i += TimeSpan.FromDays(1))
            {
                foreach (var fromAirport in this.airports)
                {
                    foreach (var toAirport in this.airports)
                    {
                        if (fromAirport == toAirport)
                            continue;

                        this.allTickets.Add(new Ticket(i, GenerateTicketPriceDay(i, rand), fromAirport, toAirport));
                    }
                }
            }

            this.ReturnDate = new DateTime(2013, 7, 24);
            this.ActualReturnDate = new DateTime(2013, 7, 24);
            this.DepartureDate = new DateTime(2013, 7, 16);
            this.ActualDepartureDate = new DateTime(2013, 7, 16);

            this.DepartureCity = this.airports[0];
            this.ArrivalCity = this.airports[2];

            this.SelectedSearchRange = 5;

            this.SearchFlights();
        }

        public List<Ticket> DepartureTickets
        {
            get
            {
                return this.departureTickets;
            }
            set
            {
                if (this.departureTickets != value)
                {
                    this.departureTickets = value;
                    this.OnPropertyChanged("DepartureTickets");
                }
            }
        }

        public List<Ticket> ReturnTickets
        {
            get
            {
                return this.returnTickets;
            }
            set
            {
                if (this.returnTickets != value)
                {
                    this.returnTickets = value;
                    this.OnPropertyChanged("ReturnTickets");
                }
            }
        }

        public int DepartureLowestPrice
        {
            get
            {
                return this.departureLowestPrice;
            }
            set
            {
                if (this.departureLowestPrice != value)
                {
                    this.departureLowestPrice = value;
                    this.OnPropertyChanged("DepartureLowestPrice");
                }
            }
        }

        public int ReturnLowestPrice
        {
            get
            {
                return this.returnLowestPrice;
            }
            set
            {
                if (this.returnLowestPrice != value)
                {
                    this.returnLowestPrice = value;
                    this.OnPropertyChanged("ReturnLowestPrice");
                }
            }
        }

        public DateTime DepartureDate
        {
            get
            {
                return this.departureDate;
            }
            set
            {
                if (this.departureDate != value)
                {
                    this.departureDate = value;
                    this.OnPropertyChanged("DepartureDate");
                }
            }
        }

        public DateTime ActualDepartureDate
        {
            get
            {
                return this.actualDepartureDate;
            }
            set
            {
                if (this.actualDepartureDate != value)
                {
                    this.actualDepartureDate = value;
                    this.OnPropertyChanged("ActualDepartureDate");
                }
            }
        }

        public DateTime ReturnDate
        {
            get
            {
                return this.returnDate;
            }
            set
            {
                if (this.returnDate != value)
                {
                    this.returnDate = value;
                    this.OnPropertyChanged("ReturnDate");
                }
            }
        }

        public DateTime ActualReturnDate
        {
            get
            {
                return this.actualReturnDate;
            }
            set
            {
                if (this.actualReturnDate != value)
                {
                    this.actualReturnDate = value;
                    this.OnPropertyChanged("ActualReturnDate");
                }
            }
        }

        public List<int> SearchRange
        {
            get
            {
                return new List<int> { 1, 3, 5, 7 };
            }
        }

        public int SelectedSearchRange
        {
            get
            {
                return this.selectedSearchRange;
            }
            set
            {
                if (this.selectedSearchRange != value)
                {
                    this.selectedSearchRange = value;
                    this.OnPropertyChanged("SelectedSearchRange");
                }
            }
        }

        public TimeSpan MinSelectionRange
        {
            get
            {
                return TimeSpan.FromDays(this.SelectedSearchRange);
            }
        }

        public TimeSpan MaxSelectionRange
        {
            get
            {
                return TimeSpan.FromDays(this.SelectedSearchRange);
            }
        }

        public SelectionRange<DateTime> DepartureDateVisiblePeriod
        {
            get
            {
                return this.departureDateVisiblePeriod;
            }
            set
            {
                if (this.departureDateVisiblePeriod != value)
                {
                    this.departureDateVisiblePeriod = value;
                    this.OnPropertyChanged("DepartureDateVisiblePeriod");
                }
            }
        }

        public SelectionRange<DateTime> DepartureDateSearchRange
        {
            get
            {
                return this.departureDateSearchRange;
            }
            set
            {
                if (this.departureDateSearchRange != value)
                {
                    this.departureDateSearchRange = value;
                    this.OnPropertyChanged("DepartureDateSearchRange");

                    if (!this.timeBarUpdatesSuspended)
                    {
                        this.UpdateSearchRange(value);
                        this.UpdateDepartureCity();
                        this.UpdateReturnCity();
                        this.RevertReturnDate();

                        if (this.ValidateSelectedRange())
                        {
                            this.UpdateDepartureDate();
                        }
                    }
                }
            }
        }

        public SelectionRange<DateTime> ReturnDateVisiblePeriod
        {
            get
            {
                return this.returnDateVisiblePeriod;
            }
            set
            {
                if (this.returnDateVisiblePeriod != value)
                {
                    this.returnDateVisiblePeriod = value;
                    this.OnPropertyChanged("ReturnDateVisiblePeriod");
                }
            }
        }

        public SelectionRange<DateTime> ReturnDateSearchRange
        {
            get
            {
                return this.returnDateSearchRange;
            }
            set
            {
                if (this.returnDateSearchRange != value)
                {
                    this.returnDateSearchRange = value;
                    this.OnPropertyChanged("ReturnDateSearchRange");

                    if (!this.timeBarUpdatesSuspended)
                    {
                        this.UpdateSearchRange(value);
                        this.UpdateDepartureCity();
                        this.UpdateReturnCity();
                        this.RevertDepartureDate();

                        if (this.ValidateSelectedRange())
                        {
                            this.UpdateReturnDate();
                        }
                    }
                }
            }
        }

        public Airport DepartureCity
        {
            get
            {
                return this.departureCity;
            }
            set
            {
                if (this.departureCity != value)
                {
                    this.departureCity = value;
                    this.OnPropertyChanged("DepartureCity");

                    this.ArrivalCities = this.airports.Where(item => item != this.departureCity).ToList();
                }
            }
        }

        public Airport ArrivalCity
        {
            get
            {
                return this.arrivalCity;
            }
            set
            {
                if (this.arrivalCity != value)
                {
                    this.arrivalCity = value;
                    this.OnPropertyChanged("ArrivalCity");

                    this.DepartureCities = this.airports.Where(item => item != this.arrivalCity).ToList();
                }
            }
        }

        public List<Airport> DepartureCities
        {
            get
            {
                return this.departureCities;
            }
            set
            {
                if (this.departureCities != value)
                {
                    this.departureCities = value;
                    this.OnPropertyChanged("DepartureCities");
                }
            }
        }

        public List<Airport> ArrivalCities
        {
            get
            {
                return this.arrivalCities;
            }
            set
            {
                if (this.arrivalCities != value)
                {
                    this.arrivalCities = value;
                    this.OnPropertyChanged("ArrivalCities");
                }
            }
        }

        public FlightPath FlightPath
        {
            get
            {
                return this.flightPath;
            }
            set
            {
                if (this.flightPath != value)
                {
                    flightPath = value;
                    this.OnPropertyChanged("FlightPath");
                }
            }
        }

        public ICommand SearchFlightsCommand
        {
            get
            {
                if (this.searchFlightsCommand == null)
                    this.searchFlightsCommand = new DelegateCommand(this.SearchFlights);

                return this.searchFlightsCommand;
            }
            set
            {
                this.searchFlightsCommand = value;
            }
        }

        public void CorrectInvalidRange()
        {
            this.UpdateSearchRange(this.DepartureDateSearchRange);

            this.CorrectDepartureDateSearchRange();
            this.CorrectReturnDateSearchRange();

            this.CorrectDepartureDate();
            this.CorrectReturnDate();

            this.UpdateDepartureCity();
            this.UpdateReturnCity();
        }

        private void CorrectDepartureDateSearchRange()
        {
            var selectedRangeOffset = Math.Max(0, SelectedSearchRange / 2);

            if (this.DepartureDateSearchRange.Start != this.ActualDepartureDate.AddDays(-selectedRangeOffset))
            {
                DateTime searchRangeStart = this.ActualDepartureDate.AddDays(-selectedRangeOffset);
                DateTime searchRangeEnd = this.ActualDepartureDate.AddDays(selectedRangeOffset + 1);

                this.DepartureDateSearchRange = new SelectionRange<DateTime>(searchRangeStart, searchRangeEnd);

                if (searchRangeEnd > this.DepartureDateVisiblePeriod.End)
                {
                    this.DepartureDateVisiblePeriod = new SelectionRange<DateTime>(searchRangeEnd.AddDays(-31), searchRangeEnd);
                }
                else if (searchRangeStart < this.DepartureDateVisiblePeriod.Start)
                {
                    this.DepartureDateVisiblePeriod = new SelectionRange<DateTime>(searchRangeStart, searchRangeStart.AddDays(31));
                }
            }
        }

        private void CorrectReturnDateSearchRange()
        {
            var selectedRangeOffset = Math.Max(0, SelectedSearchRange / 2);

            if (this.ReturnDateSearchRange.Start != this.ActualReturnDate.AddDays(-selectedRangeOffset))
            {
                DateTime searchRangeStart = this.ActualReturnDate.AddDays(-selectedRangeOffset);
                DateTime searchRangeEnd = this.ActualReturnDate.AddDays(selectedRangeOffset + 1);

                this.ReturnDateSearchRange = new SelectionRange<DateTime>(searchRangeStart, searchRangeEnd);

                if (searchRangeEnd > this.ReturnDateVisiblePeriod.End)
                {
                    this.ReturnDateVisiblePeriod = new SelectionRange<DateTime>(searchRangeEnd.AddDays(-31), searchRangeEnd);
                }
                else if (searchRangeStart < this.ReturnDateSearchRange.Start)
                {
                    this.ReturnDateVisiblePeriod = new SelectionRange<DateTime>(searchRangeStart, searchRangeStart.AddDays(31));
                }
            }
        }

        private void CorrectDepartureDate()
        {
            if (this.DepartureDate != this.ActualDepartureDate)
            {
                this.DepartureDate = this.ActualDepartureDate;
            }
        }

        private void CorrectReturnDate()
        {
            if (this.ReturnDate != this.ActualReturnDate)
            {
                this.ReturnDate = this.ActualReturnDate;
            }
        }

        private void UpdateLowestPrices()
        {
            if (this.DepartureTickets != null && this.ReturnTickets != null)
            {
                var selectedDepartureTickets = this.DepartureTickets.Where(item => this.DepartureDateSearchRange.Start <= item.Date && item.Date < this.DepartureDateSearchRange.End);
                var selectedReturnTickets = this.ReturnTickets.Where(item => this.ReturnDateSearchRange.Start <= item.Date && item.Date < this.ReturnDateSearchRange.End);

                if (selectedDepartureTickets.Count() > 0 && selectedReturnTickets.Count() > 0)
                {
                    this.DepartureLowestPrice = selectedDepartureTickets.Min(item => item.Price);
                    this.ReturnLowestPrice = selectedReturnTickets.Min(item => item.Price);
                }
            }
        }

        private void UpdateCitiesInformation()
        {
            if (this.DepartureCity != null &&
                this.ArrivalCity != null &&
                this.ArrivalCity != this.DepartureCity)
            {
                var departureTicket = this.DepartureTickets == null ? null : this.DepartureTickets.FirstOrDefault();

                if (departureTicket == null || departureTicket.From != this.departureCity || departureTicket.To != this.arrivalCity)
                {
                    this.DepartureTickets = this.allTickets.Where(item => item.From == this.departureCity && item.To == this.arrivalCity).ToList();
                    this.ReturnTickets = this.allTickets.Where(item => item.From == this.arrivalCity && item.To == this.departureCity).ToList();

                    this.FlightPath = new FlightPath(this.DepartureCity, this.ArrivalCity);

                    this.OnInformationLayerItemsSourceChanged();
                }
            }
        }

        private int GenerateTicketPriceDay(DateTime time, Random rand)
        {
            int price = 0;

            if (DayOfWeek.Thursday <= time.DayOfWeek || time.DayOfWeek <= DayOfWeek.Monday)
            {
                price = rand.Next(500, 1000);
            }
            else
            {
                price = rand.Next(200, 400);
            }

            return price;
        }

        private void SearchFlights(object parameter)
        {
            this.SearchFlights();
        }

        private void SearchFlights()
        {
            if (this.ValidateSelectedDates())
            {
                this.timeBarUpdatesSuspended = true;

                this.ActualDepartureDate = this.DepartureDate;
                this.ActualReturnDate = this.ReturnDate;

                var selectedRangeOffset = Math.Max(0, SelectedSearchRange / 2);

                this.OnPropertyChanged("MinSelectionRange");
                this.OnPropertyChanged("MaxSelectionRange");

                this.DepartureDateSearchRange = new SelectionRange<DateTime>(this.DepartureDate.AddDays(-selectedRangeOffset), this.DepartureDate.AddDays(selectedRangeOffset + 1));
                this.DepartureDateVisiblePeriod = new SelectionRange<DateTime>(this.DepartureDate.AddDays(-15), this.DepartureDate.AddDays(16));

                this.ReturnDateSearchRange = new SelectionRange<DateTime>(this.ReturnDate.AddDays(-selectedRangeOffset), this.ReturnDate.AddDays(selectedRangeOffset + 1));
                this.ReturnDateVisiblePeriod = new SelectionRange<DateTime>(this.ReturnDate.AddDays(-15), this.ReturnDate.AddDays(16));

                this.UpdateCitiesInformation();
                this.UpdateLowestPrices();

                this.timeBarUpdatesSuspended = false;
            }
        }

        private void UpdateSearchRange(SelectionRange<DateTime> range)
        {
            this.SelectedSearchRange = (range.End - range.Start).Days;
        }

        private void RevertDepartureDate()
        {
            this.DepartureDate = this.ActualDepartureDate;
        }

        private void UpdateDepartureDate()
        {
            this.DepartureDate = this.DepartureDateSearchRange.Start.AddDays(this.SelectedSearchRange / 2);
            this.ActualDepartureDate = this.DepartureDate;
            this.UpdateLowestPrices();
        }

        private void RevertReturnDate()
        {
            this.ReturnDate = this.ActualReturnDate;
        }

        private void UpdateReturnDate()
        {
            this.ReturnDate = this.ReturnDateSearchRange.Start.AddDays(this.SelectedSearchRange / 2);
            this.ActualReturnDate = this.ReturnDate;
            this.UpdateLowestPrices();
        }

        private void UpdateDepartureCity()
        {
            if (this.DepartureTickets != null && this.DepartureTickets.Count > 0)
                this.DepartureCity = this.DepartureTickets.FirstOrDefault().From;
        }

        private void UpdateReturnCity()
        {
            if (this.ReturnTickets != null && this.ReturnTickets.Count > 0)
                this.ArrivalCity = this.ReturnTickets.FirstOrDefault().From;
        }

        private bool ValidateSelectedRange()
        {
            if (this.DepartureDateSearchRange.Start > this.ReturnDateSearchRange.Start)
            {
                this.OnInvalidRangeSelected();
                return false;
            }

            return true;
        }

        private bool ValidateSelectedDates()
        {
            if (this.DepartureDate > this.ReturnDate)
            {
                this.OnInvalidRangeSelected();
                return false;
            }

            return true;
        }

        private void OnInformationLayerItemsSourceChanged()
        {
            if (this.InformationLayerItemsSourceChanged != null)
            {
                this.InformationLayerItemsSourceChanged(this, EventArgs.Empty);
            }
        }

        private void OnInvalidRangeSelected()
        {
            if (this.InvalidRangeSelected != null)
            {
                this.InvalidRangeSelected(this, EventArgs.Empty);
            }
        }
    }
}
