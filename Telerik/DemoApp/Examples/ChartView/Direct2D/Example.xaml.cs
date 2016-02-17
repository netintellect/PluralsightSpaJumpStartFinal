using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Charting;

namespace Telerik.Windows.Examples.ChartView.Direct2D
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

        private void OnTrackInfoUpdated(object sender, Controls.ChartView.TrackBallInfoEventArgs e)
        {
            if (e.Context.DataPointInfos.Count == 3)
            {
                CategoricalDataPoint dp1 = e.Context.DataPointInfos[0].DataPoint as CategoricalDataPoint;
                this.date.Text = ((DateTime)dp1.Category).ToString("MMM dd, yyyy");
                this.ibmCloseValue.Text = dp1.Value.Value.ToString("F2");
                this.msftCloseValue.Text = (e.Context.DataPointInfos[1].DataPoint as CategoricalDataPoint).Value.Value.ToString("F2");
                this.hpqCloseValue.Text = (e.Context.DataPointInfos[2].DataPoint as CategoricalDataPoint).Value.Value.ToString("F2");
            }
        }
    }
}
