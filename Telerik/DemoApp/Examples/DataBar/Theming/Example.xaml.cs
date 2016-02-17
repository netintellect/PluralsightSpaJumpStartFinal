using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.DataBar.Theming
{
    public partial class Example : UserControl
    {
        public Example()
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

        private void ApplyThemeSpecificSettings()
        {
            if (this.CurrentTheme == "Expression_Dark")
            {
                this.Container.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x3D, 0x3D, 0x3D));
            }
#if WPF
            // WPF example not reloaded on theme change so we clear the local value.
            else
            {
                this.Container.ClearValue(BackgroundProperty);
            }
#endif
        }

        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.ApplyThemeSpecificSettings();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }
    }
}
