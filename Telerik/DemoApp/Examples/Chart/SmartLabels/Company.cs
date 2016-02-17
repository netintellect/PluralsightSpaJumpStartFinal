
namespace Telerik.Windows.Examples.Chart.SmartLabels
{
    public class Company
    {
        public Company(string name, double share)
        {
            this._name = name;
            this._share = share;
        }

        private string _name;
        private double _share;

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                }
            }
        }

        public double Share
        {
            get
            {
                return this._share;
            }
            set
            {
                if (this._share != value)
                {
                    this._share = value;
                }
            }
        }
    }
}
