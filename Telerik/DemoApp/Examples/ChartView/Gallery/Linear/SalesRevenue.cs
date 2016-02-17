namespace Telerik.Windows.Examples.ChartView.Gallery.Linear
{
    public class SalesRevenue
    {
        public SalesRevenue(string month, double revenue)
        {
            this._month = month;
            this._revenue = revenue;
        }

        private string _month;
        private double _revenue;

        public string Month
        {
            get
            {
                return this._month;
            }
        }

        public double Revenue
        {
            get
            {
                return this._revenue;
            }
        }
    }
}
