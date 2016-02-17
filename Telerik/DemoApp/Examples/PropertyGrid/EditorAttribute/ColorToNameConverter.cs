using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Telerik.Windows.Examples.PropertyGrid.EditorAttribute
{
    public class ColorToNameConverter : TypeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(value.ToString());
            if (color != null && color.IsKnownColor)
            {
                return color.ToKnownColor();
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
