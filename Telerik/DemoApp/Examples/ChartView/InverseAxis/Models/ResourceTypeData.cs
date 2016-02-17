using System.Collections;

namespace Telerik.Windows.Examples.ChartView.LargeData.Models
{
    public class ResourceTypeData
    {
		public string Name { get; set; }
		public double AverageDepth { get; set; }
		public double MaximumDepth { get; set; }
		public IEnumerable ItemsSource { get; set; }
    }
}
