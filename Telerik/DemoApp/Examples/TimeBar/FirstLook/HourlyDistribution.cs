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

namespace Telerik.Windows.Examples.TimeBar.FirstLook
{
    public class HourlyDistribution
    {
        public HourlyDistribution(DateTime date, List<HourInfo> hourInfos)
        {
            this.Date = date;
            this.HourInfos = hourInfos;
        }

        public DateTime Date { get; private set; }
        public List<HourInfo> HourInfos { get; private set; }
    }
}
