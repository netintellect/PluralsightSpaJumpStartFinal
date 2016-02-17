using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Timeline.TimelineItemTemplate
{
    public class LegendPanel :
#if WPF
        ItemsControl
#endif
#if SILVERLIGHT
        Telerik.Windows.Controls.ItemsControl
#endif
    {
        public LegendPanel()
        {
        }
    }
}
