using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Controls;
using Telerik.Windows.Examples.EntityFrameworkDataSource;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="EntityFrameworkDataSourceExample"/> examples.
    ///</summary>
    public class EntityFrameworkDataSourceExample : UserControl
    {
		public EntityFrameworkDataSourceExample()
        {
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