using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.FormatProviders.OpenXml.Docx;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Media.Imaging;

namespace Telerik.Windows.Examples.ChartView.Exporting
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

#if SILVERLIGHT
            this.chart.FontFamily = new System.Windows.Media.FontFamily("Times New Roman");
#endif

            this.filterDictionary = new Dictionary<string, string>();
            this.filterDictionary.Add("PDF", "Adobe PDF Document (*.pdf)|*.pdf");
            this.filterDictionary.Add("PNG", "PNG Images (*.png)|*.png");
            this.filterDictionary.Add("WORD", "Word Documents (*.docx)|*.docx");
            this.filterDictionary.Add("EXCEL", "Excel Worksheets (*.xlsx)|*.xlsx");

            this.typeCombo.SelectedIndex = 0;

            this.columnInfos = new List<ColumnInfo>
            {
                new ColumnInfo("Country Name", stats => stats.CountryName),
                new ColumnInfo("Gold", stats => stats.Gold.ToString()),
                new ColumnInfo("Silver", stats => stats.Silver.ToString()),
                new ColumnInfo("Bronze", stats => stats.Bronze.ToString()),
                new ColumnInfo("Total", stats => stats.Total.ToString()),
            };
        }

        private Dictionary<string, string> filterDictionary;

        private List<ColumnInfo> columnInfos;

        private void OnExportButtonClicked(object sender, RoutedEventArgs e)
        {
            RadComboBoxItem selectedItem = this.typeCombo.SelectedItem as RadComboBoxItem;
            if (selectedItem == null)
            {
                return;
            }

            string selectedFormat = selectedItem.Content as string;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = this.filterDictionary[selectedFormat];
            if (!(bool)dialog.ShowDialog())
            {
                return;
            }

            using (Stream fileStream = dialog.OpenFile())
            {
                if (selectedFormat == "PDF")
                {
                    this.ExportToPdf(fileStream);
                }
                else if (selectedFormat == "PNG")
                {
                    this.ExportPNGToImage(this.chart, fileStream);
                }
                else if (selectedFormat == "WORD")
                {
                    this.ExportToWord(fileStream);
                }
                else if (selectedFormat == "EXCEL")
                {
                    Telerik.Windows.Media.Imaging.ExportExtensions.ExportToExcelMLImage(this.chart, fileStream);
                }
            }
        }

        private void OnPrintButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Print();
        }

        private void ExportPNGToImage(FrameworkElement element, Stream stream)
        {
            Telerik.Windows.Media.Imaging.ExportExtensions.ExportToImage(element, stream, new PngBitmapEncoder());
        }

        private void ExportToWord(Stream fileStream)
        {
            RadDocument document = new RadDocument();
            this.CreateChartDocumentPart(document);
            this.PrepareDocument(document);
            DocxFormatProvider provider = new DocxFormatProvider();
            provider.Export(document, fileStream);
        }

        private void PrepareDocument(RadDocument document)
        {
            document.LayoutMode = DocumentLayoutMode.Paged;
            document.Measure(RadDocument.MAX_DOCUMENT_SIZE);
            document.Arrange(new RectangleF(PointF.Empty, document.DesiredSize));
        }

        private void CreateChartDocumentPart(RadDocument document)
        {
            Section section = new Section();
            Paragraph paragraph = new Paragraph();

            using (MemoryStream ms = new MemoryStream())
            {
                this.ExportPNGToImage(this.chart, ms);

                double imageWidth = this.chart.ActualWidth;
                double imageHeight = this.chart.ActualHeight;

                if (imageWidth > 625)
                {
                    imageWidth = 625;
                    imageHeight = this.chart.ActualHeight * imageWidth / this.chart.ActualWidth;
                }

                ImageInline image = new ImageInline(ms, new Size(imageWidth, imageHeight), "png");

                paragraph.Inlines.Add(image);
                section.Blocks.Add(paragraph);
                document.Sections.Add(section);
            }
        }

        private void ExportToPdf(Stream fileStream)
        {
            RadFixedDocument document = new RadFixedDocument();
            document.Pages.Add(this.CreateChartPdfPage(this.chart));
            PdfFormatProvider provider = new PdfFormatProvider();
            provider.Export(document, fileStream);
        }

        private RadFixedPage CreateChartPdfPage(RadCartesianChart chart)
        {
            int margin = 20;
            var page = new RadFixedPage();
            page.Size = new Size(chart.ActualWidth + 2 * margin, chart.ActualHeight + 2 * margin);
            var editor = new FixedContentEditor(page, Telerik.Windows.Documents.Fixed.Model.Data.MatrixPosition.Default);

            using (editor.SavePosition())
            {
                editor.Position.Translate(margin, margin);

                // check out the ExportUIElement SDK sample of the PdfProcessing for more details
                // https://github.com/telerik/xaml-sdk/tree/master/PdfProcessing/ExportUIElement
                ExportUIElement.ExportHelper.ExportToPdf(chart, editor);
            }

            return page;
        }

        private class ColumnInfo
        {
            internal string Header;
            internal Func<OlympicStatisticsReport, string> GetValue;

            internal ColumnInfo(string header, Func<OlympicStatisticsReport, string> valueGetter)
            {
                this.Header = header;
                this.GetValue = valueGetter;
            }
        }
    }
}
