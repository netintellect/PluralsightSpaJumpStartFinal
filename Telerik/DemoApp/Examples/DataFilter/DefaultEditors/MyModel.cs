using System;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.DataFilter.DefaultEditors
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
                        new Telerik.Windows.Data.FilterDescriptor("Name", Telerik.Windows.Data.FilterOperator.Contains, "meat", true),
                        new Telerik.Windows.Data.FilterDescriptor("OrderDate", Telerik.Windows.Data.FilterOperator.IsGreaterThan, new DateTime(2007, 5, 1)),
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
