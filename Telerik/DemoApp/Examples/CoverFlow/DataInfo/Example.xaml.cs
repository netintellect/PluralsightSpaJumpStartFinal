using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Examples.CoverFlow.CS.Silverlight;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Telerik.Windows.Examples.CoverFlow.DataInfo
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			WebClient webClient = new WebClient();
			webClient.DownloadStringCompleted += this.OnDownloadStringCompleted;
			webClient.DownloadStringAsync(new Uri(@"http://api.flickr.com/services/feeds/photos_public.gne?id=57287444@N02&lang=en-us&format=rss_2", UriKind.Absolute));

			this.AddThemeResourcesToApplicationResources();
		}

		private void AddThemeResourcesToApplicationResources()
		{
			foreach (var resourceDictionary in this.Resources.MergedDictionaries)
			{
				ResourceDictionary dictionaryToRemove = new ResourceDictionary();
				dictionaryToRemove.Source = resourceDictionary.Source;
				Application.Current.Resources.MergedDictionaries.Add(dictionaryToRemove);
			}
		}

		private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			ObservableCollection<ImageInfo> flickerImagesCollection = new ObservableCollection<ImageInfo>();

			XDocument feed = XDocument.Parse(e.Result);
			foreach (XElement entry in feed.Root.Elements(XName.Get("entry", "http://www.w3.org/2005/Atom")))
			{
				ImageInfo info = new ImageInfo();

				string data = (from link in entry.Elements(XName.Get("link", "http://www.w3.org/2005/Atom"))
							   where string.Compare(link.Attribute(XName.Get("rel")).Value, "enclosure") == 0
							   select link.Attribute(XName.Get("href")).Value).FirstOrDefault();
				info.Image = data;
				info.FileExtension = Path.GetExtension(data);
							
				data = (from author in entry.Elements(XName.Get("author", "http://www.w3.org/2005/Atom"))
						select author.Element(XName.Get("uri", "http://www.w3.org/2005/Atom")).Value).FirstOrDefault();
				info.Page = data;

				data = (from link in entry.Elements(XName.Get("link", "http://www.w3.org/2005/Atom"))
						where string.Compare(link.Attribute(XName.Get("rel")).Value, "alternate") == 0
						select link.Attribute(XName.Get("href")).Value).FirstOrDefault();
				info.Link = data;

				data = (from title in entry.Elements(XName.Get("title", "http://www.w3.org/2005/Atom"))
						select title.Value).FirstOrDefault();
				info.Title = data;

				data = (from content in entry.Elements(XName.Get("content", "http://www.w3.org/2005/Atom"))
										select content.Value).FirstOrDefault();				
				info.Description = data;

				data = (from author in entry.Elements(XName.Get("author", "http://www.w3.org/2005/Atom"))
						select author.Element(XName.Get("name", "http://www.w3.org/2005/Atom")).Value).FirstOrDefault();
				info.Author = data;

				info.ImageDimensions = "316 x 223";

				flickerImagesCollection.Add(info);
			}

			this.coverFlow.ItemsSource = flickerImagesCollection;
		}
	}
}