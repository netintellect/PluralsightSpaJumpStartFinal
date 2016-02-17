using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Sparklines.Theming
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
            int column1Width, column2Width, column3Width;

            if (this.CurrentTheme == "Windows8Touch")
            {
                this.LayoutRoot.Width = 854;
                this.LayoutRoot.Height = 544;

                column1Width = 90;
                column2Width = 85;
                column3Width = 80;
            }
            else
            {
                this.LayoutRoot.Width = 784;
                this.LayoutRoot.Height = 484;

                column1Width = 75;
                column2Width = 55;
                column3Width = 55;
            }

            this.lineGridView.Columns[0].Width = column1Width;
            this.lineGridView.Columns[1].Width = column2Width;
            this.lineGridView.Columns[2].Width = column3Width;
            this.areaGridView.Columns[0].Width = column1Width;
            this.areaGridView.Columns[1].Width = column2Width;
            this.areaGridView.Columns[2].Width = column3Width;
            this.columnGridView.Columns[0].Width = column1Width;
            this.columnGridView.Columns[1].Width = column2Width;
            this.columnGridView.Columns[2].Width = column3Width;
            this.winLossGridView.Columns[0].Width = column1Width;
            this.winLossGridView.Columns[1].Width = column2Width;
            this.winLossGridView.Columns[2].Width = column3Width;
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
