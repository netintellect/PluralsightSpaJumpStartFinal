using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;
using System.Windows.Input;
#if SILVERLIGHT
using System.Net;
using System.Windows.Browser;
using Telerik.Windows.Examples.Map;
using System.Collections.Generic;
using System.Windows.Input;
#endif

namespace Telerik.Windows.Examples.Map.Cluster
{
    public partial class Example : UserControl
    {
#if SILVERLIGHT
        private string VEKey;
#endif
        private MapItemsCollection itemCollection = new MapItemsCollection();
        private BingSearchProvider searchProvider;

        public Example()
        {
            InitializeComponent();

#if SILVERLIGHT
            this.GetVEServiceKey();
#else
            this.SetProvider();
#endif
            this.DataContext = this.itemCollection;
            //restrict the last zoom level
            this.RadMap1.MaxZoomLevel -= 1;
        }

        private void SetProvider()
        {
#if SILVERLIGHT
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, this.VEKey);
#else
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;
#endif
            this.RadMap1.Provider = provider;

            // Init searh provider.
            searchProvider = new BingSearchProvider();
#if SILVERLIGHT
            searchProvider.ApplicationId = this.VEKey;
#else
            searchProvider.ApplicationId = BingMapHelper.VEKey;
#endif
            searchProvider.MapControl = this.RadMap1;

            string query = "museum in chicago";
            SearchRequest request = new SearchRequest();
            request.Query = query;
            request.Culture = new System.Globalization.CultureInfo("en-US");
            request.SearchOptions = new SearchOptions() { Count = 25, Radius = 200 };
            request.SearchOptions.ListingType = ListingType.Business;

            this.searchProvider.SearchAsync(request);

            searchProvider.SearchCompleted += new EventHandler<SearchCompletedEventArgs>(Provider_SearchCompleted);
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

        private void Provider_SearchCompleted(object sender, SearchCompletedEventArgs args)
        {
            SearchResponse response = args.Response;

            if (response != null && response.ResultSets.Count > 0)
            {
                if (response.ResultSets[0].Results.Count > 0)
                {
                    this.itemCollection.Clear();
                    foreach (BusinessSearchResult result in response.ResultSets[0].Results)
                    {
                        MyMapItem item = new MyMapItem()
                        {
                            Title = result.Name,
                            Location = result.LocationData.Locations[0],
                            Description = result.Address.AddressLine
                        };
                        this.itemCollection.Add(item);
                    }
                }

                if (response.ResultSets[0].SearchRegion != null &&
                    response.ResultSets[0].SearchRegion.GeocodeLocation != null)
                {
                    // Set map viewport to the best view returned in the search result.
                    this.RadMap1.SetView(response.ResultSets[0].SearchRegion.GeocodeLocation.BestView);
                    //set the zoomlevel so that you collapse any clusters at previous zoom level
                    this.RadMap1.ZoomLevel = response.ResultSets[0].SearchRegion.GeocodeLocation.BestView.ZoomLevel - 1;

                    // Show map shape around bounding area
                    if (response.ResultSets[0].SearchRegion.BoundingArea != null)
                    {
                        MapShape boundingArea = response.ResultSets[0].SearchRegion.BoundingArea;
                        boundingArea.Stroke = new SolidColorBrush(Colors.White);
                        boundingArea.StrokeThickness = 1;
                        this.informationLayer2.Items.Add(boundingArea);
                    }
                }
            }
        }

        private void ClusterMouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
				ClusterData cluster = element.DataContext as ClusterData;
                if (cluster != null)
                {
                    LocationRect bestViewRect = this.visualizationLayer.GetBestView(cluster.Children);
                    this.RadMap1.SetView(bestViewRect);
                }
            }
            e.Handled = true;
        }
    }
}
