using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.ToolTip.FirstLook
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        private BingSearchProvider searchProvider;
#if SILVERLIGHT
        private string VEKey;
#endif
        private ObservableCollection<MapItem> mapItemsCollection = new ObservableCollection<MapItem>();

        public Example()
        {
            InitializeComponent();
#if SILVERLIGHT
            this.GetVEServiceKey();
#else
            this.SetProvider();
#endif
            this.LoadData();
        }

        private void SetProvider()
        {
#if SILVERLIGHT
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, this.VEKey);
#else
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;
#endif
            this.radMap.Provider = provider;
        }

#if SILVERLIGHT
        private void GetVEServiceKey()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            Uri keyURI = new Uri(System.Windows.Browser.HtmlPage.Document.DocumentUri, "VEKey.txt");
            wc.DownloadStringAsync(keyURI);
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.VEKey = e.Result;
            this.SetProvider();
        }
#endif

        private void LoadData()
        {
            ObservableCollection<MapItem> mapItems = new ObservableCollection<MapItem>();
            var stream = Application.GetResourceStream(new Uri("/ToolTip;component/FirstLook/PointsOfInterest.xml", UriKind.RelativeOrAbsolute));
            XElement dataXml = XElement.Load(stream.Stream);

            foreach (XElement element in dataXml.Elements("Country"))
            {
                foreach (var place in element.Elements("POI"))
                {
                    MapItem item = new MapItem();
                    item.Title = place.Attribute("Name").Value;
                    item.Description = place.Attribute("Description").Value;
                    item.ImgPath = string.Format("../Images/{0}", place.Attribute("ImgName").Value);
                    item.Location = Location.Parse(place.Attribute("Location").Value);
                    item.CountryName = element.Attribute("Name").Value;
                    item.Caption = ((char)(mapItems.Count % 10 + 65)).ToString();

                    mapItems.Add(item);
                }
            }
            this.visualizationLayer.Loaded += (o, e) => this.SetBestView("England");
            this.visualizationLayer.ItemsSource = mapItems;
        }

        private void OnCountryButtonChecked(object sender, RoutedEventArgs e)
        {
            string country = (sender as RadRadioButton).Content.ToString();
            this.SetBestView(country);
        }

        private void SetBestView(string filter)
        {
            if (this.visualizationLayer != null && this.visualizationLayer.ItemsSource != null)
            {
                var allItems = this.visualizationLayer.ItemsSource as ObservableCollection<MapItem>;
                if (allItems == null) return;
                allItems.ToList().ForEach(x => x.IsVisible = false);

                var filderedItems = allItems.Where(x => x.CountryName == filter).ToList();
                if (filderedItems.Count > 0)
                {
                    filderedItems.ForEach(x => x.IsVisible = true);
                    LocationRect bestViewRect = this.visualizationLayer.GetBestView(filderedItems);

                    // Expanding locationRect in order to avoid cuttting of PushPins.
                    LocationRect realBestView = new LocationRect(
                     new Location(bestViewRect.North + 0.075, bestViewRect.West ),
                     new Location(bestViewRect.South - 0.075, bestViewRect.East ));

                    this.radMap.SetView(realBestView);
                }
            } 
        }
    }
}
