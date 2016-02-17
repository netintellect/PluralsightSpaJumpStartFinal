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
    public class BrowserNameToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string browserName = (string)value;
            int pixels;
            if (parameter == null || !Int32.TryParse(parameter.ToString(), out pixels))
            {
                pixels = 24;
            }
            string uriString = this.GetUriString(browserName, pixels);
            BitmapImage source = new BitmapImage(new Uri(uriString, UriKind.Relative));
            return source;
        }

        private string GetUriString(string browserName, int pixels)
        {
            if (pixels == 32)
            {
                switch (browserName)
                {
                    case BrowsersViewModel.InternetExplorerName: return "../Images/ChartView/BrowsersChart/internet_explorer_32x32.png";
                    case BrowsersViewModel.FirefoxName: return "../Images/ChartView/BrowsersChart/firefox_32x32.png";
                    case BrowsersViewModel.GoogleChromeName: return "../Images/ChartView/BrowsersChart/google_chrome_32x32.png";
                    case BrowsersViewModel.SafariName: return "../Images/ChartView/BrowsersChart/safari_32x32.png";
                    case BrowsersViewModel.OperaName: return "../Images/ChartView/BrowsersChart/opera_32x32.png";
                }
            }
            else
            {
                switch (browserName)
                {
                    case BrowsersViewModel.InternetExplorerName: return "../Images/ChartView/BrowsersChart/internet_explorer_24x24.png";
                    case BrowsersViewModel.FirefoxName: return "../Images/ChartView/BrowsersChart/firefox_24x24.png";
                    case BrowsersViewModel.GoogleChromeName: return "../Images/ChartView/BrowsersChart/google_chrome_24x24.png";
                    case BrowsersViewModel.SafariName: return "../Images/ChartView/BrowsersChart/safari_24x24.png";
                    case BrowsersViewModel.OperaName: return "../Images/ChartView/BrowsersChart/opera_24x24.png";
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
