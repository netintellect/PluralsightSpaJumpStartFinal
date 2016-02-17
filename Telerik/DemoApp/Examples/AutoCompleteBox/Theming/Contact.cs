using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.AutoCompleteBox.Theming
{
    public class Contact
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                }
            }
        }
    }
}
