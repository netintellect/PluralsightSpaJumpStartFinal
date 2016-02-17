using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.ToolTip.FirstLook
{
    public class MapItem : ViewModelBase
    {
        private string countryname;
        public string CountryName
        {
            get { return this.countryname; }
            set
            {
                if (this.countryname != value)
                {
                    this.countryname = value;
                    this.OnPropertyChanged("CountryName");
                }
            }
        }

        private string description;
        public string Description
        {
            get { return this.description; }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }

        private Location location = Location.Empty;
        public Location Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
                this.OnPropertyChanged("Location");
            }
        }

        private string title;
        public string Title
        {
            get { return this.title; }
            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        private string imgpath;
        public string ImgPath
        {
            get { return this.imgpath; }
            set
            {
                if (this.imgpath != value)
                {
                    this.imgpath = value;
                    this.OnPropertyChanged("ImgPath");
                }
            }
        }

        private string caption;
        public string Caption
        {
            get { return this.caption; }
            set
            {
                if (this.caption != value)
                {
                    this.caption = value;
                    this.OnPropertyChanged("Caption");
                }
            }
        }

        private bool isVisible;
        public bool IsVisible
        {
            get { return this.isVisible; }
            set
            {
                if (this.isVisible != value)
                {
                    this.isVisible = value;
                    this.OnPropertyChanged("IsVisible");
                }
            }
        }
    }
}