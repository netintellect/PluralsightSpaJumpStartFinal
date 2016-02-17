using System.Windows.Controls;

namespace Telerik.Windows.Examples.BulletGraph.Configurator
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
                return Telerik.Windows.Controls.QuickStart.QuickStart.GetConfigurationPanel(this);
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
