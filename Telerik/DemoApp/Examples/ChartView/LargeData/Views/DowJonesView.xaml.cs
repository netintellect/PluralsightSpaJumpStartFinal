using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Examples.ChartView.LargeData.ViewModels;

namespace Telerik.Windows.Examples.ChartView.LargeData.Views
{
    /// <summary>
    /// Interaction logic for DowJonesView.xaml
    /// </summary>
    public partial class DowJonesView : UserControl
    {
        List<LineSeries> removedSeries = new List<LineSeries>();

        public DowJonesView()
        {
            InitializeComponent();
            this.Loaded += this.DowJonesView_Loaded;
        }

        private void DowJonesView_Loaded(object sender, RoutedEventArgs e)
        {
           // this.UpdateSeries();
        }

        private void RadToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            RadToggleButton toggleButton = (RadToggleButton)sender;
            this.UpdateSeries(toggleButton.Tag, true);
        }

        private void RadToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RadToggleButton toggleButton = (RadToggleButton)sender;
            this.UpdateSeries(toggleButton.Tag, false);
        }

        private void UpdateSeries(object tag, bool shouldBeAdded)
        {
            if (shouldBeAdded)
            {
                for (int i = 0; i < this.removedSeries.Count; i++)
                {
                    var series = this.removedSeries[i];
                    if (object.Equals(tag, series.Tag))
                    {
                        this.removedSeries.RemoveAt(i);
                        this.dowJonesChart.Series.Add(series);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.dowJonesChart.Series.Count; i++)
                {
                    var series = (LineSeries)this.dowJonesChart.Series[i];
                    if (object.Equals(tag, series.Tag))
                    {
                        this.dowJonesChart.Series.RemoveAt(i);
                        this.removedSeries.Add(series);
                        break;
                    }
                }
            }
        }

        private void UpdateSeries()
        {
            DowJonesViewModel vm = this.DataContext as DowJonesViewModel;
            if (vm != null)
            {
                this.UpdateSeries("Low", vm.IsLowVisible);
                this.UpdateSeries("Open", vm.IsOpenVisible);
                this.UpdateSeries("Close", vm.IsCloseVisible);
                this.UpdateSeries("High", vm.IsHighVisible);
            }
        }
    }
}
