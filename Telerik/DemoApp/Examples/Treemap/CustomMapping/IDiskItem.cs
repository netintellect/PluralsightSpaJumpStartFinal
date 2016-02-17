using System.Collections.Generic;

namespace Telerik.Windows.Examples.Treemap.CustomMapping
{
    public interface IDiskItem
    {
        string Name { get; }
        long Size { get; }
        IEnumerable<IDiskItem> Children { get; }
    }
}
