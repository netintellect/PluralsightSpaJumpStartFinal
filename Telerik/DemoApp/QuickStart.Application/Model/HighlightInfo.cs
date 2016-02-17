using System.Xml.Linq;
using System;

namespace Telerik.Windows.QuickStart
{
	public class HighlightInfo
	{
		private XElement element;

		public HighlightInfo(XElement element)
		{
			this.element = element;
			this.Initialize();
		}

        public Enums.Platform Platform { get; private set; }
		public string Text { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }

		private void Initialize()
		{
			if (element == null)
			{
				return;
			}

			this.Text = this.element.GetAttribute("text", null);
			this.Description = this.element.GetAttribute("description", null);
			this.Image = this.element.GetAttribute("image", null);

            var platform = this.element.GetAttribute("platform", null);
            this.Platform = string.IsNullOrEmpty(platform) ? Enums.Platform.WPF : (Enums.Platform)Enum.Parse(typeof(Enums.Platform), platform, true);
		}
	}
}