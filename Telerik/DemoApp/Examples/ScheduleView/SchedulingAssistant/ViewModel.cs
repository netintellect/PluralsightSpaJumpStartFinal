using System;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.SchedulingAssistant
{
    public class ViewModel : ViewModelBase
    {
        private ObservableCollection<SupportMeetingAppointment> appointments;
        private ObservableCollection<Employee> employeesSource;
        private ResourceTypeCollection resources;
        private GroupDescriptionCollection groupDescriptions;

        public ObservableCollection<SupportMeetingAppointment> Appointments
        {
            get
            {
                if (this.appointments == null)
                {
                    this.appointments = new ObservableCollection<SupportMeetingAppointment>();
                    var app1 = new SupportMeetingAppointment { Subject = "Support Conference Call", Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(11) };
                    app1.Resources.Add((this.Resources[0]).Resources[0] as Resource);
                    app1.Resources.Add((this.Resources[0]).Resources[2] as Resource);
                    app1.Attendees.Add(this.EmployeesSource[1]);
                    app1.Attendees.Add(this.EmployeesSource[4]);
                    this.appointments.Add(app1);

                    var app2 = new SupportMeetingAppointment { Subject = "Interview For Junior Support Officer", Start = DateTime.Today.AddHours(8.25), End = DateTime.Today.AddHours(9.25) };
                    app2.Resources.Add((this.Resources[0]).Resources[1] as Resource);
                    this.appointments.Add(app2);

                    var app3 = new SupportMeetingAppointment { Subject = "Conference Call with Harry Taylor", Start = DateTime.Today.AddHours(11.25), End = DateTime.Today.AddHours(12.25) };
                    app3.Resources.Add((this.Resources[0]).Resources[1] as Resource);
                    this.appointments.Add(app3);
                }

                return this.appointments;
            }
        }

        public ObservableCollection<Employee> EmployeesSource
        {
            get
            {
                if (this.employeesSource == null)
                {
                    this.employeesSource = new ObservableCollection<Employee>();
                    this.employeesSource.Add(new Employee { Name = "Anthony Baker", ImageSource = "../../Images/ScheduleView/SchedulingAssistant/1.png" });
                    this.employeesSource.Add(new Employee { Name = "Penelope McDonald", ImageSource = "../../Images/ScheduleView/SchedulingAssistant/2.png" });
                    this.employeesSource.Add(new Employee { Name = "Gavin Thomson", ImageSource = "../../Images/ScheduleView/SchedulingAssistant/3.png" });
                    this.employeesSource.Add(new Employee { Name = "Emily Ogden", ImageSource = "../../Images/ScheduleView/SchedulingAssistant/4.png" });
                    this.employeesSource.Add(new Employee { Name = "Luke Graham", ImageSource = "../../Images/ScheduleView/SchedulingAssistant/5.png" });
                    this.employeesSource.Add(new Employee { Name = "Rebecca Quinn", ImageSource = "../../Images/ScheduleView/SchedulingAssistant/6.png" });
                    this.employeesSource.Add(new Employee { Name = "Clark Kent", ImageSource = "../../Images/ScheduleView/SchedulingAssistant/7.png" });
                }

                return this.employeesSource;
            }
        }

        public ResourceTypeCollection Resources
        {
            get
            {
                if (this.resources == null)
                {
                    ResourceType locationResource = new ResourceType("Location");
                    locationResource.AllowMultipleSelection = true;
                    locationResource.Resources.Add(new Resource("Conference Room - Sofia"));
                    locationResource.Resources.Add(new Resource("Conference Room - Boston"));
                    locationResource.Resources.Add(new Resource("Conference Room - Sidney"));

                    this.resources = new ResourceTypeCollection { locationResource };
                }

                return this.resources;
            }
        }

        public GroupDescriptionCollection GroupDescriptions
        {
            get
            {
                if (this.groupDescriptions == null)
                {
                    this.groupDescriptions = new GroupDescriptionCollection
                    {
                        new DateGroupDescription(),
                        new ResourceGroupDescription{ ResourceType = "Location" }
                    };
                }

                return this.groupDescriptions;
            }
        }
    }
}