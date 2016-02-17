using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Controls.Spreadsheet;
using Telerik.Windows.Controls.Spreadsheet.Commands;
using Telerik.Windows.Controls.Spreadsheet.Utilities;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Examples.Spreadsheet.Common;

namespace Telerik.Windows.Examples.Spreadsheet.FirstLook
{
    public partial class Example : UserControl
    {
        IRadSheetEditor activeSheetEditor;
        private const string SampleDocumentPath = "SampleData/FoodOrder.xlsx";

        public string CurrentTheme
        {
            get
            {
                return ApplicationThemeManager.GetInstance().CurrentTheme;
            }
        }

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
                this.ChangeScaleFactorIfTouchTheme();            
            }
        }

        private void ActiveSheetEditor_UICommandExecuted(object sender, UICommandExecutedEventArgs e)
        {
            if (!this.radSpreadsheet.IsKeyboardFocusWithin())
            {
                this.radSpreadsheet.Focus();
            }
        }

        private void ChangeScaleFactorIfTouchTheme()
        {
            this.radSpreadsheet.ActiveSheetEditor.ScaleFactor = this.CurrentTheme == "Windows8Touch" ? new Size(1.5, 1.5) : new Size(1, 1);
        }
        
        private void RadRibbonGroup_LaunchDialog(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            RadRibbonGroup group = (RadRibbonGroup)sender;
            this.activeSheetEditor.CommandDescriptors.ShowFormatCellsDialog.Command.Execute(group.Header);
        }
    }
}