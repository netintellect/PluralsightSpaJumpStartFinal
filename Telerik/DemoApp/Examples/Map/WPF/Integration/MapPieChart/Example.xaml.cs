using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Resources;
using Examples.Map.CS;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Map;
using System.Windows.Media.Imaging;

namespace Telerik.Windows.Examples.Map.Integration.MapPieChart
{
    public partial class Example : UserControl
    {
        private int i = 0;
        private double[] randoms;
        private string[] cityNames = new string[] { "Sofia", "Plovdiv", "Varna", "Burgas", "Russe" };
        private Location[] cityLocations = new Location[] { new Location(42.697625, 23.322283), new Location(42.15 , 24.75), new Location(43.216667, 27.916667), new Location(42.5, 27.466667), new Location(43.816667, 25.95) };
        private Location[] legendLocations = new Location[] { new Location(42.71689, 21.47842), new Location(41.4696, 24.1947), new Location(43.17127, 28.778840), new Location(42.42968, 28.33938), new Location(44.39272, 25.1313) };
        private const string KmlRelativeUri = "DataSources/Geospatial/bulgaria.kml";
        private Random rand = new Random(DateTime.Now.Millisecond);
        private RadPieChart sofiaChart = new RadPieChart() { MinHeight = 60, MinWidth = 60 };
        private RadPieChart plovdivChart = new RadPieChart() { MinHeight = 60, MinWidth = 60 };
        private RadPieChart varnaChart = new RadPieChart() { MinHeight = 60, MinWidth = 60 };
        private RadPieChart burgasChart = new RadPieChart() { MinHeight = 60, MinWidth = 60 };
        private RadPieChart russeChart = new RadPieChart() { MinHeight = 60, MinWidth = 60 };

        public Example()
        {
            InitializeComponent();

            this.SetProvider();
            this.RadMap1.ZoomChanged += this.MapZoomChanged;
        }

        // Initialize Virtual Earth map provider.
        private void SetProvider()
        {
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;
            this.RadMap1.Provider = provider;
        }

        private void MapZoomChanged(object sender, EventArgs e)
        {
            this.SetChartDimensions(this.sofiaChart);
            this.SetChartDimensions(this.plovdivChart);
            this.SetChartDimensions(this.varnaChart);
            this.SetChartDimensions(this.burgasChart);
            this.SetChartDimensions(this.russeChart);
        }

        private void SetChartDimensions(RadPieChart chart)
        {
            if (this.RadMap1.ZoomLevel < 0)
                return;

            chart.Height = 10 * this.RadMap1.ZoomLevel;
            chart.Width = 10 * this.RadMap1.ZoomLevel;
        }

        private void AsyncKmlReader_ReadShapeDataCompleted(object sender, ReadShapeDataCompletedEventArgs e)
        {
            this.RadMap1.Center = new Location(42.866667, 25.333333);
            this.RadMap1.ZoomLevel = 7;

            this.SetUpPinPoints();
            this.SetUpCharts();
        }

        private void SetUpPinPoints()
        {
            // add MapPinPoint at city location
            for (int i = 0; i < cityLocations.Length; i++)
            {
                MapPinPoint cityPinPoint = new MapPinPoint();
                cityPinPoint.IsHitTestVisible = false;
                MapLayer.SetHotSpot(cityPinPoint, new Controls.HotSpot() { X = 0.5, Y = 0.5 });
                cityPinPoint.ImageSource = new BitmapImage(new Uri("/Map;component/Resources/placemark_circle.png", UriKind.Relative));
                MapLayer.SetLocation(cityPinPoint, cityLocations[i]);
                this.VisualizationLayer.Items.Add(cityPinPoint);
            }
        }

        private void SetUpCharts()
        {
            this.InitializeChart(this.sofiaChart, cityLocations[0]);
            this.InitializeChart(this.plovdivChart, cityLocations[1]);
            this.InitializeChart(this.varnaChart, cityLocations[2]);
            this.InitializeChart(this.burgasChart, cityLocations[3]);
            this.InitializeChart(this.russeChart, cityLocations[4]);
        }

        private void InitializeMapLegend(int d1, int d2, int d3, HeaderedItemsControl headeredIC, Location location)
        {
            List<MapLegendData> data = new List<MapLegendData>();
            data.Add(new MapLegendData(d1 + "% (0 - 18)", new SolidColorBrush(Color.FromArgb(0xFF, 0x8E, 0xBC, 0x00))));
            data.Add(new MapLegendData(d2 + "% (18 - 65)", new SolidColorBrush(Color.FromArgb(0xFF, 0x25, 0xA0, 0xDA))));
            data.Add(new MapLegendData(d3 + "% (65+)", new SolidColorBrush(Color.FromArgb(0xFF, 0xEB, 0x7A, 0x2A))));

            headeredIC.ItemTemplate = this.Resources["CustomDataTemplate"] as DataTemplate;
            headeredIC.Padding = new Thickness(0, 10, 0, 0);
            headeredIC.ItemsSource = data;
            headeredIC.SetValue(MapLayer.LocationProperty, location);
           
            this.VisualizationLayer.Items.Add(headeredIC);
        }

        private void InitializeChart(RadPieChart chart, Location location)
        {
            this.SetChartDimensions(chart);

            randoms = new double[] { rand.Next(10000, 50000), rand.Next(10000, 50000), rand.Next(10000, 50000) };
            double sum = randoms[0] + randoms[1] + randoms[2];

            PieSeries series = new PieSeries() { ShowLabels = false };
            series.ItemsSource = new double[] { randoms[0], randoms[1], randoms[2] };
            chart.Series.Add(series);
            chart.Palette = ChartPalettes.Windows8;

            chart.SetValue(MapLayer.LocationProperty, location);
            this.VisualizationLayer.Items.Add(chart);

            HeaderedItemsControl legend = new HeaderedItemsControl();

            this.InitializeMapLegend((int)((randoms[0] * 100) / sum), (int)((randoms[1] * 100) / sum), (int)((randoms[2] * 100) / sum), legend, legendLocations[i++]);
        }        
    }
}
