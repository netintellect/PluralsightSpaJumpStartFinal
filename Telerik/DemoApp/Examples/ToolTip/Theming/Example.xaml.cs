using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.ToolTip.Theming
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
            this.ApplyThemeSpecificSettings();
        }

        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            this.ellipse.Fill = new SolidColorBrush(Windows8Palette.Palette.AccentColor);
            this.tBlock.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            this.ellipse.Fill = new SolidColorBrush(Colors.White);
            this.tBlock.Foreground = new SolidColorBrush(Colors.Black);
        }

        public string CurrentTheme
        {
            get
            {
                return ApplicationThemeManager.GetInstance().CurrentTheme;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.ExampleThemeChanged;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.ExampleThemeChanged;
        }

        private void ExampleThemeChanged(object sender, EventArgs e)
        {
            this.ApplyThemeSpecificSettings();
        }

        private void ApplyThemeSpecificSettings()
        {
            if (this.CurrentTheme == "Windows8Touch")
            {
                RadToolTipService.SetVerticalOffset(this.ellipse, -70);
            }
            else if (this.CurrentTheme.StartsWith("Office2013"))
            {
                RadToolTipService.SetVerticalOffset(this.ellipse, -67);
            }
            else
            {
                RadToolTipService.SetVerticalOffset(this.ellipse, -63);
            }
        }
    }
}
