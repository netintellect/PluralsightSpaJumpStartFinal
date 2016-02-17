using System.Windows.Controls;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.GanttView.TaskPlanner
{
    public partial class Example : UserControl
    {		
        public Example()
        {
            InitializeComponent();
        }

		private	ViewModel viewModel;
		public ViewModel ViewModel 
		{
			get 
			{
				if (viewModel == null)
				{
					viewModel = this.DataContext as ViewModel;
				}
				return viewModel;
			}
		}

		private void OnTaskEdited(object sender, TaskEditedEventArgs e)
		{
			var task = e.Task as CommonModel;
            this.UpdateAppointment(task);
		}

        private void OnShowDialog(object sender, ShowDialogEventArgs e)
        {
            var additionalData = new ParentsInfo { Parents = this.ViewModel.Parents };

            e.DialogViewModel.AdditionalData = additionalData;
        }

		private void OnAppointmentDeleted(object sender, AppointmentDeletedEventArgs e)
		{
            var appointment = e.Appointment as CommonModel;
            var oldParent = appointment.GetOldParent();
            this.ViewModel.UpdateParent(oldParent, null, appointment);
		}

        private void OnAppointmentSaving(object sender, AppointmentSavingEventArgs e)
        {
            var appointment = e.Appointment as CommonModel;
            var oldParent = appointment.GetOldParent();
            var newParent = appointment.Parent;
            this.ViewModel.UpdateParent(oldParent, newParent, appointment);
        }

        private void OnAppointmentCreating(object sender, AppointmentCreatingEventArgs e)
        {
            (e.Appointment as CommonModel).Parent = this.ViewModel.Tasks[0].Children[0];
        }

        private void UpdateAppointment(CommonModel task)
        {
            this.scheduleView.BeginEdit(task);
            this.scheduleView.Commit();
        }
    }	
}