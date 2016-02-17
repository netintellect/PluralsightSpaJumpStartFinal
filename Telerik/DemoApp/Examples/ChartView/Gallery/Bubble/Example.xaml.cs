using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Gallery.Bubble
{    
    public partial class Example : UserControl
    {
        private bool isLegendUpdateScheduled;
        private CustomBubbleSizeSelector sizeSelector;
        private readonly double[] ProfitsRange = new double[3] { 100000000, 50000000, 5000000 };
        private ObservableCollection<LegendItemInfo> LegendItems = new ObservableCollection<LegendItemInfo>();

        public Example()
        {
            InitializeComponent();

            var bubbleSeries = this.bubbleChart.Series[0] as ScatterBubbleSeries;
            this.sizeSelector = bubbleSeries.BubbleSizeSelector as CustomBubbleSizeSelector;
            this.sizeSelector.UserControl = this;

            this.legend.ItemsSource = this.LegendItems;
        }

        internal void ScheduleLegendUpdate()
        {
            if (this.isLegendUpdateScheduled)
            {
                return;
            }

            this.isLegendUpdateScheduled = true;
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                this.LegendItems.Clear();
                foreach (var value in this.ProfitsRange)
                {
                    var size = this.sizeSelector.SelectBubbleSize(value);
                    this.LegendItems.Add(new LegendItemInfo() { Size = size.Height, Profit = value });
                }                

                this.isLegendUpdateScheduled = false;
            }));
        }
    }
}
