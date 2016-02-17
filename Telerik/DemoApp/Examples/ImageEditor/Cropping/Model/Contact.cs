using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media.Imaging;

namespace Telerik.Windows.Examples.ImageEditor.Cropping
{
    public class Contact : INotifyPropertyChanged
    {
        private BitmapImage image;
        private string name;
        private string location;
        private string email;
        private string phone;
        private string room;

        public Contact(string imagePath, string name, string location, string email, string phone, string room)
        {
            this.Image = this.CreateBitmapImage(imagePath);
            this.Name = name;
            this.Location = location;
            this.Email = email;
            this.Phone = phone;
            this.Room = room;
        }

        public BitmapImage Image
        {
            get { return this.image; }
            set
            {
                if (this.image != value)
                {
                    this.image = value;
                    this.OnPropertyChanged("Image");
                }
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public string Location
        {
            get { return this.location; }
            set
            {
                if (this.location != value)
                {
                    this.location = value;
                    this.OnPropertyChanged("Location");
                }
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.OnPropertyChanged("Email");
                }
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (this.phone != value)
                {
                    this.phone = value;
                    this.OnPropertyChanged("Phone");
                }
            }
        }

        public string Room
        {
            get { return this.room; }
            set
            {
                if (this.room != value)
                {
                    this.room = value;
                    this.OnPropertyChanged("Room");
                }
            }
        }

        private BitmapImage CreateBitmapImage(string imagePath)
        {
            Uri uri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            return new BitmapImage(uri);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}