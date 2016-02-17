using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Gallery.Compass
{
	public partial class Example : DynamicBasePage
	{
		/// <summary>   
		/// Indicates whether the 2 animations should be used   
		/// </summary>   
		private bool doubleAnimation = false;

		/// <summary>   
		/// From value for second animation   
		/// </summary>   
		private double secondFromValue;

		/// <summary>   
		/// To value for second animation   
		/// </summary>   
		private double secondToValue;   
  

		public Example()
		{
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Gallery/Compass/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Gallery/Compass/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Gallery/Compass/Resources.xaml", UriKind.RelativeOrAbsolute) });

            InitializeComponent();
		}

		protected override void NewValue()
		{
			SetNewValueToIndicator(360 * rnd.NextDouble());
		}

		private void SetNewValueToIndicator(double newValue)
		{
			CreateAndRunAnimation(needle.Value, newValue);
		}

		private Storyboard CreateAnimation(double fromValue, double toValue, Duration duration)
		{
			// Create DoubleAnimations and set their properties.   
			DoubleAnimation needleValueAnimation = new DoubleAnimation();

			needleValueAnimation.Duration = duration;

			Storyboard storyboard = new Storyboard();
			storyboard.Children.Add(needleValueAnimation);
			Storyboard.SetTarget(needleValueAnimation, needle);

#if SILVERLIGHT
			Storyboard.SetTargetProperty(needleValueAnimation, new PropertyPath("(Needle.Value)"));
#else 
            Storyboard.SetTargetProperty(needleValueAnimation, new PropertyPath(GraphicIndicator.ValueProperty));
#endif

			needleValueAnimation.From = (double.IsNaN(fromValue) ? 0 : fromValue);
			needleValueAnimation.To = toValue;

			return storyboard;
		}

		private void CreateAndRunAnimation(double fromValue, double toValue)
		{
			Duration duration;
			double distance = Math.Abs(toValue - fromValue);
			if (distance > 180)
			{
				doubleAnimation = true;
				if (toValue > 180)
				{
					secondFromValue = 360;
					secondToValue = toValue;
					toValue = 0;
				}
				else if (fromValue > 180)
				{
					secondFromValue = 0;
					secondToValue = toValue;
					toValue = 360;
				}
				duration = new Duration(TimeSpan.FromSeconds(0.4));
			}
			else
			{
				doubleAnimation = false;
				duration = new Duration(TimeSpan.FromSeconds(0.8));
			}

			Storyboard storyboard__1 = CreateAnimation(fromValue, toValue, duration);
			storyboard__1.Completed += onCompleted;

			storyboard__1.Begin();
		}

		private void onCompleted(object sender, EventArgs e)
		{
			if (doubleAnimation)
			{
				// Create a duration of 1 seconds.   
				Duration duration = new Duration(TimeSpan.FromSeconds(0.4));

				Storyboard storyboard = CreateAnimation(secondFromValue, secondToValue, duration);
				storyboard.Begin();
			}
		}  
	}
}
