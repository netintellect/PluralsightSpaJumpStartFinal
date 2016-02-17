using System;
using System.Collections.ObjectModel;
using System.Windows;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.SchedulingAssistant
{
    public class SupportMeetingAppointment : Appointment
    {
        private ObservableCollection<Employee> attendees;
        private bool isDraggedFromListBox;
        private string imageSource;
        private string sourceResource;

        public SupportMeetingAppointment()
        {
            this.Attendees = new ObservableCollection<Employee>();
            this.Attendees.CollectionChanged += Attendees_CollectionChanged;

        }

        void Attendees_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.Attendees.Count > 4)
            {
#if SILVERLIGHT
                Deployment.Current.Dispatcher.BeginInvoke(() => this.Attendees.RemoveAt(3));
#else
                Application.Current.Dispatcher.BeginInvoke(new Action(() => this.Attendees.RemoveAt(3)));
#endif
            }
        }

        public ObservableCollection<Employee> Attendees
        {
            get
            {
                return this.Storage<SupportMeetingAppointment>().attendees;
            }
            set
            {
                var storage = this.Storage<SupportMeetingAppointment>();
                if (storage.attendees != value)
                {
                    storage.attendees = value;
                    this.OnPropertyChanged(() => this.Attendees);
                }
            }
        }

        public bool IsDraggedFromListBox
        {
            get
            {
                return this.Storage<SupportMeetingAppointment>().isDraggedFromListBox;
            }
            set
            {
                var storage = this.Storage<SupportMeetingAppointment>();
                if (storage.isDraggedFromListBox != value)
                {
                    storage.isDraggedFromListBox = value;
                    this.OnPropertyChanged(() => this.IsDraggedFromListBox);
                }
            }
        }

        public string ImageSource
        {
            get
            {
                return this.Storage<SupportMeetingAppointment>().imageSource;
            }
            set
            {
                var storage = this.Storage<SupportMeetingAppointment>();
                if (storage.imageSource != value)
                {
                    storage.imageSource = value;
                    this.OnPropertyChanged(() => this.ImageSource);
                }
            }
        }

        public string SourceResource
        {
            get
            {
                return this.Storage<SupportMeetingAppointment>().sourceResource;
            }

            set
            {
                var storage = this.Storage<SupportMeetingAppointment>();

                if (storage.sourceResource != value)
                {
                    storage.sourceResource = value;
                    this.OnPropertyChanged(() => this.SourceResource);
                }
            }
        }

        public override IAppointment Copy()
        {
            var newAppointment = new SupportMeetingAppointment();
            newAppointment.CopyFrom(this);
            return newAppointment;
        }

        public override void CopyFrom(IAppointment other)
        {
            var appointment = other as SupportMeetingAppointment;
            if (appointment != null)
            {
                this.ImageSource = appointment.ImageSource;
                this.IsDraggedFromListBox = appointment.IsDraggedFromListBox;
                this.SourceResource = appointment.SourceResource;
                this.Attendees = appointment.Attendees;
            }

            base.CopyFrom(other);
        }
    }
}
