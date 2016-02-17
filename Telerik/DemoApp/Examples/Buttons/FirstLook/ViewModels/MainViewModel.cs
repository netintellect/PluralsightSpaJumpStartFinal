using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Buttons.FirstLook.Common;

namespace Telerik.Windows.Examples.Buttons.FirstLook.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool isNextStepEnabled;
        public bool IsNextStepEnabled
        {
            get { return this.isNextStepEnabled; }
            set
            {
                if (this.isNextStepEnabled != value)
                {
                    this.isNextStepEnabled = value;
                    OnPropertyChanged("IsNextStepEnabled");
                }
            }
        }
        
        private byte currentStep = 1;
        public byte CurrentStep
        {
            get
            {
                return this.currentStep;
            }
            set
            {
                if (this.currentStep != value)
                {
                    this.currentStep = value;
                    OnPropertyChanged("CurrentStep");
                }
            }
        }

        private ObservableCollection<Passenger> passengers;
        public ObservableCollection<Passenger> Passengers
        {
            get
            {
                return this.passengers;
            }
            set
            {
                this.passengers = value;
                this.OnPropertyChanged("Passengers");
            }
        }

        public FlightViewModel FlightFormModel { get; set; }
        public PassengersViewModel PassengersFormModel {get ;set; }
        public SeatsViewModel SeatsFormModel { get; set; }
        public ICommand NextStepCommand { get; set; }
        public ICommand PreviosStepCommand { get; set; }        

        public MainViewModel()
        {
            this.Passengers = new ObservableCollection<Passenger>();
            this.FlightFormModel = new FlightViewModel();
            this.PassengersFormModel = new PassengersViewModel();
            this.SeatsFormModel = new SeatsViewModel();
            this.NextStepCommand = new DelegateCommand(_ => this.CurrentStep++);
            this.PreviosStepCommand = new DelegateCommand(_ => this.CurrentStep--);

            this.FlightFormModel.CloseDropDownButtonCommand = new DelegateCommand(OnDropDownSelectionChanged);
            this.PassengersFormModel.CloseDropDownButtonCommand = new DelegateCommand(OnDropDownSelectionChanged);

            this.Passengers.CollectionChanged += Passengers_CollectionChanged;
        }

        void Passengers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.Passengers.Count == 0)
            {
                this.IsNextStepEnabled = false;
            }
            else
            {
                this.IsNextStepEnabled = true;
            }
        }

        private void OnDropDownSelectionChanged(object obj)
        {
            if (obj == null)
            {
                return;
            }
            if (this.FlightFormModel.FromList.Contains(obj.ToString()))
            {
                this.FlightFormModel.IsFromDropDownOpen = false;
                this.FlightFormModel.FromDropDownButtonContent = obj.ToString();
                return;
            }
            if (this.FlightFormModel.ToList.Contains(obj.ToString()))
            {
                this.FlightFormModel.IsToDropDownOpen = false;
                this.FlightFormModel.ToDropDownButtonContent = obj.ToString();
                return;
            }
            if (this.FlightFormModel.AdultList.Contains(obj.ToString()))
            {
                this.FlightFormModel.IsAdultsDropDownOpen = false;
                this.FlightFormModel.AdultsDropDownButtonContent = obj.ToString();
                ClearPassenger(PassengerType.Adult);
                AddPassenger(PassengerType.Adult, this.GetCountFromString(obj.ToString()));
                return;
            }
            if (this.FlightFormModel.ChildList.Contains(obj.ToString()))
            {
                this.FlightFormModel.IsKidDropDownOpen = false;
                this.FlightFormModel.KidDropDownButtonContent = obj.ToString();
                ClearPassenger(PassengerType.Kid);
                AddPassenger(PassengerType.Kid, this.GetCountFromString(obj.ToString()));
                return;
            }
            if (this.FlightFormModel.InfantsList.Contains(obj.ToString()))
            {
                this.FlightFormModel.IsInfantDropDownOpen = false;
                this.FlightFormModel.InfantDropDownButtonContent = obj.ToString();
                ClearPassenger(PassengerType.Infant);
                AddPassenger(PassengerType.Infant, this.GetCountFromString(obj.ToString()));
                return;
            }
            if (this.FlightFormModel.ClassesList.Contains(obj.ToString()))
            {
                this.FlightFormModel.IsBusinessClassDropDownOpen = false;
                this.FlightFormModel.BusinessClassDropDownButtonContent = obj.ToString();
                return;
            }
            if (this.PassengersFormModel.Meals.Contains(obj.ToString()))
            {
                this.PassengersFormModel.IsMealDropDownOpen = false;
                this.PassengersFormModel.MealDropDownButtonContent = obj.ToString();
                return;
            }
            if (this.PassengersFormModel.Languages.Contains(obj.ToString()))
            {
                this.PassengersFormModel.IsLanguageDropDownOpen = false;
                this.PassengersFormModel.LanguageDropDownButtonContent = obj.ToString();
                return;
            }
        }

        private int GetCountFromString(string p)
        {
            return int.Parse(p.Split(' ').FirstOrDefault());
        }

        private void AddPassenger(PassengerType type, int count)
        {
            if (count == 0)
            {
                ClearPassenger(type);
                return;
            }

            for (int i = 0; i < count; i++)
            {
                this.Passengers.Add(new Passenger(type, i + 1));
                this.SeatsFormModel.RemainingSeats++;
            }
        }

        private void ClearPassenger(PassengerType passengerType)
        {
            var passengerCollection = this.Passengers;
            if (passengerCollection != null && passengerCollection.Count != 0)
            {
                List<Passenger> passengersToDelete = new List<Passenger>();
                foreach (Passenger passenger in passengerCollection)
                {
                    if (passenger.PassengerType.Equals(passengerType))
                    {
                        passengersToDelete.Add(passenger);
                    }
                }
                foreach (Passenger passanger in passengersToDelete)
                {
                    passengerCollection.Remove(passanger);
                    this.SeatsFormModel.RemainingSeats--;
                }
            }
        }

        private string ValidateFlightForm()
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(FlightFormModel.FromDropDownButtonContent))
            {
                errors.Append("Please fill in destination to leave from!");
            }
            if (string.IsNullOrEmpty(FlightFormModel.ToDropDownButtonContent))
            {
                errors.Append("Please fill in destination to travel to!");
            }
            if (string.IsNullOrEmpty(FlightFormModel.AdultsDropDownButtonContent) || 
                string.IsNullOrEmpty(FlightFormModel.KidDropDownButtonContent) || 
                string.IsNullOrEmpty(FlightFormModel.InfantDropDownButtonContent) || 
                passengers.Count == 0)
            {
                errors.Append("At least one passenger should travel!");
            }
            if (string.IsNullOrEmpty(FlightFormModel.BusinessClassDropDownButtonContent))
            {
                errors.Append("Please select the ticket class!");
            }
            return errors.ToString();
        }

        internal void ResetSession()
        {
            this.CurrentStep = 1;
            this.Passengers.Clear();

            this.FlightFormModel.FromDropDownButtonContent = string.Empty;
            this.FlightFormModel.ToDropDownButtonContent = string.Empty;
            this.FlightFormModel.DepartureDate = DateTime.Today;
            this.FlightFormModel.ReturnDate = DateTime.Today.AddDays(7 * 2);
            this.FlightFormModel.AreTicketsTwoWay = true;
            this.FlightFormModel.AdultsDropDownButtonContent = string.Empty;
            this.FlightFormModel.KidDropDownButtonContent = string.Empty;
            this.FlightFormModel.InfantDropDownButtonContent = string.Empty;
            this.FlightFormModel.BusinessClassDropDownButtonContent = string.Empty;

            this.PassengersFormModel.MealDropDownButtonContent = string.Empty;
            this.PassengersFormModel.LanguageDropDownButtonContent = string.Empty;

            this.SeatsFormModel.RemainingSeats = 0;
            this.SeatsFormModel.FirstSectionSeats.Clear();
            this.SeatsFormModel.SecondSectionSeats.Clear();
            this.SeatsFormModel.FirstVipSectionSeats.Clear();
            this.SeatsFormModel.SecondVipSectionSeats.Clear();
            this.SeatsFormModel.LoadSeats();
        }
    }
}