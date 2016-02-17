using System;

namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
{
    public class RealEstateData
    {
        private string _type;
        private double _sqFeet;
        private decimal _price;

        public RealEstateData(string type, double squareFeet, decimal price)
        {
            this._type = type;
            this._sqFeet = squareFeet;
            this._price = price;
        }

        public string Type
        {
            get
            {
                return this._type;
            }
        }

        public double SquareFeet
        {
            get
            {
                return this._sqFeet;
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
        }

        public decimal PricePerSqFeet
        {
            get
            {
                return this.Price / Convert.ToDecimal(this.SquareFeet);
            }
        }
    }
}
