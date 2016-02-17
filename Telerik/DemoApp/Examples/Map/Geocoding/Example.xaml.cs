using System;
using System.Windows;
using Telerik.Windows.Controls.Map;
using System.Windows.Controls;
#if SILVERLIGHT
using System.Net;
using System.Windows.Browser;
using Telerik.Windows.Examples.Map;
#endif

namespace Telerik.Windows.Examples.Map.Geocoding
{
	public partial class Example : UserControl
	{
#if SILVERLIGHT
		private string VEKey;
#endif
		private BingGeocodeProvider geocodeProvider;
		private Location geocodeLocation;

		public Example()
		{
			InitializeComponent();

#if SILVERLIGHT
			this.GetVEServiceKey();
#else
            this.SetProvider();
#endif
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

			// Init route provider.
			geocodeProvider = new BingGeocodeProvider();
#if SILVERLIGHT
			geocodeProvider.ApplicationId = this.VEKey;
#else
            geocodeProvider.ApplicationId = BingMapHelper.VEKey;
#endif
            geocodeProvider.MapControl = this.RadMap1; 
			geocodeProvider.GeocodeCompleted += new EventHandler<GeocodeCompletedEventArgs>(Provider_GeocodeCompleted);
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

		private void MapMouseClick(object sender, MapMouseRoutedEventArgs eventArgs)
		{
			this.informationLayer.Items.Clear();
			this.informationLayer.Items.Add(eventArgs.Location);
			this.geocodeLocation = eventArgs.Location;
		}

		private void GeocodeHandler(object sender, RoutedEventArgs e)
		{
			ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest();
            reverseGeocodeRequest.Location = geocodeLocation;
			this.geocodeProvider.ReverseGeocodeAsync(reverseGeocodeRequest);
		}

		private void Provider_GeocodeCompleted(object sender, GeocodeCompletedEventArgs e)
		{
			GeocodeResponse response = e.Response;
			listBox.ItemsSource = response.Results;
		}
	}
}
