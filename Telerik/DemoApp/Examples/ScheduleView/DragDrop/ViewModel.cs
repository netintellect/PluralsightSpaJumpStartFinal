using System.Collections.ObjectModel;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.DragDrop
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private ObservableCollection<Appointment> basket;

		public ObservableCollection<Appointment> Basket
		{
			get
			{
				if (this.basket == null)
				{
					this.basket = new ObservableCollection<Appointment>();
					for (int i = 0; i < 5; i++)
					{
						this.basket.Add(this.Appointments[0]);
						this.Appointments.RemoveAt(0);
					}
				}
				
				return this.basket;
			}
		}
	}
}