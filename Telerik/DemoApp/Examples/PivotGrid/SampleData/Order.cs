using System;

namespace Telerik.Windows.Examples.PivotGrid.SampleData
{
    public class Order
    {
        private DateTime _Date;
        private string _Product;
        private int _Quantity;
        private double _Net;
        private string _Promotion;
        private string _Advertisement;

        public Order()
        {
        }

        public DateTime Date
        {
            get
            {
                return this._Date;
            }
            set
            {
                if (this._Date != value)
                {
                    this._Date = value;
                }
            }
        }

        public string Product
        {
            get
            {
                return this._Product;
            }
            set
            {
                if (this._Product != value)
                {
                    this._Product = value;
                }
            }
        }

        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                if (this._Quantity != value)
                {
                    this._Quantity = value;
                }
            }
        }

        public double Net
        {
            get
            {
                return this._Net;
            }
            set
            {
                if (this._Net != value)
                {
                    this._Net = value;
                }
            }
        }

        public string Promotion
        {
            get
            {
                return this._Promotion;
            }
            set
            {
                if (this._Promotion != value)
                {
                    this._Promotion = value;
                }
            }
        }

        public string Advertisement
        {
            get
            {
                return this._Advertisement;
            }
            set
            {
                if (this._Advertisement != value)
                {
                    this._Advertisement = value;
                }
            }
        }
    }
}
