using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.ToolBar.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.DataContext= new ViewModel();
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
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }

        private void Example_ThemeChanged(object sender, EventArgs e)
        {
            this.ApplyThemeSpecificSettings();
        }
        private void ApplyThemeSpecificSettings()
        {
            switch (this.CurrentTheme)
            {
                case "Expression_Dark":
                case "VisualStudio2013_Dark":
                    IconSources.ChangeIconsSet(IconsSet.Dark);
                    break;

                default:
                    IconSources.ChangeIconsSet(IconsSet.Light);
                    break;
            }
        }

	}
}
