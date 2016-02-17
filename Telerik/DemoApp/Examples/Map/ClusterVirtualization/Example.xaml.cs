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
#endif

namespace Telerik.Windows.Examples.Map.ClusterVirtualization
{
    public partial class Example : UserControl
    {
        private const int MinZoomLevel = 4;
        private const int ReturnZoomLevel = 7;
        private const int OpenZoomLevel = 10;

#if SILVERLIGHT
        private string VEKey;
        private const string ShapeRelativeUriFormat = "DataSources/Geospatial/{0}";
#else
        private const string ShapeRelativeUriFormat = "/Map;component/Resources/{0}";
#endif

        public Example()
        {
            InitializeComponent();
            this.RadMap1.MinZoomLevel = MinZoomLevel;

#if SILVERLIGHT
            this.GetVEServiceKey();
#else
            this.SetProvider();
#endif
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

			this.LoadShapeFile();
        }

		private void LoadShapeFile()
		{
			AsyncShapeFileReader reader = this.virtualizationSource.Reader as AsyncShapeFileReader;
			reader.Source = new Uri(string.Format(ShapeRelativeUriFormat, "airports.shp"), UriKind.Relative);
			reader.ToolTipFormat = "AIRPT_NAME";
			this.virtualizationSource.ReadAsync();
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

        private void ClusteredItemMouseClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                PointData data = element.DataContext as PointData;
                if (data != null)
                {
                    if (this.RadMap1.ZoomLevel >= OpenZoomLevel)
                    {
                        this.RadMap1.ZoomLevel = ReturnZoomLevel;
                    }
                    else
                    {
                        this.RadMap1.ZoomLevel = OpenZoomLevel;
                    }

                    this.RadMap1.Center = data.Location;
                }
            }
        }

        private void ClusterMouseClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                ClusterData cluster = element.DataContext as ClusterData;
                if (cluster != null)
                {
                    if (RadMap1.ZoomLevel == OpenZoomLevel &&
                      cluster.ClusterState != ClusterState.ExpandedToPolygon)
                    {
                        cluster.ClusterState = ClusterState.Collapsed;
                        RadMap1.ZoomLevel = ReturnZoomLevel;
                    }
                    else if (RadMap1.ZoomLevel < ReturnZoomLevel)
                    {
                        RadMap1.ZoomLevel = ReturnZoomLevel;
                    }
                    else if ((RadMap1.ZoomLevel > OpenZoomLevel) || (RadMap1.ZoomLevel == ReturnZoomLevel))
                    {
                        cluster.HideExpanded = false;
                        cluster.ClusterState = ClusterState.ExpandedToPolygon;
                        this.RadMap1.ZoomLevel = OpenZoomLevel;
                    }

                    this.RadMap1.Center = cluster.Location;
                }
            }
        }
    }
}
