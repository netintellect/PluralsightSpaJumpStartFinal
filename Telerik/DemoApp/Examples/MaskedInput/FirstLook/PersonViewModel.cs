using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.MaskedInput.FirstLook
{
	public class PersonViewModel : ViewModelBase
	{
		private string firstName;
		private string lastName;
		private string email;
		private string zipCode;
		private string validationCode;
		private string cardNumber;

        [Required(AllowEmptyStrings = false)]
		[RegularExpression(@"\b^[A-Z][a-zA-Z '&-]*[A-Za-z]$\b", ErrorMessage = "Invalid First Name !")]
		public string FirstName
		{
			get { return this.firstName; }
			set
			{
				if (this.firstName != value)
				{
					Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "FirstName" });
					this.firstName = value;
					this.OnPropertyChanged("FirstName");
				}
			}
		}

        [Required(AllowEmptyStrings = false)]
		[RegularExpression(@"\b^[A-Z][a-zA-Z '&-]*[A-Za-z]$\b", ErrorMessage = "Invalid Last Name !")]
		public string LastName
		{
			get { return this.lastName; }
			set
			{
				if (this.lastName != value)
				{
					Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "LastName" });
					this.lastName = value;
					this.OnPropertyChanged("LastName");
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

		[StringLength(4, MinimumLength = 4, ErrorMessage = "The Zip Code must be exactly 4 characters. ")]
		[RegularExpression(@"\b^[0-9]*\b", ErrorMessage = "Only digits allowed !")]
		public string ZipCode
		{
			get { return zipCode; }
			set
			{
				Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ZipCode" });
				zipCode = value;
				this.OnPropertyChanged("ZipCode");
			}
		}

		[StringLength(4, MinimumLength = 4, ErrorMessage = "The ValidationCode must be exactly 4 characters. ")]
		[RegularExpression(@"\b^[0-9]*\b", ErrorMessage = "Only digits allowed !")]
		public string ValidationCode
		{
			get { return this.validationCode; }
			set
			{
				if (this.validationCode != value)
				{
					Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ValidationCode" });
					this.validationCode = value;
					this.OnPropertyChanged("ValidationCode");
				}
			}
		}


		[StringLength(4, MinimumLength = 4, ErrorMessage = "The CardNumber must be exactly 4 characters. ")]
		[RegularExpression(@"\b^[0-9]*\b", ErrorMessage = "Only digits allowed !")]
		public string CardNumber
		{
			get { return this.cardNumber; }
			set
			{
				if (this.cardNumber != value)
				{
					Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CardNumber" });
					this.cardNumber = value;
					this.OnPropertyChanged("CardNumber");
				}
			}
		}
	}
}
