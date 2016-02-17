using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ContextMenu.DropDownButtonIntegration
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void OnSizeButtonClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            var radmenuItem = sender as RadMenuItem;
            ellipse.Height = ellipse.Width = Math.Pow(radmenuItem.IconColumnWidth, 2) / 10;
        }

        private void OnSetButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.EllipseBrush.Color = this.ColorEditor.SelectedColor;
        }

        private void OnColorEditorLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ColorEditor.SelectedColor = this.EllipseBrush.Color;
        }
    }
}
