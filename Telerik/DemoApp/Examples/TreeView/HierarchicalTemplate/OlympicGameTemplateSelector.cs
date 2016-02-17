using System;
using System.Windows;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.TreeView.HierarchicalTemplate
{
	public class OlympicGameTemplateSelector : DataTemplateSelector
	{
		public HierarchicalDataTemplate OlympicGameTemplate { get; set; }

		public HierarchicalDataTemplate MedalDistributionTemplate { get; set; }

		public DataTemplate CountryTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			base.SelectTemplate(item, container);

			if (item is OlympicGame)
			{
				return this.OlympicGameTemplate;
			}
			else if (item is MedalDistribution)
			{
				return this.MedalDistributionTemplate;
			}
			else if (item is CountryMedal)
			{
				return this.CountryTemplate;
			}
			return null;
		}
	}
}
