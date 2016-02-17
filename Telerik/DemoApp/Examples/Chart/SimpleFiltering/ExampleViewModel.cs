using System.Windows.Media;
using Telerik.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.SimpleFiltering
{
    public class ExampleViewModel : ViewModelBase
    {
        private ICommand _changeSeriesVisibilityCommand;
        private SeriesVisibility _seriesEU27Visibility;
        private SeriesVisibility _seriesEuroAreaVisibility;
        private SeriesVisibility _seriesJapanVisibility;
        private SeriesVisibility _seriesUSVisibility;

        public ICommand ChangeSeriesVisibilityCommand
        {
            get
            {
                return this._changeSeriesVisibilityCommand;
            }
            private set
            {
                this._changeSeriesVisibilityCommand = value;
            }
        }

        public Brush ApplicationThemeAwareForeground
        {
            get
            {
                if (StyleManager.ApplicationTheme is Expression_DarkTheme)
                    return new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));

                return new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
        }

        public SeriesVisibility SeriesEU27Visibility
        {
            get
            {
                return this._seriesEU27Visibility;
            }
            set
            {
                if (this._seriesEU27Visibility != value)
                {
                    this._seriesEU27Visibility = value;
                    this.OnPropertyChanged("SeriesEU27Visibility");
                }
            }
        }

        public SeriesVisibility SeriesEuroAreaVisibility
        {
            get
            {
                return this._seriesEuroAreaVisibility;
            }
            set
            {
                if (this._seriesEuroAreaVisibility != value)
                {
                    this._seriesEuroAreaVisibility = value;
                    this.OnPropertyChanged("SeriesEuroAreaVisibility");
                }
            }
        }

        public SeriesVisibility SeriesJapanVisibility
        {
            get
            {
                return this._seriesJapanVisibility;
            }
            set
            {
                if (this._seriesJapanVisibility != value)
                {
                    this._seriesJapanVisibility = value;
                    this.OnPropertyChanged("SeriesJapanVisibility");
                }
            }
        }

        public SeriesVisibility SeriesUSVisibility
        {
            get
            {
                return this._seriesUSVisibility;
            }
            set
            {
                if (this._seriesUSVisibility != value)
                {
                    this._seriesUSVisibility = value;
                    this.OnPropertyChanged("SeriesUSVisibility");
                }
            }
        }

        public ExampleViewModel()
        {
            this.WireCommands();
        }

        public void WireCommands()
        {
            this.ChangeSeriesVisibilityCommand = new DelegateCommand(this.ChangeSeriesVisibility);
        }

        public void ChangeSeriesVisibility(object parameter)
        {
            switch (parameter.ToString())
            {
                case "EU-27":
                    if (this.SeriesEU27Visibility == SeriesVisibility.Collapsed || this.SeriesEU27Visibility == SeriesVisibility.Hidden)
                        this.SeriesEU27Visibility = SeriesVisibility.Visible;
                    else
                        this.SeriesEU27Visibility = SeriesVisibility.Hidden;
                    break;
                case "Euro area":
                    if (this.SeriesEuroAreaVisibility == SeriesVisibility.Collapsed || this.SeriesEuroAreaVisibility == SeriesVisibility.Hidden)
                        this.SeriesEuroAreaVisibility = SeriesVisibility.Visible;
                    else
                        this.SeriesEuroAreaVisibility = SeriesVisibility.Hidden;
                    break;
                case "Japan":
                    if (this.SeriesJapanVisibility == SeriesVisibility.Collapsed || this.SeriesJapanVisibility == SeriesVisibility.Hidden)
                        this.SeriesJapanVisibility = SeriesVisibility.Visible;
                    else
                        this.SeriesJapanVisibility = SeriesVisibility.Hidden;
                    break;
                case "United States":
                    if (this.SeriesUSVisibility == SeriesVisibility.Collapsed || this.SeriesUSVisibility == SeriesVisibility.Hidden)
                        this.SeriesUSVisibility = SeriesVisibility.Visible;
                    else
                        this.SeriesUSVisibility = SeriesVisibility.Hidden;
                    break;
                default:
                    break;
            }
        }
    }
}
