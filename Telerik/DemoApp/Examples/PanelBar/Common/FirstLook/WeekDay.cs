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

namespace Telerik.Windows.Examples.PanelBar.FirstLook
{
	public class WeekDay : ViewModelBase
	{
		private bool isChecked;

		public string Header { get; set; }

		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				this.isChecked = value;
				this.OnPropertyChanged("IsChecked");
			}
		}

	}
}
