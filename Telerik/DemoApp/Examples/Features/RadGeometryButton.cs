using Telerik.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Telerik.Windows.Diagrams.Features
{
	/// <summary>
	/// 
	/// </summary>
	public class RadGeometryButton : RadButton
	{
		/// <summary>
		/// 
		/// </summary>
		public static readonly DependencyProperty GeometryProperty = DependencyProperty.Register("Geometry", typeof(Geometry), typeof(RadGeometryButton), null);

		/// <summary>
		/// Gets or sets the geometry.
		/// </summary>
		/// <value>
		/// The geometry.
		/// </value>
		public Geometry Geometry
		{
			get { return (Geometry)GetValue(GeometryProperty); }
			set { SetValue(GeometryProperty, value); }
		}
	}
}
