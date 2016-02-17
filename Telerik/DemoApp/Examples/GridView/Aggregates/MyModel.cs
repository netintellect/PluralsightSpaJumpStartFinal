using System;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Aggregates
{
    public class MyModel : ViewModelBase
    {
        bool showGroupHeaderColumnAggregates;
        public bool ShowGroupHeaderColumnAggregates 
        {
            get
            {
                return showGroupHeaderColumnAggregates;
            }
            set
            {
                if (showGroupHeaderColumnAggregates != value)
                {
                    showGroupHeaderColumnAggregates = value;

                    OnPropertyChanged("ShowGroupHeaderColumnAggregates");
                }
            }
        }

        bool showHeaderAggregates;
        public bool ShowHeaderAggregates
        {
            get
            {
                return showHeaderAggregates;
            }
            set
            {
                if (showHeaderAggregates != value)
                {
                    showHeaderAggregates = value;

                    OnPropertyChanged("ShowHeaderAggregates");
                }
            }
        }
    }
}
