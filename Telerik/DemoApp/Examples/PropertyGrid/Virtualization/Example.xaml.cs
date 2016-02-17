using System;
using System.Linq;

namespace Telerik.Windows.Examples.PropertyGrid.Virtualization
{
    public partial class Example
    {
        public Example()
        { 
            InitializeComponent();

			dynamic myDataRow = new MyDataRow();
			for (int i = 0; i < 1000; i++)
			{
				myDataRow[string.Format("Property {0}", i)] = string.Format("Value {0}", i);
			}
			
			this.propertyGrid1.Item = myDataRow;
        }

		private void OnAutoGeneratingPropertyDefinition(object sender, Controls.Data.PropertyGrid.AutoGeneratingPropertyDefinitionEventArgs e)
		{
			e.PropertyDefinition.GroupName = (Int32.Parse(e.PropertyDefinition.DisplayName.Substring(9)) % 1000).ToString();
		}
    }    
}
