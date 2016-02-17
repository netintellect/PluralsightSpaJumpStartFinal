using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.Chart.EmptyValues
{
    public class MyDateObject
    {
        private double? _value1;
        private double? _value2;
        private double? _value3;
        private DateTime _date;

        public double? Value1
        {
            get
            {
                return this._value1;
            }
            set
            {
                this._value1 = value;
            }
        }

        public double? Value2
        {
            get
            {
                return this._value2;
            }
            set
            {
                this._value2 = value;
            }
        }

        public double? Value3
        {
            get
            {
                return this._value3;
            }
            set
            {
                this._value3 = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }

        public MyDateObject(double? value1, double? value2, double? value3, DateTime date)
        {
            this._value1 = value1;
            this._value2 = value2;
            this._value3 = value3;
            this._date = date;
        }
    }
}
