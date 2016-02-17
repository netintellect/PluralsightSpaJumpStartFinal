using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Media;
using Examples.Map.CS;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Map.Theatre
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private const string ShapeRelativeUriFormat = "/Map;component/Resources/Theatre/{0}";
        private const int TheatreSeatCount = 481;

        private Uri _theatreSeatsSourceUri;
        private Uri _theatreSeatsDataSourceUri;
        private Uri _theatreAisleLabelsSourceUri;
        private IEnumerable<MapLegendData> _legendData;
        private QueryableCollectionView _data;
        private bool _isBuyButtonEnabled = false; 

        public ExampleViewModel()
        {
            this.TheatreSeatsSourceUri = new Uri(string.Format(ShapeRelativeUriFormat, "theatre_seats_pol.shp"), UriKind.Relative);
            this.TheatreSeatsDataSourceUri = new Uri(string.Format(ShapeRelativeUriFormat, "theatre_seats_pol.dbf"), UriKind.Relative);
            this.TheatreAisleLabelsSourceUri = new Uri(string.Format(ShapeRelativeUriFormat, "theatre_aisle_labels.shp"), UriKind.Relative);

            this.GetData("seating_plan.csv");
            this.BuildLegendData();
        }

        public Uri TheatreSeatsSourceUri
        {
            get
            {
                return this._theatreSeatsSourceUri;
            }
            set
            {
                if (this._theatreSeatsSourceUri != value)
                {
                    this._theatreSeatsSourceUri = value;
                    this.OnPropertyChanged("TheatreSeatsSourceUri");
                }
            }
        }

        public Uri TheatreSeatsDataSourceUri
        {
            get
            {
                return this._theatreSeatsDataSourceUri;
            }
            set
            {
                if (this._theatreSeatsDataSourceUri != value)
                {
                    this._theatreSeatsDataSourceUri = value;
                    this.OnPropertyChanged("TheatreSeatsDataSourceUri");
                }
            }
        }

        public Uri TheatreAisleLabelsSourceUri
        {
            get
            {
                return this._theatreAisleLabelsSourceUri;
            }
            set
            {
                if (this._theatreAisleLabelsSourceUri != value)
                {
                    this._theatreAisleLabelsSourceUri = value;
                    this.OnPropertyChanged("TheatreAisleLabelsSourceUri");
                }
            }
        }

        public QueryableCollectionView Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                    OnPropertyChanged("Data");
                }
            }
        }

        public IEnumerable<MapLegendData> LegendData
        {
            get
            {
                return _legendData;
            }
            set
            {
                if (this._legendData != value)
                {
                    this._legendData = value;
                    OnPropertyChanged("LegendData");
                }
            }
        }

        public bool IsBuyButtonEnabled 
        {
            get
            {
                return this._isBuyButtonEnabled;
            }
            set
            {
                if (this._isBuyButtonEnabled != value)
                {
                    this._isBuyButtonEnabled = value;
                    OnPropertyChanged("IsBuyButtonEnabled");
                }
            }
        }

        public TheatreSeatInfo GetSeatInfo(int seatId)
        {
            IQueryable<TheatreSeatInfo> queryable = this.Data.QueryableSourceCollection.Where(this.Data.FilterDescriptors).OfType<TheatreSeatInfo>();
            
            return queryable.Where(info => info.ID == seatId).FirstOrDefault();
        }

        public SeatAvailability GetSeatAvailability(int seatId)
        {
            TheatreSeatInfo seatInfo = this.GetSeatInfo(seatId);
            if (seatInfo != null)
                return seatInfo.Status;

            return SeatAvailability.NotAvailable;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            List<TheatreSeatInfo> data = new List<TheatreSeatInfo>();
            string line;

            while ((line = dataReader.ReadLine()) != null)
            {
                string[] lineData = line.Split(',');
                int id = int.Parse(lineData[0], CultureInfo.InvariantCulture);
                string position = lineData[1];
                string row = lineData[2];
                int number = int.Parse(lineData[3], CultureInfo.InvariantCulture);
                double price = double.Parse(lineData[4], CultureInfo.InvariantCulture);
                SeatAvailability status = (SeatAvailability)Enum.Parse(typeof(SeatAvailability), lineData[5], true);

                TheatreSeatInfo seatInfo = new TheatreSeatInfo(id, position, row, number, price, status);

                data.Add(seatInfo);
            }

            return data;
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = new QueryableCollectionView(data);
        }

        private void BuildLegendData()
        {
            List<MapLegendData> legendItems = new List<MapLegendData>();
            legendItems.Add(new MapLegendData("Reserved", ColorizationHelper.ReservedBrush));
            legendItems.Add(new MapLegendData("Sold", ColorizationHelper.SoldBrush));
            legendItems.Add(new MapLegendData("Selected", new SolidColorBrush(Colors.Transparent), new SolidColorBrush(Colors.Black)));
            legendItems.Add(new MapLegendData("Not in the category", ColorizationHelper.NotAvailableBrush));

            this.LegendData = legendItems;
        }
    }
}
