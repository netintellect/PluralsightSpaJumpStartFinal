using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Chart.PrintAndExportWithRadDocument
{
    public class MyBusinessObject : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private double unitPrice;

        public MyBusinessObject(int ID, string Name, double UnitPrice)
        {
            this.ID = ID;
            this.Name = Name;
            this.UnitPrice = UnitPrice;
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
