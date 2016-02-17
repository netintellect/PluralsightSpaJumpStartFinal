
namespace Telerik.Windows.Examples.Chart.MultipleDataSources
{
    public class PopulationData
    {
        private long _population;
        private string _country;

        public PopulationData(long population, string country)
        {
            this._population = population;
            this._country = country;
        }

        public long Population
        {
            get
            {
                return this._population;
            }
            private set
            {
                this._population = value;
            }
        }

        public string Country
        {
            get
            {
                return this._country;
            }
            private set
            {
                this._country = value;
            }
        }
    }
}
