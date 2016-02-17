using System;

namespace Telerik.Windows.Examples.DataServiceDataSource.OData
{
    public partial class NorthwindEntities
    {
        public NorthwindEntities() 
            : base(new Uri("http://services.odata.org/Northwind/Northwind.svc", UriKind.Absolute))
		{
            //
		}
    }
}
