using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Telerik.Windows.QuickStart
{
	public class HardCoverMatrixTransform
	{
		public static double GetAngle(DependencyObject obj)
		{
			return (double)obj.GetValue(AngleProperty);
		}

		public static void SetAngle(DependencyObject obj, double value)
		{
			obj.SetValue(AngleProperty, value);
		}

		// Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AngleProperty =
			DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(HardCoverMatrixTransform), new UIPropertyMetadata(0.0, TransformChanged));

		public static double GetPerspective(DependencyObject obj)
		{
			return (double)obj.GetValue(PerspectiveProperty);
		}

		public static void SetPerspective(DependencyObject obj, double value)
		{
			obj.SetValue(PerspectiveProperty, value);
		}

		// Using a DependencyProperty as the backing store for Perspective.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty PerspectiveProperty =
			DependencyProperty.RegisterAttached("Perspective", typeof(double), typeof(HardCoverMatrixTransform), new UIPropertyMetadata(0.0, TransformChanged));

		private static void TransformChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			MatrixTransform matrixTransform = sender as MatrixTransform;
			if (matrixTransform != null)
			{
				matrixTransform.Matrix = new Matrix() { M11 = 1 * Math.Cos(HardCoverMatrixTransform.GetAngle(matrixTransform) * Math.PI / 180), M12 = Math.Sin(HardCoverMatrixTransform.GetAngle(matrixTransform) * Math.PI / 180) * HardCoverMatrixTransform.GetPerspective(matrixTransform), M21 = 0, M22 = 1, OffsetX = 0, OffsetY = 0 };
			}
		}
	}
}
