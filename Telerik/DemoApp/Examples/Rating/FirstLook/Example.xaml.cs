using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Rating;

namespace Telerik.Windows.Examples.Rating.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

		private void PrecisionChanged(object sender, RoutedEventArgs e)
		{
			string contentString = (e.OriginalSource as RadioButton).Content.ToString();
			RatingPrecision currentPrecision;
			Enum.TryParse(contentString, out currentPrecision);
			this.SetRatingsPrecision(currentPrecision);
		}	

		private void SetRatingsPrecision(RatingPrecision precisionType)
		{
			if (this.horizontalRating != null) this.horizontalRating.Precision = precisionType;
			if (this.verticalRating != null) this.verticalRating.Precision = precisionType;
			if (this.contentRating != null) this.contentRating.Precision = precisionType;
		}
    }
}



