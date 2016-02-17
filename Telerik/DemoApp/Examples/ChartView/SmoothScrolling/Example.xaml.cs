using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.ChartView.SmoothScrolling
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/ChartView;component/SmoothScrolling/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/ChartView;component/SmoothScrolling/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            InitializeComponent();
        }

        private void ChartTrackBallBehavior_TrackInfoUpdated(object sender, Controls.ChartView.TrackBallInfoEventArgs e)
        {
            DataPointInfo closestDataPoint = e.Context.ClosestDataPoint;
            if (closestDataPoint != null)
            {
                FinancialData data = closestDataPoint.DataPoint.DataItem as FinancialData;
                this.volume.Text = data.Volume.ToString("##,#");
                this.date.Text = data.Date.ToString("MMM dd, yyyy");
                this.price.Text = data.Close.ToString("0,0.00");
            }
        }
    }
}
