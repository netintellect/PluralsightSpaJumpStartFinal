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
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.WatermarkTextBox.FirstLook
{
	public class ExampleViewModel
	{
		public class Page : ViewModelBase
		{
			private string text;

			public Uri ImageSource { get; set; }
			public string Text
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
						OnPropertyChanged("Text");
					}
				}
			}
		}
		private ObservableCollection<Page> pages;
		public ObservableCollection<Page> Pages
		{
			get
			{
				return pages = this.PageCollection();
			}
		}
		public ObservableCollection<Page> PageCollection()
		{
			ObservableCollection<Page> pageCollection = new ObservableCollection<Page>();
			pageCollection.Add(new Page() { ImageSource = new Uri("../Images/WatermarkTextBox/FirstLook/Image1.png", UriKind.RelativeOrAbsolute) });
			pageCollection.Add(new Page() { ImageSource = new Uri("../Images/WatermarkTextBox/FirstLook/Image2.png", UriKind.RelativeOrAbsolute) });
			pageCollection.Add(new Page() { ImageSource = new Uri("../Images/WatermarkTextBox/FirstLook/Image3.png", UriKind.RelativeOrAbsolute) });
			pageCollection.Add(new Page() { ImageSource = new Uri("../Images/WatermarkTextBox/FirstLook/Image4.png", UriKind.RelativeOrAbsolute) });
			pageCollection.Add(new Page() { ImageSource = new Uri("../Images/WatermarkTextBox/FirstLook/Image5.png", UriKind.RelativeOrAbsolute) });
			pageCollection.Add(new Page() { ImageSource = new Uri("../Images/WatermarkTextBox/FirstLook/Image6.png", UriKind.RelativeOrAbsolute) });

			return pageCollection;
		}
	}
}
