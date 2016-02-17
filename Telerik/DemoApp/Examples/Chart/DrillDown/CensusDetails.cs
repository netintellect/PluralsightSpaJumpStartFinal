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

namespace Telerik.Windows.Examples.Chart.DrillDown
{
    public class CensusDetails
    {
        private string _region;
        private int _population;
        private int _age;

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
