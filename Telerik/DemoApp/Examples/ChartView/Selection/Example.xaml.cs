using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Data;
using Telerik.Windows.Examples.ChartView.Selection.Models;
using Telerik.Windows.Examples.ChartView.Selection.Utilities;

namespace Telerik.Windows.Examples.ChartView.Selection
{
    public partial class Example : UserControl
    {

        private readonly List<string> SelectableCountries = new List<string>(9);
        private readonly List<string> EUCountries = new List<string>(27);
        private RadObservableCollection<CountryData> countriesData = new RadObservableCollection<CountryData>();

        public Example()
        {
            InitializeComponent();
            InitializeCountries();
            InitializeColors();
            pieChart.Series[0].ItemsSource = this.countriesData;
            this.pieChart.LayoutUpdated += pieChart_LayoutUpdated;
        }

        private void InitializeColors()
        {
            CountryUtilities.DefaultCountryColor = (Color)this.Resources["DefaultCountryColor"];
            CountryUtilities.SelectedCountryColor = (Color)this.Resources["SelectedCountryColor"];
            CountryUtilities.CountryBorderColor = (Color)this.Resources["CountryBorderColor"];
            var countryToColorDict = new Dictionary<string, Color>();
            countryToColorDict[CountryUtilities.FranceCountryName] = (Color)this.Resources["FranceColor"];
            countryToColorDict[CountryUtilities.SpainCountryName] = (Color)this.Resources["SpainColor"];
            countryToColorDict[CountryUtilities.UnitedKingdomCountryName] = (Color)this.Resources["UnitedKingdomColor"];
            countryToColorDict[CountryUtilities.GermanyCountryName] = (Color)this.Resources["GermanyColor"];
            countryToColorDict[CountryUtilities.ItalyCountryName] = (Color)this.Resources["ItalyColor"];
            CountryUtilities.CountryToColorDictionary = countryToColorDict;
        }

        private void ReaderPreviewReadCompleted(object sender, PreviewReadShapesCompletedEventArgs eventArgs)
        {
            for (int i = eventArgs.Items.Count - 1; i >= 0; i--)
            {
                MapShape mapShape = eventArgs.Items[i] as MapShape;
                string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
                if (!EUCountries.Contains(countryName))
                    eventArgs.Items.Remove(mapShape);
            }

            List<Brush> paletteBrushes = new List<Brush>();
            this.countriesData.SuspendNotifications();
            double restOfEuGdp = 0;
            foreach (MapShape mapShape in eventArgs.Items)
            {
                string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
                double gdp = CountryUtilities.GetGDP(countryName, 2012);
                if (SelectableCountries.Contains(countryName))
                {
                    Color countryColor = CountryUtilities.GetColor(countryName);
                    paletteBrushes.Add(new SolidColorBrush(countryColor));

                    MapInteractivity.InitializeFill(mapShape);
                    mapShape.MouseLeftButtonDown += this.MapShapeMouseLeftButtonDown;
                    mapShape.MouseLeftButtonDown += MapInteractivity.MapShapeMouseLeftButtonDown;
                    mapShape.MouseLeave += MapInteractivity.MapShapeMouseLeave;
                    mapShape.MouseEnter += MapInteractivity.MapShapeMouseEnter;

                    CountryData country = new CountryData() { Name = countryName, Year = 2012, GDP = gdp, };
                    this.countriesData.Add(country);
                }
                else
                {
                    restOfEuGdp += gdp;
                }
            }

            CountryData resOfEu = new CountryData();
            resOfEu.GDP = restOfEuGdp;
            resOfEu.Name = "Rest of EU";
            this.countriesData.Add(resOfEu);

            var pieChartPalette = new ChartPalette();
            foreach (var brush in paletteBrushes)
            {
                pieChartPalette.GlobalEntries.Add(new PaletteEntry(brush));
            }
            pieChartPalette.GlobalEntries.Add(new PaletteEntry(new SolidColorBrush(CountryUtilities.DefaultCountryColor)));
            this.pieChart.Palette = pieChartPalette;

            this.countriesData.ResumeNotifications();
        }

        private void LineSeries_DataBindingComplete(object sender, System.EventArgs e)
        {
            var lineSeries = (LineSeries)sender;
            if (lineSeries == null || lineSeries.DataPoints.Count == 0)
                return;

            string countryName = ((CountryData)lineSeries.DataPoints[0].DataItem).Name;
            UpdateLine(countryName, false);
        }

        private void MapShapeMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MapShape mapShape = sender as MapShape;
            string countryName = CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape);
            bool shouldSelect = !MapInteractivity.IsSelected(mapShape);
            if (shouldSelect)
                MapInteractivity.SelectShape(mapShape);
            else
                MapInteractivity.UnselectShape(mapShape);

            this.UpdatePieSlice(countryName, shouldSelect);
            this.UpdateBar(countryName, shouldSelect);
            this.UpdateLine(countryName, shouldSelect);
        }

        private void PieChartSelectionBehavior_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            foreach (var dataPoint in this.pieChart.Series[0].DataPoints)
            {
                string countryName = ((CountryData)dataPoint.DataItem).Name;
                if (!this.SelectableCountries.Contains(countryName))
                {
                    dataPoint.IsSelected = false;
                }
            }

            this.UpdateAll(this.pieChart.Series[0].DataPoints);
        }

        private void BarChartSelectionBehavior_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            var barSeries = (BarSeries)this.barChart.Series[0];
            this.UpdateAll(barSeries.DataPoints);
        }

        private void UpdateAll(IEnumerable<DataPoint> dataPoints)
        {
            foreach (var dataPoint in dataPoints)
            {
                string countryName = ((CountryData)dataPoint.DataItem).Name;
                this.UpdatePieSlice(countryName, dataPoint.IsSelected);
                this.UpdateBar(countryName, dataPoint.IsSelected);
                this.UpdateMapShape(countryName, dataPoint.IsSelected);
                this.UpdateLine(countryName, dataPoint.IsSelected);
            }
        }

        private void UpdateMapShape(string countryName, bool shouldSelect)
        {
            foreach (MapShape mapShape in this.InformationLayer.Items)
            {
                if (countryName == CountryUtilities.ExtractNameFromMapShapeExtendedData(mapShape))
                {
                    if (shouldSelect)
                        MapInteractivity.SelectShape(mapShape);
                    else
                        MapInteractivity.UnselectShape(mapShape);
                    break;
                }
            }
        }

        private void UpdatePieSlice(string countryName, bool shouldSelect)
        {
            for (int i = 0; i < this.countriesData.Count; i++)
            {
                if (this.countriesData[i].Name == countryName)
                {
                    this.pieChart.Series[0].DataPoints[i].IsSelected = shouldSelect;
                    Brush brush = shouldSelect ? new SolidColorBrush(CountryUtilities.SelectedCountryColor) : CountryUtilities.GetBrush(countryName);
                    this.pieChart.Palette.GlobalEntries[i] = new PaletteEntry(brush);
                    break;
                }
            }
        }

        private void UpdateBar(string countryName, bool shouldSelect)
        {
            var barSeries = this.barChart.Series[0] as BarSeries;
            if (barSeries == null)
                return;

            foreach (var dataPoint in barSeries.DataPoints)
            {
                string nameOfCountry = ((CountryData)dataPoint.DataItem).Name;
                if (countryName == nameOfCountry)
                {
                    dataPoint.IsSelected = shouldSelect;
                    Brush brush = shouldSelect ? new SolidColorBrush(CountryUtilities.SelectedCountryColor) : CountryUtilities.GetBrush(countryName);
                    this.SetBarBrush(dataPoint, brush);
                }
            }
        }

        private void UpdateLine(string countryName, bool isSelected)
        {
            foreach (LineSeries lineSeries in this.lineChart.Series)
            {
                if (lineSeries.DataPoints.Count != 0)
                {
                    string nameOfCountry = ((CountryData)lineSeries.DataPoints[0].DataItem).Name;
                    if (nameOfCountry == countryName)
                    {
                        Brush brush = isSelected ? new SolidColorBrush(CountryUtilities.SelectedCountryColor) : CountryUtilities.GetBrush(countryName);
                        lineSeries.Stroke = brush;
                    }
                }
            }
        }

        private void SetBarBrush(CategoricalDataPoint dataPoint, Brush brush)
        {
            var bars = Telerik.Windows.Controls.ChildrenOfTypeExtensions.ChildrenOfType<Border>(this.barChart.Series[0]);
            var bar = bars.FirstOrDefault(b => b.DataContext == dataPoint);
            if (bar != null)
            {
                bar.Background = brush;
            }
        }

        private void pieChart_LayoutUpdated(object sender, System.EventArgs e)
        {
            var paths = Telerik.Windows.Controls.ChildrenOfTypeExtensions.ChildrenOfType<Path>(this.pieChart.Series[0]).ToList();
            if (paths.Count == 0)
                return;

            this.pieChart.LayoutUpdated -= pieChart_LayoutUpdated;

            foreach (var path in paths)
            {
                var dataPoint = path.Tag as PieDataPoint;
                if (dataPoint == null)
                    return;

                string countryName = ((CountryData)dataPoint.DataItem).Name;
                if (this.SelectableCountries.Contains(countryName))
                {
                    path.MouseEnter += uiElement_MouseEnter;
                    path.MouseLeave += uiElement_MouseLeave;
                }
            }
        }

        private void uiElement_MouseEnter(object sender, MouseEventArgs e)
        {
            UIElement bar = (UIElement)sender;
            bar.Opacity = 0.5;
        }

        private void uiElement_MouseLeave(object sender, MouseEventArgs e)
        {
            UIElement bar = (UIElement)sender;
            bar.Opacity = 1;
        }

        private void InitializeCountries()
        {
            this.SelectableCountries.Add(CountryUtilities.GermanyCountryName);
            this.SelectableCountries.Add(CountryUtilities.UnitedKingdomCountryName);
            this.SelectableCountries.Add(CountryUtilities.SpainCountryName);
            this.SelectableCountries.Add(CountryUtilities.FranceCountryName);
            this.SelectableCountries.Add(CountryUtilities.ItalyCountryName);

            this.EUCountries.Add("Austria");
            this.EUCountries.Add("Belgium");
            this.EUCountries.Add("Bulgaria");
            this.EUCountries.Add("Czech Republic");
            this.EUCountries.Add("Denmark");
            this.EUCountries.Add("Estonia");
            this.EUCountries.Add("Finland");
            this.EUCountries.Add("France");
            this.EUCountries.Add("Germany");
            this.EUCountries.Add("Hungary");
            this.EUCountries.Add("Ireland");
            this.EUCountries.Add("Italy");
            this.EUCountries.Add("Latvia");
            this.EUCountries.Add("Lithuania");
            this.EUCountries.Add("Luxembourg");
            this.EUCountries.Add("Malta");
            this.EUCountries.Add("Netherlands");
            this.EUCountries.Add("Poland");
            this.EUCountries.Add("Portugal");
            this.EUCountries.Add("Romania");
            this.EUCountries.Add("Slovakia");
            this.EUCountries.Add("Slovenia");
            this.EUCountries.Add("Spain");
            this.EUCountries.Add("Sweden");
            this.EUCountries.Add("United Kingdom");
            this.EUCountries.Add("Switzerland");
        }
    }
}
