using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
    class ControlsMajorGroupHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((string)value == AllControlsTouchViewModel.SampleAppsGroupName)
            {
                return QuickStartData.Instance.Element.Element("SampleApps").GetAttribute("titleTouch", "Sample Apps");
            }
            else if((string)value == AllControlsTouchViewModel.NewControlsGroupName)
            {
                return QuickStartData.Instance.Element.Element("NewControls").GetAttribute("title", "New Controls");
            }
            else if ((string)value == AllControlsTouchViewModel.HighlightedControlsGroupName)
            {
                return QuickStartData.Instance.Element.Element("HighlightedControlsTouch").GetAttribute("title", "Highlights");
            }
            else if((string)value == "A-B")
            {
                return QuickStartData.Instance.Element.Element("AllControls").GetAttribute("title", "All Controls");
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
