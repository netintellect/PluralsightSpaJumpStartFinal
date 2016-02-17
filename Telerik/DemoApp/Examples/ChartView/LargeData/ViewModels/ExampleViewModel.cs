using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.LargeData.ViewModels
{
    public class ExampleViewModel : ViewModelBase
    {
        private string example = "Scatter";
        public string Example
        {
            get
            {
                return this.example;
            }
            set
            {
                if (this.example != value)
                {
                    this.example = value;
                    this.OnPropertyChanged("Example");
                }
            }
        }
    }
}
