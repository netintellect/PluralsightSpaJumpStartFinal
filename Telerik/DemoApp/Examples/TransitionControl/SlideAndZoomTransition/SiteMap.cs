using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;

namespace Telerik.Windows.Examples.TransitionControl.SlideAndZoomTransition
{
	public class SiteMap : ViewModelBase, ISupportInitialize
	{
		public SiteMap()
		{
			this._Pages = new ObservableCollection<SitePage>();
		}

		private SitePage _SelectedPage;
		public SitePage SelectedPage
		{
			get
			{
				return this._SelectedPage;
			}
			set
			{
				if (this._SelectedPage != value)
				{
					this._SelectedPage = value;
					this.OnPropertyChanged("SelectedPage");
				}
			}
		}

		private ObservableCollection<SitePage> _Pages;
		public ObservableCollection<SitePage> Pages
		{
			get
			{
				return this._Pages;
			}
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			this.SelectedPage = this.Pages.FirstOrDefault();
		}
	}
}
