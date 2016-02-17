using System.ComponentModel;

namespace Examples.CoverFlow.CS.Silverlight
{
    public class ImageInfo : INotifyPropertyChanged
    {
        private string link;
		private string page;
        private string image;
		private string image_dimensions;
        private string title;
		private string author;
		private string description;
		private string file_extension;

        public ImageInfo()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                if (value != link)
                {
                    link = value;
                    this.OnPropertyChanged("Link");
                }
            }
        }

		public string Page
		{
			get
			{
				return page;
			}

			set
			{
				if (value != page)
				{
					page = value;
					this.OnPropertyChanged("Page");
				}
			}
		}

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                if (image != value)
                {
                    image = value;
                    this.OnPropertyChanged("Image");
                }
            }
        }

		public string ImageDimensions
		{
			get
			{
				return image_dimensions;
			}
			set
			{
				if (image_dimensions != value)
				{
					image_dimensions = value;
					this.OnPropertyChanged("ImageDimensions");
				}
			}
		}

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				if (description != value)
				{
					description = value;
					this.OnPropertyChanged("Description");
				}
			}
		}

		public string Author
		{
			get
			{
				return author;
			}
			set
			{
				if (author != value)
				{
					author = value;
					this.OnPropertyChanged("Author");
				}
			}
		}

		public string FileExtension
		{
			get
			{
				return file_extension;
			}
			set
			{
				if (file_extension != value)
				{
					file_extension = value;
					this.OnPropertyChanged("FileExtension");
				}
			}
		}
    }
}