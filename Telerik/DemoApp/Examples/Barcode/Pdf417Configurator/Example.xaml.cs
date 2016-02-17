using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Controls;
using Telerik.Windows.Media.Imaging;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Barcode.Pdf417Configurator
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Barcode;component/Pdf417Configurator/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Barcode;component/Pdf417Configurator/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            ExportPDF417(this.PDF417Code);
        }

        private void ExportPDF417(RadBarcodePDF417 PDF417Code)
        {
            string extension = "png";
            SaveFileDialog dialog = new SaveFileDialog()
            {
                DefaultExt = extension,
#if WPF 
                FileName = "PDF417Code",
#elif SILVERLIGHT
                DefaultFileName = "PDF417Code",
#endif
                Filter = "Png (*.png)|*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                using (Stream stream = dialog.OpenFile())
                {
                    ExportExtensions.ExportToImage(PDF417Code, stream, new PngBitmapEncoder());
                }
            }
        }
    }
}
