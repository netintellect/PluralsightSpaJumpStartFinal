using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Model.Styles;
using Telerik.Windows.Examples.RichTextBox.Extensibility;
#if WPF
using Microsoft.Win32;
#endif

namespace Telerik.Windows.Examples.RichTextBox.StyleSheets
{
    public partial class Example : UserControl
    {
        #region Constants

        private const string DefaultStyleSheetPath = "SampleData/StyleSheetDefault.xaml";
        private const string CustomStyleSheetPath = "SampleData/StyleSheetDemo.xaml";

        #endregion

        #region Constructors

        static Example()
        {
            // This method is used only to work around limitations for using MEF in Examples.
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            InitializeComponent();
            this.ApplyThemeSpecificChanges();

            using (var stream = Application.GetResourceStream(GetResourceUri("SampleData/StyleSheetDemoDocument.xaml")).Stream)
            {
                this.editor.Document = new XamlFormatProvider().Import(stream);
            }
        }

        #endregion

        #region Methods

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }

        private void LoadStyleSheet_Click(object sender, RadRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xaml Files|*.xaml";
            if (ofd.ShowDialog() == true)
            {
#if WPF
                using (var stream = ofd.OpenFile())
#else
                using (var stream = ofd.File.OpenRead())
#endif
                {
                    Stylesheet stylesheet = XamlFormatProvider.LoadStylesheet(stream);
                    stylesheet.ApplyStylesheetToDocument(this.editor.Document);
                }
            }
        }

        private void SaveStyleSheet_Click(object sender, RadRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xaml Files|*.xaml";
            if (sfd.ShowDialog() == true)
            {
                using (var stream = sfd.OpenFile())
                {
                    Stylesheet stylesheet = new Stylesheet();
                    stylesheet.ExtractStylesheetFromDocument(this.editor.Document);
                    XamlFormatProvider.SaveStylesheet(stylesheet, stream);
                }
            }
        }

        private void LoadDefaultStyleSheet_Click(object sender, RoutedEventArgs e)
        {
            LoadStyleSheetFromResource(DefaultStyleSheetPath);
        }

        private void LoadCustomStyleSheet_Click(object sender, RoutedEventArgs e)
        {
            LoadStyleSheetFromResource(CustomStyleSheetPath);
        }

        private void LoadStyleSheetFromResource(string rsourcePath)
        {
            using (var stream = Application.GetResourceStream(GetResourceUri(rsourcePath)).Stream)
            {
                Stylesheet stylesheet = XamlFormatProvider.LoadStylesheet(stream);
                stylesheet.ApplyStylesheetToDocument(this.editor.Document);
            }
        }

        private void ApplyThemeSpecificChanges()
        {
            this.fontSizeComboBox.Width = ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch" ? 70 : 45;
            IconSources.ChangeIconsSet(IconsSet.Modern);
        }

        #endregion
    }
}