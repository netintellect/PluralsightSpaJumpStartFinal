using System.ComponentModel;

namespace Telerik.Windows.Examples.Chart.Integration.ChartContextMenuIntegration
{
    public class ChartDataItem : INotifyPropertyChanged
    {
        private double _amount;
        private string _cashFlow;
        private MenuItemsCollection menuItems;

        public event PropertyChangedEventHandler PropertyChanged;

        public ChartDataItem(double amount, string cashFlow)
        {
            this._amount = amount;
            this._cashFlow = cashFlow;
        }

        public double Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if (this._amount != value)
                {
                    this._amount = value;
                    this.OnPropertyChanged("Amount");
                }
            }
        }

        public string CashFlow
        {
            get
            {
                return this._cashFlow;
            }
            set
            {
                if (this._cashFlow != value)
                {
                    this._cashFlow = value;
                    this.OnPropertyChanged("CashFlow");
                }
            }
        }

        public MenuItemsCollection MenuItems
        {
            get
            {
                if (this.menuItems == null)
                {
                    this.menuItems = new MenuItemsCollection();
                }

                return this.menuItems;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (null != this.PropertyChanged)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
