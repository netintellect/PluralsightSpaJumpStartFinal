using System.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.DataContext = new GanttDeadlineViewModel();
		}

		private void OnTaskEdited(object sender, Controls.GanttView.TaskEditedEventArgs e)
		{
			this.RefreshTimeRuler();
		}

		private void RefreshTimeRuler()
		{
			var viewModel = this.DataContext as GanttDeadlineViewModel;
			var tempBehavior = viewModel.TimeRulerDeadlineBehavior;
			viewModel.TimeRulerDeadlineBehavior = null;
			viewModel.TimeRulerDeadlineBehavior = tempBehavior;
		}
	}
}
