using System.Linq;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="RadDomainDataSource"/> examples.
    ///</summary>
    public class DomainDataSourceExample : UserControl
    {
		public DomainDataSourceExample()
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