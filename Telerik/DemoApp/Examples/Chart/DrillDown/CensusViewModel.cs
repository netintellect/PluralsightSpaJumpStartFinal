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
using System.Globalization;

namespace Telerik.Windows.Examples.Chart.DrillDown
{
    public class CensusViewModel
    {
        private string _ageRange;
        private string _state;
        private string _region;
        private int _age;
        private string _gender;
        private int _population;

        public string AgeRange
        {
            get { return _ageRange; }
            set
            {
                _ageRange = value;
            }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }


    }
}
