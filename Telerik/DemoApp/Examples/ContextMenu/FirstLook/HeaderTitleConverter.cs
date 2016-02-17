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

namespace Telerik.Windows.Examples.ContextMenu.FirstLook
{

    public class HeaderTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string param = System.Convert.ToString(parameter);
            switch (param)
            {
                case "EnableState":
                    return UpdateEnableDisableTitle(value as UIElement);

                case "ZoomState":
                    return UpdateZoomStateTitle(value as UIElement);

                default:
                    break;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private object UpdateEnableDisableTitle(UIElement element)
        {
            if (element != null && element.Opacity < 1)
            {
                return "Enable";
            }

            return "Disable";
        }

        private object UpdateZoomStateTitle(UIElement element)
        {
            System.Windows.Controls.ListBoxItem listBoxItem = element as System.Windows.Controls.ListBoxItem;
            if (listBoxItem != null && listBoxItem.IsSelected)
            {
                return "Zoom Out";
            }

            return "Zoom In";
        }
    }
}
