using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.Financial
{
    public class ExampleViewModel : ViewModelBase
    {
        private string _SeriesType = "Candlestick";
        public string SeriesType
        {
            get
            {
                return this._SeriesType;
            }
            set
            {
                if (this._SeriesType != value)
                {
                    this._SeriesType = value;
                    this.OnPropertyChanged("SeriesType");
                }
            }
        }
    }
}
