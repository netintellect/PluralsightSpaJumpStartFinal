using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.DataBinding
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            this.FillDataSourcesComboBox();

            this.SetDataMappings("DataTable");
            this.RadChart1.ItemsSource = RandomDataGenerator.GetDataTable();
            (this.dataSources.Items[0] as RadComboBoxItem).IsSelected = true;
            this.textBlockDescription.Text = "DataTable"; 
        }

        private void FillDataSourcesComboBox()
        {
            RadComboBoxItem comboItem = new RadComboBoxItem();
            comboItem.Content = "DataTable";
            dataSources.Items.Add(comboItem);

            comboItem = new RadComboBoxItem();
            comboItem.Content = "List of custom objects";
            dataSources.Items.Add(comboItem);

            comboItem = new RadComboBoxItem();
            comboItem.Content = "ArrayList";
            dataSources.Items.Add(comboItem);

            comboItem = new RadComboBoxItem();
            comboItem.Content = "ObservableCollection";
            dataSources.Items.Add(comboItem);

            comboItem = new RadComboBoxItem();
            comboItem.Content = "ObjectDataProvider";
            dataSources.Items.Add(comboItem);

            comboItem = new RadComboBoxItem();
            comboItem.Content = "CollectionView";
            dataSources.Items.Add(comboItem);

            comboItem = new RadComboBoxItem();
            comboItem.Content = "Property Paths";
            dataSources.Items.Add(comboItem);
        }

        protected void dataSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			string dataSource = this.dataSources.SelectedValue.ToString();

            this.ResetChart();

            switch (dataSource)
            {
                case "DataTable":
                    this.SetDataMappings("DataTable");
                    this.RadChart1.ItemsSource = RandomDataGenerator.GetDataTable();
                    this.textBlockDescription.Text = "DataTable";
                    break;

                case "ArrayList":
                    this.SetArrayListDataMapping();
                    this.RadChart1.ItemsSource = RandomDataGenerator.GetArrayList();
                    this.textBlockDescription.Text = "ArrayList";
                    break;

                case "List of custom objects":
                    this.SetDataMappings("Custom objects");
                    this.RadChart1.ItemsSource = RandomDataGenerator.GetObjectData();
                    this.textBlockDescription.Text = "List of custom objects";
                    break;

                case "ObservableCollection":
                    this.SetDataMappings("ObservableCollection");
                    this.RadChart1.ItemsSource = RandomDataGenerator.GetObservableCollection();
                    this.textBlockDescription.Text = "Observable collection";
                    break;

                case "ObjectDataProvider":
                        this.SetDataMappings("ObjectDataProvider");
                        this.RadChart1.ItemsSource = RandomDataGenerator.GetObjectDataProvider();
                        this.textBlockDescription.Text = "ObjectDataProvider";
                        break;

                case "CollectionView":
                    this.SetDataMappings("CollectionView");
                    this.RadChart1.ItemsSource = RandomDataGenerator.GetCollectionView();
                    this.textBlockDescription.Text = "Collection View";
                    break;

                case "Property Paths":
                    this.textBlockDescription.Text = "This is a demonstration of binding to a custom .NET object by using property paths. " +
                                                     "This feature of RadChart allows you to bind to nested properties of any depth.";

                    this.SetPropertyPathDataMappings("Property Paths");
                    this.RadChart1.ItemsSource = RandomDataGenerator.GetDataFromPropertyPaths();
                    break;
            }
        }

        private void SetArrayListDataMapping()
        {
            RadChart1.DefaultView.ChartLegend.Header = "ArrayList";
        }

        private void SetDataMappings(string seriesLabel)
        {
            RadChart1.DefaultView.ChartLegend.Header = seriesLabel;

            SeriesMapping seriesMapping = new SeriesMapping();
            seriesMapping.SeriesDefinition = new BarSeriesDefinition();

            ItemMapping itemMapping = new ItemMapping();
            itemMapping.DataPointMember = DataPointMember.YValue;
            itemMapping.FieldName = "DoubleData";
            seriesMapping.ItemMappings.Add(itemMapping);

            this.RadChart1.SeriesMappings.Add(seriesMapping);

            SeriesMapping seriesMapping2 = new SeriesMapping();
            seriesMapping2.SeriesDefinition = new LineSeriesDefinition();

            ItemMapping itemMapping2 = new ItemMapping();
            itemMapping2.DataPointMember = DataPointMember.YValue;
            itemMapping2.FieldName = "DoubleData2";
            seriesMapping2.ItemMappings.Add(itemMapping2);

            this.RadChart1.SeriesMappings.Add(seriesMapping2);
        }

        private void SetPropertyPathDataMappings(string seriesLabel)
        {
            RadChart1.DefaultView.ChartLegend.Header = seriesLabel;

            SeriesMapping seriesMapping = new SeriesMapping();
            seriesMapping.SeriesDefinition = new BarSeriesDefinition();

            ItemMapping itemMapping = new ItemMapping();
            itemMapping.DataPointMember = DataPointMember.YValue;
            itemMapping.FieldName = "Data.DoubleData";
            seriesMapping.ItemMappings.Add(itemMapping);

            this.RadChart1.SeriesMappings.Add(seriesMapping);

            SeriesMapping seriesMapping2 = new SeriesMapping();
            seriesMapping2.SeriesDefinition = new LineSeriesDefinition();

            ItemMapping itemMapping2 = new ItemMapping();
            itemMapping2.DataPointMember = DataPointMember.YValue;
            itemMapping2.FieldName = "Data.DoubleData2";
            seriesMapping2.ItemMappings.Add(itemMapping2);

            this.RadChart1.SeriesMappings.Add(seriesMapping2);
        }

        private void ResetChart()
        {
            this.RadChart1.SeriesMappings.Clear();
            this.RadChart1.ItemsSource = null;
        }
    }
}
