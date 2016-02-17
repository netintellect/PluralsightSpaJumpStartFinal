using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.Common
{
    public class ResourceAppointmentItemStyleSelector : OrientedAppointmentItemStyleSelector
    {
        private Style newsHorizontalStyle;
        private Style sportsHorizontalStyle;
        private Style kidsHorizontalStyle;
        private Style moviesHorizontalStyle;
        private Style showsHorizontalStyle;

        private Style newsVerticalStyle;
        private Style sportsVerticalStyle;
        private Style kidsVerticalStyle;
        private Style moviesVerticalStyle;
        private Style showsVerticalStyle;

        public Style NewsHorizontalStyle
        {
            get
            {
                return this.newsHorizontalStyle;
            }
            set
            {
                this.newsHorizontalStyle = value;
            }
        }

        public Style SportsHorizontalStyle
        {
            get
            {
                return this.sportsHorizontalStyle;
            }
            set
            {
                this.sportsHorizontalStyle = value;
            }
        }

        public Style KidsHorizontalStyle
        {
            get
            {
                return this.kidsHorizontalStyle;
            }
            set
            {
                this.kidsHorizontalStyle = value;
            }
        }

        public Style MoviesHorizontalStyle
        {
            get
            {
                return this.moviesHorizontalStyle;
            }
            set
            {
                this.moviesHorizontalStyle = value;
            }
        }

        public Style ShowsHorizontalStyle
        {
            get
            {
                return this.showsHorizontalStyle;
            }
            set
            {
                this.showsHorizontalStyle = value;
            }
        }

        public Style NewsVerticalStyle
        {
            get
            {
                return this.newsVerticalStyle;
            }
            set
            {
                this.newsVerticalStyle = value;
            }
        }

        public Style SportsVerticalStyle
        {
            get
            {
                return this.sportsVerticalStyle;
            }
            set
            {
                this.sportsVerticalStyle = value;
            }
        }

        public Style KidsVerticalStyle
        {
            get
            {
                return this.kidsVerticalStyle;
            }
            set
            {
                this.kidsVerticalStyle = value;
            }
        }

        public Style MoviesVerticalStyle
        {
            get
            {
                return this.moviesVerticalStyle;
            }
            set
            {
                this.moviesVerticalStyle = value;
            }
        }

        public Style ShowsVerticalStyle
        {
            get
            {
                return this.showsVerticalStyle;
            }
            set
            {
                this.showsVerticalStyle = value;
            }
        }

        public override Style SelectStyle(object item, DependencyObject container, ViewDefinitionBase activeViewDefinition)
        {
            IAppointment appointment = item as IAppointment;
            if (appointment == null)
            {
                return base.SelectStyle(item, container, activeViewDefinition);
            }

            IResource resource = appointment.Resources.OfType<IResource>().FirstOrDefault((IResource r) => r.ResourceType == "Programme");
            if (resource != null)
            {
                if (activeViewDefinition.GetOrientation() == Orientation.Horizontal)
                {
                    switch (resource.ResourceName)
                    {
                        case "News": return this.NewsHorizontalStyle;
                        case "Sports": return this.SportsHorizontalStyle;
                        case "Kids": return this.KidsHorizontalStyle;
                        case "Movies": return this.MoviesHorizontalStyle;
                        case "Shows": return this.ShowsHorizontalStyle;
                        default: break;
                    }
                }
                else
                {
                    switch (resource.ResourceName)
                    {
                        case "News": return this.NewsVerticalStyle;
                        case "Sports": return this.SportsVerticalStyle;
                        case "Kids": return this.KidsVerticalStyle;
                        case "Movies": return this.MoviesVerticalStyle;
                        case "Shows": return this.ShowsVerticalStyle;
                        default: break;
                    }
                }
            }

            return base.SelectStyle(item, container, activeViewDefinition);
        }
    }
}
