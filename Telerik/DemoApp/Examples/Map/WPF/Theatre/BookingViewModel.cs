using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Telerik.Windows.Controls;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Map.Theatre
{
    public class BookingViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _email;
        private DateTime? _cardExpirationDate;
        private string _performanceTitle;
        private TheatreSeatInfoCollection _selectedSeats;
        private string _cardHolderName;
        private string _cardNumber;
        private bool _isFormSubmitted = false;
        private bool _isBuyOptionSelected = true;
        private bool _isReserveOptionSelected = false;

        public BookingViewModel()
            : this("", new TheatreSeatInfoCollection())
        {
        }

        public BookingViewModel(string title, TheatreSeatInfoCollection seats)
        {
            this.PerformanceTitle = title;
            this.SelectedSeats = seats;

            this.Email = "john.smith@gmail.com";
            this.CardholderName = "John Smith";
            this.CardNumber = "1234567891011";
            this.CardExpirationDate = DateTime.Today.AddYears(1);
        }

        public string PerformanceTitle
        {
            get
            {
                return this._performanceTitle;
            }
            set
            {
                if (this._performanceTitle != value)
                {
                    this._performanceTitle = value;
                    this.OnPropertyChanged("PerformanceTitle");
                }
            }
        }

        public bool IsBuyOptionSelected
        {
            get
            {
                return this._isBuyOptionSelected;
            }
            set
            {
                if (this._isBuyOptionSelected != value)
                {
                    this._isBuyOptionSelected = value;
                    this.OnPropertyChanged("IsBuyOptionSelected");
                }
            }
        }

        public bool IsReserveOptionSelected
        {
            get
            {
                return this._isReserveOptionSelected;
            }
            set
            {
                if (this._isReserveOptionSelected != value)
                {
                    this._isReserveOptionSelected = value;
                    this.OnPropertyChanged("IsReserveOptionSelected");
                }
            }
        }

        public TheatreSeatInfoCollection SelectedSeats
        {
            get
            {
                return this._selectedSeats;
            }
            set
            {
                if (this._selectedSeats != value)
                {
                    this._selectedSeats = value;
                    this.OnPropertyChanged("SelectedSeats");
                }
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (this._email != value)
                {
                    this._email = value;
                    this.OnPropertyChanged("Email");
                }
            }
        }

        public string CardholderName
        {
            get
            {
                return this._cardHolderName;
            }
            set
            {
                if (this._cardHolderName != value)
                {
                    this._cardHolderName = value;
                    this.OnPropertyChanged("CardholderName");
                }
            }
        }

        public string CardNumber
        {
            get
            {
                return this._cardNumber;
            }
            set
            {
                if (this._cardNumber != value)
                {
                    this._cardNumber = value;
                    this.OnPropertyChanged("CardNumber");
                }
            }
        }

        public DateTime? CardExpirationDate
        {
            get
            {
                return this._cardExpirationDate;
            }
            set
            {
                if (this._cardExpirationDate != value)
                {
                    this._cardExpirationDate = value;
                    this.OnPropertyChanged("CardExpirationDate");
                }
            }
        }

        public bool IsFormSubmitted
        {
            get
            {
                return this._isFormSubmitted;
            }
            set
            {
                this._isFormSubmitted = value;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string propertyName]
        {
            get
            {

                switch (propertyName)
                {
                    case "Email":
                        if (!Regex.IsMatch(this.Email, @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-z]{2,4}\b"))
                            return "Please enter valid email address";
                        break;
                    case "CardholderName":
                        if (string.IsNullOrEmpty(this.CardholderName))
                            return "Please enter valid cardholder's name";
                        break;
                    case "CardNumber":
                        if (string.IsNullOrEmpty(this.CardNumber))
                            return "Please enter valid card number (13-16 digits)";
                        break;
                    case "CardExpirationDate":
                        if (this.CardExpirationDate < DateTime.Today || this.CardExpirationDate > DateTime.Today.AddYears(5))
                            return string.Format("Please enter valid expiration date prior to {0:MM/dd/yyyy}", DateTime.Today.AddYears(5));
                        break;
                    default:
                        break;
                }

                return null;
            }
        }
    }
}
