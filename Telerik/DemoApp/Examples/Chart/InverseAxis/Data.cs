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

namespace Telerik.Windows.Examples.Chart.InverseAxis
{
    public class Data
    {
        private int _year;
        private long _feet;

        public Data(int year, long feet)
        {
            this._year = year;
            this._feet = feet;
        }

        public int Year 
        {
            get
            {
                return this._year;
            }
            private set
            {
                this._year = value;
            }
        }

        public long Feet
        {
            get
            {
                return this._feet;
            }
            private set
            {
                this._feet = value;
            }
        }
    }
}
