using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Examples.RichTextBox.Extensibility;

namespace Telerik.Windows.Examples.RichTextBox.References
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        private const string FootnoteDocumentPath = "SampleData/ReferencesFootnote.xaml";
        private const string EndnoteDocumentPath = "SampleData/ReferencesEndnote.xaml";
        private const string BibliographyDocumentPath = "SampleData/ReferencesBibliography.xaml";

        static Example()
        {
            // This method is used only to work around limitations for using MEF in Examples.
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            InitializeComponent();
            this.ApplyThemeSpecificChanges();
            using (var stream = Application.GetResourceStream(GetResourceUri(FootnoteDocumentPath)).Stream)
            {
                this.editor.Document = new XamlFormatProvider().Import(stream);
            }
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }

        private void LoadDocument(string path)
        {
            using (var stream = Application.GetResourceStream(GetResourceUri(path)).Stream)
            {
                this.editor.Document = new XamlFormatProvider().Import(stream);
            }
        }

        private void loadFootnotes_Click(object sender, RoutedEventArgs e)
        {
            LoadDocument(FootnoteDocumentPath);
        }

        private void loadEndnotes_Click(object sender, RoutedEventArgs e)
        {
            LoadDocument(EndnoteDocumentPath);
        }

        private void loadBibliography_Click(object sender, RoutedEventArgs e)
        {
            LoadDocument(BibliographyDocumentPath);

        }

        private void ApplyThemeSpecificChanges()
        {
            this.fontSizeComboBox.Width = ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch" ? 70 : 45;
            IconSources.ChangeIconsSet(IconsSet.Modern);
        }
    }
}