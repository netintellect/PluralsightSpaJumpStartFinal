using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.FixedDocumentViewersUI.Dialogs;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.Fixed.UI.Extensibility;

namespace Telerik.Windows.Examples.PdfViewer.FirstLook
{
    public partial class Example : UserControl
    {
        private List<string> modernThemes;

        public string CurrentTheme
        {
            get
            {
                return ApplicationThemeManager.GetInstance().CurrentTheme;
            }
        }

        public Example()
        {
            ExtensibilityManager.RegisterFindDialog(new FindDialog());
            InitializeComponent();
           
            this.AddThemes();
            this.ApplyThemeSpecificSettings();
        }

        private void AddThemes()
        {
            this.modernThemes = new List<string>();

            this.modernThemes.Add("Windows8");
            this.modernThemes.Add("Windows8Touch");
            this.modernThemes.Add("Office2013");
            this.modernThemes.Add("Office2013_LightGray");
            this.modernThemes.Add("Office2013_DarkGray");
            this.modernThemes.Add("VisualStudio2013");
            this.modernThemes.Add("VisualStudio2013_Blue");
            this.modernThemes.Add("VisualStudio2013_Dark");
        }

        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.ApplyThemeSpecificSettings();
        }

        private void ApplyThemeSpecificSettings()
        {
            if (this.modernThemes.Contains(this.CurrentTheme))
            {
                IconSources.ChangeIconsSet(IconsSet.Modern);
            }
            else
            {
                IconSources.ChangeIconsSet(IconsSet.Light);
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }

        private void tbCurrentPage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
        }
    }
}