using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public enum StoreType
    {
        Area,
        Market,
        Store
    }

    public class StoreLocation
    {
        private double _latitude;
        private double _longitude;
        private string _storeName;
        private StoreType _storeType;

        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                _longitude = value;
            }
        }

        public string StoreName
        {
            get
            {
                return _storeName;
            }
            set
            {
                _storeName = value;
            }
        }

        public StoreType StoreType
        {
            get
            {
                return _storeType;
            }
            set
            {
                _storeType = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the StoreLocation class.
        /// </summary>
        public StoreLocation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StoreLocation class.
        /// </summary>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        /// <param name="storeName">Store name.</param>
        /// <param name="storeType">Store type.</param>
        public StoreLocation(double latitude, double longitude, string storeName, StoreType storeType)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.StoreName = storeName;
            this.StoreType = storeType;
        }
    }
}
