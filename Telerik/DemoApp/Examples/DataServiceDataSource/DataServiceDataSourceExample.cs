using System.Linq;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="DataServiceDataSourceExample"/> examples.
    ///</summary>
    public class DataServiceDataSourceExample : UserControl
    {
		public DataServiceDataSourceExample()
        {
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