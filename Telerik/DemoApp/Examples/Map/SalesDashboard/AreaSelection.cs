using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public class AreaSelection : ViewModelBase
    {
        private const string DefaultSelectedAreaName = "Atlanta";

        private IList<ISalesData> data;
        private Area selectedArea;

        public AreaSelection()
        {
            this.Data = new List<ISalesData>();
        }

        public IList<ISalesData> Data
        {
            get
            {
                if (this.SelectedArea != null)
                {
                    return this.SelectedArea.Stores;
                }

                return this.data;
            }
            private set
            {
                this.data = value;
            }
        }

        public string Name
        {
            get
            {
                if (this.SelectedArea != null)
                {
                    return this.SelectedArea.Name;
                }
                else
                {
                    return DefaultSelectedAreaName;
                }
            }
        }

        public Area SelectedArea
        {
            get
            {
                return this.selectedArea;
            }
            set
            {
                if (this.selectedArea != value)
                {
                    this.selectedArea = value;

                    OnPropertyChanged("SelectedArea");
                    OnPropertyChanged("Data");
                    OnPropertyChanged("Name");
                    OnPropertyChanged("TotalRevenue");
                    OnPropertyChanged("Diversion");
                }
            }
        }

        public decimal TotalRevenue
        {
            get
            {
                if (this.SelectedArea != null)
                {
                    return this.SelectedArea.Total;
                }
                else
                {
                    return this.Data.Sum(s => s.Total);
                }
            }
        }

        public decimal TotalRevenueInThousand
        {
            get
            {  
                    return 1000*(this.TotalRevenue);  
            }
        }

        public decimal Diversion
        {
            get
            {
                if (this.SelectedArea != null)
                {
                    return this.SelectedArea.Diversion;
                }
                else
                {
                    return Math.Round((this.TotalRevenue / this.Data.Sum(s => s.Target)) * 100 - 100, 2);
                }
            }
        }
    }
}
