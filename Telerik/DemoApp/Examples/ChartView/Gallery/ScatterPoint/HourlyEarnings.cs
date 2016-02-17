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

namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
{
    public class HourlyEarnings
    {
        private string _sector;
        private double _wage;
        private int _age;

        public HourlyEarnings(string sector, double wage, int age)
        {
            this._sector = sector;
            this._wage = wage;
            this._age = age;
        }

        public string Sector
        {
            get
            {
                return this._sector;
            }
        }

        public double Wage
        {
            get
            {
                return this._wage;
            }
        }

        public int Age
        {
            get
            {
                return this._age;
            }
        }
    }
}
