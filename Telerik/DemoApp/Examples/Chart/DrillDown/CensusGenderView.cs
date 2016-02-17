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
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.DrillDown
{
    public class CensusGenderView
    {
        private string _ageRange;
        private string _gender;
        private int _population;
        private List<CensusDetails> _details;

        public string AgeRange
        {
            get { return _ageRange; }
            set { _ageRange = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int Population
        {
            get { return _population; }
            set { _population = value; }
        }

        public List<CensusDetails> Details
        {
            get { return _details; }
            set { _details = value; }
        }

    }
}
