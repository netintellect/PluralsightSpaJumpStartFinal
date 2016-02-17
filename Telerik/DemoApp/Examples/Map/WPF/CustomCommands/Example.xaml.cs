using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Map.CustomCommands
{
	public partial class Example : UserControl
    {
        private const string ImagePathFormat = "/Map;component/WPF/CustomCommands/Images/{0}.png";
        private MapItemsCollection itemCollection = new MapItemsCollection();
		private BingSearchProvider searchProvider;
        private BingMapProvider provider;

		public Example()
		{

            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Map;component/WPF/CustomCommands/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
               this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Map;component/WPF/CustomCommands/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
			InitializeComponent();

            this.SetProvider();

            this.informationLayer.DataMappings.Add(new DataMapping("Location", DataMember.Location));

			Binding binding = new Binding();
			binding.Source = this.itemCollection;
			this.informationLayer.SetBinding(System.Windows.Controls.ItemsControl.ItemsSourceProperty, binding);

            RadMap1.InitializeCompleted += new EventHandler(RadMap1_InitializeCompleted);
		}

        private void RadMap1_InitializeCompleted(object sender, EventArgs e)
        {
            this.RadMap1.MapZoomBar.Commands.Clear();

            this.AddCustomZoomAction(16, "Downtown");
            this.AddCustomZoomAction(18, "Neighborhood");
            this.AddCustomZoomAction(20, "Block");
        }

		private void SetProvider()
		{
            this.provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
            this.provider.IsTileCachingEnabled = true;
            this.provider.Commands.Clear();
            this.provider.CommandBindingCollection.Clear();

            this.AddCustomCommandAction(this.provider, "Restaurants");
            this.AddCustomCommandAction(this.provider, "Bars");
            this.AddCustomCommandAction(this.provider, "Museums");

            this.RadMap1.Provider = provider;

			this.searchProvider = new BingSearchProvider();
            this.searchProvider.ApplicationId = BingMapHelper.VEKey;
            this.searchProvider.MapControl = this.RadMap1;

            this.searchProvider.SearchCompleted += new EventHandler<SearchCompletedEventArgs>(Provider_SearchCompleted);
		}

        private void AddCustomZoomAction(int zoomLevel, string label)
        {
            string imagePath = string.Format(ImagePathFormat, label);

            this.RadMap1.MapZoomBar.RegisterSetZoomLevelCommand(zoomLevel,
                label,
                this.Resources["CustomCommandDataTemplate"] as DataTemplate,
                new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

        private void AddCustomCommandAction(BingMapProvider provider, string poi)
        {
            string commandText = string.Format("Find {0}", poi);
            string commandName = string.Format("Find{0}Command", poi);

            CommandDescription commandDescription = new CommandDescription();
            commandDescription.Command = new RoutedUICommand(commandText, commandName, typeof(BingMapProvider));
            commandDescription.CommandParameter = poi;
            commandDescription.DataTemplate = this.Resources["CustomCommandDataTemplate"] as DataTemplate;

            string imagePath = string.Format(ImagePathFormat, poi);
            commandDescription.ImageUri = new Uri(imagePath, UriKind.RelativeOrAbsolute);

            CommandBinding commandBinding = new CommandBinding(commandDescription.Command, ExecuteCustomCommand);

            provider.Commands.Add(commandDescription);
            provider.CommandBindingCollection.Add(commandBinding);
        }

        private void ExecuteCustomCommand(object sender, ExecutedRoutedEventArgs e)
        {
            SearchRequest request = new SearchRequest();
            request.Culture = new System.Globalization.CultureInfo("en-US");
            request.Query = string.Format("{0} in Boston", e.Parameter);

            this.searchProvider.SearchAsync(request);
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

                if (response.ResultSets[0].SearchRegion != null)
                {
                    // Set map viewport to the best view returned in the search result.
                    this.RadMap1.SetView(response.ResultSets[0].SearchRegion.GeocodeLocation.BestView);
                    this.RadMap1.ZoomLevel = 15;

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
