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

namespace Telerik.Windows.Examples.ScheduleView.Grouping.GroupingAndFiltering
{
    public class Speaker
    {
        private string name;
        private string title;
        
        public Speaker(string speakerName, string speakerTitle)
        {
            this.name = speakerName;
            this.title = speakerTitle;
        }

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
    }
}
