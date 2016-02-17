using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView
{
	public abstract class GanttViewModel : ViewModelBase
	{
		public GanttViewModel()
		{
			this.Tasks = new SoftwarePlanning();
		}

		public IList<IGanttTask> Tasks { get; private set; }
	}
}