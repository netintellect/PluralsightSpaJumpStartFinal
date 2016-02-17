using System.Windows.Input;
using System;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Map.Shapefile;

namespace Telerik.Windows.Examples.Map.DrillDown
{
    public class ExampleViewModel : ShapefileViewModel
    {
        private string _county;
        private Uri _countyShapefileDataSourceUri;
        private Uri _countyShapefileSourceUri;
        private Location _mapCenter;
        private int _mapZoomLevel;
        private ICommand _resetMapViewCommand;
        private bool _zoomEnabled;

        public ExampleViewModel()
        : base()
        {
            this._zoomEnabled = true;
            ResetMapView(null);
        }

        public string County
        {
            get
            {
                return _county;
            }
            set
            {
                if (this._county == value)
                    return;

                _county = value;
                this.LoadCountyData();
                OnPropertyChanged("County");
            }
        }

        public Uri CountyShapefileDataSourceUri
        {
            get
            {
                return _countyShapefileDataSourceUri;
            }
            set
            {
                if (this._countyShapefileDataSourceUri == value)
                    return;

                _countyShapefileDataSourceUri = value;
                OnPropertyChanged("CountyShapefileDataSourceUri");
            }
        }

        public Uri CountyShapefileSourceUri
        {
            get
            {
                return _countyShapefileSourceUri;
            }
            set
            {
                if (this._countyShapefileSourceUri == value)
                    return;

                _countyShapefileSourceUri = value;
                OnPropertyChanged("CountyShapefileSourceUri");
            }
        }

        public Location MapCenter
        {
            get
            {
                return _mapCenter;
            }
            set
            {
                if (this._mapCenter == value)
                    return;

                _mapCenter = value;
                OnPropertyChanged("MapCenter");
            }
        }

        public int MapZoomLevel
        {
            get
            {
                return _mapZoomLevel;
            }
            set
            {
                if (this._mapZoomLevel == value)
                    return;

                _mapZoomLevel = value;
                OnPropertyChanged("MapZoomLevel");
            }
        }

        public ICommand ResetMapViewCommand
        {
            get
            {
                if (this._resetMapViewCommand == null)
                {
                    this._resetMapViewCommand = new DelegateCommand(this.ResetMapView);
                }

                return this._resetMapViewCommand;
            }
        }

        public bool ZoomEnabled
        {
            get
            {
                return _zoomEnabled;
            }
            set
            {
                if (this._zoomEnabled == value)
                    return;

                _zoomEnabled = value;
                OnPropertyChanged("ZoomEnabled");

                if (!value)
                    ResetMapView(null);
            }
        }

        private void LoadCountyData()
        {
            string filename = System.IO.Path.Combine("USA", this.County.Replace(" ", "_"));

            this.CountyShapefileSourceUri = new Uri(string.Format(ShapeRelativeUriFormat, filename, ShapeExtension), UriKind.Relative);
            this.CountyShapefileDataSourceUri = new Uri(string.Format(ShapeRelativeUriFormat, filename, DbfExtension), UriKind.Relative);
        }

        private void ResetMapView(object parameter)
        {
            this.MapZoomLevel = 4;
            this.MapCenter = new Location(36.8174363084084d, -97.3212482126264d);
        }
    }
}

