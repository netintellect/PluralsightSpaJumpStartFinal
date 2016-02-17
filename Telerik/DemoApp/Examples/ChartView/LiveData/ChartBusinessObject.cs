using System;

namespace Telerik.Windows.Examples.ChartView.LiveData
{
    public class ChartBusinessObject
    {
        private double _value;
        private DateTime _category;

        public double Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public DateTime Category
        {
            get
            {
                return this._category;
            }
            set
            {
                this._category = value;
            }
        }
    }
}
