using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Telerik.Windows.QuickStart
{
	/// <summary>
	/// Interaction logic for NonHighlightedControls.xaml
	/// </summary>
	public partial class NonHighlightedControls : UserControl
	{
		public bool IsRenderingSmall
		{
			get { return (bool)GetValue(IsRenderingSmallProperty); }
			private set { SetValue(IsRenderingSmallProperty, value); }
		}

		// TODO: make read only
		public static readonly DependencyProperty IsRenderingSmallProperty =
			DependencyProperty.Register("IsRenderingSmall", typeof(bool), typeof(NonHighlightedControls), new UIPropertyMetadata(false));

		public NonHighlightedControls()
		{
			InitializeComponent();
		}

		protected override Size MeasureOverride(Size constraint)
		{
			this.IsRenderingSmall = constraint.Width < 750;
			return base.MeasureOverride(constraint);
		}
	}
}
