using System.Windows;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.TreeView.HierarchicalTemplate
{
	public class MasterDetailTemplateSelector : DataTemplateSelector
	{
		private readonly DataTemplate emptyTemplate = new DataTemplate();

		public DataTemplate OlympicGameTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			OlympicGame game = item as OlympicGame;
			if (game != null)
			{
				return this.OlympicGameTemplate;
			}
			return this.emptyTemplate;
		}
	}
}
