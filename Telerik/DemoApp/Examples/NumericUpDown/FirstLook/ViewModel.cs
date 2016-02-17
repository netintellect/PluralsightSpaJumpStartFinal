using System.ComponentModel;
using System;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.NumericUpDown.FirstLook
{
    public class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            this.EURAmount = 1;
        }

        private double usdAmount;
        private double eurAmount;

        public double USDAmount
        {
            get
            {
                return this.usdAmount;
            }
            set
            {
                if (this.usdAmount != value)
                {
                    this.usdAmount = value;
                    this.OnPropertyChanged("USDAmount");
                    this.eurAmount = this.USDAmount * 0.719;
                    this.OnPropertyChanged("EURAmount");

                }
            }
        }

        public double EURAmount
        {
            get
            {
                return this.eurAmount;
            }
            set
            {
                if (this.eurAmount != value)
                {
                    this.eurAmount = value;
                    this.OnPropertyChanged("EURAmount");
                    this.usdAmount = this.EURAmount * 1.388;
                    this.OnPropertyChanged("USDAmount");
                }
            }
        }
    }
}