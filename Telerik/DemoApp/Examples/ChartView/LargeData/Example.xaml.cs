using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.ChartView.LargeData
{
    public partial class Example : UserControl
    {
        protected Panel ConfigurationPanel
        {
            get
            {
                return QuickStart.GetConfigurationPanel(this);
            }
        }

        public Example()
        {
            InitializeComponent();
            this.BindConfigurationPanel();
            this.ExampleHeader.DataContext = this.DataContext;
        }

        private void BindConfigurationPanel()
        {
            if (this.ConfigurationPanel.DataContext == null)
            {
                this.ConfigurationPanel.DataContext = this.DataContext;
            }
        }
    }
}
