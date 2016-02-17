using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Collections;
using Telerik.Windows.Controls;
using System.Windows.Media.Animation;


namespace Telerik.Windows.Examples.Carousel.Reflection
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		Telerik.Windows.Controls.RadCarouselPanel panel;
		public Example()
		{
			InitializeComponent();
			this.DataContext = new Northwind();
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			this.sampleRadCarousel.ReflectionSettings.Visibility = Visibility.Hidden;
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			this.sampleRadCarousel.ReflectionSettings.Visibility = Visibility.Visible;
		}

		private void opacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.sampleRadCarousel.ReflectionSettings.Opacity = (double) e.NewValue;
		}

		private void offsetXSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.sampleRadCarousel.ReflectionSettings.OffsetX = (double) e.NewValue;
		}

		private void offsetYSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.sampleRadCarousel.ReflectionSettings.OffsetY = (double) e.NewValue;
 		}

		private void hiddenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.sampleRadCarousel.ReflectionSettings.HiddenPercentage = (double) e.NewValue;
		}

		private void angleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.sampleRadCarousel.ReflectionSettings.Angle = (double) e.NewValue;
		}

		private void offsetHSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.sampleRadCarousel.ReflectionSettings.HeightOffset = (double) e.NewValue;
		}

		private void offsetWSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.sampleRadCarousel.ReflectionSettings.WidthOffset = (double) e.NewValue;
		}

	}
}