using Telerik.Windows.Persistence;
using Telerik.Windows.Controls;
using System.Windows;
namespace Telerik.Windows.Examples.PersistenceFramework.IntrinsicControls
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		private void buttonBold_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			RadToggleButton button = sender as RadToggleButton;
			if (button != null)
			{
				if (button.IsChecked == true)
				{
					targetText.FontWeight = FontWeights.Bold;
				}
				else
				{
					targetText.ClearValue(System.Windows.Controls.TextBox.FontWeightProperty);
				}
			}
		}

		private void buttonItalic_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			RadToggleButton button = sender as RadToggleButton;
			if (button != null)
			{
				if (button.IsChecked == true)
				{
					targetText.FontStyle = FontStyles.Italic;
				}
				else
				{
					targetText.ClearValue(System.Windows.Controls.TextBox.FontStyleProperty);
				}
			}
		}
	}
}
