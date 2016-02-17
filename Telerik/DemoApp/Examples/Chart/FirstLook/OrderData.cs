using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.FirstLook
{
    public class OrderData
    {
        private int _amount;
        private string _country;
        private DateTime _date;
        private string _productName;
        private string _region;
        private int _target;

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public double PercentTarget
        {
            get
            {
                return this.Amount / this.Target;
            }
        }

        public string Product
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }

        public string Region
        {
            get
            {
                return _region;
            }
            set
            {
                _region = value;
            }
        }

        public int Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
    }
}