using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Examples.ExpressionEditor;

namespace Telerik.Windows.Examples
{
    ///<summary>
    /// Servers as a base type for all <see cref="RadExpressionEditor"/> examples.
    ///</summary>
    public class ExpressionEditorExample : UserControl
    {
		public ExpressionEditorExample()
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