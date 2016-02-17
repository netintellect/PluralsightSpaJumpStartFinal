using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
#if SILVERLIGHT
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.Map.DynamicLayer
{
	public class StoreTemplateSelector : DataTemplateSelector
	{
		public StoreTemplateSelector()
		{
		}

		public DataTemplate AreaTemplate
		{
			get;
			set;
		}

		public DataTemplate MarketTemplate
		{
			get;
			set;
		}

		public DataTemplate StoreTemplate
		{
			get;
			set;
		}

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			StoreLocation store = item as StoreLocation;
			if (store != null)
			{
				switch (store.StoreType)
				{
					case StoreType.Area:
						return this.AreaTemplate;

					case StoreType.Market:
						return this.MarketTemplate;

					case StoreType.Store:
					default:
						return this.StoreTemplate;
				}
			}

			return null;
		}
	}
}
