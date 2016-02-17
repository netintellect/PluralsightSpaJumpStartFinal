using System.Windows.Controls;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all Data Virtualization examples.
    ///</summary>
    public class DataVirtualizationExample : UserControl
    {
        public DataVirtualizationExample()
        {
            //
		}

        protected Panel ConfigurationPanel
        {
            get
            {
                return Telerik.Windows.Controls.QuickStart.QuickStart.GetConfigurationPanel(this);
			}
        }
    }
}