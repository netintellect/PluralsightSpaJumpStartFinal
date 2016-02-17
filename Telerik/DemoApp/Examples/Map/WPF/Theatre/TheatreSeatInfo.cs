
namespace Telerik.Windows.Examples.Map.Theatre
{
    public class TheatreSeatInfo
    {
        private int _id;
        private string _position;
        private string _row;
        private int _number;
        private double _price;
        private SeatAvailability _status;

        public TheatreSeatInfo()
        {
        }

        public TheatreSeatInfo(int id, string position, string row, int number, double price, SeatAvailability status)
        {
            this._id = id;
            this._position = position;
            this._row = row;
            this._number = number;
            this._price = price;
            this._status = status;
        }

        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }

        public string Row
        {
            get
            {
                return this._row;
            }
            set
            {
                this._row = value;
            }
        }

        public int Number
        {
            get
            {
                return this._number;
            }
            set
            {
                this._number = value;
            }
        }

        public double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }

        public SeatAvailability Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
    }
}
