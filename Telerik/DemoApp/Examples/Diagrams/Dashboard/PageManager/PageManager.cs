using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.Common;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// Manages the different pages in the dashboard.
	/// </summary>
	/// <remarks>Could be replaced by a custom navigation framework.</remarks>
	public sealed class PageManager : ViewModelBase
	{
		private const string location = "Dashboard/Pages/Local";
		private readonly RadDiagram diagram;
		private readonly FileManager fileManager;
		
		private Page currentPage;
		private bool diagramDoesnShowASlideRightNow;

		public PageManager(RadDiagram diagram)
		{
			this.diagram = diagram;
			this.fileManager = new FileManager(diagram);
			this.Pages = new ObservableCollection<Page>();
			this.HyperLinks = new ObservableCollection<LogicalLink>();
		}

		public Page CurrentPage
		{
			get
			{
				return this.currentPage;
			}
			set
			{
				if (this.DiagramDoesnShowASlideRightNow)
				{
					this.DiagramDoesnShowASlideRightNow = false;
					this.currentPage = value;
					if (value != null && !value.IsNew) this.LoadSlideInDiagram(value.Id);
					this.OnPropertyChanged("CurrentPage"); //let the listbox in the UI know about the change
				}
				else
				{
					if (value == this.currentPage) return;
					if (this.currentPage != null && value != null) this.SaveCurrent();
					this.currentPage = value;
					if (value != null && !value.IsNew) this.LoadSlideInDiagram(value.Id);
					this.OnPropertyChanged("CurrentPage"); //let the listbox in the UI know about the change
				}
			}
		}

		public bool DiagramDoesnShowASlideRightNow
		{
			get
			{
				return this.diagramDoesnShowASlideRightNow;
			}
			private set
			{
				this.diagramDoesnShowASlideRightNow = value;
				this.OnPropertyChanged("DiagramDoesnShowASlideRightNow");
			}
		}

		public ObservableCollection<LogicalLink> HyperLinks { get; private set; }

		public ObservableCollection<Page> Pages { get; private set; }

		public Page AddSlide(string name, bool saveCurrentFirst = true)
		{
			if (saveCurrentFirst && this.CurrentPage != null && !this.DiagramDoesnShowASlideRightNow) this.SaveCurrent();

			var slide = new Page { Name = name, IsNew = true };
			this.Pages.Add(slide);

			this.CurrentPage = slide;
			this.diagram.Clear();
			this.diagram.AddShape(new TextShape { Text = "Dragdrop new items from the toolbox onto this surface.", Position = new Point(400, 400) });
			//nothing to load since this is a new Page
			this.diagram.Metadata.Id = slide.Id;
			this.diagram.Metadata.Title = name;
			// every new Page is saved even if nothing has been added
			this.SaveCurrent();
			return slide;
		}

		public void ImportAllPagesFromAssembly()
		{
			// reset the whole manager
			this.Reset();
			var names = new[] { "XOM", "Info", "News", "AAPL", "MSFT" };
			Page infoPage = null;
			foreach (var name in names)
			{
				try
				{
					var sri = ExtensionUtilities.GetStream(string.Format("{0}/{1}.xml", location, name), ExtensionUtilities.ExecutingAssemblyName);
					// Application.GetResourceStream(new Uri(string.Format("{0}/{1}.xml", location, name), UriKind.Relative));
					if (sri == null)
					{
						return;
					}
					using (var s = sri)
					{
						var reader = new StreamReader(s);
						var xml = reader.ReadToEnd();
						reader.Close();
						string id = null;
						string title = null;
						GetDiagramIdAndTitle(xml, ref id, ref title);
						if (string.IsNullOrEmpty(id))
						{
							continue;
						}
						if (string.IsNullOrEmpty(title))
						{
							continue;
						}
						this.SaveInStorage(xml, id);

						var page = new Page(id) { Name = title };
						if (title == "Info")
						{
							infoPage = page;
						}
						this.Pages.Add(page);
					}
				}
				catch (Exception exc)
				{
					continue;
				}
			}
			// set the info page as starting page
			if (infoPage != null)
			{
				this.CurrentPage = infoPage;
			}
		}

		public void InitializeFromStorage()
		{
			this.diagram.Clear();
#if WPF
			var xmls = fileManager.LoadPages();
			foreach (var slideXml in xmls)
			{
				string id = null;
				string title = null;
				GetDiagramIdAndTitle(slideXml, ref id, ref title);
				if (string.IsNullOrEmpty(id)) throw new Exception("The slide doesn't have an Id.");
				var page = new Page(id) { Name = title };
				this.Pages.Add(page);
			}
#else
			var xmls = fileManager.LoadPages();
			foreach (var slideXml in xmls)
			{
				string id = null;
				string title = null;
				GetDiagramIdAndTitle(slideXml, ref id, ref title);
				if (string.IsNullOrEmpty(id)) throw new Exception("The slide doesn't have an Id.");
				var page = new Page(id) { Name = title };
				this.Pages.Add(page);
			}
#endif
			if (this.Pages.Any())
			{
				this.CurrentPage = this.Pages[0];
				fileManager.CurrentFile = this.currentPage.Id;
			}
		}

		/// <summary>
		/// Presents the next page, if possible.
		/// </summary>
		public void MoveNext()
		{
			if (this.DiagramDoesnShowASlideRightNow)
			{
				return;
			}
			if (this.Pages.Count > 1)
			{
				this.CurrentPage = this.Pages.IndexOf(this.CurrentPage) < this.Pages.Count - 1 ? this.Pages[this.Pages.IndexOf(this.CurrentPage) + 1] : this.Pages[0];
			}
		}

		/// <summary>
		/// Presents the previous page, if possible.
		/// </summary>
		public void MovePrevious()
		{
			if (this.DiagramDoesnShowASlideRightNow)
			{
				return;
			}
			if (this.Pages.Count > 1)
			{
				this.CurrentPage = this.Pages.IndexOf(this.CurrentPage) > 0 ? this.Pages[this.Pages.IndexOf(this.CurrentPage) - 1] : this.Pages[this.Pages.Count - 1];
			}
		}
		
		public void RemoveSlide(string id)
		{
			var slide = this.Pages.SingleOrDefault(s => s.Id == id);
			if (slide == null)
			{
				return;
			}

			//change the current Page
			if (this.Pages.Count == 1) //hmm, dont delete everything
			{
				RadWindow.Alert("You cannot delete this single page of the dashboard.");
				return;
			}
			var index = this.Pages.IndexOf(slide);
			var newCurrent = index < this.Pages.Count - 1 ? this.Pages[index + 1] : this.Pages[0];

			this.Pages.Remove(slide);
			fileManager.CurrentFile = id;
			fileManager.LoadFromFile();
			/*var appStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);

			if (!appStore.FileExists(id))
			{
				throw new Exception(string.Format("The file '{0}' does not exist in the storage area.", id));
			}
			try
			{
				using (var stream = appStore.OpenFile(id, FileMode.Open, FileAccess.Read))
				{
					var reader = new StreamReader(stream);
					var xml = reader.ReadToEnd();
					if (string.IsNullOrEmpty(xml))
					{
						throw new Exception(string.Format("The file '{0}' exists but seems to be corrupt or empty. ", id));
					}
					this.diagram.Clear();
					this.diagram.Load(xml);
					reader.Close();
				}
			}
			catch (Exception exc)
			{
				RadWindow.Alert(exc.Message);
				return;
			}*/
			this.CurrentPage = newCurrent;
		}

		public void Reset()
		{
			this.Pages.Clear();
			this.HyperLinks.Clear();
			//make sure this is the lowercase private field
			this.currentPage = null;
			this.OnPropertyChanged("currentPage");
			//clear the storage
			DeleteAllFilesFromStorage();
		}

		public void SaveCurrent()
		{
			//doesnt make sense to save the hypergraph or if (by accident) something changed at run
			if (this.DiagramDoesnShowASlideRightNow || ApplicationManager.ApplicationState == ApplicationState.RunMode)
			{
				return;
			}
			if (this.CurrentPage == null)
			{
				throw new Exception("No current Page.");
			}
			this.SaveSlide(this.CurrentPage);
		}

		public void SaveCurrentToDisk(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			path = Path.GetFullPath(path);
			path = Path.ChangeExtension(Path.Combine(path, this.CurrentPage.Id), "xml");
			try
			{
				using (var stream = File.Open(path, FileMode.Create, FileAccess.Write))
				{
					var writer = new StreamWriter(stream);
					var xml = this.diagram.Save();
					writer.Write(xml);
					writer.Flush();
					writer.Close();
				}
				RadWindow.Alert(string.Format("Current diagram was saved to {0}", path));
			}
			catch (Exception exc)
			{
				RadWindow.Alert(exc.Message);
			}
		}

		public void ShowInfo()
		{
			var slide = this.Pages.SingleOrDefault(s => s.Name == "Info");
			if (slide == null)
			{
				RadWindow.Alert("The Info page has not been created yet and will be added for you.");
				this.AddSlide("Info");
			}
			else this.CurrentPage = slide;
		}

		public void Update()
		{
			this.RemoveObsoleteLinks();
		}

        internal void SaveSlide(Page page)
        {
            if (page == null) throw new ArgumentNullException("page");
            try
            {
                //make sure the Page info is stored as part of the diagram serialization
                this.diagram.Metadata.Title = page.Name;
                this.diagram.Metadata.Id = page.Id;
                var xml = this.diagram.Save();
                this.SaveInStorage(xml, page.Id);
            }
            catch (Exception exc)
            {
                RadWindow.Alert(exc.Message);
            }
            page.IsNew = false; //once saved it's not new anymore
        }

		private void DeleteAllFilesFromStorage()
		{
			fileManager.DeleteAllSlideFiles();
		}

		private static void GetDiagramIdAndTitle(string xml, ref string id, ref string title)
		{
			var doc = XDocument.Parse(xml);
			// the old way
			var idElement = doc.Descendants("Id").SingleOrDefault();
			if (idElement != null)
				id = idElement.Value;
			else
			{
				// the new serialization
				var metaElement = doc.Descendants("Metadata").SingleOrDefault();
				if (metaElement != null && metaElement.Attribute("Id") != null) id = metaElement.Attribute("Id").Value;
			}



			var titleElement = doc.Descendants("Title").SingleOrDefault();
			if (titleElement != null) title = titleElement.Value.ToString(CultureInfo.InvariantCulture);
		}

		private void LoadSlideInDiagram(string id)
		{
			fileManager.CurrentFile = id;
			fileManager.LoadFromFile();
		}

		private void RemoveObsoleteLinks()
		{
			var toremove = this.HyperLinks.Where(l => !this.SlideExists(l.FromId) || !this.SlideExists(l.ToId)).Select(l => this.HyperLinks.IndexOf(l)).ToArray();
			if (toremove.Any())
			{
				for (var i = toremove.Length - 1; i == 0; i--) this.HyperLinks.RemoveAt(i);
			}
		}

		private void SaveInStorage(string xml, string id)
		{
			/*var appStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);

			using (var stream = appStore.OpenFile(id, FileMode.Create, FileAccess.Write))
			{
				var writer = new StreamWriter(stream);

				// check the consistency of the hypergraph
				this.RemoveObsoleteLinks();
				//have a look at the links between the diagrams, i.e. the hypergraph links
				this.CheckInternalLinks(xml);

				writer.Write(xml);
				writer.Flush();
				writer.Close();
			}*/
			fileManager.CurrentFile = id;
			fileManager.SaveToFile(xml);
		}

		private bool SlideExists(string id)
		{
			return this.Pages.Count(s => s.Id == id) > 0;
		}

		public sealed class LogicalLink
		{
			public LogicalLink(string from, string to)
			{
				this.FromId = from;
				this.ToId = to;
			}

			public string FromId { get; private set; }

			public string ToId { get; private set; }
		}
	}
}