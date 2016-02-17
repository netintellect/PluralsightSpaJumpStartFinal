using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Documents.FormatProviders;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Examples.RichTextBox.Extensibility;

namespace Telerik.Windows.Examples.RichTextBox.CustomizePresentation
{
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/RadRichTextBoxCustomizePresentation.xaml";

        RadDocument radDocument;
        CustomLayersBuilder customLayersBuilder;

        static Example()
        {
            // Required only to work around limitations for using MEF in Examples
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            InitializeComponent();

            this.LoadRadDocument();
            this.customLayersBuilder = new CustomLayersBuilder() { HighlightCurrentWordLayer = true};
            
            // here we add our custom layer
            this.editor.UILayersBuilder = this.customLayersBuilder;
            this.checkBoxHighlightCurrentWord.IsChecked = true;
        }

        private void LoadRadDocument()
        {
            this.radDocument = this.ImportRadDocument(SampleDocumentPath);
            this.SetupNewDocument(this.radDocument);
            this.editor.Document = this.radDocument;
        }

        private RadDocument ImportRadDocument(string radDocumentPath)
        {
            RadDocument currentRadDocument;
            using (Stream stream = Application.GetResourceStream(GetResourceUri(radDocumentPath)).Stream)
            {
                IDocumentFormatProvider xamlProvider = DocumentFormatProvidersManager.GetProviderByExtension(".xaml");
                currentRadDocument = xamlProvider.Import(stream);
            }

            return currentRadDocument;
        }

        private void RecreateUI()
        {
            if (this.editor.ActiveEditorPresenter != null)
            {
                this.editor.ActiveEditorPresenter.RecreateUI();
                this.editor.UpdateEditorLayout();
            }
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(TelerikEditorExample).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);
            return resourceUri;
        }

        private void SetupNewDocument(RadDocument document)
        {
            document.LayoutMode = DocumentLayoutMode.Paged;
            document.ParagraphDefaultSpacingAfter = 10;
            document.SectionDefaultPageMargin = new Padding(40);
        }

        private void checkBoxHighlightCurrentWord_Checked(object sender, RoutedEventArgs e)
        {
            this.customLayersBuilder.HighlightCurrentWordLayer = true;
            this.RecreateUI();
        }

        private void checkBoxHighlightCurrentWord_Unchecked(object sender, RoutedEventArgs e)
        {
            this.customLayersBuilder.HighlightCurrentWordLayer = false;
            this.RecreateUI();
        }

        private void checkBoxHighlightCurrentLine_Checked(object sender, RoutedEventArgs e)
        {
            this.customLayersBuilder.HighlightCurrentLineLayer = true;
            this.RecreateUI();
        }

        private void checkBoxHighlightCurrentLine_Unchecked(object sender, RoutedEventArgs e)
        {
            this.customLayersBuilder.HighlightCurrentLineLayer = false;
            this.RecreateUI();
        }
    }
}
