using System;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Drawing.ViewModels
{
	/// <summary>
	/// ViewModel for the Brush Gallery Items.
	/// </summary>
	public class GalleryItemViewModel : ViewModelBase
	{
		public GalleryItemViewModel(bool markerVisible)
		{
			this.IsMarkerVisible = markerVisible;
		}
		private Brush customBrush;
		public Brush CustomBrush
		{
			get { return this.customBrush; }
			set
			{
				if (this.customBrush != value)
				{
					this.customBrush = value;
					this.OnPropertyChanged("CustomBrush");
				}
			}
		}		

		public bool IsMarkerVisible { get; set; }
	}
}
