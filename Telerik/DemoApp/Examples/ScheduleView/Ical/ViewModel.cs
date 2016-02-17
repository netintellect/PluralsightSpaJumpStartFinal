using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using Microsoft.Win32;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.Controls.ScheduleView.ICalendar;

namespace Telerik.Windows.Examples.ScheduleView.Ical
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private string exportValue;
		private ICommand exportCommand;
		private ICommand importCommand;

		public ViewModel()
		{
			this.ExportCommand = new DelegateCommand(this.ExportExecuted);
			this.ImportCommand = new DelegateCommand(this.ImportExecuted);
		}

		public ICommand ExportCommand
		{
			get
			{
				return this.exportCommand;
			}
			set
			{
				this.exportCommand = value;
			}
		}

		public ICommand ImportCommand
		{
			get
			{
				return this.importCommand;
			}
			set
			{
				this.importCommand = value;
			}
		}

		public string ExportValue
		{
			get
			{
				return this.exportValue;
			}
			set
			{
				if (this.exportValue != value)
				{
					this.exportValue = value;
					this.OnPropertyChanged(() => this.ExportValue);
				}
			}
		}

		public Visibility TextBoxVisibility
		{
			get
			{
#if WPF
				return BrowserInteropHelper.IsBrowserHosted ? Visibility.Visible : Visibility.Collapsed;
#else
				return Visibility.Collapsed;
#endif
			}
		}

		private void ExportExecuted(object parameter)
		{
#if WPF
			if (BrowserInteropHelper.IsBrowserHosted)
			{
				this.ExportValue = this.ExportToString();
			}
			else
			{
#endif
				this.ExportToFile();
#if WPF
			}
#endif
		}

		private void ImportExecuted(object parametere)
		{
#if WPF
			if (BrowserInteropHelper.IsBrowserHosted)
			{
				this.ImportFromString(this.ExportValue);
			}
			else
			{
				this.ImportFromFile();
			}
#else
			this.ImportFromFile();
#endif
		}

		private void ExportToFile()
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.DefaultExt = ".ics";
			dialog.Filter = "ICalendar file (.ics)|*.ics";

			bool? result = dialog.ShowDialog();
			if (result.HasValue && result.Value)
			{
				using (Stream stream = dialog.OpenFile())
				{
					using (TextWriter writer = new StreamWriter(stream))
					{
						AppointmentCalendarExporter exporter = new AppointmentCalendarExporter();
						exporter.Export(this.Appointments.OfType<IAppointment>(), writer);
					}
				}
			}
		}

		private string ExportToString()
		{
			StringBuilder builder = new StringBuilder();
			using (TextWriter writer = new StringWriter(builder))
			{
				AppointmentCalendarExporter exporter = new AppointmentCalendarExporter();
				exporter.Export(this.Appointments.OfType<IAppointment>(), writer);
			}

			return builder.ToString();
		}

#if WPF
		private void ImportFromFile()
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.DefaultExt = ".ics";
			dialog.Filter = "ICalendar file (.ics)|*.ics";
			bool? result = dialog.ShowDialog();
			if (result.HasValue && result.Value)
			{
				using (TextReader txtReader = new StreamReader(dialog.FileName))
				{
					this.Import(txtReader);
				}
			}
		}
#else
		private void ImportFromFile()
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "ICalendar file (.ics)|*.ics";
			bool? result = dialog.ShowDialog();
			if (result.HasValue && result.Value)
			{
				using (Stream reader = dialog.File.OpenRead())
				{
					using (TextReader txtReader = new StreamReader(reader))
					{
						this.Import(txtReader);
					}
				}
			}
		}
#endif

		private void ImportFromString(string s)
		{
			using (TextReader reader = new StringReader(s))
			{
				this.Import(reader);
			}
		}

		private void Import(TextReader reader)
		{
			try
			{
				AppointmentCalendarImporter importer = new AppointmentCalendarImporter();
				IEnumerable<IAppointment> appointments = importer.Import(reader);

				foreach (Appointment app in appointments)
				{
					this.Appointments.Add(app);
				}
			}
			catch (CalendarParseException ex)
			{
				MessageBox.Show(ex.Message, "CalendarParseException", MessageBoxButton.OK);
			}
		}
	}
}