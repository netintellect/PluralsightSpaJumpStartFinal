using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.DragDrop;

namespace Telerik.Windows.Examples.Chart.DragAndDrop
{
    public partial class Example : UserControl
    {
        private Random random = new Random(123456);
        private DragAndDropMode _DragAndDropMode;
        private string DataPointKey = "DataPoint";

        public Color color1 = Color.FromArgb(0xFF, 0x8E, 0xBC, 0x00);
        public Color color2 = Color.FromArgb(0xFF, 0x25, 0xA0, 0xDA);

        public Example()
        {
            InitializeComponent();

            this.Initialize();

            DragDropManager.AddDragInitializeHandler(this.topChart, Chart_DragInitialize);
            DragDropManager.AddDropHandler(this.topChart, Chart_Drop, true);
            DragDropManager.AddGiveFeedbackHandler(this.topChart, Chart_GiveFeedback);

            DragDropManager.AddDragInitializeHandler(this.bottomChart, Chart_DragInitialize);
            DragDropManager.AddDropHandler(this.bottomChart, Chart_Drop, true);
            DragDropManager.AddGiveFeedbackHandler(this.bottomChart, Chart_GiveFeedback);
        }

        private DragAndDropMode DragAndDropMode
        {
            get
            {
                return this._DragAndDropMode;
            }
            set
            {
                this._DragAndDropMode = value;
            }
        }

        private void Initialize()
        {
            this.InitializeChart(topChart, "Total Gross Worldwide", color1, color2, gross);
            this.InitializeChart(bottomChart, "Movie Budget", color2, color1, budget);
        }

        private double[] gross = new double[] { 2781505847, 1835300000, 1129219252, 1065896541, 1062984497 };
        private double[] budget = new double[] { 237000000, 200000000, 94000000, 225000000, 200000000 };
        private string[] categories = new string[] { "Avatar", "Titanic", "The Lord of the\nRings:The Return\nof the King", "Pirates of the\nCaribbean: Dead\nMan's Chest", "Toy Story 3" };

        private void InitializeChart(RadChart chart, string chartTitle, Color seriesColor, Color series2Color, double[] data)
        {
            //Generate some data:
            DataSeries series = new DataSeries();
            if (this.DragAndDropMode == DragAndDropMode.ItemDragAndDrop)
            {
                series.Definition = new StackedBarSeriesDefinition() { ShowItemLabels = true };
            }
            else series.Definition = new BarSeriesDefinition() { ShowItemLabels = true };
            series.Definition.ItemStyle = this.LayoutRoot.Resources["BarItemsStyle"] as Style;
            series.Definition.Appearance.Fill = new SolidColorBrush(seriesColor);
            series.Definition.Appearance.Stroke = new SolidColorBrush(seriesColor);
            series.Definition.Appearance.Cursor = Cursors.Hand;

            for (int i = 0; i < 5; i++)
            {
                series.Add(new DataPoint(categories[i], data[i]));
            }

            chart.DefaultView.ChartArea.DataSeries.Clear();
            chart.DefaultView.ChartArea.DataSeries.Add(series);
            chart.DefaultView.ChartArea.AxisX.LayoutMode = AxisLayoutMode.Between;

            if (this.DragAndDropMode == DragAndDropMode.ItemDragAndDrop)
            {
                DataSeries series2 = new DataSeries();
                series2.Definition = new StackedBarSeriesDefinition() { ShowItemLabels = true };
                series2.Definition.ItemStyle = this.LayoutRoot.Resources["BarItemsStyle"] as Style;
                series2.Definition.Appearance.Fill = new SolidColorBrush(series2Color);
                series2.Definition.Appearance.Stroke = new SolidColorBrush(series2Color);
                series2.Definition.Appearance.Cursor = Cursors.Hand;
                chart.DefaultView.ChartArea.DataSeries.Add(series2);
            }

            chart.DefaultView.ChartArea.EnableAnimations = false;
            chart.DefaultView.ChartLegend.Visibility = Visibility.Collapsed;
            chart.DefaultView.ChartTitle.Content = chartTitle;
            chart.DefaultView.ChartArea.AxisY.ExtendDirection = AxisExtendDirection.None;
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (this.ItemDragRadioButton == null)
                return;

            if ((bool)this.ItemDragRadioButton.IsChecked)
                this.DragAndDropMode = DragAndDropMode.ItemDragAndDrop;
            else
                this.DragAndDropMode = DragAndDropMode.SeriesDragAndDrop;

            this.Initialize();
        }

        private void Chart_GiveFeedback(object sender, Telerik.Windows.DragDrop.GiveFeedbackEventArgs args)
        {
            args.SetCursor(Cursors.Arrow);
            args.Handled = true;
        }

        private void Chart_DragInitialize(object sender, Telerik.Windows.DragDrop.DragInitializeEventArgs args)
        {
            args.AllowedEffects = DragDropEffects.All;

            var dragVisual = new DragVisual() { ContentTemplate = this.Resources["DragVisualTemplate"] as DataTemplate };
            var dataPoint = (args.OriginalSource as BaseChartItem).DataPoint;

            if (this.DragAndDropMode == DragAndDropMode.ItemDragAndDrop)
                dragVisual.Content = this.GetItemHeaderTextFromDataSeries(dataPoint.DataSeries);
            else
                dragVisual.Content = this.GetSeriesHeaderTextFromDataSeries(dataPoint.DataSeries);

            args.DragVisual = dragVisual;
            args.DragVisualOffset = new Point(args.RelativeStartPoint.X, args.RelativeStartPoint.Y - 5);

#if WPF
            var dataObject = new System.Windows.DataObject();
            dataObject.SetData("dataPoint", dataPoint);
            args.Data = dataObject;
#else
            args.Data = dataPoint;
#endif
        }

        private void Chart_Drop(object sender, Telerik.Windows.DragDrop.DragEventArgs args)
        {
            var targetChart = sender as RadChart;
            if (targetChart == null)
                return;
                        
#if WPF
            DataPoint dataPoint;
            var dataObject = args.Data as System.Windows.DataObject;
            if (dataObject == null)
                return;

            dataPoint = dataObject.GetData("dataPoint") as DataPoint;
#else
            DataPoint dataPoint = args.Data as DataPoint;
#endif

            if (dataPoint == null)
                return;

            DataSeries sourceDataSeries = dataPoint.DataSeries;

            if (this.DragAndDropMode == DragAndDropMode.ItemDragAndDrop)
            {
                Color sourceColor = GetColorFromDataSeries(sourceDataSeries);
                DataSeries targetDataSeries = GetDataSeriesByColor(targetChart, sourceColor);

                if (sourceDataSeries != targetDataSeries)
                {
                    sourceDataSeries.Remove(dataPoint);
                    targetDataSeries.Add(dataPoint);
                }
            }
            else
            {
                if (!targetChart.DefaultView.ChartArea.DataSeries.Contains(sourceDataSeries))
                {
                    RadChart sourceChart = targetChart == this.topChart ? this.bottomChart : this.topChart;
                    sourceChart.DefaultView.ChartArea.DataSeries.Remove(sourceDataSeries);
                    targetChart.DefaultView.ChartArea.DataSeries.Add(sourceDataSeries);
                }
            }
        }

        private DataSeries GetDataSeriesByColor(RadChart chart, Color color)
        {
            foreach (DataSeries series in chart.DefaultView.ChartArea.DataSeries)
            {
                SolidColorBrush brush = series.Definition.Appearance.Fill as SolidColorBrush;
                if (brush.Color.Equals(color))
                    return series;
            }

            return null;
        }

        private Color GetColorFromDataSeries(DataSeries dataSeries)
        {
            SolidColorBrush brush = dataSeries.Definition.Appearance.Fill as SolidColorBrush;

            if (brush != null)
                return brush.Color;

            return Colors.Transparent;
        }

        private string GetItemHeaderTextFromDataSeries(DataSeries dataSeries)
        {
            Color color = this.GetColorFromDataSeries(dataSeries);

            if (color == color1)
                return "Movie Total Gross";
            else
                return "Movie Budget";
        }

        private string GetSeriesHeaderTextFromDataSeries(DataSeries dataSeries)
        {
            Color color = this.GetColorFromDataSeries(dataSeries);

            if (color == color1)
                return "Total Gross Data";
            else
                return "Movie Budget Data";
        }
    
    }

    public enum DragAndDropMode
    {
        SeriesDragAndDrop,
        ItemDragAndDrop
    }
}
