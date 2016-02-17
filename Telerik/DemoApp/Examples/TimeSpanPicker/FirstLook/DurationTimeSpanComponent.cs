using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TimeSpanPicker.FirstLook
{
    public class DurationTimeSpanComponent : TimeSpanComponentBase
    {
        public override long GetTicksFromItem(object item)
        {
            var duration = item as string;

            if (duration != null)
            {
                var value = duration.Split(' ').ElementAt(0);
                return TimeSpan.FromMinutes(double.Parse(value)).Ticks;
            }
            return 0;
        }

        protected override System.Windows.Freezable CreateInstanceCore()
        {
            return new DurationTimeSpanComponent();
        }
    }
}
