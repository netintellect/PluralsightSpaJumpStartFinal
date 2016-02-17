using System.Linq;
using System;
using System.Windows.Controls;
using Telerik.Windows.Examples.DataFilter;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="RadDataFilter"/> examples.
    ///</summary>
    public class DataFilterExample : UserControl
    {
		public DataFilterExample()
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