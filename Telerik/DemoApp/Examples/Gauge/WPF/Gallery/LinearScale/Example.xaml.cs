using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauges;

namespace Telerik.Windows.Examples.Gauge.Gallery.LinearScale
{
    public partial class Example : DynamicBasePage
    {
        public Example()
        {
            InitializeComponent();
        }

        protected override void NewValue()
        {
            gauge1_marker.Value = linearScale.Min + (linearScale.Max - linearScale.Min) * rnd.NextDouble();
            gauge2_marker.Value = linearScale.Min + (linearScale.Max - linearScale.Min) * rnd.NextDouble();
            gauge3_marker.Value = linearScale.Min + (linearScale.Max - linearScale.Min) * rnd.NextDouble();
        }
    }
}
