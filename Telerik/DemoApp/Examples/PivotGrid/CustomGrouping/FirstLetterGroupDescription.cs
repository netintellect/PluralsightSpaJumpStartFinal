using Telerik.Pivot.Core;

namespace Telerik.Windows.Examples.PivotGrid.CustomGrouping
{
    public class FirstLetterGroupDescription : PropertyGroupDescriptionBase
    {
        protected override object GroupNameFromItem(object item, int level)
        {
            var groupName = base.GroupNameFromItem(item, level).ToString();
            return groupName.Substring(0, 1).ToUpperInvariant();
        }

        protected override Cloneable CreateInstanceCore()
        {
            return new FirstLetterGroupDescription();
        }

        protected override void CloneOverride(Cloneable source)
        {
            // Copy all properties from source to 'this' description.
        }
    }
}
