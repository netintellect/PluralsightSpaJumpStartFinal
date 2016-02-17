using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Wizard.FirstLook
{
	public class ViewModel : ViewModelBase
	{
		private int buttonClicksCount;
		public int ButtonClicksCount
		{
			get { return this.buttonClicksCount; }
			set
			{
				if (value != this.buttonClicksCount)
				{
					this.buttonClicksCount = value;
					this.OnPropertyChanged("IsSelected");
				}
			}
		}

		public bool IsSelected
		{
			get
			{
				return this.buttonClicksCount > 0;
			}		
		}
	}
}
