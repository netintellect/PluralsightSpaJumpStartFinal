using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Telerik.Windows.Examples.TileList.FirstLook
{
    public class NASDAQViewModel : INotifyPropertyChanged
    {
        public NASDAQViewModel()
        {
            this.displayValue = 3498;
        }

        private double displayValue;
        public double DisplayValue
        {
            get
            {
                return this.displayValue;
            }
            set
            {
                if (this.displayValue != value)
                {
                    this.displayValue = value;
                    this.OnPropertyChanged("DisplayValue");
                }
            }
        }

        public void UpdateDisplayValue()
        {
            if (this.DisplayValue == 3498)
            {
                this.DisplayValue = 3470;
            }
            else
            {
                this.DisplayValue = (int)3498;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
