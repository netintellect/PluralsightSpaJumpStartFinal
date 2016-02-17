using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls;
#if SILVERLIGHT
using Telerik.Windows.Examples.Map.DataService;
#endif

namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public class Area : ViewModelBase, ISalesData
    {
        private decimal areaTotal;
        private decimal areaTarget;
        private int managersCount;
        private LocationCollection areaPoints;
        private SolidColorBrush fill;
        private SolidColorBrush stroke;
        private double strokeThickness;
        private IList<ISalesData> stores = new List<ISalesData>();

#if SILVERLIGHT
        private RadMapDataServiceSalesArea area;
#else 
        private SalesArea area;
#endif

#if SILVERLIGHT
        public Area(RadMapDataServiceSalesArea areaData)
#else
        public Area(SalesArea areaData)
#endif
        {
            this.area = areaData;

            this.InitializeAreaStores(areaData);
            this.InitializeAreaAppearance(areaData);

            this.CalculateTotal();
        }

        public string Name
        {
            get
            {
                return this.area.StoreName;
            }
        }

        public decimal Total
        {
            get
            {
                return this.areaTotal;
            }
        }

        public decimal Target
        {
            get
            {
                return this.areaTarget;
            }
        }

        public int Managers
        {
            get
            {
                return this.managersCount;
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
                return Math.Round((this.Total / this.Target) * 100 - 100, 2);
            }
        }

        public int StoresNumber
        {
            get
            {
                return this.area.Stores.Count();
            }
        }

        public LocationCollection Points
        {
            get
            {
                return this.areaPoints;
            }
        }

        public SolidColorBrush Fill
        {
            get
            {
                return this.fill;
            }

            set
            {
                if (this.fill != value)
                {
                    this.fill = value;
                    this.OnPropertyChanged("Fill");
                }
            }
        }

        public SolidColorBrush Stroke
        {
            get
            {
                return this.stroke;
            }

            set
            {
                if (this.stroke != value)
                {
                    this.stroke = value;
                    this.OnPropertyChanged("Stroke");
                }
            }
        }

        public double StrokeThickness
        {
            get
            {
                return this.strokeThickness;
            }

            set
            {
                if (this.strokeThickness != value)
                {
                    this.strokeThickness = value;
                    this.OnPropertyChanged("StrokeThickness");
                }
            }
        }

        public IList<ISalesData> Stores
        {
            get
            {
                return this.stores;
            }

            set
            {
                if (this.stores != value)
                {
                    this.stores = value;
                    this.OnPropertyChanged("Stores");
                }
            }
        }

        public Location Center
        {
            get
            {
                return new Location(this.area.Latitude, this.area.Longitude);
            }
        }

#if SILVERLIGHT
        private void InitializeAreaAppearance(RadMapDataServiceSalesArea areaData)
#else
        private void InitializeAreaAppearance(SalesArea areaData)
#endif
        {
            this.stroke = GetColor(areaData.Stroke, Colors.LightGray);
            this.strokeThickness = 0;
            this.fill = GetColor(areaData.Fill, Colors.LightGray);
        }

#if SILVERLIGHT
        private void InitializeAreaStores(RadMapDataServiceSalesArea areaData)
#else
        private void InitializeAreaStores(SalesArea areaData)
#endif
        {
            var stores = new List<ISalesData>();

            foreach (var storeData in areaData.Stores)
            {
                stores.Add(new Store(storeData, this));
            }

            this.Stores = stores;
        }

        private void CalculateTotal()
        {
            this.areaTotal = 0;
            this.areaTarget = 0; 
            this.managersCount = 0;
            this.areaPoints = new LocationCollection();
#if SILVERLIGHT
            foreach (RadMapDataServiceStoreData store in this.area.Stores)
#else 
            foreach (StoreData store in this.area.Stores)
#endif
            {
                this.areaTotal += store.SalesTotal;
                this.areaTarget += store.SalesTarget;
                this.managersCount += store.Managers;
            }
#if SILVERLIGHT
            foreach(RadMapDataServiceLocation location in this.area.Area)
#else
            foreach (Location location in this.area.Area)
#endif
            {
                this.areaPoints.Add(new Location(location.Latitude, location.Longitude));
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        private static SolidColorBrush GetColor(string colorString, Color defaultColor)
        {
            uint parsedColor = 0;

            if (string.IsNullOrEmpty(colorString) ||
                !uint.TryParse(colorString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out parsedColor))
            {
                return new SolidColorBrush(defaultColor);
            }

            return new SolidColorBrush(Color.FromArgb(
                ConvertToByte(parsedColor >> 24),
                ConvertToByte(parsedColor >> 16),
                ConvertToByte(parsedColor >> 8),
                ConvertToByte(parsedColor)));
        }

        private static byte ConvertToByte(uint unsignedInteger)
        {
            return Convert.ToByte(unsignedInteger % 256);
        }
    }
}
