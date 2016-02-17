using System.ComponentModel;

namespace Telerik.Windows.Examples.Chart.CustomTooltips
{
    public class Data : INotifyPropertyChanged
    {
        private string _category;
        private long _volume;

        public Data(long volume, string category)
        {
            this.Volume = volume;
            this.Category = category;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }

        public long Volume
        {
            get
            {
                return this._volume;
            }
            set
            {
                this._volume = value;
                this.OnPropertyChanged("Volume");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
