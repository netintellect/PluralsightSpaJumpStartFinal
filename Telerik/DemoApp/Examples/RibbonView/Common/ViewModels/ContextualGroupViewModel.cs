using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RibbonView.MVVM.ViewModels
{
	public class ContextualGroupViewModel : ViewModelBase
	{
		private string name;

		public ContextualGroupViewModel()
		{
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}		
	}
}
