using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.PersistenceFramework.TileViewConfigurator
{
	public class Person
	{
		public Person()
		{
		}
		public string Name { get; set; }
		public string Image { get; set; }
		public string Details { get; set; }
		public string Tel { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Number { get; set; }
	}
}
