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
    public class HourInfo
    {
        public HourInfo(DateTime hour, double distribution)
        {
            this.Hour = hour;
            this.Distribution = distribution;
        }

        public DateTime Hour { get; private set; }
        public double Distribution { get; private set; }
    }
}
