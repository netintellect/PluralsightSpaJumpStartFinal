using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Examples.Diagrams.Drawing.ViewModels
{
	/// <summary>
	/// ViewModel for the items in the StrokeThickness gallery.
	/// </summary>
	public class StrokeThicknessViewModel : ViewModelBase
	{
		public StrokeThicknessViewModel(double thickness)
		{
			this.Thickness = thickness;
		}

		private double thickness;
		public double Thickness
		{
			get { return this.thickness; }
			set
			{
				if (this.thickness != value)
				{
					this.thickness = value;
					this.OnPropertyChanged("Thickness");
				}
			}
		}

		private EllipseGeometry ellipseGeometry;
		public EllipseGeometry EllipseGeometry
		{
			get
			{
				//Cloning the geometry , this way preventing SL exception when using shared geometry.
				double x = this.ellipseGeometry.RadiusX;
				return new EllipseGeometry(){ Center = new Point(x, x), RadiusX = x, RadiusY = x};
			}
			set
			{
				if (this.ellipseGeometry != value)
				{
					this.ellipseGeometry = value;
					this.OnPropertyChanged("EllipseGeometry");
				}
			}
		}
		
	}
}
