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
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ToolBar.FirstLook
{
	public class ViewModel : ViewModelBase
	{
		public ViewModel()
		{
			this.TextMessage = "Hi Team, " + "\n" + "\nI will be out of office for a week." + "\n" + "\nRegards," + "\n" + "\nNancy Davolio";
			this.ClearCommand = new DelegateCommand(x => this.ExecuteClear());
			this.NewDocCommand = new DelegateCommand(x => this.ExecuteNewDocument());
			this.SaveCommand = new DelegateCommand(x => this.ExecuteSave());
			this.PrintCommand = new DelegateCommand(x => this.ExecutePrint());
		}

		private string textMessage;
		public string TextMessage
		{
			get { return this.textMessage; }
			set
			{
				if (this.textMessage != value)
				{
					this.textMessage = value;
					this.OnPropertyChanged("TextMessage");
				}
			}
		}		

		private DelegateCommand clearCommand;
		public DelegateCommand ClearCommand
		{
			get { return this.clearCommand; }
			set
			{
				if (this.clearCommand != value)
				{
					this.clearCommand = value;
					this.OnPropertyChanged("ClearCommand");
				}
			}
		}

		private DelegateCommand newDocCommand;
		public DelegateCommand NewDocCommand
		{
			get { return this.newDocCommand; }
			set
			{
				if (this.newDocCommand != value)
				{
					this.newDocCommand = value;
					this.OnPropertyChanged("NewDocCommand");
				}
			}
		}

		private DelegateCommand saveCommand;
		public DelegateCommand SaveCommand
		{
			get { return this.saveCommand; }
			set
			{
				if (this.saveCommand != value)
				{
					this.saveCommand = value;
					this.OnPropertyChanged("SaveCommand");
				}
			}
		}

		private DelegateCommand printCommand;
		public DelegateCommand PrintCommand
		{
			get { return this.printCommand; }
			set
			{
				if (this.printCommand != value)
				{
					this.printCommand = value;
					this.OnPropertyChanged("PrintCommand");
				}
			}
		}
		
		private void ExecutePrint()
		{
			MessageBox.Show("Document sent to Printer!");
		}
		
		private void ExecuteSave()
		{
			MessageBox.Show("Document Saved!");
		}

		private void ExecuteClear()
		{
			this.TextMessage = string.Empty;
		}

		private void ExecuteNewDocument()
		{
			this.TextMessage = "Hi, " + "\n\nRegards,";
		}		
	}
}
