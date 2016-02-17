using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.ExampleHelpers;
using Telerik.Windows.Media.Imaging;
using Telerik.Windows.Media.Imaging.FormatProviders;

namespace Telerik.Windows.Examples.ImageEditor.Cropping
{
    public class ExampleViewModel : ViewModelBase
    {
        private static readonly string imagesFolder = @"/ImageEditor;component/SampleImages/";

        private Contact selectedContact;
        private List<Contact> contacts;
        private RadBitmap croppedImage;
        private Size initialSize;

        public ExampleViewModel()
        {
            this.Initialize();
        }

        public Contact SelectedContact
        {
            get { return this.selectedContact; }
            set
            {
                if (this.selectedContact != value)
                {
                    this.selectedContact = value;
                    this.OnPropertyChanged("SelectedContact");
                    this.OnSelectedContactChanged();
                }
            }
        }

        public RadBitmap CroppedImage
        {
            get { return this.croppedImage; }
            set
            {
                if (this.croppedImage != value)
                {
                    this.croppedImage = value;
                    this.OnPropertyChanged("CroppedImage");
                }
            }
        }

        public Size InitialSize
        {
            get { return this.initialSize; }
            set
            {
                if (this.initialSize != value)
                {
                    this.initialSize = value;
                    this.OnInitialSizeChanged();
                }
            }
        }

        public List<Contact> Contacts
        {
            get { return this.contacts; }
            set
            {
                if (this.contacts != value)
                {
                    this.contacts = value;
                    this.OnPropertyChanged("Contacts");
                }
            }
        }

        private void Initialize()
        {
            this.Contacts = new List<Contact>()
            {
                new Contact(imagesFolder + "photo1.png", "Robert King", "London, UK", "Robert.King@example.com", "5598", "71B"),
                new Contact(imagesFolder + "photo2.png", "Nancy Diavolio", "Seattle, USA", "Nancy.Diavolio@example.com", "9857", "206"),
                new Contact(imagesFolder + "photo3.png", "Steven Buchanan", "London, UK", "Steven.Buchanan@example.com", "4848", "71"),
            };

            this.SelectedContact = this.Contacts[0];
            this.CroppedImage = ImageExampleHelper.GetRadBitmap(imagesFolder + "thumbnail.png", new PngFormatProvider());
        }

        public event EventHandler SelectedContactChanged;
        protected void OnSelectedContactChanged()
        {
            if (this.SelectedContactChanged != null)
            {
                this.SelectedContactChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler InitialSizeChanged;
        protected void OnInitialSizeChanged()
        {
            if (this.InitialSizeChanged != null)
            {
                this.InitialSizeChanged(this, EventArgs.Empty);
            }
        }

    }
}