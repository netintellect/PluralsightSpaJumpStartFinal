using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Documents.FormatProviders;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Examples.RichTextBox.Extensibility;

namespace Telerik.Windows.Examples.RichTextBox.TelerikEditor
{
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/RadRichTextBox.xaml";

        private RadDocument radDocument;

        static Example()
        {
            // Required only to work around limitations for using MEF in Examples
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            InitializeComponent();

            using (Stream stream = Application.GetResourceStream(GetResourceUri(SampleDocumentPath)).Stream)
            {
                IDocumentFormatProvider xamlProvider = DocumentFormatProvidersManager.GetProviderByExtension(".xaml");
                this.radDocument = xamlProvider.Import(stream);
            }

            this.exampleWindow.RadDocument = this.radDocument;
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(TelerikEditorExample).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }
    }
}
