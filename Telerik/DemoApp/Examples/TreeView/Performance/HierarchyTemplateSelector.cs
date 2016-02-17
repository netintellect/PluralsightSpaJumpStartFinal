using System.Windows;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.TreeView.Performance
{
	public class HierarchyTemplateSelector : DataTemplateSelector
	{
		public DataTemplate FolderTemplate { get; set; }

		public DataTemplate FileTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is FolderViewModel)
			{
				return FolderTemplate;
			}
			else if (item is FileViewModel)
			{
				return FileTemplate;
			}
			return base.SelectTemplate(item, container);
		}
	}
}
