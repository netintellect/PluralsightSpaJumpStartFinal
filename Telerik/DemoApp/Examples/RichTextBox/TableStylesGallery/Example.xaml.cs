using System;
using System.Linq; 
using System.Reflection;
using System.Windows;
using System.Windows.Controls; 
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Examples.RichTextBox.Extensibility;

namespace Telerik.Windows.Examples.RichTextBox.TableStylesGallery
{
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/TableStylesGalleryDemo.xaml";
         
        static Example()
        {
            // Required only to work around limitations for using MEF in Examples
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            InitializeComponent();
            this.ApplyThemeSpecificChanges();
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }
         
        private void RadRichTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            using (var stream = Application.GetResourceStream(GetResourceUri(SampleDocumentPath)).Stream)
            {
                this.radRichTextBox.Document = new XamlFormatProvider().Import(stream);
            }
        }

        private void RadRichTextBox_DocumentChanged(object sender, EventArgs e)
        {
            if (this.radRichTextBox.Document != null)
            {
                Table table = this.radRichTextBox.Document.EnumerateChildrenOfType<Table>().FirstOrDefault();
                if (table != null)
                {
                    this.radRichTextBox.Document.CaretPosition.MoveToStartOfDocumentElement(table);
                }
            }
        }

        private void ApplyThemeSpecificChanges()
        {
            this.fontSizeComboBox.Width = ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch" ? 70 : 45;
            IconSources.ChangeIconsSet(IconsSet.Modern);
        }
    }
}
