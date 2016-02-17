using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RibbonView;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.RibbonView.MVVM.ViewModels
{
	public class ButtonGroupViewModel : ButtonViewModel
	{
		private bool isSmallGroup;
		private ObservableCollection<ButtonViewModel> buttons;

		public ButtonGroupViewModel()
		{
			buttons = new ObservableCollection<ButtonViewModel>();
		}

		public ObservableCollection<ButtonViewModel> Buttons
		{
			get
			{
				return buttons;
			}
		}

		public bool IsSmallGroup
		{
			get
			{
				return isSmallGroup;
			}
			set
			{
				isSmallGroup = value;
			}
		}
	}
}
