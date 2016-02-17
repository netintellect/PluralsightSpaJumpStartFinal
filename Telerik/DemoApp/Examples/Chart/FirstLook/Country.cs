using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.FirstLook
{
    public class Country : OrderView
    {
        public Country(string name, IEnumerable<OrderData> data)
            : base(name, data)
        {
        }
    }
}
