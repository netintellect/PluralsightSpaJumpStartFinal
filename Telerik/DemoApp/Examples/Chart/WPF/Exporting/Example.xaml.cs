using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.Chart.Exporting
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

            this.BindConfigurationPanel();
            RadChart1.DataBound += new System.EventHandler<Controls.Charting.ChartDataBoundEventArgs>(RadChart1_DataBound);
        }

        void RadChart1_DataBound(object sender, Controls.Charting.ChartDataBoundEventArgs e)
        {
            string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", };
            for (int i = 0; i < months.Length; i++)
            {
                RadChart1.DefaultView.ChartArea.AxisX.TickPoints[i].Label = months[i];
            }
        }

        protected Panel ConfigurationPanel
        {
            get
            {
                return QuickStart.GetConfigurationPanel(this);
            }
        }

        private void BindConfigurationPanel()
        {
            if (this.ConfigurationPanel.DataContext == null)
            {
                this.ConfigurationPanel.DataContext = this.DataContext;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (BrowserInteropHelper.IsBrowserHosted)
            {
                MessageBox.Show("No permission to export images in XBAP.");
                return;
            }

            SaveFileDialog dialog = PrepareSaveDialog();

            if (!(bool)dialog.ShowDialog())
                return;

            string fileName = dialog.FileName;
            this.ExportTheFile(fileName);
        }

        private void ExportTheFile(string fileName)
        {
            switch (ExportFormat.SelectedItem.ToString())
            {
                case "PNG":
                    RadChart1.Save(fileName, 96d, 96d, new PngBitmapEncoder());
                    break;

                case "BMP":
                    RadChart1.Save(fileName, 96d, 96d, new BmpBitmapEncoder());
                    break;

                case "XLSX":
                    RadChart1.ExportToExcelML(fileName);
                    break;

                case "XPS":
                    RadChart1.ExportToXps(fileName);
                    break;

                default:
                    RadChart1.Save(fileName, 96d, 96d, new PngBitmapEncoder());
                    break;
            }
        }

        private SaveFileDialog PrepareSaveDialog()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = ExportFormat.SelectedItem.ToString().ToLower();
            dialog.Filter = this.GetDefaulExt();
            return dialog;
        }

        private string GetDefaulExt()
        {
            return string.Format("*.{0} | {1} File", ExportFormat.SelectedItem.ToString().ToLower(), ExportFormat.SelectedItem.ToString());
        }
	}
}
