using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.DrillDown
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        private double[] quarterlyRevenues = new double[4];

        public Example()
        {
            InitializeComponent();
        }

        private void ChartArea1_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            if (ChartArea1.SelectedItems.Count == 0)
            {
                RadChart1.HierarchyManager.Reset();
                return;
            }

            if (e.AddedItems.Count == 0)
                return;

            foreach (DataPoint dataPoint in ChartArea1.SelectedItems)
            {
                if (dataPoint != e.AddedItems[0])
                    ChartArea1.UnselectItem(dataPoint);
            }
        }
    }
}
