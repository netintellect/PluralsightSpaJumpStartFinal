using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.AutoCompleteBox.FirstLook
{
    public class FoodPlace
    {
        private string name = String.Empty;
        private Uri iconPath;
        private string iconBackground = String.Empty;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                }
            }
        }

        public Uri IconPath
        {
            get
            {
                return this.iconPath;
            }
            set
            {
                if (this.iconPath != value)
                {
                    this.iconPath = value;
                }
            }
        }

        public string IconBackground
        {
            get
            {
                return this.iconBackground;
            }
            set
            {
                if (this.iconBackground != value)
                {
                    this.iconBackground = value;
                }
            }
        }
    }
}
