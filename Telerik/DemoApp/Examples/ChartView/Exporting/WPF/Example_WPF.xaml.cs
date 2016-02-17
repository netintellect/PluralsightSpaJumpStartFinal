using System.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.Exporting
{
    public partial class Example : UserControl
    {
        private void Print()
        {
            PrintDialog dialog = new PrintDialog();
            if (!(bool)dialog.ShowDialog())
            {
                return;
            }

            dialog.PrintVisual(this.chart, "MyDocument");
        }
    }
}
