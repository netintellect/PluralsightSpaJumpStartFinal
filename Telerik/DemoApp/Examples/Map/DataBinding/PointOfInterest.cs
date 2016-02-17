using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.DataBinding
{
    public class PointOfInterest : ViewModelBase
    {
        private Location _location;
        private ZoomRange _zoomRange = ZoomRange.Empty;
		private double _baseZoomLevel = double.NaN;
        private string _title;
        private string _imageUri;
        private string _description;

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
				this.OnPropertyChanged("Location");
            }
        }

        public ZoomRange ZoomRange
        {
            get
            {
                return _zoomRange;
            }
            set
            {
                _zoomRange = value;
				this.OnPropertyChanged("ZoomRange");
			}
        }

        public double BaseZoomLevel
        {
            get
            {
                return _baseZoomLevel;
            }
            set
            {
                _baseZoomLevel = value;
				this.OnPropertyChanged("BaseZoomLevel");
			}
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
				this.OnPropertyChanged("Title");
			}
        }

        public string ImageUri
        {
            get
            {
                return _imageUri;
            }
            set
            {
                _imageUri = value;
				this.OnPropertyChanged("ImageUri");
			}
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
				this.OnPropertyChanged("Description");
			}
        }
    }
}
