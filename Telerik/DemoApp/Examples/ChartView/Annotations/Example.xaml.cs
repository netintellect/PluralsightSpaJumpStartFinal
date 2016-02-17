using System;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.Annotations
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void ClosestDataPointChanged(object sender, DataPointEventArgs e)
        {
            if (e.DataPoint != null)
            {
                this.date.Text = ((DateTime)(e.DataPoint.Category)).ToString("MMM dd, yyyy");
                this.price.Text = e.DataPoint.Value.Value.ToString("0,0.00");
            }
        }
    }
}
