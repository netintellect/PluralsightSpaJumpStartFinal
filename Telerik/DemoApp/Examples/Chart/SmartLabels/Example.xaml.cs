using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.Chart.SmartLabels
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.BindConfigurationPanel();
            this.BindExampleHeader();
        }

        protected Panel ConfigurationPanel
        {
            get
            {
                return QuickStart.GetConfigurationPanel(this);
            }
        }

        protected FrameworkElement ExampleHeader
        {
            get
            {
                return QuickStart.GetExampleHeader(this) as FrameworkElement;
            }
        }

        private void BindConfigurationPanel()
        {
            if (this.ConfigurationPanel.DataContext == null)
            {
                this.ConfigurationPanel.DataContext = this.DataContext;
            }
        }

        private void BindExampleHeader()
        {
            if (this.ExampleHeader.DataContext == null)
            {
                this.ExampleHeader.DataContext = this.DataContext;
            }
        }
    }
}