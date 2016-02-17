using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.AutoCompleteBox.FirstLook
{
    public class Movie
    {
        private string movieTitle = String.Empty;

        public string MovieTitle
        {
            get
            {
                return this.movieTitle;
            }
            set
            {
                if (this.movieTitle != value)
                {
                    this.movieTitle = value;
                }
            }
        }
    }
}
