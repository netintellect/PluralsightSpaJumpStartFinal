using System.Linq;
using System;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using System.Windows;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="RadDataPager"/> examples.
    ///</summary>
    public class DataPagerExample : UserControl
    {
        public DataPagerExample()
        { 
            this.Loaded += this.OnLoaded;
        }

        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ConfigurationPanel != null)
            {
                ConfigurationPanel.DataContext = this.ChildrenOfType<RadDataPager>().FirstOrDefault();
            }
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