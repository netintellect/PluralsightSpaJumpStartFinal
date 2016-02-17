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

namespace Telerik.Windows.Examples.ContextMenu.FirstLook
{
    public class Flag
    {
        private string country;
        private string source;

        public Flag()
        {
            this.country = null;
            this.source = null;
        }

        public Flag(string country, string source)
        {
            this.country = country;
            this.source = source;
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        
    }
}
