using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TreeMap;

namespace Telerik.Windows.Examples.Treemap.CustomMapping
{
    public class FileCustomMapping : Telerik.Windows.Controls.TreeMap.CustomMapping
    {
        private static readonly string[] documents;
        private static readonly string[] music;
        private static readonly string[] images;
        private static readonly string[] video;
#if WPF
        string path = "/Treemap;component/Images/Treemap/CustomMapping/{0}";
#else
        string path = "../Images/Treemap/CustomMapping/{0}";
#endif

        static FileCustomMapping()
        {
            documents = new string[3];
            documents[0] = "txt";
            documents[1] = "doc";
            documents[2] = "odt";
            music = new string[3];
            music[0] = "mp3";
            music[1] = "wma";
            music[2] = "flac";
            images = new string[3];
            images[0] = "gif";
            images[1] = "jpeg";
            images[2] = "png";
            video = new string[3];
            video[0] = "mpeg";
            video[1] = "avi";
        }

        protected override void Apply(RadTreeMapItem treemapItem, object dataItem)
        {
            File file = dataItem as File;
            string extention = System.IO.Path.GetExtension(file.Name).TrimStart('.');
            Brush brush = null;
            ImageBrush image = null;
            if (documents.Contains(extention))
            {
                brush = new SolidColorBrush(Color.FromArgb(0xff, 0x99, 0xB9, 0x4E));
                image = this.GetImage("text.png");
            }
            else if (music.Contains(extention))
            {
                brush = new SolidColorBrush(Color.FromArgb(0xff, 0xF0, 0xB3, 0x2D));
                image = this.GetImage("music.png");
            }
            else if (images.Contains(extention))
            {
                brush = new SolidColorBrush(Color.FromArgb(0xff, 0xDC, 0x81, 0xAC));
                image = this.GetImage("img.png");
            }
            else if (video.Contains(extention))
            {
                brush = new SolidColorBrush(Color.FromArgb(0xff, 0x5A, 0xAB, 0xDC));
                image = this.GetImage("video.png");
            }
            treemapItem.Background = brush;
            Grid grid = treemapItem.ChildrenOfType<Grid>().ElementAt(1);
            grid.Background = image;
        }

        private ImageBrush GetImage(string fileName)
        {
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.Stretch = Stretch.None;
            imageBrush.AlignmentX = AlignmentX.Right;
            imageBrush.AlignmentY = AlignmentY.Bottom;
            TranslateTransform transform = new TranslateTransform();
            transform.X = transform.Y = -6;
            imageBrush.Transform = transform;

            Uri resourceURI = new Uri(string.Format(path, fileName), UriKind.RelativeOrAbsolute);
#if WPF
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceURI);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = streamInfo.Stream;
            bitmapImage.EndInit();
            imageBrush.ImageSource = bitmapImage;
#else
            imageBrush.ImageSource = new BitmapImage(resourceURI);
#endif
            return imageBrush;
        }

        protected override void Clear(RadTreeMapItem treemapItem, object dataItem)
        {
            treemapItem.ClearValue(RadTreeMapItem.BackgroundProperty);
        }
    }
}
