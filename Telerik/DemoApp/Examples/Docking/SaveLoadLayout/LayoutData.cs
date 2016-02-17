using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Docking.SaveLoadLayout
{
	public class LayoutData : ViewModelBase
	{
		private string xml;
		public string Xml
		{
			get
			{
				return this.xml;
			}
			set
			{
				if (this.xml != value)
				{
					this.xml = value;
					this.OnPropertyChanged("Xml");
				}
			}
		}
	}
}