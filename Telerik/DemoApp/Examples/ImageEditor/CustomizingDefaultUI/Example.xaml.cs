using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.ExampleHelpers;

namespace Telerik.Windows.Examples.ImageEditor.CustomizingDefaultUI
{
    public partial class Example : UserControl
    {
        public ObservableCollection<ImageToolViewModel> toolsCollection;

        public Example()
        {
            InitializeComponent();

            this.toolsCollection = ImageToolViewModel.GetAllTools();

            this.Tools.ItemsSource = this.toolsCollection;
            this.UpdateToolsSection();

            ImageExampleHelper.LoadSampleImage(this.radImageEditor, "RadImageEditor.png");
        }

        private void changeTools_Click(object sender, RoutedEventArgs e)
        {
            this.UpdateToolsSection();
        }
  
        private void UpdateToolsSection()
        {
            ImageToolsSection section = new ImageToolsSection();
            section.Header = "Tools";
            foreach (ImageToolViewModel tool in toolsCollection)
            {
                if (tool.IsSelected)
                {
                    section.Items.Add(tool.Item);
                }
            }
            this.radImageEditor.ImageToolsSections.Clear();
            this.radImageEditor.ImageToolsSections.Add(section);
        }
    }
}
