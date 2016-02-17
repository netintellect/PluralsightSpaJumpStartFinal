using System;
using System.Net;
using System.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.MultipleTileLayers
{
    public partial class Example : UserControl
    {
        private const double BaseAerialLayerOpacity = 1.0;
        private const double RoadLayerOpacity = 0.5;

#if SILVERLIGHT
        private string VEKey;
#endif
        public Example()
        {
            InitializeComponent();

#if SILVERLIGHT
            this.GetVEServiceKey();
#else
            this.SetProvider();
#endif
            this.RadMap1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
        }

        private void SetProvider()
        {
#if SILVERLIGHT
            BingMapProvider baseAerialProvider = new BingMapProvider(MapMode.Aerial, true, this.VEKey);
            OpenStreetMapProvider openStreeMapProvider = new OpenStreetMapProvider();
#else
            BingMapProvider baseAerialProvider = new BingMapProvider(MapMode.Aerial, false, BingMapHelper.VEKey);
            baseAerialProvider.IsTileCachingEnabled = true;

            OpenStreetMapProvider openStreeMapProvider = new OpenStreetMapProvider();
            openStreeMapProvider.IsTileCachingEnabled = true;
#endif
            openStreeMapProvider.Opacity = 0.9;

            // Restrict the OSM provider will be visible only between zoom levels 12 to 16.
            MapLayer.SetZoomRange(openStreeMapProvider, new ZoomRange(12, 16));

            // Restrict the OSM within specified geographic bounds.
            openStreeMapProvider.GeoBounds = new LocationRect(38.8926145921155, -77.0367630041506, 2.8805463957252573, 3.5936233103348907);

            this.RadMap1.Providers.Add(baseAerialProvider);
            this.RadMap1.Providers.Add(openStreeMapProvider);
        }

#if SILVERLIGHT
        private void GetVEServiceKey()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += this.WebClientDownloadStringCompleted;
            Uri keyURI = new Uri(URIHelper.CurrentApplicationURL, "VEKey.txt");
            wc.DownloadStringAsync(keyURI);
        }

        private void WebClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.VEKey = e.Result;
            this.SetProvider();
        }
#endif
    }
}
