using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Telerik.Windows.Examples.ExampleHelpers;
using Telerik.Windows.Media.Imaging.FormatProviders;

namespace Telerik.Windows.Examples.ImageEditor.Cropping.Converters
{
    public class BitmapToRadBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage bitmapImage = value as BitmapImage;
            if (bitmapImage == null)
            {
                return null;
            }
            return ImageExampleHelper.GetRadBitmap(bitmapImage.UriSource.ToString(), new PngFormatProvider());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}