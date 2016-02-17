using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.DragDrop
{
	public class HRResource : Resource
	{
		public string Name { get; set; }
		public string Photo { get; set; }
		public string Room { get; set; }
		public Brush Brush { get; set; }
	}
}
