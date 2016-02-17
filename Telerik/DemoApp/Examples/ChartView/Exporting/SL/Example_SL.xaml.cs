using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Printing;

namespace Telerik.Windows.Examples.ChartView.Exporting
{
    public partial class Example : UserControl
    {
        private void Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += this.OnPrintPage;
            pd.Print("MyDocument");
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            ScaleTransform transform = new ScaleTransform();
            transform.ScaleX = e.PrintableArea.Width / this.chart.ActualWidth;
            transform.ScaleY = transform.ScaleX;
            this.chart.RenderTransform = transform;
            e.PageVisual = this.chart;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                this.chart.RenderTransform = null;
            }));
        }
    }
}
