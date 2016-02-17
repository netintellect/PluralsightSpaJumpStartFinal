using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.DesktopAlert.Customization
{
    public class ViewModel : ViewModelBase, IDataErrorInfo
    {
        private ObservableCollection<Shipment> shipments;
        private ObservableCollection<int> items;
        private ObservableCollection<CityDetails> cities;
        private ObservableCollection<DeliveryType> trasnportTypes;

        private CityDetails selectedCityFrom;
        private CityDetails selectedCityTo;
        private DeliveryType selectedTransport;
        private string numOfItems;
        private static int id = 1;
        private bool isDateValid;
        private bool isAddressValid;
        private bool isNumOfItemsValid;
        private bool isShipmentSending;

        private DateTime? selectedDate;

        public ViewModel()
        {
            this.Shipments = new ObservableCollection<Shipment>();

            this.SubmitDelivery = new DelegateCommand(OnSubmitDeliveryExecuted, OnSubmitDeliveryCanExecute);
            this.AlertClosedCommand = new DelegateCommand(OnAlertClosedCommandExecute);
            this.NumOfItems = "1";
            this.SelectedDate = DateTime.Now.Date;
            this.isShipmentSending = false;

            this.SelectedCityFrom = this.Cities[0];
            this.SelectedCityTo = this.Cities[1];
        }

        public Action<Shipment> ActivateDesktopAlertAction { get; set; }
        public DelegateCommand SubmitDelivery { get; set; }
        public DelegateCommand AlertClosedCommand { get; set; }

        public ObservableCollection<Shipment> Shipments
        {
            get
            {
                return this.shipments;
            }
            set
            {
                this.shipments = value;
            }
        }

        public ObservableCollection<int> Items
        {
            get
            {
                if(this.items == null)
                {
                    this.items = new ObservableCollection<int>();

                    for (int i = 1; i <= 10; i++)
                    {
                        this.items.Add(i);
                    }
                }

                return items;
            }
        }

        public ObservableCollection<CityDetails> Cities
        {
            get
            {
                if (this.cities == null)
                {
                    this.cities = new ObservableCollection<CityDetails>()
                    {
                        new CityDetails() { Country = "England", CityName = "London" },
                        new CityDetails() { Country = "England", CityName = "Liverpool" },
                        new CityDetails() { Country = "England", CityName  ="Manchester" },
                        new CityDetails() { Country = "Spain", CityName  ="Madrid" },
                        new CityDetails() { Country = "Spain", CityName  ="Barcelona" },
                        new CityDetails() { Country = "France", CityName  ="Paris" },
                        new CityDetails() { Country = "Italy", CityName  ="Rome" },
                        new CityDetails() { Country = "Germany", CityName  ="Berlin" }
                    };
                }

                return this.cities;
            }
        }

        public ObservableCollection<DeliveryType> TransportTypes
        {
            get
            {
                if(this.trasnportTypes == null)
                {
                    this.trasnportTypes = new ObservableCollection<DeliveryType>()
                    {
                        DeliveryType.Truck,
                        DeliveryType.Train,
                        DeliveryType.Ship
                    };
                }

                return this.trasnportTypes;
            }
        }

        public DeliveryType SelectedTransport
        {
            get
            {
                return this.selectedTransport;
            }
            set
            {
                if(this.selectedTransport != value)
                {
                    this.selectedTransport = value;
                    this.OnPropertyChanged(() => this.SelectedTransport);
                }
            }
        }

        public DateTime? SelectedDate
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
                    this.OnPropertyChanged(() => this.SelectedDate);
                }
            }
        }

        public CityDetails SelectedCityFrom
        {
            get
            {
                return this.selectedCityFrom;
            }
            set
            {
                if (this.selectedCityFrom != value)
                {
                    this.selectedCityFrom = value;
                    this.OnPropertyChanged(() => this.SelectedCityTo);
                    this.OnPropertyChanged(() => this.SelectedCityFrom);
                }
            }
        }

        public CityDetails SelectedCityTo
        {
            get
            {
                return this.selectedCityTo;
            }
            set
            {
                if (this.selectedCityTo != value)
                {

                    this.selectedCityTo = value;
                    this.OnPropertyChanged(() => this.SelectedCityFrom);
                    this.OnPropertyChanged(() => this.SelectedCityTo);
                }
            }
        }

        public string NumOfItems
        {
            get
            {
                return this.numOfItems;
            }
            set
            {
                if(this.numOfItems != value)
                {
                    this.numOfItems = value;
                    this.OnPropertyChanged(() => this.NumOfItems);
                }
            }
        }

        public bool IsShipmentSending
        {
            get
            {
                return this.isShipmentSending;
            }
            set
            {
                if (this.isShipmentSending != value)
                {
                    this.isShipmentSending = value;
                    this.OnPropertyChanged(() => this.IsShipmentSending);
                }
            }
        }

        public string Error
        {
            get
            {
                return this.ValidateAddress() ?? this.ValidateSelectedDate() ?? this.ValidateNumOfItems();
            }
        }

       
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "SelectedCityFrom":
                    case "SelectedCityTo":
                        var validationAddressRes = this.ValidateAddress();
                        this.SubmitDelivery.InvalidateCanExecute();
                        return validationAddressRes;
                    case "SelectedDate":
                        var validationDateRes = this.ValidateSelectedDate();
                        this.SubmitDelivery.InvalidateCanExecute();
                        return validationDateRes;
                    case "NumOfItems":
                        var validateNumOfItems = this.ValidateNumOfItems();
                        this.SubmitDelivery.InvalidateCanExecute();
                        return validateNumOfItems;
                }

                this.SubmitDelivery.InvalidateCanExecute();
                return null;
            }
        }

        private bool OnSubmitDeliveryCanExecute(object obj)
        {
            if (this.isAddressValid && this.isDateValid && this.isNumOfItemsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnSubmitDeliveryExecuted(object obj)
        {
            this.IsShipmentSending = true;
            var newShipment = new Shipment() { ID = id, CityFrom = this.SelectedCityFrom, CityTo = this.SelectedCityTo, DateOfArrival = (DateTime)this.SelectedDate, 
                NumberOfItems = int.Parse(this.NumOfItems), DeliveryType = this.SelectedTransport};

            this.Shipments.Add(newShipment);

            if (this.ActivateDesktopAlertAction != null)
            {
                this.ActivateDesktopAlertAction.Invoke(newShipment);
            }
        }

        private void OnAlertClosedCommandExecute(object obj)
        {
            this.SelectedCityFrom = this.Cities[0];
            this.SelectedCityTo = this.Cities[1];
            this.SelectedDate = DateTime.Now.Date;
            this.SelectedTransport = this.TransportTypes[0];
            this.NumOfItems = "1";
            id++;

            this.IsShipmentSending = false;
        }

        private string ValidateSelectedDate()
        {
            if(this.SelectedDate < DateTime.Now.Date)
            {
                this.isDateValid = false;
                return "Select a date that is not in the past!";
            }
            else
            {
                if(this.SelectedDate == null)
                {
                    this.isDateValid = false;
                    return "Please, select a date.";
                }
            }

            this.isDateValid = true;
            return null;
        }

        private string ValidateAddress()
        {
            if(this.SelectedCityFrom == null || this.SelectedCityTo == null)
            {
                this.isAddressValid = false;
                return "Please, select a city!";
            }
            else
            {
                if(this.SelectedCityFrom != null)
                {
                    if(this.SelectedCityFrom.Equals(this.SelectedCityTo))
                    {
                        this.isAddressValid = false;
                        return "Please, select a different city!";
                    }
                }

                if(this.SelectedCityTo != null)
                {
                    if (this.SelectedCityTo.Equals(this.SelectedCityFrom))
                    {
                        this.isAddressValid = false;
                        return "Please, select a different city!";
                    }
                }
            }

            this.isAddressValid = true;
            return null;
        }

        private string ValidateNumOfItems()
        {
            int itemsCount = 0;

            if(this.NumOfItems != null)
            {
                if (!int.TryParse(this.NumOfItems.ToString(), out itemsCount))
                {
                    this.isNumOfItemsValid = false;
                    return "The number " + this.NumOfItems.ToString() + " is too big! The maximum number of items is 1 000 000!";
                }
                else
                {
                    if (itemsCount > 1000000)
                    {
                        this.isNumOfItemsValid = false;
                        return "The number " + this.NumOfItems.ToString() + " is too big! The maximum number of items is 1 000 000!";
                    }
                }
            }
            else
            {
                this.isNumOfItemsValid = false;
                return "Please enter the number of items you need to send.";
            }

            this.isNumOfItemsValid = true;
            return null;
        }
    }
}
