
namespace Telerik.Windows.Examples.Chart.MultipleDataSources
{
    public class RoadNetworkData
    {
        private long _roadNetwork;
        private string _country;

        public RoadNetworkData(long roadNetwork, string country)
        {
            this._roadNetwork = roadNetwork;
            this._country = country;
        }

        public long RoadNetwork
        {
            get
            {
                return this._roadNetwork;
            }
            private set
            {
                this._roadNetwork = value;
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
