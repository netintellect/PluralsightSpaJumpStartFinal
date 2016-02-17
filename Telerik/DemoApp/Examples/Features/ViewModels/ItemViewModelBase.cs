using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Diagrams.Features.ViewModels
{
	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class ItemViewModelBase : ViewModelBase
	{
		private Point position;
		private Visibility visibility = Visibility.Visible;
		private object content;

		public ItemViewModelBase()
		{
		}
		
		public Visibility Visibility
		{
			get
			{
				return this.visibility;
			}
			set
			{
				if (this.visibility != value)
				{
					this.visibility = value;
					this.OnPropertyChanged("Visibility");
				}
			}
		}

		public Point Position
		{
			get
			{
				return this.position;
			}
			set
			{
				if (this.position != value)
				{
					this.position = value;
					this.OnPropertyChanged("Position");
				}
			}
		}

		/// <summary>
		/// Gets or sets the content or label of this connection.
		/// </summary>
		/// <value>
		/// The content.
		/// </value>
		public object Content
		{
			get
			{
				return this.content;
			}
			set
			{
				if (this.content != value)
				{
					this.content = value;
					this.OnPropertyChanged("Content");
				}
			}
		}
	}
}
