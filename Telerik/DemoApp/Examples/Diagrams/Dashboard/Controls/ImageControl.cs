using System.Windows;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// Inheritable Image compatible with Silverlight.
	/// </summary>
	public class ImageControl : GeometryControl
	{
		public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageControl), null);

#if WPF
		static ImageControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageControl), new FrameworkPropertyMetadata(typeof(ImageControl)));
		}
#endif

		public ImageSource Source
		{
			get
			{
				return (ImageSource)this.GetValue(SourceProperty);
			}
			set
			{
				this.SetValue(SourceProperty, value);
			}
		}
	}
}