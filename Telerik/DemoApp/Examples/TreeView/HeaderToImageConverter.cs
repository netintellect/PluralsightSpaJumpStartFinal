using System;
using System.Windows.Data;
using System.Examples.Web.NorthwindModel;
using System.Windows.Media.Imaging;

namespace Telerik.Windows.Examples.TreeView
{
    public class HeaderToImageConverter : IValueConverter
    {
        private string uriStringFormat = "../Images/TreeView";
        
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Category category = value as Category;

            if (category == null)
                return null;
            else
            {
                if (parameter != null && !string.IsNullOrEmpty(parameter.ToString()))
                {
                    this.uriStringFormat = parameter.ToString();
                }
                string product = category.CategoryName.Replace(" ", string.Empty).Replace("/", string.Empty);
                uriStringFormat += "/" + product + ".png";
				return new BitmapImage(new Uri(uriStringFormat, UriKind.RelativeOrAbsolute));
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
