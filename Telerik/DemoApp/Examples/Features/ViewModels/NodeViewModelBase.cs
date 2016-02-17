using System;
using System.Linq;

namespace Telerik.Windows.Diagrams.Features.ViewModels
{
	/// <summary>
	/// Base class for MVVM nodes.
	/// </summary>
	/// <example>
	public class NodeViewModelBase : ItemViewModelBase
	{
		private double width = double.NaN;
		private double height = double.NaN;
		private double rotationAngle;
		private bool isSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeViewModelBase"/> class.
        /// </summary>
		public NodeViewModelBase()
		{
		}

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
		public double Width
		{
			get
			{
				return this.width;
			}
			set
			{
				if (this.width != value)
				{
					this.width = value;
					this.OnPropertyChanged("Width");
				}
			}
		}

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
		public double Height
		{
			get
			{
				return this.height;
			}
			set
			{
				if (this.height != value)
				{
					this.height = value;
					this.OnPropertyChanged("Height");
				}
			}
		}

		/// <summary>
		/// Gets or sets the rotation of the shape.
		/// </summary>
		public double RotationAngle
		{
			get
			{
				return this.rotationAngle;
			}
			set
			{
				if (Math.Abs(this.rotationAngle - value) > Telerik.Windows.Diagrams.Core.Utils.Epsilon)
				{
					this.rotationAngle = value;
					this.OnPropertyChanged("RotationAngle");
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
		/// </value>
		public bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				if (this.IsSelected != value)
				{
					this.isSelected = value;
					this.OnPropertyChanged("IsSelected");
				}
			}
		}
	}
}
