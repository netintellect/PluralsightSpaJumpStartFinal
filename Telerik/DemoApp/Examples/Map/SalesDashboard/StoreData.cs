using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public class StoreData : StoreLocation
    {
        private decimal _salesTotal;
        public decimal SalesTotal
        {
            get
            {
                return _salesTotal;
            }
            set
            {
                _salesTotal = value;
            }
        }

        private decimal _salesTarget;
        public decimal SalesTarget
        {
            get
            {
                return _salesTarget;
            }
            set
            {
                _salesTarget = value;
            }
        }

        private int _managers;
        public int Managers
        {
            get
            {
                return _managers;
            }
            set
            {
                _managers = value;
            }
        }

        public StoreData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StoreLocation class.
        /// </summary>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        /// <param name="storeName">Store name.</param>
        /// <param name="salesTotal">Sales total.</param>
        /// <param name="managers">Managers count.</param>
        public StoreData(double latitude, double longitude, string storeName, decimal salesTotal, decimal salesTarget, int managers) :
            base(latitude, longitude, storeName, StoreType.Store)
        {
            this.SalesTotal = salesTotal;
            this.SalesTarget = salesTarget;
            this.Managers = managers;
        }
    }
}
