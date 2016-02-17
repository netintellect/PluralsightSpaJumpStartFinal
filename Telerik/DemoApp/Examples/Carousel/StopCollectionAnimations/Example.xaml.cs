using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Carousel.StopCollectionAnimations
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

		private void AnimationButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.StopsAnimation.GetIsPaused(this.PanelHost))
				this.StopsAnimation.Resume(this.PanelHost);
			else
				this.StopsAnimation.Pause(this.PanelHost);
		}
	}
}