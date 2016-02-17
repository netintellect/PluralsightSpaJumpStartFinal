using System;
using System.IO;
using System.Reflection;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Examples.RichTextBox.Extensibility;
using Telerik.Windows.Examples.RichTextBox.SampleData;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.RichTextBox.DocumentProtection
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        private const string SampleDocumentPath = "SampleData/RadRichTextBoxProtection.xaml";

        static Example()
        {
            // This method is used only to work around limitations for using MEF in Examples.
            ExamplesMefCatalogManager.ChangeDefaultMefCatalog();
        }

        public Example()
        {
            InitializeComponent();
            this.ApplyThemeSpecificChanges();

            ExamplesDataContext dataContext = new ExamplesDataContext();

            this.richTextBox.Users = dataContext.Users;
            this.comboBoxLoggedUser.ItemsSource = dataContext.CurrentUsers;
            this.comboBoxLoggedUser.SelectedIndex = 0;
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            using (Stream stream = Application.GetResourceStream(GetResourceUri(SampleDocumentPath)).Stream)
            {
                this.richTextBox.Document = new XamlFormatProvider().Import(stream);
            }
        }

        private Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(this.GetType().Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);
            return resourceUri;
        }

        private void comboBoxLoggedUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.richTextBox.CurrentUser = this.comboBoxLoggedUser.SelectedItem as UserInfo;
        }

        private void ApplyThemeSpecificChanges()
        {
            this.fontSizeComboBox.Width = ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch" ? 70 : 45;
            IconSources.ChangeIconsSet(IconsSet.Modern);
        }
    }
}