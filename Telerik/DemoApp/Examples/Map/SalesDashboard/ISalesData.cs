
namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public interface ISalesData
    {
        decimal Target
        {
            get;
        }

        decimal Total
        {
            get;
        }

        decimal Diversion
        {
            get;
        }

        string Name
        {
            get;
        }
    }
}
