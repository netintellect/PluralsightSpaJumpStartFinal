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
using System.Windows.Media.Imaging;
using Telerik.Windows.Examples.ChartView.BrowsersChart.ViewModels;

namespace Telerik.Windows.Examples.ChartView.BrowsersChart.Converters
{
    public class BrowserNameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string browserName = (string)value;
            Color? color = null;
            switch (browserName)
            {
                case BrowsersViewModel.InternetExplorerName: color = new Color() { A = 255, R = 28, G = 157, B = 223 }; break;
                case BrowsersViewModel.FirefoxName: color = new Color() { A = 255, R = 245, G = 151, B = 1 }; break;
                case BrowsersViewModel.GoogleChromeName: color = new Color() { A = 255, R = 143, G = 196, B = 66 }; break;
                case BrowsersViewModel.SafariName: color = new Color() { A = 255, R = 107, G = 110, B = 141 }; break;
                case BrowsersViewModel.OperaName: color = new Color() { A = 255, R = 210, G = 0, B = 0 }; break;
            }

            return color.HasValue ? new SolidColorBrush(color.Value) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
