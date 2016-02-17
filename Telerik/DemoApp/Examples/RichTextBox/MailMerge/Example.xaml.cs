using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.FormatProviders;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Examples.RichTextBox.Extensibility;
using Telerik.Windows.Examples.RichTextBox.MailMerge.HelperClasses;

namespace Telerik.Windows.Examples.RichTextBox.MailMerge
{
    public partial class Example : UserControl
    {

        #region Constants

        private const string SampleDocumentPath = "SampleData/RadRichTextBoxMailMerge.xaml";

        #endregion

        #region Fields

        private readonly ExampleDataContext exampleDataContext;

        #endregion

        #region Constructors

        static Example()
        {
            // This method is used only to work around limitations for using MEF in Examples.
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            this.InitializeComponent();

            IconSources.ChangeIconsSet(IconsSet.Modern);

            this.exampleDataContext = new ExampleDataContext();
            this.DataContext = this.exampleDataContext;

            this.radRichTextBox.DocumentChanging += RadRichTextBox_DocumentChanging;
            this.radRichTextBox.DocumentChanged += RadRichTextBox_DocumentChanged;
            this.radRichTextBox.Document = this.GetSampleDocument();

            this.exampleDataContext.SelectedMessageInfo = this.exampleDataContext.MailMessageInfos[0];
        }

        #endregion

        #region Methods

        private RadDocument GetSampleDocument()
        {
            IDocumentFormatProvider xamlProvider = new XamlFormatProvider();
            using (Stream stream = Application.GetResourceStream(GetResourceUri(SampleDocumentPath)).Stream)
            {
                return xamlProvider.Import(stream);
            }
        }

        private void RadRichTextBox_DocumentChanged(object sender, EventArgs e)
        {
            this.radRichTextBox.Document.MailMergeDataSource.ItemsSource = this.exampleDataContext.MailMessageInfos;
            this.radRichTextBox.Document.MailMergeDataSource.CurrentItemChanged += MailMergeDataSource_CurrentItemChanged;
        }

        private void RadRichTextBox_DocumentChanging(object sender, EventArgs e)
        {
            if (this.radRichTextBox.Document != null)
            {
                this.radRichTextBox.Document.MailMergeDataSource.CurrentItemChanged -= MailMergeDataSource_CurrentItemChanged;
            }
        }

        private void MailMergeDataSource_CurrentItemChanged(object sender, EventArgs e)
        {
            this.exampleDataContext.SelectedMessageInfo = this.radRichTextBox.Document.MailMergeDataSource.CurrentItem as MailMessageInfo;
        }

#if WPF
        private void MailMessageInfosListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateMailMergeFields();
        }
#else
        private void MailMessageInfosListBox_SelectionChanged(object sender, Controls.SelectionChangedEventArgs e)
        {
            this.UpdateMailMergeFields();
        }
#endif

        private void InsertPictureField_Click(object sender, RoutedEventArgs e)
        {
            MergeField mergeField = new MergeField();
            mergeField.PropertyPath = "RecipientPhoto";
            IncludePictureField pictureField = new IncludePictureField();
            pictureField.SetPropertyValue(IncludePictureField.ImageUriProperty, mergeField);
            this.radRichTextBox.InsertField(pictureField);
        }

        private void UpdateMailMergeFields()
        {
            MailMessageInfo info = this.exampleDataContext.SelectedMessageInfo;
            if (info != null)
            {
                int index = this.exampleDataContext.MailMessageInfos.IndexOf(info);
                this.radRichTextBox.Document.MailMergeDataSource.MoveToIndex(index);
                this.radRichTextBox.UpdateAllFields(FieldDisplayMode.Result);
            }
        }

        #endregion

        #region Helper Methods

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);
            return resourceUri;
        }

        #endregion

    }
}