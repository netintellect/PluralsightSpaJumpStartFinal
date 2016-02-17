using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.EntityFrameworkDataSource
{
    public partial class App : Application
    {
		public App()
		{
			this.StartupUri = new Uri("/FirstLook/Example.xaml", UriKind.Relative);
		}
	}
}
