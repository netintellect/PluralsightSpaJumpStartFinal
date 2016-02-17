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

namespace Telerik.Windows.Examples.Carousel.PathPadding
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		Thickness thisckness = new Thickness();

		public Example()
		{
			InitializeComponent();
		}

		private void LeftSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.thisckness.Left = e.NewValue;
			this.Panel.PathPadding = this.thisckness;
		}

		private void RightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.thisckness.Right = e.NewValue;
			this.Panel.PathPadding = this.thisckness;
		}

		private void TopSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.thisckness.Top = e.NewValue;
			this.Panel.PathPadding = this.thisckness;
		}

		private void BottomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.thisckness.Bottom = e.NewValue;
			this.Panel.PathPadding = this.thisckness;
		}

		private void MoveForward_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.LineRight();
		}

		private void MoveBackward_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.LineLeft();
		}

		private void NextPage_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.PageRight();
		}

		private void PreviousPage_Click(object sender, RoutedEventArgs e)
		{
			this.Panel.PageLeft();
		}

	}
}