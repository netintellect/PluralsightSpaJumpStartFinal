using System.ComponentModel;

namespace Telerik.Windows.Examples.Docking.FirstLook
{
	public class ToolboxItem : INotifyPropertyChanged
	{
		public ToolboxItem()
		{
			_toolboxitemheader = ToolboxItemHeader;
			_toolboximagesource = ToolboxImageSource;
		}

		private string _toolboxitemheader;
		public string ToolboxItemHeader
		{
			get
			{
				return this._toolboxitemheader;
			}
			set
			{
				if (this._toolboxitemheader != value)
				{
					this._toolboxitemheader = value;
					this.OnPropertyChanged("ToolboxItemHeader");
				}
			}
		}

		private string _toolboximagesource;
		public string ToolboxImageSource
		{
			get
			{
				return this._toolboximagesource;
			}
			set
			{
				if (this._toolboximagesource != value)
				{
					this._toolboximagesource = value;
					this.OnPropertyChanged("ToolboxImageSource");
				}
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
