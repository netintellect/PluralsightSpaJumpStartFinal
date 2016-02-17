namespace Telerik.Windows.Examples.Chart.Aggregates
{
    public class BusinessObject
    {
        private string _type;
        private string _quarter;
        private int _year;
        private string _location;
        private double _sales;

        public BusinessObject(int year, string quarter, string type, string location, double sales)
        {
            this._year = year;
            this._quarter = quarter;
            this._type = type;
            this._location = location;
            this._sales = sales;
        }

        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public string Quarter
        {
            get
            {
                return this._quarter;
            }
            set
            {
                this._quarter = value;
            }
        }

        public int Year
        {
            get
            {
                return this._year;
            }
            set
            {
                this._year = value;
            }
        }

        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
            }
        }

        public double Sales
        {
            get
            {
                return this._sales;
            }
            set
            {
                this._sales = value;
            }
        }
    }
}
