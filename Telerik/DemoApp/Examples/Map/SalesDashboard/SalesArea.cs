using System.Collections.Generic;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public class SalesArea : StoreLocation
    {
        private List<StoreData> _stores;
        private List<Location> _area;
        private string _stroke;
        private string _fill;

        public List<StoreData> Stores
        {
            get
            {
                return _stores;
            }
            set
            {
                _stores = value;
            }
        }

        public List<Location> Area
        {
            get
            {
                return _area;
            }
            set
            {
                _area = value;
            }
        }

        public string Stroke
        {
            get
            {
                return _stroke;
            }
            set
            {
                _stroke = value;
            }
        }

        public string Fill
        {
            get
            {
                return _fill;
            }
            set
            {
                _fill = value;
            }
        }

        public SalesArea()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StoreLocation class.
        /// </summary>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        /// <param name="storeName">Store name.</param>
        public SalesArea(double latitude, double longitude, string storeName) :
            base(latitude, longitude, storeName, StoreType.Area)
        {
        }
    }
}
