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
using Telerik.Windows.Controls.TransitionControl;

namespace Telerik.Windows.Examples.TransitionControl.Configurator
{
	public class TransitionItem : ViewModelBase
	{
		private string _DisplayName;
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if (this._DisplayName != value)
				{
					this._DisplayName = value;
					this.OnPropertyChanged("DisplayName");
				}
			}
		}

		private TransitionProvider _Transition;
		public TransitionProvider Transition
		{
			get
			{
				return this._Transition;
			}
			set
			{
				if ((object)(this._Transition) != value)
				{
					this._Transition = value;
					this.OnPropertyChanged("Transition");
				}
			}
		}
	}
}
