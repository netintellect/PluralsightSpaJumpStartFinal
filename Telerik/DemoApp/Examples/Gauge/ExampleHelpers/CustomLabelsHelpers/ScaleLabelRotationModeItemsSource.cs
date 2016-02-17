using System.Collections;
using Telerik.Windows.Controls.Gauge;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Items source that represents scale object rotation mode.
	/// </summary>
	public class ScaleLabelRotationModeItemsSource : EnumItemsSource
	{
		/// <summary>
		/// Creates instance of the class
		/// </summary>
		public ScaleLabelRotationModeItemsSource()
		{
			this.TypeName = typeof(RotationMode).AssemblyQualifiedName;
		}
	}
}
