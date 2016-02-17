using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// Inheritable Image compatible with Silverlight.
	/// </summary>
	public class GeometryControl : Control
	{		
		public static readonly DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(Geometry), typeof(GeometryControl), null);
		
#if WPF
		static GeometryControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(GeometryControl), new FrameworkPropertyMetadata(typeof(GeometryControl)));
		}
#endif

		public Geometry Path
		{
			get { return (Geometry)GetValue(PathProperty); }
			set { SetValue(PathProperty, value); }
		}
	}
}