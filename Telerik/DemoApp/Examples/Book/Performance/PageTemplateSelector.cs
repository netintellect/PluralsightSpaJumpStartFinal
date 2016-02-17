using System;
using System.Windows;
#if WPF
using System.Windows.Controls;
using Telerik.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.Book.Performance
{
	public class PageTemplateSelector : DataTemplateSelector
	{
		private DataTemplate pageTemplate1, pageTemplate2, pageTemplate3, pageTemplate4;
		public DataTemplate PageTemplate1
		{
			get
			{
				return this.pageTemplate1;
			}
			set
			{
				this.pageTemplate1 = value;
			}
		}
		public DataTemplate PageTemplate2
		{
			get
			{
				return this.pageTemplate2;
			}
			set
			{
				this.pageTemplate2 = value;
			}
		}
		public DataTemplate PageTemplate3
		{
			get
			{
				return this.pageTemplate3;
			}
			set
			{
				this.pageTemplate3 = value;
			}
		}
		public DataTemplate PageTemplate4
		{
			get
			{
				return this.pageTemplate4;
			}
			set
			{
				this.pageTemplate4 = value;
			}
		}
		

		private Random randomGenerator = new Random(DateTime.Now.Millisecond);

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			int randomTemplate = this.randomGenerator.Next(1, 5);
			RadBookItem page = container as RadBookItem;

			if (page.ContentTemplate != null &&
				(page.ContentTemplate.Equals(this.PageTemplate1) ||
				page.ContentTemplate.Equals(this.PageTemplate2) ||
				page.ContentTemplate.Equals(this.PageTemplate3) ||
				page.ContentTemplate.Equals(this.PageTemplate4)))
			{
				return page.ContentTemplate;
			}
			if (randomTemplate == 1)
			{
				return this.PageTemplate1;
			}
			else if (randomTemplate == 2)
			{
				return this.PageTemplate2;
			}
			else if (randomTemplate == 3)
			{
				return this.PageTemplate3;
			}
			else
			{
				return this.PageTemplate4;
			}
		}
	}
}
