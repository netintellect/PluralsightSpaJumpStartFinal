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

namespace Telerik.Windows.Examples.ChartView.RadarAnnotations.Models
{
    public class SolsticesAndEquinoxesData : AnnotationsData
    {
        public string Event { get; set; }
        public string Month { get; set; }
        public DateTime DateOfOccurance { get; set; }
    }
}
