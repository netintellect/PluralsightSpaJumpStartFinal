using System;
using System.Collections;
using System.Windows.Data;
using Telerik.Windows.Diagrams.Features.ViewModels;

namespace Telerik.Windows.Diagrams.Features.Layout
{
	/// <summary>
	/// A converter which takes a hierarchical collection and creates a GraphSource
	/// </summary>
	public class HierarchicalGraphSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			GraphSourceBase<HierarchicalNodeViewModel, LinkViewModelBase<HierarchicalNodeViewModel>> graphSource = null;

			using (graphSource = new GraphSourceBase<HierarchicalNodeViewModel, LinkViewModelBase<HierarchicalNodeViewModel>>())
			{
				var collection = value as IEnumerable;
				if (collection != null)
				{
					foreach (HierarchicalNodeViewModel item in collection)
					{
						this.PopulateGraphSource(item, graphSource);
					}
				}
			}

			return graphSource;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		private void PopulateGraphSource(HierarchicalNodeViewModel node, GraphSourceBase<HierarchicalNodeViewModel, LinkViewModelBase<HierarchicalNodeViewModel>> graphSource)
		{
			using (graphSource)
			{
				graphSource.AddNode(node);

				foreach (HierarchicalNodeViewModel subNode in node.Children)
				{
					using (var link = new LinkViewModelBase<HierarchicalNodeViewModel>(node, subNode))
					{
						graphSource.AddLink(link);

						this.PopulateGraphSource(subNode, graphSource);
					}
				}
			}
		}
	}
}