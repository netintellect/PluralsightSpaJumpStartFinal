using System.Windows.Controls;
using System.Windows.Shapes;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.ChartView.Palettes
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.BindConfigurationPanel();
        }

        protected Panel ConfigurationPanel
        {
            get
            {
                return QuickStart.GetConfigurationPanel(this);
            }
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
