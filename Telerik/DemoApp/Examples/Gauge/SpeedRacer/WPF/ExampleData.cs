using System;
using System.IO;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;

namespace Telerik.Windows.Examples.Gauge.SpeedRacer
{
    public partial class Example : UserControl
    {
        protected virtual string WpfPath
        {
            get
            {
                return "/Gauge;component/DataSources/{0}";
            }
        }

        protected virtual void GetData(string fileName)
        {
            Uri uri = new Uri(string.Format(this.WpfPath, fileName), UriKind.RelativeOrAbsolute);
            System.Windows.Resources.StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(uri);
            using (StreamReader fileReader = new StreamReader(streamInfo.Stream))
            {
                this.Points = this.ParseData(fileReader);
            }
        }

        private void AnimateCarIndiactor(Point newPosition)
        {
            DoubleAnimation xAnimation = new DoubleAnimation(Canvas.GetLeft(this.carIndicator), newPosition.X - this.carIndicator.Width / 2, new Duration(clockInterval));
            DoubleAnimation yAnimation = new DoubleAnimation(Canvas.GetTop(this.carIndicator), newPosition.Y - this.carIndicator.Width / 2, new Duration(clockInterval));
            this.carIndicator.BeginAnimation(Canvas.LeftProperty, xAnimation);
            this.carIndicator.BeginAnimation(Canvas.TopProperty, yAnimation);
        }
    }
}
