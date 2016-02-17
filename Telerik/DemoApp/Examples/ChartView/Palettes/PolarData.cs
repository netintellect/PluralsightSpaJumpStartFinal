using System;

namespace Telerik.Windows.Examples.ChartView.Palettes
{
    public class PolarData
    {
        private double _angle;
        private double _value;

        public PolarData(double angle, double value)
        {
            this._angle = angle;
            this._value = value;
        }

        public double Angle
        {
            get
            {
                return this._angle;
            }
            set
            {
                if (this._angle != value)
                {
                    this._angle = value;
                }
            }
        }

        public double Value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (this._value != value)
                {
                    this._value = value;
                }
            }
        }
    }
}
