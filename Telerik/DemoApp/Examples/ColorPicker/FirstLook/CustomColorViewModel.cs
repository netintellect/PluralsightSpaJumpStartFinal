using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ColorPicker.FirstLook
{
	public class CustomColorViewModel : ViewModelBase
	{
		public CustomColorViewModel(Color currentColor)
		{
			this.CurrentColor = currentColor;
			this.CurrentlyEditedColor = currentColor;
			this.OpenEditColorsCommand = new DelegateCommand(x => OpenEditColorsDialog());
			this.OkCommand = new DelegateCommand(x => CloseEditColorsDialog(true));
			this.CancelCommand = new DelegateCommand(x => CloseEditColorsDialog(false));
		}

		private bool isOpen;
		public bool IsOpen
		{
			get { return this.isOpen; }
			set
			{
				if (this.isOpen != value)
				{
					this.isOpen = value;
					this.OnPropertyChanged("IsOpen");
				}
			}
		}			

		private Color startColor = Colors.Transparent;

		private Color currentColor;
		public Color CurrentColor	
		{
			get { return this.currentColor; }
			set
			{
				if (this.currentColor != value)
				{
					this.currentColor = value;
					this.OnPropertyChanged("CurrentColor");
				}
			}
		}

		private Color currentlyEditedColor;

		public Color CurrentlyEditedColor
		{
			get { return this.currentlyEditedColor; }
			set
			{
				if (this.currentlyEditedColor != value)
				{
					this.currentlyEditedColor = value;
					this.OnPropertyChanged("CurrentlyEditedColor");
				}
			}
		}
		

		private DelegateCommand openEditColorsCommand;
		public DelegateCommand OpenEditColorsCommand
		{
			get { return this.openEditColorsCommand; }
			set
			{
				if (this.openEditColorsCommand != value)
				{
					this.openEditColorsCommand = value;
					this.OnPropertyChanged("OpenEditColorsCommand");
				}
			}
		}

		private DelegateCommand okCommand;
		public DelegateCommand OkCommand
		{
			get { return this.okCommand; }
			set
			{
				if (this.okCommand != value)
				{
					this.okCommand = value;
					this.OnPropertyChanged("OkCommand");
				}
			}
		}

		private DelegateCommand cancelCommand;
		public DelegateCommand CancelCommand
		{
			get { return this.cancelCommand; }
			set
			{
				if (this.cancelCommand != value)
				{
					this.cancelCommand = value;
					this.OnPropertyChanged("CancelCommand");
				}
			}
		}

		private void OpenEditColorsDialog()
		{
			EditColorsWindow window = new EditColorsWindow();
			window.DataContext = this;
			window.ShowDialog();
			this.IsOpen = false;
			this.startColor = this.CurrentColor;
		}

		private void CloseEditColorsDialog(bool acceptNewColor)
		{
			if (acceptNewColor == false)
			{
				this.CurrentColor = startColor;
			}
			else
			{
				this.CurrentColor = this.CurrentlyEditedColor;
			}
			RadWindowManager.Current.CloseAllWindows();
		}
	}
}
