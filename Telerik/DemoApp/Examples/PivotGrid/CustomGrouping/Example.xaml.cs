using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.CustomGrouping
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

        private void LocalDataSourceProvider_PrepareDescriptionForField(object sender, Pivot.Core.PrepareDescriptionForFieldEventArgs e)
        {
            if (e.DescriptionType == Telerik.Pivot.Core.DataProviderDescriptionType.Group && e.FieldInfo.Name == "Product")
            {
                e.Description = new FirstLetterGroupDescription() { PropertyName = "Product" };
            }
        }
    }
}
