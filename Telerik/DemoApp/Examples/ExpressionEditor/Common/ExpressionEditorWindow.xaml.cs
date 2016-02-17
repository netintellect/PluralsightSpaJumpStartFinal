using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ExpressionEditor
{
	/// <summary>
	/// Interaction logic for ExpressionEditorWindow.xaml
	/// </summary>
	public partial class ExpressionEditorWindow : RadWindow
	{
		public ExpressionEditorWindow()
		{
			InitializeComponent();
		}

		private void OnOkButtonClick(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
			this.Close();
		}

		private void OnCancelButtonClick(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
			this.Close();
		}
	}
}
