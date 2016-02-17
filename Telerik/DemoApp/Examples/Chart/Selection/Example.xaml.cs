using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Chart.Selection
{
    public partial class Example : UserControl
    {
        private readonly List<string> SelectableCountries = new List<string>(9);
        private readonly List<string> EUCountries = new List<string>(27);
        private RadObservableCollection<Country> countries = new RadObservableCollection<Country>();

        public Example()
        {
            InitializeComponent();
            Initialize();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            RadChart1.ItemsSource = this.countries;
        }

        private void ReaderPreviewReadCompleted(object sender, PreviewReadShapesCompletedEventArgs eventArgs)
        {
            for (int i = eventArgs.Items.Count - 1; i >= 0; i--)
            {
                MapShape mapShape = eventArgs.Items[i] as MapShape;
                if (!EUCountries.Contains(Country.ExtractNameFromMapShapeExtendedData(mapShape)))
                    eventArgs.Items.Remove(mapShape);
            }

            List<Brush> paletteBrushes = new List<Brush>();
            countries.SuspendNotifications();
            double interactableCountriesPopulation = 0;
            double otherCountriesPopulation = 0;
            foreach (MapShape mapShape in eventArgs.Items)
            {
                string countryName = Country.ExtractNameFromMapShapeExtendedData(mapShape);
                if (SelectableCountries.Contains(countryName))
                {
                    Color countryColor = MapInteractivity.ReturnNormalColor(mapShape);
                    paletteBrushes.Add(new SolidColorBrush(countryColor));

                    MapInteractivity.UnSelectShape(mapShape);
                    mapShape.MouseLeftButtonDown += this.MapShapeMouseLeftButtonDown;
                    mapShape.MouseLeftButtonDown += MapInteractivity.MapShapeMouseLeftButtonDown;
                    mapShape.MouseEnter += MapInteractivity.MapShapeMouseEnter;
                    mapShape.MouseLeave += MapInteractivity.MapShapeMouseLeave;

                    interactableCountriesPopulation += Country.ExtractPopulationFromMapShapeExtendedData(mapShape);
                    countries.Add(Country.ExtractFromMapShapeExtendedData(mapShape));
                }
                else
                {
                    otherCountriesPopulation += Country.ExtractPopulationFromMapShapeExtendedData(mapShape);
                }
            }

            RadChart1.PaletteBrushes.AddRange(paletteBrushes);
            RadChart1.PaletteBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x77, 0x77, 0x77)));

            Country country = new Country();
            country.Population = otherCountriesPopulation;
            country.Name = "Rest of EU Countries";
            countries.Add(country);

            countries.ResumeNotifications();
        }

        private void MapShapeMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            string countryName = Country.ExtractNameFromMapShapeExtendedData(mapShape);
            if (MapInteractivity.IsSelected(mapShape))
                SelectCountryInChart(countryName, false);
            else
                SelectCountryInChart(countryName, true);
        }

        private void ToggleSelectionOfCountryInMap(string countryName)
        {
            foreach (MapShape mapShape in this.InformationLayer.Items)
            {
                if (countryName == Country.ExtractNameFromMapShapeExtendedData(mapShape))
                {
                    if (MapInteractivity.IsSelected(mapShape))
                        MapInteractivity.UnSelectShape(mapShape);
                    else
                        MapInteractivity.SelectShape(mapShape);
                    break;
                }
            }
        }

        bool propagateSelection = true;
        private void SelectCountryInChart(string countryName, bool shouldSelect)
        {
            int index = -1;
            for (int i = 0; i < (this.countries as ICollection<Country>).Count; i++)
            {
                if (this.countries[i].Name == countryName)
                {
                    index = i;
                    break;
                }
            }

            this.propagateSelection = false;
            if (shouldSelect)
                RadChart1.DefaultView.ChartArea.SelectItem(index);
            else
                RadChart1.DefaultView.ChartArea.UnselectItem(index);
        }

        private void ChartAreaSelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            DataPoint dataPoint = null;
            if (e.AddedItems.Count > 0)
                dataPoint = e.AddedItems[0];
            else if (e.RemovedItems.Count > 0)
                dataPoint = e.RemovedItems[0];

            if (dataPoint != null && propagateSelection)
            {
                string country = dataPoint.LegendLabel;
                this.ToggleSelectionOfCountryInMap(country);
            }

            this.propagateSelection = true;
        }

        private void Initialize()
        {
            SelectableCountries.Add("Germany");
            SelectableCountries.Add("France");
            SelectableCountries.Add("Spain");
            SelectableCountries.Add("Poland");
            SelectableCountries.Add("United Kingdom");
            SelectableCountries.Add("Italy");
            SelectableCountries.Add("Romania");
            SelectableCountries.Add("Netherlands");
            SelectableCountries.Add("Portugal");

            EUCountries.Add("Austria");
            EUCountries.Add("Belgium");
            EUCountries.Add("Bulgaria");
            EUCountries.Add("Cyprus");
            EUCountries.Add("Czech Republic");
            EUCountries.Add("Denmark");
            EUCountries.Add("Estonia");
            EUCountries.Add("Finland");
            EUCountries.Add("France");
            EUCountries.Add("Germany");
            EUCountries.Add("Greece");
            EUCountries.Add("Hungary");
            EUCountries.Add("Ireland");
            EUCountries.Add("Italy");
            EUCountries.Add("Latvia");
            EUCountries.Add("Lithuania");
            EUCountries.Add("Luxembourg");
            EUCountries.Add("Malta");
            EUCountries.Add("Netherlands");
            EUCountries.Add("Poland");
            EUCountries.Add("Portugal");
            EUCountries.Add("Romania");
            EUCountries.Add("Slovakia");
            EUCountries.Add("Slovenia");
            EUCountries.Add("Spain");
            EUCountries.Add("Sweden");
            EUCountries.Add("United Kingdom");
        }
    }
}