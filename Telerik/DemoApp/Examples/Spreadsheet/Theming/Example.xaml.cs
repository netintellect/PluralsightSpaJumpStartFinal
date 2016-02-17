using System;
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

namespace Telerik.Windows.Examples.Spreadsheet.Theming
{
    public partial class Example : UserControl
    {
        IRadSheetEditor activeSheetEditor;

        static Example()
        {
            WorkbookFormatProvidersManager.RegisterFormatProvider(new PdfFormatProvider());
            WorkbookFormatProvidersManager.RegisterFormatProvider(new XlsxFormatProvider());
        }

        public Example()
        {
            InitializeComponent();

            this.radSpreadsheet.Loaded += this.RadSpreadsheet_Loaded;
            this.radSpreadsheet.ActiveSheetEditorChanged += this.RadSpreadsheet_ActiveSheetEditorChanged;

            this.ApplyThemeSpecificSettings();
        }

        public string CurrentTheme
        {
            get
            {
                return ApplicationThemeManager.GetInstance().CurrentTheme;
            }
        }

        private void RadSpreadsheet_Loaded(object sender, RoutedEventArgs e)
        {
            this.radSpreadsheet.Focus();
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

        private void RadRibbonGroup_LaunchDialog(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            RadRibbonGroup group = (RadRibbonGroup)sender;
            this.activeSheetEditor.CommandDescriptors.ShowFormatCellsDialog.Command.Execute(group.Header);
        }

        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.ApplyThemeSpecificSettings();
        }

        private void ApplyThemeSpecificSettings()
        {
            switch (this.CurrentTheme)
            {
                case "Expression_Dark":
                case "VisualStudio2013_Dark":
                case "Green":
                case "Green_Dark":
                    IconSources.ChangeIconsSet(IconsSet.Dark);
                    break;

                default:
                    IconSources.ChangeIconsSet(IconsSet.Light);
                    break;
            }
        }

        private void ChangeScaleFactorIfTouchTheme()
        {
            this.radSpreadsheet.ActiveSheetEditor.ScaleFactor = this.CurrentTheme == "Windows8Touch" ? new Size(1.5, 1.5) : new Size(1, 1);
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }
    }
}