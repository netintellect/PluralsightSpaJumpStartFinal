using System;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.DataFilter.CustomEditors
{
    public class MyModel
    {
        ObservableCollection<Telerik.Windows.Data.FilterDescriptor> _filterDescriptors;
        public ObservableCollection<Telerik.Windows.Data.FilterDescriptor> FilterDescriptors
        {
            get
            {
                if (_filterDescriptors == null)
                {
                    _filterDescriptors = new ObservableCollection<Telerik.Windows.Data.FilterDescriptor>() 
                    {  
                        new Telerik.Windows.Data.FilterDescriptor("Name", Telerik.Windows.Data.FilterOperator.IsEqualTo, "Crab Meat", true),
                        new Telerik.Windows.Data.FilterDescriptor("OrderTime", Telerik.Windows.Data.FilterOperator.IsGreaterThan, new DateTime(1, 1, 1, 2, 45, 0)),
                        new Telerik.Windows.Data.FilterDescriptor("Quantity", Telerik.Windows.Data.FilterOperator.IsGreaterThan, 10),
                        new Telerik.Windows.Data.FilterDescriptor("UnitPrice", Telerik.Windows.Data.FilterOperator.IsLessThan, 899.99),
                        new Telerik.Windows.Data.FilterDescriptor("Discontinued", Telerik.Windows.Data.FilterOperator.IsEqualTo, true)
                    };
                }

                return _filterDescriptors;
            }
        }
    }
}
