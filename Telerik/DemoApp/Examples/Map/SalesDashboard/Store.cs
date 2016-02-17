using System;
using System.Windows;
using Telerik.Windows.Controls.Map;
#if SILVERLIGHT
using Telerik.Windows.Examples.Map.DataService;
#endif

namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public class Store : ISalesData
    {
        private Area area;
#if SILVERLIGHT
        private RadMapDataServiceStoreData store;
#else 
        private StoreData store;
#endif
        public string Name
        {
            get
            {
                return this.store.StoreName;
            }
        }

        public Area Area
        {
            get
            {
                return this.area;
            }
        }

        public decimal Total
        {
            get
            {
                return this.store.SalesTotal;
            }
        }

        public int Managers
        {
            get
            {
                return this.store.Managers;
            }
        }

        public decimal Target
        {
            get
            {
                return this.store.SalesTarget;
            }
        }

        public decimal Avg
        {
            get
            {
                return Math.Round(this.Total / this.Managers);
            }
        }

        public decimal Diversion
        {
            get
            {
                return Math.Round((this.Total / this.Target)*100-100, 2);
            }
        }

        public int StoresNumber
        {
            get
            {
                return 1;
            }
        }

        public Location Center
        {
            get
            {
                return new Location(this.store.Latitude, this.store.Longitude);
            }
        }

#if SILVERLIGHT
        public Store(RadMapDataServiceStoreData storeData, Area areaData)     
#else
        public Store(StoreData storeData, Area areaData)
#endif
        {
            this.store = storeData;
            this.area = areaData;
        }
    }
}
