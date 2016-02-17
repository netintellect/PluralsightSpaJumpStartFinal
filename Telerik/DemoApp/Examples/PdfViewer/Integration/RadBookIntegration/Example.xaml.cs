using System;
using System.IO;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed.FormatProviders;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model;
#if WPF
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
#endif

namespace Telerik.Windows.Examples.PdfViewer.Integration.RadBookIntegration
{
    public partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            this.dialog = new OpenFileDialog();
            this.dialog.Filter = "PDF Files (*.pdf)|*.pdf";
            this.documentStream = App.GetResourceStream(new Uri("/PdfViewer;component/SampleData/Book.pdf", UriKind.Relative)).Stream;
            RadFixedDocument doc = new PdfFormatProvider(this.documentStream, FormatProviderSettings.ReadOnDemand).Import();
            this.book.ItemsSource = doc.Pages;
        }

        private OpenFileDialog dialog;
        private Stream documentStream;

        private void CloseStream()
        {
            if (this.documentStream != null)
            {
                this.documentStream.Close();
                this.documentStream.Dispose();
            }
        }

        private void Open_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.dialog.ShowDialog() == true)
            {
                this.CloseStream();
#if SILVERLIGHT
                this.documentStream = this.dialog.File.OpenRead();
#elif WPF
                this.documentStream = this.dialog.OpenFile();
#endif
                RadFixedDocument doc = new PdfFormatProvider(this.documentStream, FormatProviderSettings.ReadOnDemand).Import();
                this.book.ItemsSource = doc.Pages;
            }
        }
    }
}
