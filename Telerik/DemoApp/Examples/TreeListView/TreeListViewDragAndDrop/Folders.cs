using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.TreeListView.TreeListViewDragAndDrop
{
	public class Folders
	{
		public Folders()
		{
			this.SampleFolders = new ObservableCollection<Folder>();
			Folder mediaFolder = new Folder("My Media");
			this.SampleFolders.Add(mediaFolder);
			mediaFolder.SubFolders.Add(new Folder("Videos"));
			mediaFolder.SubFolders.Add(new Folder("Music"));
			mediaFolder.SubFolders.Add(new Folder("Images"));

			this.SampleFolders.Add(new Folder("My Files"));
		}

		private ObservableCollection<Folder> sampleFolders;
		public ObservableCollection<Folder> SampleFolders
		{
			get
			{
				return this.sampleFolders;
			}
			private set
			{
				this.sampleFolders = value;
			}
		}
	}

	public class Folder
	{
		public Folder(string name)
		{
			this.Name = name;
			this.Type = "File folder";
			this.LastModified = DateTime.Now;
			this.SubFolders = new ObservableCollection<Folder>();
			this.SubFolders.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(SubFolders_CollectionChanged);
		}

		void SubFolders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
			{
				foreach (Folder folder in e.NewItems)
				{
					folder.ParentFolder = this;
				}
			}
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string type;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		private DateTime lastModified;

		public DateTime LastModified
		{
			get { return lastModified; }
			set { lastModified = value; }
		}

		private Folder parentFolder;

		public Folder ParentFolder
		{
			get { return parentFolder; }
			set { parentFolder = value; }
		}

		private ObservableCollection<Folder> subFolders;
		public ObservableCollection<Folder> SubFolders 
		{ 
			get
			{
				return this.subFolders;
			}
			private set
			{
				this.subFolders = value;
			}
		}
	}
}
