using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Telerik.Windows.Examples.PropertyGrid.EditorAttribute
{
    public class ContactInformation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string phoneNumber;
        private string email;

        [RegularExpression(@"\d+", ErrorMessage = "Invalid Phone Number !")]
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (this.phoneNumber != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "PhoneNumber" });
                    this.phoneNumber = value;
                    this.OnPropertyChanged("PhoneNumber");
                }
            }
        }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"[a-z]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Invalid E-mail !")]
        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.email != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Email" });

                    this.email = value;
                    this.OnPropertyChanged("Email");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Input phone number and e-mail");
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
