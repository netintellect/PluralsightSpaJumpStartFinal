using System.IO;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Examples.RichTextBox.SampleData;

namespace Telerik.Windows.Examples.RichTextBox
{
    public partial class TelerikEditorExample : UserControl
    {
        public TelerikEditorExample()
        {
            InitializeComponent();

            this.ApplyThemeSpecificSettings();
        }

        public string CurrentTheme
        {
            get
            {
                return ApplicationThemeManager.GetInstance().CurrentTheme;
            }
        }

        public RadDocument RadDocument
        {
            get
            {
                return this.radRichTextBox.Document;
            }
            set
            {
                SetupNewDocument(value);
                this.radRichTextBox.Document = value;

                ExamplesDataContext dataContext = new ExamplesDataContext();

                this.radRichTextBox.Document.MailMergeDataSource.ItemsSource = dataContext.Employees;
                this.radRichTextBox.Users = dataContext.Users;
            }
        }

        private void SetupNewDocument(RadDocument document)
        {
            document.LayoutMode = DocumentLayoutMode.Paged;
            document.ParagraphDefaultSpacingAfter = 10;
            document.SectionDefaultPageMargin = new Padding(95);
        }

        private bool IsSupportedImageFormat(string extension)
        {
            if (extension != null)
            {
                extension = extension.ToLower();
            }

            return extension == ".jpg" ||
                extension == ".jpeg" ||
                extension == ".png" ||
                extension == ".bmp" ||
                extension == ".tif" ||
                extension == ".tiff" ||
                extension == ".ico" ||
                extension == ".gif" ||
                extension == ".wdp" ||
                extension == ".hdp";
        }

        private void ApplyThemeSpecificSettings()
        {
            switch (this.CurrentTheme)
            {
                case "Expression_Dark":
                case "VisualStudio2013_Dark":
                    IconSources.ChangeIconsSet(IconsSet.Dark);
                    break;
                case "Green_Dark":
                    IconSources.ChangeIconsSet(IconsSet.Dark);
                    break;
                case "Green_Light" :
                case "Office2013":
                case "Office2013_LightGray":
                case "Office2013_DarkGray":
                case "VisualStudio2013":
                case "VisualStudio2013_Blue":
                case "Windows8":
                case "Windows8Touch":
                    IconSources.ChangeIconsSet(IconsSet.Modern);
                    break;
                default:
                    IconSources.ChangeIconsSet(IconsSet.Light);
                    break;
            }

            this.fontSizeComboBox.Width = this.CurrentTheme == "Windows8Touch" ? 70 : 45;
        }

        private void radRichTextBox_Drop(object sender, DragEventArgs e)
        {
            string[] droppedFiles = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string droppedFile in droppedFiles)
            {
                string extension = System.IO.Path.GetExtension(droppedFile);
                if (IsSupportedImageFormat(extension))
                {
                    FileInfo file = new FileInfo(droppedFile);
                    using (Stream imageStream = file.OpenRead())
                    {
                        this.radRichTextBox.InsertImage(imageStream, extension);
                    }
                }
            }
        }

        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.ApplyThemeSpecificSettings();
        }
 
        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void Example_Unloaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }
    }
}