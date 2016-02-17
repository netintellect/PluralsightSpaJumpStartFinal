using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Examples.CoverFlow.CS.Silverlight.FirstLook
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public PersonViewModel()
        {
        }

        private string employeeName;
        public string EmployeeName
        {
            get
            {
                return this.employeeName;
            }
            set
            {
                this.employeeName = value;
                this.OnNotifyPropertyChanged("EmployeeName");
            }
        }

        private string image;
        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
                this.OnNotifyPropertyChanged("Image");
            }
        }

		private string city;
		public string City
		{
			get
			{
				return this.city;
			}
			set
			{
				this.city = value;
				this.OnNotifyPropertyChanged("City");
			}
		}

		private string phone;
		public string Phone
		{
			get
			{
				return this.phone;
			}
			set
			{
				this.phone = value;
				this.OnNotifyPropertyChanged("Phone");
			}
		}
        
        protected void OnNotifyPropertyChanged(string propertyName)
        {
            if (null != this.PropertyChanged)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

	public class EmployeesViewModel : ObservableCollection<PersonViewModel>
	{
		public EmployeesViewModel()
		{
		}
	}
}