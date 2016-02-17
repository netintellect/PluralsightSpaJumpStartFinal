using System.Collections.ObjectModel;
using System.Globalization;

namespace Telerik.Windows.Examples.ChartView.Gallery.Bubble
{
    public class MoviesViewModel : DataSourceViewModelBase
    {
        private ObservableCollection<LegendItemInfo> legendItems;
        public ObservableCollection<LegendItemInfo> LegendItems
        {
            get { return this.legendItems; }
            set 
            {
                if (this.legendItems != value)
                {
                    this.legendItems = value;
                    this.OnPropertyChanged("LegendItems");
                }
            }
        }

        private ObservableCollection<MovieInfo> movies;
        public ObservableCollection<MovieInfo> Movies
        {
            get { return movies; }
            set 
            {
                if (this.movies != value)
                {
                    this.movies = value;
                    this.OnPropertyChanged("Movies");
                }                
            }
        }

        public MoviesViewModel()
        {
            this.GetData("MoviesData.csv");
            this.LegendItems = new ObservableCollection<LegendItemInfo>();
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {         
            this.Movies = data as ObservableCollection<MovieInfo>;
        }

        protected override System.Collections.IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;
            ObservableCollection<MovieInfo> chartData = new ObservableCollection<MovieInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                MovieInfo dataItem = new MovieInfo();
                dataItem.Title = data[0];
                dataItem.Budget = decimal.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.ScreeningsCount = int.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.Profit = decimal.Parse(data[3], CultureInfo.InvariantCulture);
                dataItem.DirectorName = data[4];
                dataItem.Duration = int.Parse(data[5], CultureInfo.InvariantCulture);
                dataItem.Rating = double.Parse(data[6], CultureInfo.InvariantCulture);
                dataItem.ImagePath = "../../Images/ChartView/Gallery/Bubble/" + data[7];

                chartData.Add(dataItem);
            }

            return chartData;
        }
    }
}
