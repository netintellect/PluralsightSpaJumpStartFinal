using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.ChartView.EmptyValues
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.BindConfigurationPanel();
        }

        private IScrollInfo scrollControl;

        protected Panel ConfigurationPanel
        {
            get
            {
                return QuickStart.GetConfigurationPanel(this);
            }
        }

        public IScrollInfo ScrollControl
        {
            get
            {
                if (this.scrollControl == null)
                {
                    this.scrollControl = this.listBox.FindChildByType<VirtualizingPanel>() as IScrollInfo;
                }
                return scrollControl;
            }
        }

        private void BindConfigurationPanel()
        {
            if (this.ConfigurationPanel.DataContext == null)
            {
                this.ConfigurationPanel.DataContext = this.DataContext;
            }
        }

        private void OnLineLeftButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ScrollControl.LineLeft();
        }

        private void OnLineRightButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ScrollControl.LineRight();
        }
    }
}
