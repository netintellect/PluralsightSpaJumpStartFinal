using System;
using System.Net;
using System.Windows; 
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using System.Windows.Controls;
#if SILVERLIGHT
using ItemsControl = Telerik.Windows.Controls.ItemsControl;
using System.Windows.Browser;
using Telerik.Windows.Examples.Map;
#endif

namespace Telerik.Windows.Examples.Map.DataBinding
{
    public partial class Example : UserControl
    {
#if SILVERLIGHT
        private string VEKey;
#endif

        private POICollection poiCollection = new POICollection();

        public Example()
        {
            InitializeComponent();

#if SILVERLIGHT
            this.GetVEServiceKey();
#else
            this.SetProvider();
#endif

			this.InformationLayer1.ItemTemplateSelector = new WayPointTemplateSelector(
				this.LayoutRoot.Resources["LeftWayPointTemplate"] as DataTemplate,
				this.LayoutRoot.Resources["CenterWayPointTemplate"] as DataTemplate,
				this.LayoutRoot.Resources["RightWayPointTemplate"] as DataTemplate);

			Binding binding = new Binding();
			binding.Source = this.poiCollection;
			this.InformationLayer3.SetBinding(VisualizationLayer.ItemsSourceProperty, binding);
        }

        // Initialize Bing Maps provider.
        private void SetProvider()
        {
#if SILVERLIGHT
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, this.VEKey);
#else
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;
#endif
            this.RadMap1.Provider = provider;
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
        private void RadMap1_InitializeCompleted(object sender, EventArgs e)
        {
		}

        private void RadMap1_MapMouseClick(object sender, MapMouseRoutedEventArgs eventArgs)
        {
            // Create new map item.
            PointOfInterest item = new PointOfInterest();
            item.Title = string.Format("Lat: {0:F4}, Lon: {1:F4}", eventArgs.Location.Latitude, eventArgs.Location.Longitude);
            item.Location = eventArgs.Location;
			item.BaseZoomLevel = this.RadMap1.ZoomLevel;

            this.poiCollection.RemoveAll();
            this.poiCollection.Add(item);
        }
	}
}
