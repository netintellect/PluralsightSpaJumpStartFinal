using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PropertyGrid.EditorAttribute
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private string position;
        private string location;
        private Color currentColor;
        private ContactInformation contactInformation;

        [Display(Name = "Employee Name")]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");

                }
            }
        }

        public string Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (this.position != value)
                {
                    this.position = value;
                    this.OnPropertyChanged("Position");
                }
            }
        }

        [Telerik.Windows.Controls.Data.PropertyGrid.Editor(typeof(MapEditorControl), "Location", Telerik.Windows.Controls.Data.PropertyGrid.EditorStyle.Modal),]
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (this.location != value)
                {
                    this.location = value;
                    this.OnPropertyChanged("Location");
                }
            }
        }
#if !SILVERLIGHT		
        [TypeConverter(typeof(ColorToNameConverter))]
#endif
        [Display(Name = "Color", Order = 5)]
        [Telerik.Windows.Controls.Data.PropertyGrid.Editor(typeof(RadColorSelector), "SelectedColor", Telerik.Windows.Controls.Data.PropertyGrid.EditorStyle.DropDown)]
        public Color CurrentColor
        {
            get
            {
                return this.currentColor;
            }
            set
            {
                if (this.currentColor != value)
                {
                    this.currentColor = value;
                    this.OnPropertyChanged("CurrentColor");
                }
            }
        }

        [Display(Name = "Contact Information", Order = 4)]
        [Telerik.Windows.Controls.Data.PropertyGrid.Editor(typeof(ContactInformationControl), Telerik.Windows.Controls.Data.PropertyGrid.EditorStyle.DropDown)]
        public ContactInformation ContactInformation
        {
            get
            {
                return this.contactInformation;
            }
            set
            {
                if (this.contactInformation != value)
                {
                    this.contactInformation = value;
                    this.OnPropertyChanged("ContactInformation");
                }
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
