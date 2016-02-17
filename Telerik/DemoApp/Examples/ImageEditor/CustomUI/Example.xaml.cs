using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Telerik.Windows.Examples.ExampleHelpers;

namespace Telerik.Windows.Examples.ImageEditor.CustomUI
{
    public partial class Example : UserControl
    {
        private Storyboard FadeIn;
        private Storyboard FadeOut;

        public Example()
        {
            InitializeComponent();

            this.FadeIn = (Storyboard)this.LayoutRoot.Resources["FadeIn"];
            this.FadeOut = (Storyboard)this.LayoutRoot.Resources["FadeOut"];

            this.imageEditor.ToolSettingsContainer = this.settingsContainer;

            ImageExampleHelper.LoadSampleImage(this.imageEditor, "CustomUIImage.jpg");
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.FadeOut.Stop();
            this.FadeIn.Begin();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.FadeIn.Stop();
            this.FadeOut.Begin();
        }
    }
}
