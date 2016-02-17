using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Spreadsheet;
using Telerik.Windows.Controls.Spreadsheet.Commands;
using Telerik.Windows.Controls.Spreadsheet.Utilities;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Examples.Spreadsheet.Common;

namespace Telerik.Windows.Examples.Spreadsheet.Printing
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        IRadSheetEditor activeSheetEditor;
        private const string SampleDocumentPath = "SampleData/Printing.xlsx";

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

            this.radSpreadsheet.ActiveSheetEditorChanged += this.RadSpreadsheet_ActiveSheetEditorChanged;
            this.Loaded += this.Example_Loaded;
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            this.radSpreadsheet.Focus();
            IconSources.ChangeIconsSet(IconsSet.Light);
        }

        private void RadSpreadsheet_ActiveSheetEditorChanged(object sender, EventArgs e)
        {
            if (this.activeSheetEditor != null)
            {
                this.activeSheetEditor.UICommandExecuted -= this.ActiveSheetEditor_UICommandExecuted;
            }

            this.activeSheetEditor = this.radSpreadsheet.ActiveSheetEditor;
            if (this.activeSheetEditor != null)
            {
                this.activeSheetEditor.UICommandExecuted += this.ActiveSheetEditor_UICommandExecuted;
            }
        }

        private void ActiveSheetEditor_UICommandExecuted(object sender, UICommandExecutedEventArgs e)
        {
            if (!this.radSpreadsheet.IsKeyboardFocusWithin())
            {
                this.radSpreadsheet.Focus();
            }
        }
    }
}