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

namespace Telerik.Windows.Examples.TransitionControl.MappedLightTransitions
{
	public class Wall : ViewModelBase
	{
		private ImageSource _WallImage;
		public ImageSource WallImage
		{
			get
			{
				return this._WallImage;
			}
			set
			{
				if ((object)(this._WallImage) != (object)value)
				{
					this._WallImage = value;
					this.OnPropertyChanged("WallImage");
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
				if ((object)(this._Transition) != (object)value)
				{
					this._Transition = value;
					this.OnPropertyChanged("Transition");
				}
			}
		}
	}
}
