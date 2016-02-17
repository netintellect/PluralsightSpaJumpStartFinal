using System;
using System.Windows.Media;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.CustomStyles.AppointmentTemplate
{
    public class CustomAppointment : Appointment
    {
        private Brush backgroundBrush;
        private string lecturePart;
        private string pathData;
        private int pathWidth;
        private int pathHeight;

        public CustomAppointment()
        {
            this.backgroundBrush = new SolidColorBrush(Color.FromArgb(255, 169, 162, 0));
            this.lecturePart = "Lecture Part 1";
            this.pathData = string.Empty;
            this.pathWidth = 14;
            this.pathHeight = 16;
        }

        public Brush BackgroundBrush
        {
            get
            {
                return this.backgroundBrush;
            }
            set
            {
                this.backgroundBrush = value;
            }
        }

        public string LecturePart
        {
            get
            {
                return this.lecturePart;
            }
            set
            {
                this.lecturePart = value;
            }
        }

        public string PathData
        {
            get
            {
                return this.pathData;
            }
            set
            {
                this.pathData = value;
            }
        }

        public int PathWidth
        {
            get
            {
                return this.pathWidth;
            }
            set
            {
                this.pathWidth = value;
            }
        }

        public int PathHeight
        {
            get
            {
                return this.pathHeight;
            }
            set
            {
                this.pathHeight = value;
            }
        }
    }
}
