using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.Carousel.TopElementPathFraction
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e); 
		}

		void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (e.NewValue > 0.03 && e.NewValue < 0.97)
			{
				this.Panel.TopItemPathFraction = e.NewValue;
				this.scaleCenterPoint.PathFraction = e.NewValue;
				this.opacityCenterPoint.PathFraction = e.NewValue;
				this.opacityLeftPoint.PathFraction = e.NewValue - 0.03;
				this.opacityRightPoint.PathFraction = e.NewValue + 0.03;
			}
			else if(e.NewValue <= 0.5)
			{
				this.Slider_ValueChanged(this, new RoutedPropertyChangedEventArgs<double>(0, 0.04));
			}
			else if(e.NewValue >= 0.97)
			{
				this.Slider_ValueChanged(this, new RoutedPropertyChangedEventArgs<double>(0, 0.96));
			}
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