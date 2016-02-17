using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Telerik.Windows.QuickStart
{
	public class HomePageInfo
	{
		private XElement element;

		public HomePageInfo(XElement element)
		{
			this.element = element;
			this.Initialize();
		}

		public HighlightInfo Headline { get; private set; }

		public IList<HighlightInfo> Highlights { get; private set; }

		private void Initialize()
		{
			if (this.element == null)
			{
				return;
			}

			this.Headline = this.LoadHeadLineData();
			this.Highlights = LoadHighLightsData();
		}

		private HighlightInfo LoadHeadLineData()
		{
			return element.Elements("Headline").Select(e => new HighlightInfo(e)).FirstOrDefault(h => h.Platform == Enums.Platform.WPF);
		}

		private IList<HighlightInfo> LoadHighLightsData()
		{
			var result = new List<HighlightInfo>();
			var highlights = element.Element("Highlights");
			if (highlights != null)
			{
                result.AddRange((highlights.Elements("Highlight").Select(e => new HighlightInfo(e)).Where(h => h.Platform == Enums.Platform.WPF)));
			}

			return result;
		}
	}
}
