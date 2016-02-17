using System.Windows;
using System.Windows.Controls;
using Telerik.Pivot.Core;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.CustomAggregateDescription
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
            this.Unloaded += this.OnExampleUnloaded;
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void LocalDataSourceProvider_PrepareDescriptionForField(object sender, Telerik.Pivot.Core.PrepareDescriptionForFieldEventArgs e)
        {
            if (e.DescriptionType == Telerik.Pivot.Core.DataProviderDescriptionType.Aggregate && (e.FieldInfo.Name == "Quantity" || e.FieldInfo.Name == "Net"))
            {
                e.Description = new MyAggregateDescription() { PropertyName = e.FieldInfo.Name };
            }
            else
            {
                if (e.DescriptionType == Telerik.Pivot.Core.DataProviderDescriptionType.Group && e.FieldInfo.Name == "Product")
                {
                    (e.Description as PropertyGroupDescriptionBase).CalculatedItems.Add(new ProductCalculatedItem() { GroupName = "Product CalculatedItem" });
                }
            }
        }
	}
}