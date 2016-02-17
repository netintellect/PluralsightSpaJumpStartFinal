using System.Linq;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Examples.VirtualizingWrapPanel;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="RadDataPager"/> examples.
    ///</summary>
    public class VirtualizingWrapPanelExample : UserControl
    {
		public VirtualizingWrapPanelExample()
        {
			this.DataContext = new ExamplesViewModel();
		}

        protected Panel ConfigurationPanel
        {
            get
            {
				return QuickStart.GetConfigurationPanel(this);
			}
        }
    }
}