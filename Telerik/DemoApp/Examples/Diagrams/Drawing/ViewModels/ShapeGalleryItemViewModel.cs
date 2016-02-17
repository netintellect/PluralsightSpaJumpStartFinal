using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Drawing.ViewModels
{
	public class ShapeGalleryItemViewModel : ViewModelBase
	{
		private Geometry customGeometry;
		public Geometry CustomGeometry
		{
			get { return this.customGeometry; }
			set
			{
				if (this.customGeometry != value)
				{
					this.customGeometry = value;
					this.OnPropertyChanged("CustomGeometry");
				}
			}
		}
		
	}
}
