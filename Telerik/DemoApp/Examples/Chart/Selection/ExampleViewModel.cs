using System;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.Selection
{
    public class ExampleViewModel
    {
#if SILVERLIGHT
        private const string ShapeRelativeUriFormat = "DataSources/Geospatial/europe.{0}";
#else
        private const string ShapeRelativeUriFormat = "/Chart;component/Resources/europe.{0}";
#endif
        private const string ShapeExtension = "shp";
        private const string DbfExtension = "dbf";

        public Uri ShapeSourceUri
        {
            get
            {
                return new Uri(string.Format(ShapeRelativeUriFormat, ShapeExtension), UriKind.Relative);
            }
        }

        public Uri ShapeDataSourceUri
        {
            get
            {
                return new Uri(string.Format(ShapeRelativeUriFormat, DbfExtension), UriKind.Relative);
            }
        }

        public Brush ApplicationThemeAwareForeground
        {
            get
            {
                if (StyleManager.ApplicationTheme is Expression_DarkTheme)
                    return new SolidColorBrush(Color.FromArgb(255, 204, 204, 204));

                return new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
        }
    }
}
