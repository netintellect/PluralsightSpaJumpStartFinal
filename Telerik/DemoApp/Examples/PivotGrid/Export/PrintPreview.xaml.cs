using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.FormatProviders;
using Telerik.Windows.Documents.FormatProviders.Html;
using Telerik.Windows.Documents.FormatProviders.OpenXml.Docx;
using Telerik.Windows.Documents.FormatProviders.Pdf;
using Telerik.Windows.Documents.Model;

namespace Telerik.Windows.Examples.PivotGrid.Export
{
    /// <summary>
    /// Interaction logic for PrintPreview.xaml
    /// </summary>
    public partial class PrintPreview : UserControl
    {
        private IDocumentFormatProvider provider { get; set; }
        private RadDocument document { get; set; }

        public PrintPreview(RadDocument document, IDocumentFormatProvider provider)
        {
            InitializeComponent();
            this.document = document;
            this.provider = provider;

            this.RichTextBox.Document = this.document;
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            IDocumentFormatProvider provider = this.provider;
            SaveFileDialog dialog = new SaveFileDialog();

            if ((provider as DocxFormatProvider) != null)
            {
                dialog.DefaultExt = "docx";
                dialog.Filter = "Word document (docx) | *.docx |All Files (*.*) | *.*";
            }
            else if ((provider as PdfFormatProvider) != null)
            {
                dialog.DefaultExt = "pdf";
                dialog.Filter = "Pdf document (pdf) | *.pdf |All Files (*.*) | *.*";
            }
            else if ((provider as HtmlFormatProvider) != null)
            {
                dialog.DefaultExt = "html";
                dialog.Filter = "Html document (html) | *.html |All Files (*.*) | *.*";
            }
            else
            {
                MessageBox.Show("Unknown output format!");
                return;
            }
            
            SaveFile(dialog, provider, document);
            (this.Parent as RadWindow).Close();
        }

        private static void SaveFile(SaveFileDialog dialog, IDocumentFormatProvider provider, RadDocument document)
        {
            var result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    using (var stream = dialog.OpenFile())
                    {
                        provider.Export(document, stream);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as RadWindow).Close();
        }

        
    }
}
