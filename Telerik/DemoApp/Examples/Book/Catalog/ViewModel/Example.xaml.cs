using Telerik.Windows.Controls;
using System.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Book.Catalog
{
	public partial class Example : UserControl
	{
		private void FullscreenButton_Click(object sender, RoutedEventArgs e)
		{
#if SILVERLIGHT
			Application.Current.Host.Content.IsFullScreen = !Application.Current.Host.Content.IsFullScreen;
#endif
		}
	}
}