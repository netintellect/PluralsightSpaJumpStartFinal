using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.AutoCompleteBox.FirstLook
{
    public class Song
    {
        private string title = String.Empty;
        private string author = String.Empty;

        public string Title 
        {
            get
            {
                return this.title;
            }
            set
            {
                if (this.title != value)
                {
                    this.title = value;
                }
            }
        }
        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (this.author != value)
                {
                    this.author = value;
                }
            }
        }
    }
}
