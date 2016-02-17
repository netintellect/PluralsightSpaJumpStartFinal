
namespace Telerik.Windows.Examples.Chart.MultipleDataSources
{
    public class VehicleData
    {
        private long _vehicles;
        private string _country;

        public VehicleData(long vehicles, string country)
        {
            this._vehicles = vehicles;
            this._country = country;
        }

        public long Vehicles
        {
            get
            {
                return this._vehicles;
            }
            private set
            {
                this._vehicles = value;
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
