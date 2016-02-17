using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView.TaskPlanner
{
	public class ParentsInfo : ViewModelBase
	{
		public IEnumerable<CommonModel> Parents { get; set; }
	}
}
