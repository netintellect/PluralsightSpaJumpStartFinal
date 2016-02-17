using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Rendering;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class TimeRulerOverdueContainer : Control, IDataContainer
	{
		private object data;

		public TimeRulerOverdueContainer()
		{
			this.DefaultStyleKey = typeof(TimeRulerOverdueContainer);
		}

		public object DataItem
		{
			get { return this.data; }
			set
			{
                if (this.data != value)
                {
                    this.data = value;
                    var info = this.data as TimeRulerOverdueTickInfo;
                    if (info != null)
                    {
                        this.DataContext = info.Task;
                    }
                }
			}
		}
	}
}
