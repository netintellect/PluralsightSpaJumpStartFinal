using System;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Examples.Diagrams.Drawing.ViewModels
{
	/// <summary>
	/// ViewModel for the FillRule settings.
	/// </summary>
	public class FillRuleViewModel : ViewModelBase
	{
		private FillRule fillRule;

		public FillRule FillRule	
		{
			get { return this.fillRule; }
			set
			{
				if (this.fillRule != value)
				{
					this.fillRule = value;
					this.OnPropertyChanged("FillRule");
				}
			}
		}

		private Geometry stargeometry;

		public Geometry StarGeometry
		{
			get 
			{
				//Cloning the geometry , this way preventing SL exception when using shared geometry.
				return GeometryExtensions.Clone(this.stargeometry);
			}
			set
			{
				if (this.stargeometry != value)
				{
					this.stargeometry = value;
					this.OnPropertyChanged("StarGeometry");
				}
			}
		}
		
		
	}
}
