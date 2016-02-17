using System;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	public partial class Example : UserControl
	{
		public Example()
		{
			this.InitializeComponent();
			this.UpdateMinimap();
		}

		private void TimeBar_VisiblePeriodChanged(object sender, RadRoutedEventArgs e)
		{
			if (this.TimeBar != null)
			{
				DateTime roundedVisiblePeriodStart = this.TimeBar.VisiblePeriodStart.Date;
				DateTime roundedVisiblePeriodEnd = this.TimeBar.VisiblePeriodEnd.Date;

				if (roundedVisiblePeriodStart != this.TimeBar.VisiblePeriodStart)
				{
					this.TimeBar.VisiblePeriodStart = roundedVisiblePeriodStart;
				}
				if (roundedVisiblePeriodEnd != this.TimeBar.VisiblePeriodEnd)
				{
					this.TimeBar.VisiblePeriodEnd = roundedVisiblePeriodEnd;
				}

				this.UpdateMinimap();
			}
		}

		private void UpdateMinimap()
		{
			int visibleDays = (int)this.TimeBar.VisiblePeriodEnd.Date.Subtract(this.TimeBar.VisiblePeriodStart.Date).TotalDays;

			this.MinimapSchedule.ActiveViewDefinition.VisibleDays = visibleDays;
		}

		private void MainSchedule_AppointmentCreated(object sender, Controls.AppointmentCreatedEventArgs e)
		{
            var viewModel = (sender as RadScheduleView).DataContext as RandomGeneratorViewModel;
            viewModel.SelectedAppointment = e.CreatedAppointment as Appointment;
            viewModel.UpdateMinimap();
		}

		private void MainSchedule_AppointmentDeleted(object sender, AppointmentDeletedEventArgs e)
		{
			((sender as RadScheduleView).DataContext as RandomGeneratorViewModel).UpdateMinimap();
		}

		private void MainSchedule_AppointmentEdited(object sender, AppointmentEditedEventArgs e)
		{
			((sender as RadScheduleView).DataContext as RandomGeneratorViewModel).UpdateMinimap();
		}
	}
}