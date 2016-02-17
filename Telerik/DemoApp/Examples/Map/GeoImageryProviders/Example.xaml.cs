using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.Map;
using System.Windows.Threading;
using System.Net;
#if SILVERLIGHT
using System.Windows.Browser;
using Telerik.Windows.Examples.Map;
#endif

namespace Telerik.Windows.Examples.Map.GeoImageryProviders
{
    public partial class Example : UserControl
    {
        DispatcherTimer zoomOutTimer = new DispatcherTimer();
        DispatcherTimer zoomInTimer = new DispatcherTimer();
        DispatcherTimer moveTimer = new DispatcherTimer();

        private bool providerChanged = false;
#if SILVERLIGHT
        private string VEKey;
#endif
        private const int minZoomLevel = 3;
        private const int maxZoomLevel = 7;

        public Example()
        {
            InitializeComponent();

#if SILVERLIGHT
            this.GetVEServiceKey();
#endif 
            LocationBox.SelectedIndex = 0;
            ProviderBox.SelectedIndex = 0;
#if WPF
            this.SetProvider();
#endif
            RadMap1.Center = (Location)LocationBox.SelectedItem;
            zoomOutTimer.Interval = TimeSpan.FromMilliseconds(150);
            zoomInTimer.Interval = TimeSpan.FromMilliseconds(150);
            moveTimer.Interval = TimeSpan.FromMilliseconds(800);
            zoomInTimer.Tick += new EventHandler(zoomInTimer_Tick);
            zoomOutTimer.Tick += new EventHandler(zoomOutTimer_Tick);
            moveTimer.Tick += new EventHandler(moveTimer_Tick);
 
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

        void moveTimer_Tick(object sender, EventArgs e)
        {
            this.moveTimer.Stop();
            this.ZoomIn();
        }

        void zoomInTimer_Tick(object sender, EventArgs e)
        {
            if (this.RadMap1.ZoomLevel < maxZoomLevel)
                this.RadMap1.ZoomLevel++;
            else
                this.zoomInTimer.Stop();
        }

        void zoomOutTimer_Tick(object sender, EventArgs e)
        {
            if (this.RadMap1.ZoomLevel > minZoomLevel)
                this.RadMap1.ZoomLevel--;
            else
            {
                this.zoomOutTimer.Stop();
                this.ZoomOutFinished();
            }
        }

        void ZoomOutFinished()
        {
            RadMap1.Center = (Location)LocationBox.SelectedItem;
            this.SetProvider();
            this.moveTimer.Start();
        }

        private void SetProvider()
        {
            if (providerChanged)
            {
                string providerName = (ProviderBox.SelectedItem as ListBoxItem).Content.ToString();
               
                MapProviderBase provider;

                if (providerName == "OpenStreetMapProvider")
                {
                    provider = new OpenStreetMapProvider();
                }
                else
                {
                    provider = InitializeBingMapProvider(MapMode.Road, true);
                }

                this.RadMap1.Provider = provider;

                this.providerChanged = false;
            }
        }

#if SILVERLIGHT
        private BingMapProvider InitializeBingMapProvider(MapMode providerMode, bool isLabelVisible)
        {
            if (string.IsNullOrEmpty(this.VEKey))
                return null;

           return new BingMapProvider(providerMode, isLabelVisible, this.VEKey);
        }
#else
        private BingMapProvider InitializeBingMapProvider(MapMode providerMode, bool isLabelVisible)
        {
            if (string.IsNullOrEmpty(BingMapHelper.VEKey))
                return null;

            BingMapProvider provider = new BingMapProvider(providerMode, isLabelVisible, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;

            return provider;
        }
#endif

        private void ZoomOut()
        {
            if (this.zoomOutTimer.IsEnabled || this.zoomInTimer.IsEnabled)
                return;

            this.zoomOutTimer.Start();
        }

        private void ZoomIn()
        {
            if (this.zoomOutTimer.IsEnabled || this.zoomInTimer.IsEnabled)
                return;

            this.zoomInTimer.Start();
        }

        private void LocationBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ZoomOut();
        }

        private void ProviderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ProviderBox.SelectedItem != null)
            {
                this.providerChanged = true;
                this.ZoomOut();
            }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.zoomInTimer.Tick -= this.zoomInTimer_Tick;
            this.zoomOutTimer.Tick -= this.zoomOutTimer_Tick;
            this.moveTimer.Tick -= this.moveTimer_Tick;
        }
    }
}
