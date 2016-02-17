using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace Telerik.Windows.QuickStart
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : System.Windows.Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			Telerik.Windows.Controls.StyleManager.IsEnabled = false;
		}
	}
}
