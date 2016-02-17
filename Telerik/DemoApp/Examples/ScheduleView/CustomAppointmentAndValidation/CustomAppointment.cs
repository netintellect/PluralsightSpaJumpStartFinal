using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.CustomAppointment
{
    public class CustomAppointment : Appointment, IDataErrorInfo
    {
		private int episodeNumber;
		private bool isLive;

        public string Duration
        {
            get 
            {
				string durationInMinutes = (this.End - this.Start).TotalMinutes.ToString() + " min";
				return durationInMinutes;
            }
        }

		public int EpisodeNumber
		{
			get
			{
				return this.Storage<CustomAppointment>().episodeNumber;
			}
			set
			{
				CustomAppointment storage = this.Storage<CustomAppointment>();
				if (storage.episodeNumber != value)
				{
					storage.episodeNumber = value;
					this.OnPropertyChanged(() => this.EpisodeNumber);
				}
			}
		}

		public bool IsLive
		{
			get
			{
				return this.Storage<CustomAppointment>().isLive;
			}
			set
			{
				CustomAppointment storage = this.Storage<CustomAppointment>();
				if (storage.isLive != value)
				{
					storage.isLive = value;
					this.OnPropertyChanged(() => this.IsLive);
				}
			}
		}

		public string Error
		{
			get { return this.ValidateAppointment(); }
		}

		public string this[string columnName]
		{
			get 
			{
				switch (columnName)
				{
					case "EpisodeNumber":
						return this.ValidateEpisodeNumber();
					case "Subject":
						return this.ValidateSubject();
				}
				return null;
			}
		}

		public override IAppointment Copy()
		{
			IAppointment appointment = new CustomAppointment();
			appointment.CopyFrom(this);
			return appointment;
		}

		public override void CopyFrom(IAppointment other)
		{
			CustomAppointment appointment = other as CustomAppointment;
			if (appointment != null)
			{
				this.EpisodeNumber = appointment.EpisodeNumber;
				this.IsLive = appointment.IsLive;
			}
			base.CopyFrom(other);
		}

		protected override void OnPropertyChanged(string propertyName)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == "Start" || propertyName == "End")
			{
				this.OnPropertyChanged("Duration");
			}

			if (propertyName == "EpisodeNumber" || propertyName == "Subject")
			{
				CommandManager.InvalidateRequerySuggested();
			}
		}

		private string ValidateAppointment()
		{
			string errorString = this.ValidateSubject();
			errorString += this.ValidateEpisodeNumber();

			return errorString;
		}
	
		private string ValidateSubject()
		{
			if (string.IsNullOrEmpty(this.Subject))
			{
				return "The subject cannot be empty!";
			}
			return null;
		}

		private string ValidateEpisodeNumber()
		{
			if (this.EpisodeNumber <= 0)
			{
				return "The Episode number should be positive number";
			}
			return null;
		}
	}
}
