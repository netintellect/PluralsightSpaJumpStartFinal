using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace Telerik.Windows.Examples.Diagrams.MindMap
{
	/// <summary>
	/// Interaction logic for SettingsPane.xaml
	/// </summary>
	public partial class SettingsPane : UserControl
	{
		public SettingsPane()
		{
			InitializeComponent();
		}

		private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}
	}
}
