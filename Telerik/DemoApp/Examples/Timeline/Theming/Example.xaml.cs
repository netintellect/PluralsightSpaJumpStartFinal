using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Timeline.Theming
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
            if (this.CurrentTheme == "Windows8Touch")
            {
                RadTimeline1.ClearValue(HeightProperty);
            }
            else
            {
                RadTimeline1.Height = 230d;
            }
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
