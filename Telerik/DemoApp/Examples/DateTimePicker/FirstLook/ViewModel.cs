using Telerik.Windows.Controls;
using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.DateTimePicker.FirstLook
{
	public class ViewModel : ViewModelBase, IDataErrorInfo
	{
		private DateTime? checkInDate;
		private DateTime? checkOutDate;

		public DateTime? CheckInDate
		{
			get
			{
				return this.checkInDate;
			}
			set
			{
				if (this.checkInDate != value)
				{
					this.checkInDate = value;
					this.OnPropertyChanged(() => this.CheckInDate);
					this.OnPropertyChanged("CheckInDate");
					this.OnPropertyChanged("CheckOutDate");
				}
			}
		}

		public DateTime? CheckOutDate
		{
			get
			{
				return this.checkOutDate;
			}
			set
			{
				if (this.checkOutDate != value)
				{
					this.checkOutDate = value;
					this.OnPropertyChanged(() => this.CheckOutDate);
					this.OnPropertyChanged("CheckOutDate");
					this.OnPropertyChanged("CheckInDate");
				}
			}
		}

		private string ValidateCheckInDate()
		{
			if (!this.CheckInDate.HasValue)
			{
				return "Check in date can not be empty.";
			}
			else if (DateTime.Now.CompareTo(this.CheckInDate.Value) == 0)
			{
				return "Check in date can not be today.";
			}
			else if (DateTime.Now.CompareTo(this.CheckInDate.Value) == 1)
			{
				return "Check in date can not be in the past.";
			}
			else if (this.CheckOutDate.HasValue && this.CheckOutDate.Value.CompareTo(this.CheckInDate.Value) != 1)
			{
				return "Check in date should be before return sign out.";
			}
			return null;
		}

		private string ValidateCheckOutDate()
		{
			if (!this.CheckOutDate.HasValue)
			{
				return "Check out date can not be empty";
			}
			else if (this.CheckInDate.HasValue && this.CheckOutDate.Value.CompareTo(this.CheckInDate.Value) != 1)
			{
				return "Check out date should be after the sign in date.";
			}
			else if (DateTime.Now.CompareTo(this.CheckOutDate.Value) == 1)
			{
				return "Check out date can not be in the past.";
			}
			return null;
		}

		public string Error
		{
			get
			{
				return ValidateCheckInDate() ?? ValidateCheckOutDate();
			}
		}

		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case "CheckInDate": return this.ValidateCheckInDate();
					case "CheckOutDate": return this.ValidateCheckOutDate();
				}
				return null;
			}
		}

        public ViewModel()
        {
            this.CheckInDate = DateTime.Now.AddHours(1);
            this.CheckOutDate = DateTime.Now.AddHours(3);
        }
	}
}
