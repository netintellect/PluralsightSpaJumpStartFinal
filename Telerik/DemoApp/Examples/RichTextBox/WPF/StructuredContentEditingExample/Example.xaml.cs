using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Examples.RichTextBox.Extensibility;

namespace Telerik.Windows.Examples.RichTextBox.StructuredContentEditing
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl, INotifyPropertyChanged
    {
        #region Constants

        private const int RefreshInterval = 1;

        private const string FirstDocumentPath = "SampleData/Recipe1.xaml";
        private const string SecondDocumentPath = "SampleData/Recipe2.xaml";
        private const string ThirdDocumentPath = "SampleData/Recipe3.xaml";
        private const string FourthDocumentPath = "SampleData/Recipe4.xaml";

        private const string Recipe1ImagePath = @"Images/RichTextBox/StructuredContentEditing/recipe1.jpg";
        private const string Recipe2ImagePath = @"Images/RichTextBox/StructuredContentEditing/recipe2.jpg";
        private const string Recipe3ImagePath = @"Images/RichTextBox/StructuredContentEditing/recipe3.jpg";
        private const string Recipe4ImagePath = @"Images/RichTextBox/StructuredContentEditing/recipe4.jpg";

        #endregion

        #region Fields

        private bool hasRadRichTextBoxChanged;
        private bool hasMSRichTextBoxChanged;

        private Uri imageSource;

        #endregion

        #region Properties

        private DocumentInfo[] GetSampleDocumentsInfos()
        {
            return new DocumentInfo[] 
            {
                new DocumentInfo("Tiramisu Cake", GetResourceUri(FirstDocumentPath), FirstDocumentPath, Recipe1ImagePath),
                new DocumentInfo("Roasted Salmon", GetResourceUri(SecondDocumentPath), SecondDocumentPath,Recipe2ImagePath),
                new DocumentInfo("Pommes Frites", GetResourceUri(ThirdDocumentPath), ThirdDocumentPath, Recipe3ImagePath),
                new DocumentInfo("Italian Meatballs", GetResourceUri(FourthDocumentPath), FourthDocumentPath, Recipe4ImagePath),
            };
        }

        public string CurrentRecipe { get; set; }

        public Uri ImageSource
        {
            get { return this.imageSource; }
            set
            {
                if (this.imageSource != value)
                {
                    this.imageSource = value;
                    this.OnPropertyChanged("ImageSource");
                }
            }
        }

        #endregion

        #region Constructors

        static Example()
        {
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            InitializeComponent();
            IconSources.ChangeIconsSet(IconsSet.Modern);

            InitializeData();

            AttachEvents();
        }

        #endregion

        #region Methods

        private void InitializeData()
        {
            this.hasRadRichTextBoxChanged = false;
            this.hasMSRichTextBoxChanged = false;

            this.CurrentRecipe = FirstDocumentPath;
            this.ImageSource = GetResourceUri(Recipe1ImagePath);
            this.tabControl.DataContext = GetSampleDocumentsInfos();
            this.listBox_documents.ItemsSource = GetSampleDocumentsInfos();
            this.listBox_documents.SelectedIndex = 0;

            this.UserControl.DataContext = this;
        }

        private void AttachEvents()
        {
            this.listBox_documents.SelectionChanged += ListBox_documents_SelectionChanged;
            this.textBox.TextChanged += TextBox_TextChanged;

            this.tabControl.SelectionChanged += RadTabControl_SelectionChanged;

            this.richTextBox.DocumentChanged += Editor_DocumentChanged;
            this.richTextBox.DocumentContentChanged += Document_DocumentContentChanged;
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);
            return resourceUri;
        }

        private void Document_DocumentContentChanged(object sender, EventArgs e)
        {
            this.hasRadRichTextBoxChanged = true;
            this.hasMSRichTextBoxChanged = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.hasMSRichTextBoxChanged = true;
            this.hasRadRichTextBoxChanged = false;
        }

        private void ListBox_documents_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.hasRadRichTextBoxChanged = false;
            this.hasMSRichTextBoxChanged = false;

            this.CurrentRecipe = ((DocumentInfo)listBox_documents.SelectedItem).Path;
            DocumentInfo documentInfo = (DocumentInfo)this.listBox_documents.SelectedItem;

            using (Stream stream = Application.GetResourceStream(documentInfo.Uri).Stream)
            {
                this.richTextBox.Document = new XamlFormatProvider().Import(stream);
            }

            this.ImageSource = GetResourceUri(documentInfo.ImagePath);

            this.textBox.Text = new HRecipeFormatProvider().ExportCustomAnnotationsToHtml(this.richTextBox.Document);
            this.webBrowser.NavigateToString(this.textBox.Text);
        }

        private void Editor_DocumentChanged(object sender, EventArgs e)
        {
            this.textBox.Text = new HRecipeFormatProvider().ExportCustomAnnotationsToHtml(this.richTextBox.Document);
        }

        private void RadTabControl_SelectionChanged(object sender, Telerik.Windows.Controls.RadSelectionChangedEventArgs e)
        {
            int currentlySelected = this.tabControl.Items.IndexOf(e.AddedItems[0]);

            if (currentlySelected == 0)
            {
                DocumentInfo documentInfo = (DocumentInfo)this.listBox_documents.SelectedItem;
                if (hasMSRichTextBoxChanged)
                {
                    this.richTextBox.Document = new HRecipeFormatProvider().ImportHtmlToDocument(this.textBox.Text, documentInfo);
                    this.richTextBox.Document.CaretPosition.MoveToFirstPositionInDocument();
                }
                else if (!hasRadRichTextBoxChanged)
                {
                    using (Stream stream = Application.GetResourceStream(documentInfo.Uri).Stream)
                    {
                        this.richTextBox.Document = new XamlFormatProvider().Import(stream);
                    }
                }
            }
            else if (currentlySelected == 1)
            {
                if (this.hasRadRichTextBoxChanged)
                {
                    this.textBox.Text = new HRecipeFormatProvider().ExportCustomAnnotationsToHtml(this.richTextBox.Document);
                }
            }
            else if (currentlySelected == 2)
            {
                if (this.hasRadRichTextBoxChanged == true)
                {
                    this.textBox.Text = new HRecipeFormatProvider().ExportCustomAnnotationsToHtml(this.richTextBox.Document);
                }
                this.webBrowser.NavigateToString(this.textBox.Text);
            }
        }

        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.fontSizeComboBox.Width = ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch" ? 70 : 45;
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void Example_Unloaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}