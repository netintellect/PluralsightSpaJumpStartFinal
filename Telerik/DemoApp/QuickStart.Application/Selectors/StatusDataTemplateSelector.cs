using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.QuickStart
{
	public class StatusDataTemplateSelector : DataTemplateSelector
	{

		public DataTemplate New { get; set; }
		public DataTemplate Beta { get; set; }
		public DataTemplate Ctp { get; set; }
		public DataTemplate Updated { get; set; }
		public DataTemplate Obsolete { get; set; }
		public DataTemplate Normal { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			IStatusInfo ci = item as IStatusInfo;
			if (ci != null)
			{
				switch (ci.Status)
				{
					case Enums.StatusMode.New: return this.New;
					case Enums.StatusMode.Beta: return this.Beta;
					case Enums.StatusMode.Ctp: return this.Ctp;
					case Enums.StatusMode.Updated: return this.Updated;
                    case Enums.StatusMode.Obsolete: return this.Obsolete;
					default: return this.Normal;
				}
			}
			return base.SelectTemplate(item, container);
		}
	}
}
