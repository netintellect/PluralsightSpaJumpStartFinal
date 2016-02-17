using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Spreadsheet.Worksheets;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Examples.Spreadsheet.Common;

namespace Telerik.Windows.Examples.Spreadsheet.Protection
{
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/BalanceSheet.xlsx";
        private RadWorksheetEditor worksheetEditor;

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

            this.radSpreadsheet.ThemesManager.CurrentFontScheme = radSpreadsheet.ThemesManager.BuiltInFontSchemes.First((scheme) => { return scheme.Name == "Angels"; });
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            this.radSpreadsheet.Focus();

            this.UpdateProtectButtonContent();
        }

        private void RadSpreadsheet_ActiveSheetEditorChanged(object sender, EventArgs e)
        {
            if(this.worksheetEditor != null)
            {
                this.worksheetEditor.Selection.ActiveCellModeChanged -= this.Selection_ActiveCellModeChanged;
                if (this.worksheetEditor.Worksheet != null)
                {
                    this.worksheetEditor.Worksheet.IsProtectedChanged -= this.Worksheet_IsProtectedChanged;
                }
            }

            this.worksheetEditor = this.radSpreadsheet.ActiveWorksheetEditor;

            if (this.worksheetEditor != null)
            {
                this.worksheetEditor.Selection.ActiveCellModeChanged += this.Selection_ActiveCellModeChanged;
                if (this.worksheetEditor.Worksheet != null)
                {
                    this.worksheetEditor.Worksheet.IsProtectedChanged += this.Worksheet_IsProtectedChanged;
                }
            }
        }

        private void Worksheet_IsProtectedChanged(object sender, EventArgs e)
        {
            this.UpdateProtectButtonContent();
        }

        private void Selection_ActiveCellModeChanged(object sender, EventArgs e)
        {
            this.UpdateProtectionOptionsIsEnabled();
        }

        private void ProtectSheet_Click(object sender, RoutedEventArgs e)
        {
            if (this.radSpreadsheet.Workbook.ActiveWorksheet.IsProtected)
            {
                bool requriesNoPassword = this.radSpreadsheet.Workbook.ActiveWorksheet.Unprotect(string.Empty);
                if (!requriesNoPassword)
                {
                    this.radSpreadsheet.ActiveWorksheetEditor.Commands.ShowUnprotectSheetDialog.Execute(null);
                }
            }
            else
            {
                this.radSpreadsheet.ActiveWorksheetEditor.Commands.ShowProtectSheetDialog.Execute(null);
            }
        }

        private void UpdateProtectionOptionsIsEnabled()
        {
            if (this.worksheetEditor != null)
            {
                bool enabled = this.radSpreadsheet.ActiveWorksheetEditor.Selection.ActiveCellMode == Controls.Spreadsheet.Worksheets.ActiveCellMode.Display;
                this.protectSheet.IsEnabled = enabled;
                this.saveSheet.IsEnabled = enabled;
            }
        }

        private void UpdateProtectButtonContent()
        {
            string content = "Protect Sheet";
            if(this.radSpreadsheet.Workbook.ActiveWorksheet.IsProtected)
            {
                content = "Unprotect Sheet";
            }

            this.protectSheet.Content = content;
        }

        private void SaveSheet_Click(object sender, RoutedEventArgs e)
        {
            if(this.worksheetEditor != null)
            {
                this.worksheetEditor.Commands.SaveFile.Execute(null);
            }
        }
    }
}
