using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ColorPicker.ColorSelectorAndPaletteView
{
	public class ViewModel : ViewModelBase
	{
		public ViewModel()
		{
			this.IsColorSelectorVisible = true;
			this.IsPaletteViewVisible = false;
		}

		private bool isColorSelectorVisible;
		public bool IsColorSelectorVisible
		{
			get { return this.isColorSelectorVisible; }
			set
			{
				if (this.isColorSelectorVisible != value)
				{
					this.isColorSelectorVisible = value;
					this.OnPropertyChanged("IsColorSelectorVisible");
				}
			}
		}

		private bool isPaletteViewVisible;
		public bool IsPaletteViewVisible
		{
			get { return this.isPaletteViewVisible; }
			set
			{
				if (this.isPaletteViewVisible != value)
				{
					this.isPaletteViewVisible = value;
					this.OnPropertyChanged("IsPaletteViewVisible");
				}
			}
		}
		
		
		
	}
}
