using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.Fixed;
using Telerik.Windows.Documents.FormatProviders;
using Telerik.Windows.Documents.FormatProviders.Pdf;
using Telerik.Windows.Examples.RichTextBox.Extensibility;

namespace Telerik.Windows.Examples.RichTextBox.Integration.PdfViewerIntegration
{
    public partial class Example : UserControl
    {
        #region Constants

        private const string DefaultSampleDocument = "SampleData/RadRichTextBoxPdfViewerIntegration.xaml";
        private const int RefreshInterval = 1;

        #endregion


        #region Fields

        private readonly PdfFormatProvider providerPdf;

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

            this.providerPdf = new PdfFormatProvider();

            this.LoadSampleDocument();
            this.UpdatePdfViewer();
            this.DataContext = new Context() { Uri = GetResourceUri(DefaultSampleDocument).OriginalString };
        }

        public class Context
        {
            public string Uri { get; set; }
        }

        #endregion


        #region Methods

        public void LoadSampleDocument()
        {
            using (Stream stream = Application.GetResourceStream(GetResourceUri(DefaultSampleDocument)).Stream)
            {
                IDocumentFormatProvider xamlProvider = DocumentFormatProvidersManager.GetProviderByExtension(".xaml");
                this.radRichTextBox.Document = xamlProvider.Import(stream);
                this.radRichTextBox.Document.DocumentContentChangedInterval = TimeSpan.FromSeconds(RefreshInterval);
                this.radRichTextBox.Document.DocumentContentChanged += new EventHandler(Document_DocumentContentChanged);
            }
        }

        private void Document_DocumentContentChanged(object sender, EventArgs e)
        {
            this.UpdatePdfViewer();
        }

        private void UpdatePdfViewer()
        {
            MemoryStream outputStream = new MemoryStream();
            this.providerPdf.Export(this.radRichTextBox.Document, outputStream);
            this.radRichTextBox.UpdateEditorLayout();
            this.pdfViewer.DocumentSource = new PdfDocumentSource(outputStream);
            this.pdfViewer.DocumentSource.Loaded += (s, e) => { outputStream.Close(); };
        }

        private void ApplyThemeSpecificChanges()
        {
            this.fontSizeComboBox.Width = ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch" ? 70 : 45;
            IconSources.ChangeIconsSet(IconsSet.Modern);
        }

        #endregion


        #region Helper methods

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);
            return resourceUri;
        }

        #endregion


        #region EventHandlers

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

        #endregion
    }
}
