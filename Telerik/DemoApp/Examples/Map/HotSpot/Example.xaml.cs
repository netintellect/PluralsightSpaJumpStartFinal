using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
#if SILVERLIGHT
using System.Net;
using System.Windows.Browser;
using Telerik.Windows.Examples.Map;
using System.Collections.Generic;
#endif

namespace Telerik.Windows.Examples.Map.HotSpot
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
            (this.LayoutRoot.DataContext as ExampleViewModel).PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Example_PropertyChanged);
        }

        void Example_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (propertyName == "HotSpotUnits" ||
                propertyName == "HotSpotXFraction" ||
                propertyName == "HotSpotYFraction" ||
                propertyName == "HotSpotXPixels" ||
                propertyName == "HotSpotYPixels" ||
                propertyName == "HotSpotXInnerPixels" ||
                propertyName == "HotSpotYInnerPixels")
            {
                this.ConfigureHotSpot();
            }

            if (propertyName == "HotSpotGridRow" || propertyName == "HotSpotGridColumn")
            {
                this.hotSpotElement.InvalidateMeasure();
                this.ConfigureHotSpot();
            }
        }

        private void ConfigureHotSpot()
        {
            if (this.informationLayer != null && this.hotSpotElement != null)
                this.informationLayer.ArrangeItem(this.hotSpotElement);
        }
    }
}
