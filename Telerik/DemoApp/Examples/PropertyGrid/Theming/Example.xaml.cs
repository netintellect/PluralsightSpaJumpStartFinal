using System;
using System.Linq;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.PropertyGrid.Theming
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			DataContext = new EmployeeDataContext();
		}

        private void myRadPropertyGrid_AutoGeneratingPropertyDefinition(object sender, Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs e)
        {
            e.PropertyDefinition.GroupName = "Properties";  
        }
	}
}
