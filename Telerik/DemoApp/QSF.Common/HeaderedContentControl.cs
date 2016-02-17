using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Controls.QuickStart
{
	/// <summary>
	/// A HeaderedContentControl control.
	/// </summary>
#if WPF
	public class HeaderedContentControl : System.Windows.Controls.HeaderedContentControl
#else
    public class HeaderedContentControl : Telerik.Windows.Controls.HeaderedContentControl
#endif
	{

#if WPF
		static HeaderedContentControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(
				   typeof(HeaderedContentControl),
				   new FrameworkPropertyMetadata(typeof(System.Windows.Controls.HeaderedContentControl)));
		}
#endif

		/// <summary>
		/// Initializes a new instance of the RadButton class.
		/// </summary>
		public HeaderedContentControl()
		{
#if !WPF
			this.DefaultStyleKey = typeof(Telerik.Windows.Controls.QuickStart.HeaderedContentControl);
#endif
		}

#if !SILVERLIGHT
		/// <summary>
		/// Raises the <see cref="E:System.Windows.FrameworkElement.Initialized"/> event. This method is invoked whenever <see cref="P:System.Windows.FrameworkElement.IsInitialized"/> is set to true internally.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs"/> that contains the event data.</param>
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
			StyleManager.SetDefaultStyleKey(this, typeof(System.Windows.Controls.HeaderedContentControl));
		}
#endif
	}
}
