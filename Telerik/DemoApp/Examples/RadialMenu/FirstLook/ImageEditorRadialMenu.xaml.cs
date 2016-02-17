using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RadialMenu.FirstLook
{
    /// <summary>
    /// Interaction logic for ImageEditorRadialMenu.xaml
    /// </summary>
    public partial class ImageEditorRadialMenu : RadRadialMenu
    {
        public ImageEditorRadialMenu()
        {
            InitializeComponent();
        }

        private void OnRadRadialMenuNavigated(object sender, RadRoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void OnRadRadialMenuItemClick(object sender, RadRoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void OnRadialMenuClosed(object sender, RadRoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }
    }
}