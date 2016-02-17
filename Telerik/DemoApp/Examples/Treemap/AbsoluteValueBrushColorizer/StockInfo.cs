using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.Treemap.AbsoluteValueBrushColorizer
{
    public class StockInfo
    {
        private string _stockSymbol;
        private double _changeRate;
        private double _marketValue;

        public string StockSymbol
        {
            get
            {
                return this._stockSymbol;
            }
            set
            {
                this._stockSymbol = value;
            }
        }
        public double ChangeRate
        {
            get
            {
                return this._changeRate;
            }
            set
            {
                this._changeRate = value;
            }
        }

        public double MarketValue
        {
            get
            {
                return this._marketValue;
            }
            set
            {
                this._marketValue = value;
            }
        }
    }
}
