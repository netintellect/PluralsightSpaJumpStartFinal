using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Examples.ExampleHelpers;
using Telerik.Windows.Media.Imaging.Tools;

namespace Telerik.Windows.Examples.ImageEditor.CustomTool
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            ImageExampleHelper.LoadSampleImage(this.imageEditor, "RadImageEditor.png");
            this.imageEditor.ImageEditor.ExecuteTool(this.LayoutRoot.Resources["WatermarkTool"] as ITool);
        }
    }
}
