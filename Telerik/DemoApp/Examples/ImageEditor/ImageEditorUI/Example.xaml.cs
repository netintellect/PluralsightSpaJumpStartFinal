using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;
using Telerik.Windows.Media.Imaging.Tools;
using Telerik.Windows.Examples.ExampleHelpers;

namespace Telerik.Windows.Examples.ImageEditor.ImageEditorUI
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ImageExampleHelper.LoadSampleImage(this.ImageEditorUI, "RadImageEditor.png");
            this.ImageEditorUI.ImageEditor.ExecuteTool(new ResizeTool());
        }

    }
}
