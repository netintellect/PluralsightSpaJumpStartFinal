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
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.FirstLook
{
    public class DetailsStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            DetailedInfo info = item as DetailedInfo;
            if (info == null)
                return null;

            if (info.Actual > info.Target)
                return this.PositiveStyle;
            else
                return this.NegativeStyle;
        }
        public Style PositiveStyle { get; set; }
        public Style NegativeStyle { get; set; }
    }
}
