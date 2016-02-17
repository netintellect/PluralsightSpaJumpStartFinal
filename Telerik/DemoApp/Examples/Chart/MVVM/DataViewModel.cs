using System.ComponentModel;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Chart.MVVM
{
    public class DataViewModel : INotifyPropertyChanged
    {
        private Data _data;
        private Brush _populationColor;

        public DataViewModel(Data data)
        {
            this._data = data;
            data.PropertyChanged += HandleDataPropertyChanged;

            this.UpdatePopulationColor();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Data Data
        {
            get
            {
                return _data;
            }
        }

        public Brush PopulationColor
        {
            get
            {
                return _populationColor;
            }
            private set
            {
                if (object.Equals(this._populationColor, value))
                    return;

                this._populationColor = value;
                this.OnPropertyChanged("PopulationColor");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private Brush CreateBrush(string color)
        {
            return new SolidColorBrush(this.GetColorFromHexString(color));
        }

        private Color GetColorFromHexString(string s)
        {
            s = s.Replace("#", string.Empty);

            byte a = System.Convert.ToByte(s.Substring(0, 2), 16);
            byte r = System.Convert.ToByte(s.Substring(2, 2), 16);
            byte g = System.Convert.ToByte(s.Substring(4, 2), 16);
            byte b = System.Convert.ToByte(s.Substring(6, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }

        private void HandleDataPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Population")
                this.UpdatePopulationColor();
        }

        private void UpdatePopulationColor()
        {
            if (this.Data.EU < 0)
                this.PopulationColor = this.CreateBrush("#FFE61E26");
            else
                this.PopulationColor = this.CreateBrush("#FF8EBC00");
        }
    }
}
