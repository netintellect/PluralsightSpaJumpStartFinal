using System;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Telerik.Windows.Media.Imaging;
using Telerik.Windows.Media.Imaging.FormatProviders;

namespace Telerik.Windows.Examples.ImageEditor.Cropping.Converters
{
    public class RadBitmapToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            RadBitmap radBitmap = value as RadBitmap;
            if (radBitmap == null)
            {
                return null;
            }

            MemoryStream stream = new MemoryStream();
            PngFormatProvider provider = new PngFormatProvider();
            provider.Export(radBitmap, stream);
            stream.Seek(0, SeekOrigin.Begin);

            BitmapImage bitmapImage = new BitmapImage();
#if SILVERLIGHT
            bitmapImage.SetSource(stream);
#elif WPF
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
#endif
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}