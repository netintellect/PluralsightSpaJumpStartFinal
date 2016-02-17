using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RibbonView;

namespace Telerik.Windows.Examples.RibbonView.MVVM.ViewModels
{
	public class ButtonViewModel : ViewModelBase
	{
		private String text;
		private ButtonSize size;

		private string smallImage;

		private string largeImage;

		/// <summary>
		///     Gets or sets Text.
		/// </summary>
		public String Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					this.text = value;
					this.OnPropertyChanged("Text");
				}
			}
		}

		public ButtonSize Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
			}
		}

		public string SmallImage
		{
			get
			{
				return smallImage;
			}
			set
			{
				smallImage = value;
			}
		}

		public string LargeImage
		{
			get
			{
				return largeImage;
			}
			set
			{
				largeImage = value;
			}
		}
	}
}
