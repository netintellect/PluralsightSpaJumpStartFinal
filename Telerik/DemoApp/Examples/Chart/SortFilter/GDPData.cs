namespace Telerik.Windows.Examples.Chart.SortFilter
{
    public class GDPData
    {
        private string _country;
        private decimal _gdp;

        public GDPData(string country, decimal gdp)
        {
            this.GDP = gdp;
            this.Country = country;
        }

        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }

        public decimal GDP
        {
            get
            {
                return this._gdp;
            }
            set
            {
                this._gdp = value;
            }
        }
    }
}