using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.TableShape.Models;

namespace Telerik.Windows.Examples.Diagrams.TableShape
{
    public class ShapeStyleSelector : StyleSelector
    {
        public Style RowStyle { get; set; }
        public Style TableStyle { get; set; }

        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            if (item is RowModel)
                return this.RowStyle;

            return this.TableStyle;
        }
    }
}
