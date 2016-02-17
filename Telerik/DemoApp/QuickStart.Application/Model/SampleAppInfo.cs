using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Telerik.Windows.QuickStart
{
	public class SampleAppInfo : ISampleAppInfo
	{
		private XElement element;

		public SampleAppInfo(XElement element)
		{
			this.element = element;
			this.Initialize();
		}

		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public string ImageTouch { get; set; }
		public string Url { get; set; }

		private void Initialize()
		{
			if (element == null)
			{
				return;
			}

			this.Title = this.element.GetAttribute("title", null);
			this.Description = this.element.GetAttribute("description", null);
			this.Image = this.element.GetAttribute("image", null);
			this.ImageTouch = this.element.GetAttribute("imageTouch", null);
			this.Url = this.element.GetAttribute("url", null);
		}
	}
}
