using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using System.Linq;
using System.Windows;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Chart.FirstLook
{
    public class OrderViewModel : DataSourceViewModelBase
    {
        private QueryableCollectionView _data;
        private QueryableCollectionView _regions;
        private ICommand _chartArea1ClickCommand;

        private bool _chartArea1ClickCommandCanExecute = true;

        private ICommand _goBack1Command;
        private bool _goBack1CanExecute;

        private string _salesByProductTitle = "Total sales by product";
        private SeriesMappingCollection _barChartSeriesMappings;
        private SeriesMappingCollection _lineChartSeriesMappings;
        private string _axisXLabelFormat = "yyyy";

        public OrderViewModel()
        {
            this.GetData("dashboard.csv");
            this.InitializeBarChartSeriesMappings();
            this.InitializeLineChartSeriesMappings();
        }

        public QueryableCollectionView Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if (_data != value)
                {
                    _data = value;
                    OnPropertyChanged("Data");
                }
            }
        }

        public QueryableCollectionView Regions
        {
            get
            {
                return this._regions;
            }
            set
            {
                if (_regions != value)
                {
                    _regions = value;
                    OnPropertyChanged("Regions");
                }
            }
        }

        public ICommand ChartArea1ClickCommand
        {
            get
            {
                if (this._chartArea1ClickCommand == null)
                    this._chartArea1ClickCommand = new DelegateCommand(ChartArea1ItemClick, CanExecuteChartArea1ItemClick);

                return this._chartArea1ClickCommand;
            }
            set
            {
                this._chartArea1ClickCommand = value;
            }
        }

        public ICommand GoBack1Command
        {
            get
            {
                if (this._goBack1Command == null)
                    this._goBack1Command = new DelegateCommand(GoBack1, CanExecuteGoBack1);

                return this._goBack1Command;
            }
            set
            {
                this._goBack1Command = value;
            }
        }

        public string AxisXLabelFormat
        {
            get
            {
                return this._axisXLabelFormat;
            }
            set
            {
                if (this._axisXLabelFormat != value)
                {
                    this._axisXLabelFormat = value;
                    this.OnPropertyChanged("AxisXLabelFormat");
                }
            }
        }

        public string SalesByProductTitle
        {
            get
            {
                return this._salesByProductTitle;
            }
            set
            {
                if (this._salesByProductTitle != value)
                {
                    this._salesByProductTitle = value;
                    this.OnPropertyChanged("SalesByProductTitle");
                }
            }
        }

        public SeriesMappingCollection BarChartSeriesMappings
        {
            get
            {
                return this._barChartSeriesMappings;
            }
            set
            {
                if (this._barChartSeriesMappings != value)
                {
                    this._barChartSeriesMappings = value;
                    this.OnPropertyChanged("BarChartSeriesMappings");
                }
            }
        }

        public SeriesMappingCollection LineChartSeriesMappings
        {
            get
            {
                return this._lineChartSeriesMappings;
            }
            set
            {
                if (this._lineChartSeriesMappings != value)
                {
                    this._lineChartSeriesMappings = value;
                    this.OnPropertyChanged("LineChartSeriesMappings");
                }
            }
        }

        #region Data
        public IEnumerable<OrderData> GetRegionData(string region)
        {
            List<OrderData> orders = new List<OrderData>();

            foreach (OrderData order in this.Data)
            {
                if (order.Region == region)
                    orders.Add(order);
            }

            return orders;
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            IEnumerable<OrderData> orderdata = data as IEnumerable<OrderData>;
            this.Data = new QueryableCollectionView(orderdata);
            this.Regions = this.MapRegions(orderdata);
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<OrderData> chartData = new List<OrderData>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                OrderData newOrderData = new OrderData();
                newOrderData.Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture);
                newOrderData.Amount = int.Parse(data[1], CultureInfo.InvariantCulture);
                newOrderData.Target = int.Parse(data[2], CultureInfo.InvariantCulture);
                newOrderData.Product = data[3].Trim();
                newOrderData.Country = data[4].Trim();
                newOrderData.Region = data[5].Trim();
                chartData.Add(newOrderData);
            }

            return chartData;
        }

        private IEnumerable<string> GetRegions(IEnumerable<OrderData> data)
        {
            List<string> regions = new List<string>();

            foreach (OrderData order in data)
            {
                if (!regions.Contains(order.Region))
                    regions.Add(order.Region);
            }

            return regions;
        }

        private QueryableCollectionView MapRegions(IEnumerable<OrderData> data)
        {
            List<OrderView> regions = new List<OrderView>();

            foreach (string region in GetRegions(data))
            {
                regions.Add(new Region(region, GetRegionData(region)));
            }

            return new QueryableCollectionView(regions);
        }
        #endregion

        #region Bar/Line chart
        private void InitializeBarChartSeriesMappings()
        {
            SeriesMappingCollection seriesMappings = new SeriesMappingCollection();
            StackedBarSeriesDefinition seriesDefinition1 = CreateBarSeriesDefinition();
            SeriesMapping seriesMapping1 = this.CreateSeriesMapping("Beverages", seriesDefinition1, "Amount", ChartAggregateFunction.Sum);
            seriesMapping1.GroupingSettings.GroupDescriptors.Add(new ChartYearGroupDescriptor("Date"));
            seriesMappings.Add(seriesMapping1);


            SeriesDefinition seriesDefinition2 = CreateBarSeriesDefinition();
            SeriesMapping seriesMapping2 = this.CreateSeriesMapping("Snacks", seriesDefinition2, "Amount", ChartAggregateFunction.Sum);
            seriesMapping2.GroupingSettings.GroupDescriptors.Add(new ChartYearGroupDescriptor("Date"));
            seriesMappings.Add(seriesMapping2);

            this.BarChartSeriesMappings = seriesMappings;
        }

        private static StackedBarSeriesDefinition CreateBarSeriesDefinition()
        {
            StackedBarSeriesDefinition seriesDefinition = new StackedBarSeriesDefinition();
            seriesDefinition.ShowItemLabels = false;
            seriesDefinition.LabelSettings.LabelDisplayMode = LabelDisplayMode.Inside;
            return seriesDefinition;
        }

        private void InitializeLineChartSeriesMappings()
        {
            SeriesMappingCollection seriesMappings = new SeriesMappingCollection();
            LineSeriesDefinition seriesDefinition1 = CreateLineSeriesDefinition();
            SeriesMapping seriesMapping1 = this.CreateSeriesMapping("Beverages", seriesDefinition1, "PercentTarget", ChartAggregateFunction.Average);
            seriesMappings.Add(seriesMapping1);

            LineSeriesDefinition seriesDefinition2 = CreateLineSeriesDefinition();
            seriesDefinition2.ShowItemLabels = false;
            seriesDefinition2.ShowPointMarks = false;
            SeriesMapping seriesMapping2 = this.CreateSeriesMapping("Snacks", seriesDefinition2, "PercentTarget", ChartAggregateFunction.Average);
            seriesMappings.Add(seriesMapping2);

            this.LineChartSeriesMappings = seriesMappings;
        }

        private static LineSeriesDefinition CreateLineSeriesDefinition()
        {
            LineSeriesDefinition seriesDefinition1 = new LineSeriesDefinition();
            seriesDefinition1.ShowItemLabels = false;
            seriesDefinition1.ShowPointMarks = false;
            return seriesDefinition1;
        }

        private SeriesMapping CreateSeriesMapping(string product, SeriesDefinition seriesDefinition, string yValueField, ChartAggregateFunction aggFunction)
        {
            SeriesMapping result = new SeriesMapping();
            result.LegendLabel = product;
            result.SeriesDefinition = seriesDefinition;
            result.ItemMappings.Add(new ItemMapping("Date", DataPointMember.XCategory));
            result.ItemMappings.Add(new ItemMapping(yValueField, DataPointMember.YValue, aggFunction));
            result.FilterDescriptors.Add(new FilterDescriptor("Product", FilterOperator.IsEqualTo, product));
            result.GroupingSettings.ShouldFlattenSeries = true;
            result.GroupingSettings.GroupDescriptors.Add(new ChartYearGroupDescriptor("Date"));

            return result;
        }

        private void UpdateBarChartSeriesMappings(int year)
        {
            SeriesMappingCollection seriesMappings = new SeriesMappingCollection();
            StackedBarSeriesDefinition seriesDefinition1 = CreateBarSeriesDefinition();
            SeriesMapping seriesMapping1 = this.CreateSeriesMapping("Beverages", seriesDefinition1, "Amount", ChartAggregateFunction.Sum);
            seriesMapping1.GroupingSettings.GroupDescriptors.Add(new ChartMonthGroupDescriptor("Date"));
            seriesMapping1.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsGreaterThanOrEqualTo, new DateTime(year, 1, 1)));
            seriesMapping1.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsLessThanOrEqualTo, new DateTime(year, 12, 31)));
            seriesMappings.Add(seriesMapping1);

            StackedBarSeriesDefinition seriesDefinition2 = CreateBarSeriesDefinition();
            SeriesMapping seriesMapping2 = this.CreateSeriesMapping("Snacks", seriesDefinition2, "Amount", ChartAggregateFunction.Sum);
            seriesMapping2.GroupingSettings.GroupDescriptors.Add(new ChartMonthGroupDescriptor("Date"));
            seriesMapping2.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsGreaterThanOrEqualTo, new DateTime(year, 1, 1)));
            seriesMapping2.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsLessThanOrEqualTo, new DateTime(year, 12, 31)));
            seriesMappings.Add(seriesMapping2);

            this.BarChartSeriesMappings = seriesMappings;
        }

        private void UpdateLineChartSeriesMappings(int year)
        {
            SeriesMappingCollection seriesMappings = new SeriesMappingCollection();
            LineSeriesDefinition seriesDefinition1 = CreateLineSeriesDefinition();
            SeriesMapping seriesMapping1 = this.CreateSeriesMapping("Beverages", seriesDefinition1, "PercentTarget", ChartAggregateFunction.Average);
            seriesMapping1.GroupingSettings.GroupDescriptors.Add(new ChartMonthGroupDescriptor("Date"));
            seriesMapping1.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsGreaterThanOrEqualTo, new DateTime(year, 1, 1)));
            seriesMapping1.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsLessThanOrEqualTo, new DateTime(year, 12, 31)));
            seriesMappings.Add(seriesMapping1);

            LineSeriesDefinition seriesDefinition2 = CreateLineSeriesDefinition();
            SeriesMapping seriesMapping2 = this.CreateSeriesMapping("Snacks", seriesDefinition2, "PercentTarget", ChartAggregateFunction.Average);
            seriesMapping2.GroupingSettings.GroupDescriptors.Add(new ChartMonthGroupDescriptor("Date"));
            seriesMapping2.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsGreaterThanOrEqualTo, new DateTime(year, 1, 1)));
            seriesMapping2.FilterDescriptors.Add(new ChartFilterDescriptor("Date", typeof(DateTime), FilterOperator.IsLessThanOrEqualTo, new DateTime(year, 12, 31)));
            seriesMappings.Add(seriesMapping2);

            this.LineChartSeriesMappings = seriesMappings;
        }

        private void GoBack1(object parameter)
        {
            this.SalesByProductTitle = "Total sales by product";
            this.AxisXLabelFormat = "yyyy";

            this.InitializeBarChartSeriesMappings();
            this.InitializeLineChartSeriesMappings();
            UpdateCommands();
        }

        private void ChartArea1ItemClick(object parameter)
        {
            DataPoint dataPoint = parameter as DataPoint;
            if (dataPoint == null)
                return;

            KeyValuePair<string, string> dataItem = (dataPoint.DataItem as List<KeyValuePair<string, string>>)[0];
            string field = dataItem.Key;
            int year = int.Parse(dataItem.Value);

            this.SalesByProductTitle = SalesByProductTitle + " for " + year.ToString();

            this.AxisXLabelFormat = "MMM";
            this.UpdateBarChartSeriesMappings(year);
            this.UpdateLineChartSeriesMappings(year);
            this.UpdateCommands();
        }

        private void UpdateCommands()
        {
            this._goBack1CanExecute = !this._goBack1CanExecute;
            (this.GoBack1Command as DelegateCommand).InvalidateCanExecute();

            this._chartArea1ClickCommandCanExecute = !this._chartArea1ClickCommandCanExecute;
            (this.ChartArea1ClickCommand as DelegateCommand).InvalidateCanExecute();
        }

        private bool CanExecuteChartArea1ItemClick(object parameter)
        {
            return this._chartArea1ClickCommandCanExecute;
        }

        private bool CanExecuteGoBack1(object parameter)
        {
            return this._goBack1CanExecute;
        }
        #endregion

        #region Pie chart / GridView
        private void ChartArea2ItemClick(object parameter)
        {
            DataPoint dataPoint = parameter as DataPoint;
            if (dataPoint == null)
                return;

            Region region = dataPoint.DataItem as Region;
            if (region == null)
                return;

            string name = region.Name;
        }
        #endregion
    }
}

