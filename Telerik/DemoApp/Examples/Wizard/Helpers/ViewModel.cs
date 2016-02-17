using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Wizard.Helpers
{
	public class ViewModel : ViewModelBase
	{
		private bool isActive = true;
		public string Url { get; set; }
		public DelegateCommand NavigateCommand { get; set; }

		public bool IsActive
		{
			get { return this.isActive; }
			set
			{
				if (value != this.isActive)
				{
					this.isActive = value;
					this.OnPropertyChanged("IsActive");
				}
			}
		}
		public ViewModel()
		{
			NavigateCommand = new DelegateCommand(new Action<object>(d => { this.Navigate(d); }));
		}

		private void Navigate(object d)
		{
#if WPF
			System.Diagnostics.Process.Start(this.Url);
#else
			System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(this.Url), "_blank");
#endif
		}
	}
}
