using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;
#if SILVERLIGHT
using System.Net;
using System.Windows.Browser;
using Telerik.Windows.Examples.Map;
#endif

namespace Telerik.Windows.Examples.Map.Search
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

            this.informationLayer.DataMappings.Add(
				new DataMapping("Location", DataMember.Location));

			Binding binding = new Binding();
			binding.Source = this.itemCollection;
			this.informationLayer.SetBinding(ItemsControl.ItemsSourceProperty, binding);
		}

		// Initialize Virtual Earth map provider.
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

		private void SearchHandler(object sender, RoutedEventArgs e)
		{
			string query = this.SearchCondition.Text;

			if (!string.IsNullOrEmpty(query))
			{
				SearchRequest request = new SearchRequest();
                request.Culture = new System.Globalization.CultureInfo("en-US");
                request.Query = query;

				this.searchProvider.SearchAsync(request);
			}
		}

		private void Provider_SearchCompleted(object sender, SearchCompletedEventArgs args)
		{
			SearchResponse response = args.Response;

			if (response != null && response.ResultSets.Count > 0)
			{
				if (response.ResultSets[0].Results.Count > 0)
				{
					this.itemCollection.Clear();
					foreach (SearchResultBase result in response.ResultSets[0].Results)
					{
						MyMapItem item = new MyMapItem()
						{
							Title = result.Name,
							Location = result.LocationData.Locations[0]
						};
						this.itemCollection.Add(item);
					}
				}

				if (response.ResultSets[0].SearchRegion != null &&
                    response.ResultSets[0].SearchRegion.GeocodeLocation != null)
				{
					// Set map viewport to the best view returned in the search result.
					this.RadMap1.SetView(response.ResultSets[0].SearchRegion.GeocodeLocation.BestView);

					// Show map shape around bounding area
					if (response.ResultSets[0].SearchRegion.BoundingArea != null)
					{
						MapShape boundingArea = response.ResultSets[0].SearchRegion.BoundingArea;
						boundingArea.Stroke = new SolidColorBrush(Colors.Red);
						boundingArea.StrokeThickness = 1;
						this.informationLayer2.Items.Add(boundingArea);
					}

					if (response.ResultSets[0].SearchRegion.GeocodeLocation.Address != null
						&& response.ResultSets[0].SearchRegion.GeocodeLocation.Locations.Count > 0)
					{
						foreach (Location location in response.ResultSets[0].SearchRegion.GeocodeLocation.Locations)
						{
							MyMapItem item = new MyMapItem()
							{
								Title = response.ResultSets[0].SearchRegion.GeocodeLocation.Address.FormattedAddress,
								Location = location
							};
							this.itemCollection.Add(item);
						}
					}
				}
			}
		}
	}
}
