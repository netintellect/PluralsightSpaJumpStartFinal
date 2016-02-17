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
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Window.APC
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{		

		public Example()
		{
			InitializeComponent();
			this.employeeName.Text = "Maria Ferero";			
		}

		private void btnAlert_Click(object sender, RoutedEventArgs e)
		{
			string alertText = "The employee photo has been uploaded.";
            RadWindow.Alert(new DialogParameters
            {
                Content = alertText,
                Closed = new EventHandler<WindowClosedEventArgs>(OnClosed),
                Owner = Application.Current.MainWindow
            });
		}

		private void btnPrompt_Click(object sender, RoutedEventArgs e)
		{
			string promptText = "Rename employee:";
            RadWindow.Prompt(new DialogParameters
            {
                Content = promptText,
                Closed = new EventHandler<WindowClosedEventArgs>(OnPromptClosed),
                Owner = Application.Current.MainWindow
            });
        }

		private void btnConfirm_Click(object sender, RoutedEventArgs e)
		{
			string confirmText = "Are you sure you want to switch the photo?";
            RadWindow.Confirm(new DialogParameters
            {
                Content = confirmText,
                Closed = new EventHandler<WindowClosedEventArgs>(OnConfirmClosed),
                Owner = Application.Current.MainWindow
            });
		}

		private void OnClosed(object sender, WindowClosedEventArgs e)
		{
            RadWindow.Alert(new DialogParameters
            {
                Content = String.Format("DialogResult: {0}, PromptResult: {1}", e.DialogResult, e.PromptResult),
                Owner = Application.Current.MainWindow
            });
		}
		private void OnPromptClosed(object sender, WindowClosedEventArgs e)
		{
            RadWindow.Alert(new DialogParameters
            {
                Content = String.Format("DialogResult: {0}, PromptResult: {1}", e.DialogResult, e.PromptResult),
                Owner = Application.Current.MainWindow
            });
			if (e.PromptResult != null && e.PromptResult != string.Empty)
			{
				this.employeeName.Text = e.PromptResult;
			}
		}
		private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
		{
            RadWindow.Alert(new DialogParameters
            {
                Content = String.Format("DialogResult: {0}, PromptResult: {1}", e.DialogResult, e.PromptResult),
                Owner = Application.Current.MainWindow
            });

			if (e.DialogResult == true)
			{
				if (this.femalePhoto.Visibility == Visibility.Visible)
				{
					this.femalePhoto.Visibility = Visibility.Collapsed;
					this.malePhoto.Visibility = Visibility.Visible;
					this.employeeName.Text = "Dan Brinke";
				}
				else
				{
					this.malePhoto.Visibility = Visibility.Collapsed;
					this.femalePhoto.Visibility = Visibility.Visible;
					this.employeeName.Text = "Maria Ferero";
				}
			}
		}		
		
	}
}
