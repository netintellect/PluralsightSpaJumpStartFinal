using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.CoverFlow.DataBinding
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			WebClient webClient = new WebClient();
			webClient.DownloadStringCompleted += this.OnDownloadStringCompleted;
			webClient.DownloadStringAsync(new Uri(@"http://api.flickr.com/services/feeds/photos_public.gne?id=57287444@N02&lang=en-us&format=rss_2", UriKind.Absolute));
		}

		private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			ObservableCollection<Uri> flickerImagesCollection = new ObservableCollection<Uri>();

			XDocument feed = XDocument.Parse(e.Result);

			foreach (XElement entry in feed.Root.Elements(XName.Get("entry", "http://www.w3.org/2005/Atom")))
			{
				string[] links = (from link in entry.Elements(XName.Get("link", "http://www.w3.org/2005/Atom"))
								  where string.Compare(link.Attribute(XName.Get("rel")).Value, "enclosure") == 0
								  select link.Attribute(XName.Get("href")).Value).ToArray<string>();
				if (links.Length > 0)
				{
					flickerImagesCollection.Add(new Uri(links[0], UriKind.Absolute));
				}
			}

			this.coverFlow.ItemsSource = flickerImagesCollection;
		}
	}
}