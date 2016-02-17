using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.PanelBar.FirstLook
{
	public class Publication
	{
		public string PublicationInfo { get; set; }
		public int Year { get; set; }

		public override string ToString()
		{
			return this.PublicationInfo + ", " + this.Year.ToString() + "\n\n";
		}
	}
}
