using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Windows.Examples.TreeListView.IsExpanded
{
    public class WarehouseItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isExpanded;
        private string name;
        private int count;

        public WarehouseItem(string name, int count, bool isExpanded = true)
        {
            this.Name = name;
            this.Count = count;
            this.IsExpanded = isExpanded;
            this.Items = new ObservableCollection<WarehouseItem>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }
            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }
            }
        }

        [Display(AutoGenerateField = false)]
        public ObservableCollection<WarehouseItem> Items { get; set; }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                if (value != this.count)
                {
                    this.count = value;
                    this.OnPropertyChanged("Count");
                }
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}