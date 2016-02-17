using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Windows.Examples.MaskedInput.Customizations
{
    public class CustomizationsViewModel : ViewModelBase
    {
        private decimal? bankAccount = null;
        private string fullName;
        private decimal? amount = null;

        public decimal? BankAccount
        {
            get { return bankAccount; }
            set
            {
                bankAccount = value;
                this.OnPropertyChanged("BankAccount");
            }
        }

        [Required(ErrorMessage = "Name is required.")]
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                this.OnPropertyChanged("FullName");
            }
        }

        public decimal? Amount
        {
            get { return amount; }
            set
            {
                if (value == null)
                {
                    throw new ValidationException("Amount cannot be null.");
                }
                amount = value;
                this.OnPropertyChanged("Amount");
            }
        }
    }
}
