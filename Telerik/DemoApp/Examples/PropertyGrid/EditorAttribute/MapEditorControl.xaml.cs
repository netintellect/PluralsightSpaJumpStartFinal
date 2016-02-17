using System;
using System.Windows;
using Telerik.Windows.Controls.Map;
using System.Windows.Controls;
using Telerik.Windows.Examples.Map;
using Telerik.Windows.Controls;
#if SILVERLIGHT
using System.Net;
using System.Windows.Browser;
#endif

namespace Telerik.Windows.Examples.PropertyGrid.EditorAttribute
{
    /// <summary>
    /// Interaction logic for PhoneEditorControl.xaml
    /// </summary>
    public partial class MapEditorControl : UserControl
    {
#if SILVERLIGHT
		private string VEKey;
#endif
        private BingGeocodeProvider geocodeProvider;
        private Location geocodeLocation = new Location(42.356861, -71.064992);

        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register("Location", typeof(string), typeof(MapEditorControl), null);

        public string Location
        {
            get
            {
                return (string)this.GetValue(LocationProperty);
            }
            set
            {
                this.SetValue(LocationProperty, value);
            }
        }

        public MapEditorControl()
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

        private void Provider_GeocodeCompleted(object sender, GeocodeCompletedEventArgs e)
        {
            GeocodeResponse response = e.Response;
            if (response.Results.Count > 0)
            {
                Location = response.Results[0].Address.FormattedAddress;
            }
            else
            {
                MessageBox.Show("Invalid Address");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
		    var parentWindow = (sender as Button).ParentOfType<ChildWindow>();            
#else
            var parentWindow = (sender as Button).ParentOfType<Window>();
#endif
            if (parentWindow != null)
            {
                ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest();
                reverseGeocodeRequest.Location = geocodeLocation;
                this.geocodeProvider.ReverseGeocodeAsync(reverseGeocodeRequest);
                parentWindow.Close();
            }

        }
    }
}
