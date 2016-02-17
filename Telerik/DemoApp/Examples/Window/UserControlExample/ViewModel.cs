using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Window.UserControlExample
{
	public class ViewModel : ViewModelBase
	{
		private DateTime startTime;
		private DateTime endTime;
		private DelegateCommand sendCommand;
		private DelegateCommand cancelCommand;

		public DelegateCommand SendCommand
		{
			get
			{
				return this.sendCommand;
			}
			set
			{
				this.sendCommand = value;
			}
		}

		public DelegateCommand CancelCommand
		{
			get
			{
				return this.cancelCommand;
			}
			set
			{
				this.cancelCommand = value;
			}
		}

		public DateTime StartTime
		{
			get
			{
				return this.startTime;
			}

			set
			{
				this.startTime = value;
				OnPropertyChanged("StartTime");
			}
		}

		public DateTime EndTime
		{
			get
			{
				return this.endTime;
			}

			set
			{
				this.endTime = value;
				OnPropertyChanged("EndTime");
			}
		}

		public ViewModel()
		{
			this.StartTime = DateTime.Today;
			this.EndTime = DateTime.Today;

			this.sendCommand = new DelegateCommand(this.SendCommandExecuted);
			this.cancelCommand = new DelegateCommand(this.CancelCommandExecuted);
		}

		private void SendCommandExecuted(object parameter)
		{
			RadWindow.Alert("Start time: " + this.StartTime + "\nEnd time: " + this.EndTime);
		}

		private void CancelCommandExecuted(object parameter)
		{
			UIElement elelemnt = parameter as UIElement;

			RadWindow window = elelemnt.GetVisualParent<RadWindow>();
			window.Close();
			window.Show();
		}
	}
}