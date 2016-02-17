using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.FormatProviders.OpenXml.Docx;

namespace Telerik.Windows.Examples.RichTextBox.RepeatHeaderRows
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/RepeatHeaderRows.docx";

        public Example()
        {
            InitializeComponent();

            IconSources.ChangeIconsSet(IconsSet.Modern);
        }

        private void RadRichTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            using (Stream stream = Application.GetResourceStream(GetResourceUri(SampleDocumentPath)).Stream)
            {
                DocxFormatProvider provider = new DocxFormatProvider();
                this.radRichTextBox.Document = provider.Import(stream);
            }
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