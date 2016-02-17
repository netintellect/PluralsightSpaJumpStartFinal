using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using System.Xml;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Globalization;
using System.Windows.Resources;
using Telerik.Windows.Examples.Map;
using System.Net;
#if SILVERLIGHT
using Telerik.Windows.Examples.Map.DataService;
#endif

namespace Telerik.Windows.Examples.Map.DynamicLayer
{
    public class ExampleViewModel : ViewModelBase
    {
#if SILVERLIGHT
        private string VEKey;
#endif
        private MapProviderBase _provider;

        public ExampleViewModel()
        {
#if WPF
            SetProvider();
#elif SILVERLIGHT 
            this.GetVEServiceKey();
#endif
            this.ZoomLevel=4;
            this.Center = new Location(37.684297, -99.06924);
        }

        private void SetProvider()
        {
#if SILVERLIGHT
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, this.VEKey);
#endif
#if WPF
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;
#endif
            this.Provider = provider;
        }

#if SILVERLIGHT
        private void GetVEServiceKey()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            Uri keyURI = new Uri(URIHelper.CurrentApplicationURL, "VEKey.txt");
            wc.DownloadStringAsync(keyURI);
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.VEKey = e.Result;
            this.SetProvider();
        }
#endif

        public MapProviderBase Provider
        {
            get
            {
                return this._provider;
            }
            set
            {
                if (this._provider != value)
                {
                    this._provider = value;
                    this.OnPropertyChanged("Provider");
                }
            }
        }


        private int _zoomLevel;
        public int ZoomLevel
        {
            get
            {
                return this._zoomLevel;
            }
            set
            {
                if (this._zoomLevel != value)
                {
                    this._zoomLevel = value;
                    this.OnPropertyChanged("ZoomLevel");
                }
            }
        }

        private Location _center;
        public Location Center
        {
            get
            {
                return this._center;
            }
            set
            {
                if (this._center != value)
                {
                    this._center = value;
                    this.OnPropertyChanged("Center");
                }
            }
        }

#if SILVERLIGHT
        /// <summary>
        /// Callback of the GetStores async call.
        /// The method uses the web service response to building objects on the dynamic layer.
        /// </summary>
        internal void DataServiceGetStoresCompleted(object sender, GetStoresCompletedEventArgs e)
        {
            List<object> objects = new List<object>();

            if (e.Error == null)
            {
                foreach (RadMapDataServiceStoreLocation serviceStoreLocation in e.Result)
                {
					StoreType storeType = (StoreType)Enum.Parse(
						typeof(StoreType),
						serviceStoreLocation.StoreType.ToString(),
						false);

					StoreLocation store = new StoreLocation(
						serviceStoreLocation.Latitude,
						serviceStoreLocation.Longitude,
						serviceStoreLocation.StoreName,
						storeType);

                    objects.Add(store);
                }

				MapItemsRequestEventArgs request = e.UserState as MapItemsRequestEventArgs;

                request.CompleteItemsRequest(objects);
            }
        }
#elif WPF
        internal List<StoreLocation> GetStores(
			double upperLeftLat,
			double upperLeftLong, 
			double lowerRightLat, 
			double lowerRightLong,
            StoreType storeType)
        {
            List<StoreLocation> locations = new List<StoreLocation>();

            StreamResourceInfo streamInfo = Application.GetResourceStream(
                new Uri("/Map;component/DynamicLayer/StoresLocation.xml", UriKind.Relative));

            XmlDocument document = new XmlDocument();
            document.Load(streamInfo.Stream);

            string latLonCondition = "[number(@Latitude) < " + upperLeftLat.ToString(CultureInfo.InvariantCulture) +
                " and number(@Latitude) > " + lowerRightLat.ToString(CultureInfo.InvariantCulture) +
                " and number(@Longitude) > " + upperLeftLong.ToString(CultureInfo.InvariantCulture) +
                " and number(@Longitude) < " + lowerRightLong.ToString(CultureInfo.InvariantCulture) + "]";

            switch (storeType)
            {
                case StoreType.Area:
                    {
                        XmlNodeList nodeList = document.SelectNodes("/StoresLocation/Area" + latLonCondition);
                        foreach (XmlNode node in nodeList)
                        {
                            XmlElement element = (XmlElement)node;

                            locations.Add(new StoreLocation(
                                Convert.ToDouble(element.GetAttribute("Latitude"), CultureInfo.InvariantCulture),
                                Convert.ToDouble(element.GetAttribute("Longitude"), CultureInfo.InvariantCulture),
                                element.GetAttribute("Name"), StoreType.Area));
                        }
                    }
                    break;

                case StoreType.Store:
                    {
                        XmlNodeList nodeList = document.SelectNodes("/StoresLocation/Area/*" + latLonCondition);
                        foreach (XmlNode node in nodeList)
                        {
                            XmlElement element = (XmlElement)node;

                            locations.Add(new StoreLocation(
                                Convert.ToDouble(element.GetAttribute("Latitude"), CultureInfo.InvariantCulture),
                                Convert.ToDouble(element.GetAttribute("Longitude"), CultureInfo.InvariantCulture),
                                element.GetAttribute("Name"),
                                element.LocalName == "Market" ? StoreType.Market : StoreType.Store));
                        }
                    }
                    break;
            }

            return locations;
        }

        /// <summary>
        /// Callback of the GetStores async call.
        /// The method uses the web service response to building objects on the dynamic layer.
        /// </summary>
		internal void SetStores(List<StoreLocation> list, MapItemsRequestEventArgs request)
        {
			request.CompleteItemsRequest(list);
        }
#endif
    }
}
