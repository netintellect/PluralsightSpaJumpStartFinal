using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Window.RestrictedArea
{
	public class WindowViewModel : ViewModelBase
	{
		private bool isRestricted;

		public bool IsRestricted
		{
			get
			{
				return this.isRestricted;
			}
			set
			{
				if (this.isRestricted != value)
				{
					this.isRestricted = value;
					OnPropertyChanged("IsRestricted");
				}
			}
		}
	}
}