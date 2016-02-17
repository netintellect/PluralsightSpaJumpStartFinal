using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.BulletGraph.FirstLook
{
    public class KeyMeasure
    {
        private string _representativeName;
        private List<Measure> _actualProfitByMonth;
        private double _targetYTDProfit;
        private double _targetProfit;

        public KeyMeasure()
        {
            this._actualProfitByMonth = new List<Measure>(12);
            this._representativeName = string.Empty;
        }

        public string RepresentativeName
        {
            get
            {
                return this._representativeName;
            }
            set
            {
                this._representativeName = value;
            }
        }

        public List<Measure> ActualProfitByMonth
        {
            get
            {
                return _actualProfitByMonth;
            }
            set
            {
                _actualProfitByMonth = value;
            }
        }

        public virtual double ActualYTDProfit
        {
            get
            {
                double sum = 0d;

                for (int index = 2; index < this.ActualProfitByMonth.Count; index++)
                {
                    sum += this.ActualProfitByMonth[index].Value;
                }

                return sum;
            }
        }

        public virtual string ActualYTDProfitText
        {
            get
            {
                return String.Format("{0:N2}", ActualYTDProfit);
            }
        }

        public virtual double TargetYTDProfit
        {
            get
            {
                return _targetYTDProfit;
            }
            set
            {
                this._targetYTDProfit = value;
            }
        }

        public double TargetYTDProfitPoor
        {
            get
            {
                return this.TargetYTDProfit * 0.5;
            }
        }

        public double TargetYTDProfitSatisfactory
        {
            get
            {
                return this.TargetYTDProfit * 0.75;
            }
        }

        public virtual double PercentDiversion
        {
            get
            {
                return (this.ActualYTDProfit - this.TargetYTDProfit) / this.TargetYTDProfit;
            }
        }

        public virtual string PercentDiversionText
        {
            get
            {
                return String.Format("{0:P}", PercentDiversion);
            }
        }

        public double TargetProfit
        {
            get
            {
                return this._targetProfit;
            }
            set
            {
                this._targetProfit = value;
            }
        }
    }

    public class Measure
    {
        private DateTime _date;
        private double _value;

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
    }
}

