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

namespace Telerik.Windows.Examples.TimeBar.FirstLook
{
    public class TrafficInfo
    {
        public TrafficInfo(DateTime date, double directTraffic, double refferingSites, double searchEngines, double others)
        {
            this.Date = date;
            this.DirectTraffic = directTraffic;
            this.RefferingSites = refferingSites;
            this.SearchEngines = searchEngines;
            this.Others = others;
        }

        public DateTime Date { get; private set; }
        public double DirectTraffic { get; private set; }
        public double RefferingSites { get; private set; }
        public double SearchEngines { get; private set; }
        public double Others { get; private set; }
    }
}
