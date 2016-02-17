using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.BulletGraph.Theming
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
            SolidColorBrush background = null;
            SolidColorBrush foreground = null;

            if (this.CurrentTheme == "Expression_Dark")
            {
                //The same background as the one of GridView
                background = new SolidColorBrush(Color.FromArgb(0xFF, 0x3D, 0x3D, 0x3D));
                foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xDD, 0xDD, 0xDD));
            }
            else if (this.CurrentTheme == "VisualStudio2013_Dark")
            {
                //The same background as the one of GridView
                background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x1E, 0x1E));
                foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xF1, 0xF1, 0xF1));
            }

            if (background != null)
            {
                this.Container.Background = background;
            }
#if WPF
            // WPF example not reloaded on theme change so we clear the local value.
            else
            {
                this.Container.ClearValue(BackgroundProperty);
            }
#endif
            if (foreground != null)
            {
                this.TextBlock1.Foreground = foreground;
                this.TextBlock2.Foreground = foreground;
                this.TextBlock3.Foreground = foreground;
                this.TextBlock4.Foreground = foreground;
                this.TextBlock5.Foreground = foreground;
                this.TextBlock6.Foreground = foreground;
                this.TextBlock7.Foreground = foreground;
                this.TextBlock8.Foreground = foreground;
                this.TextBlock9.Foreground = foreground;
                this.TextBlock10.Foreground = foreground;
                this.TextBlock11.Foreground = foreground;
                this.TextBlock12.Foreground = foreground;
            }
#if WPF
            // WPF example not reloaded on theme change so we clear the local value.
            else
            {
                this.TextBlock1.ClearValue(ForegroundProperty);
                this.TextBlock2.ClearValue(ForegroundProperty);
                this.TextBlock3.ClearValue(ForegroundProperty);
                this.TextBlock4.ClearValue(ForegroundProperty);
                this.TextBlock5.ClearValue(ForegroundProperty);
                this.TextBlock6.ClearValue(ForegroundProperty);
                this.TextBlock7.ClearValue(ForegroundProperty);
                this.TextBlock8.ClearValue(ForegroundProperty);
                this.TextBlock9.ClearValue(ForegroundProperty);
                this.TextBlock10.ClearValue(ForegroundProperty);
                this.TextBlock11.ClearValue(ForegroundProperty);
                this.TextBlock12.ClearValue(ForegroundProperty);
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
