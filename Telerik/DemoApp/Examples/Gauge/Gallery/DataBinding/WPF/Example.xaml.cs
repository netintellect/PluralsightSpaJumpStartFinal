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

namespace Telerik.Windows.Examples.Gauge.Gallery.DataBinding
{
	public partial class Example : DynamicBasePage
	{
		public Example()
		{
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Gallery/DataBinding/WPF/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Gallery/DataBinding/WPF/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }            
			InitializeComponent();

			this.Loaded += new RoutedEventHandler(Example_Loaded);
		}

        private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			this.radialBar.ValueSource = new double[]
			{
				10,
				15,
				25,
				17,
				40,
				50,
				60,
				70,
				25,
				15,
				5,
				10,
				12,
				18,
				29,
				37,
				92
			};
		}

		private void Reset(object sender, RoutedEventArgs e)
		{
			this.radialBar.Reset();
			this.radialBar.MoveNext();
		}

		private void MoveNext(object sender, RoutedEventArgs e)
		{
			this.radialBar.MoveNext();
		}

		private void MovePrevious(object sender, RoutedEventArgs e)
		{
			this.radialBar.MovePrevious();
		}

		private void StartPlayback(object sender, RoutedEventArgs e)
		{
			this.radialBar.StartPlayback();
		}

		private void StopPlayback(object sender, RoutedEventArgs e)
		{
			this.radialBar.StopPlayback();
		}
	}
}
