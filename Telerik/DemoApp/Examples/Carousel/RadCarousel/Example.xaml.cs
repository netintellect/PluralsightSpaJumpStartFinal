using System;
using Telerik.Windows.Data;
using System.Windows.Controls;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.Carousel.RadCarousel
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new Northwind();
			QuickStart.GetConfigurationPanel(this).DataContext = this.DataContext;
		}

		private void Contact_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!this.sampleRadCarousel.IsLoaded)
				return;

            if(e.AddedItems.Count > 0)
                this.sampleRadCarousel.BringDataItemIntoView(e.AddedItems[0]);
		}

		private void HorizontalSrollBarVisibility_Checked(object sender, RoutedEventArgs e)
		{
			sampleRadCarousel.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible;
		}

		private void HorizontalSrollBarVisibility_Unchecked(object sender, RoutedEventArgs e)
		{
			sampleRadCarousel.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Hidden;
		}

		private void VerticalSrollBarVisibility_Unchecked(object sender, RoutedEventArgs e)
		{
			sampleRadCarousel.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Hidden;
		}

		private void VerticalSrollBarVisibility_Checked(object sender, RoutedEventArgs e)
		{
			sampleRadCarousel.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Visible;
		}
	}
}