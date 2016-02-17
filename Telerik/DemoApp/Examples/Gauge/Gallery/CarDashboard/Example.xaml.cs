using System;
using System.Net;
using System.Windows;
using System.Windows.Media;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls;
#if SILVERLIGHT
using System.Windows.Browser;
using Telerik.Windows.Examples.Gauge;
#endif


namespace Telerik.Windows.Examples.Gauge.Gallery.CarDashboard
{
	public partial class Example : DynamicBasePage
	{
        private RealDataEmulator FuelGenerator = new RealDataEmulator(0, 100, 100);
        private RealDataEmulator BatteryGenerator = new RealDataEmulator(30, 70, 50, 5, 5);
        private RealDataEmulator CoolerGenerator = new RealDataEmulator(10, 30, 20, 3, 3);
        private RealDataEmulator Needle1Generator = new RealDataEmulator(20, 150, 50, 20, 21);
        private RealDataEmulator Needle2Generator = new RealDataEmulator(1, 4, 2, 0.2, 0.2);

#if SILVERLIGHT
        private string VEKey;
#endif
#if WPF
        public const string VEKey = "Aq42ZfawAk-DT5xXh0Pc_mcZjpajPg4FUnWPRFKwtTZUKJ_qF4RhlqlfOWla3zxc";
#endif

        private BingRouteProvider routeProvider; 
        private LocationCollection routePoints = new LocationCollection();
        private MapPolyline routeLine = new MapPolyline();

		public Example()
		{
            StyleManager.ApplicationTheme = new Office_BlackTheme();
			InitializeComponent();

            FuelGenerator.AddRange(0, 10, 0.57, 0, 90);
            FuelGenerator.AddRange(10, 100, 0.57, 0, 10); 

#if SILVERLIGHT
            this.GetVEServiceKey();
#endif
#if WPF
            SetProvider(); 
            this.AddPoints();
            this.FindRoute();
#endif
        }

        protected override void NewValue()
        {
            FuelGenerator.GetNextValue();
            BatteryGenerator.GetNextValue();
            CoolerGenerator.GetNextValue();
            Needle1Generator.GetNextValue();
            Needle2Generator.GetNextValue();

            bar1.Value = FuelGenerator.GetNextValue();
            bar2.Value = BatteryGenerator.GetNextValue();
            bar3.Value = CoolerGenerator.GetNextValue();  
            needle1.Value = Needle1Generator.GetNextValue();
            needle2.Value = Needle2Generator.GetNextValue();
        }

        // Initialize Virtual Earth map provider.
        private void SetProvider()
        { 
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, VEKey);
#if WPF
            provider.IsTileCachingEnabled = true;
#endif
            this.RadMap1.Provider = provider;

            // Init route provider.
            routeProvider = new BingRouteProvider();
            routeProvider.ApplicationId = VEKey;
            routeProvider.MapControl = this.RadMap1; 

            routeProvider.RoutingCompleted += new EventHandler<RoutingCompletedEventArgs>(Provider_RoutingCompleted);
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
            this.AddPoints();
            this.FindRoute();
        }
#endif

        private void AddPoints()
        {
            this.routePoints.Add(new Location(42.1009656551826, 24.7193981705648));
            this.routePoints.Add(new Location(35.3920640030319, 25.1588512955649));      

			// Show route points on the map.
			this.informationLayer.Items.Clear();
			foreach (Location location in this.routePoints)
			{
				this.informationLayer.Items.Add(location);
			}
        }

        private void FindRoute()
        {
            this.ErrorSummary.Visibility = Visibility.Collapsed;

            RouteRequest routeRequest = new RouteRequest();
            routeRequest.Culture = new System.Globalization.CultureInfo("en-US");
            routeRequest.Options.RoutePathType = RoutePathType.Points;
 
            if (this.routePoints.Count > 1)
            {
                foreach (Location location in this.routePoints)
                {
                    routeRequest.Waypoints.Add(location);
                }
                this.routeProvider.CalculateRouteAsync(routeRequest);
            }
        }

        private void Provider_RoutingCompleted(object sender, RoutingCompletedEventArgs e)
        {  
            RouteResponse routeResponse = e.Response as RouteResponse;
            if (routeResponse != null)
            {
                if (routeResponse.Result.RoutePath != null)
                {
                    routeLine.Points = routeResponse.Result.RoutePath.Points;
                    routeLine.Stroke = new SolidColorBrush(Color.FromArgb(255, 53, 191, 74));
                    routeLine.StrokeThickness = 2;

                    this.informationLayer.Items.Add(routeLine);
                }
                else
                {
                    this.ErrorSummary.Visibility = Visibility.Visible;
                }
            }
        }
	}
}
