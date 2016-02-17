using System.Windows;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Chart.MeteoChart
{
	public static class DependencyObjectExtensions
	{
		public static TParent GetVisualParent<TParent>(DependencyObject dependencyObject) where TParent : DependencyObject
		{
			DependencyObject parent = null;

			if (dependencyObject != null)
				parent = VisualTreeHelper.GetParent(dependencyObject);

			while ((parent != null) && !(parent is TParent))
			{
				parent = VisualTreeHelper.GetParent(parent);
			}

			return (TParent)parent;
		}
	}
}
