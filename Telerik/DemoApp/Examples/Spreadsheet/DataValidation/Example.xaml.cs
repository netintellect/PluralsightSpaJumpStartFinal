using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Examples.Spreadsheet.Common;

namespace Telerik.Windows.Examples.Spreadsheet.DataValidation
{
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/MonthlyReport.xlsx";

        static Example()
        {
            WorkbookFormatProvidersManager.RegisterFormatProvider(new PdfFormatProvider());
            WorkbookFormatProvidersManager.RegisterFormatProvider(new XlsxFormatProvider());
        }

        public Example()
        {
            InitializeComponent();

            using (var stream = Application.GetResourceStream(FileHelper.GetResourceUri(SampleDocumentPath, typeof(Example))).Stream)
            {
                this.radSpreadsheet.Workbook = new XlsxFormatProvider().Import(stream);
            }

            this.Loaded += this.Example_Loaded;
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            this.radSpreadsheet.Focus();
        }

        private void CircleInvalidData(object sender, RoutedEventArgs e)
        {
            this.radSpreadsheet.ActiveWorksheetEditor.CircleInvalidData();
        }

        private void ClearInvalidDataCircles(object sender, RoutedEventArgs e)
        {
            this.radSpreadsheet.ActiveWorksheetEditor.ClearInvalidDataCircles();
        }
    }
}