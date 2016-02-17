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
	public class Lecture
	{
		public string StarTime { get; set; }
		public string EndTime { get; set; }
		public string DayOfTheWeek { get; set; }
		public string Location { get; set; }

		public override string ToString()
		{
			return DayOfTheWeek + ", " + StarTime + " - " + EndTime + " " + Location + "\n\n";
		}
	}
}
