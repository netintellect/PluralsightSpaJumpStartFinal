using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using Telerik.Windows.Controls;


namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// File management utility geared towards RadDiagram.
	/// When using WPF the user's temp folder will be user, when using SL things will go to the isostorage.
	/// </summary>
	public class FileManager
	{
		private const string SlidePrefix = "RadSlide-";

		private readonly RadDiagram diagram;

		private readonly string tempPath;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileManager"/> class.
		/// </summary>
		/// <param name="diagram">The diagram.</param>
		public FileManager(RadDiagram diagram)
		{
			this.CurrentFile = string.Empty;
			if (diagram == null) throw new ArgumentNullException("diagram");

			this.diagram = diagram;
#if WPF
			tempPath = Path.GetTempPath();
#else
#endif
		}

		/// <summary>
		/// Gets or sets the current file path.
		/// </summary>
		/// <value>
		/// The current file.
		/// </value>
		public string CurrentFile { get; set; }

		public void DeleteAllSlideFiles()
		{
#if WPF
			var slidePaths = GetSlidePaths();
			if (slidePaths == null) return;
			foreach (var slidePath in slidePaths) File.Delete(slidePath);
#else
			var slidePaths = this.GetSlidePaths();
			if (slidePaths == null) return;
			var appStore = OpenIsolatedStorage();
			slidePaths.ForEach(appStore.DeleteFile);
#endif
		}

		public List<string> GetSlidePaths()
		{
#if WPF
			var found = Directory.GetFiles(tempPath, "*.xml");
#else
			var appStore = OpenIsolatedStorage();
			var found = appStore.GetFileNames("*.xml");
#endif
			return found.Where(f => Path.GetFileName(f) != null && Path.GetFileName(f).StartsWith(SlidePrefix)).ToList();
		}

		/// <summary>
		/// Loads the diagram from file.
		/// </summary>
		public void LoadFromFile()
		{
			if (string.IsNullOrEmpty(this.CurrentFile)) throw new Exception("CurrentFile is not set.");
			var filename = string.Format("{0}{1}", SlidePrefix, this.CurrentFile);

#if WPF
			if (string.IsNullOrEmpty(tempPath)) throw new Exception("Temporary path is not set.");
			var path = Path.Combine(tempPath, filename);
			if (!Path.HasExtension(path)) path = Path.ChangeExtension(path, ".xml");
			using (var fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read))
			{
				var reader = new StreamReader(fileStream);
				var serializationString = reader.ReadToEnd();
				this.diagram.Clear();
				this.diagram.Load(serializationString);
			}
#else

			var path = filename;
			if (!Path.HasExtension(path)) path = Path.ChangeExtension(path, ".xml");
			var appStore = OpenIsolatedStorage();
			using (var storageFileStream = appStore.OpenFile(path, FileMode.Open))
			{
				var reader = new StreamReader(storageFileStream);
				var xml = reader.ReadToEnd();
				if (string.IsNullOrEmpty(xml)) throw new IsolatedStorageException("The serialed string was null or empty.");
				this.diagram.Clear();
				this.diagram.Load(xml);
			}
#endif
		}

		public IEnumerable<string> LoadPages()
		{
			var list = new List<string>();
			var slidePaths = this.GetSlidePaths();
			if (!slidePaths.Any()) return list;

#if WPF
			foreach (var path in slidePaths)
			{
				using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
				{
					var reader = new StreamReader(fileStream);
					var serializationString = reader.ReadToEnd();

					list.Add(serializationString);
				}
			}
#else
			var appStore = OpenIsolatedStorage();
			foreach (var path in slidePaths)
			{
				using (var fileStream = appStore.OpenFile(path, FileMode.Open))
				{
					var reader = new StreamReader(fileStream);
					var serializationString = reader.ReadToEnd();
					list.Add(serializationString);
				}
			}
#endif

			return list;
		}

		/// <summary>
		/// Saves the diagram to file.
		/// </summary>
		/// <param name="xml">The xml content to write.</param>
		public void SaveToFile(string xml)
		{
			if (string.IsNullOrEmpty(this.CurrentFile)) throw new Exception("CurrentFile is not set.");
			var filename = string.Format("RadSlide-{0}", this.CurrentFile);
#if WPF
			var path = Path.Combine(tempPath, filename);
			if (!Path.HasExtension(path)) path = Path.ChangeExtension(path, ".xml");
			var filemode = File.Exists(path) ? FileMode.Truncate : FileMode.CreateNew;
			using (var fileStream = File.Open(path, filemode, FileAccess.Write))
			{
				using (var writer = new StreamWriter(fileStream))
				{
					writer.Write(xml);
				}
			}
#else
			try
			{
				if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this.diagram)) throw new Exception("This doesn't work by design in design mode.");
				var path = filename;
				if (!Path.HasExtension(path)) path = Path.ChangeExtension(path, ".xml");
				var appStore = OpenIsolatedStorage();
				using (var storageFileStream = appStore.CreateFile(path))
				{
					var writer = new StreamWriter(storageFileStream);
					writer.Write(xml);
					writer.Flush();
				}
			}
			catch (IsolatedStorageException exc)
			{
				RadWindow.Alert(exc.Message);
			}
			catch (Exception)
			{
			}

#endif
		}
#if !WPF

		/// <summary>
		/// Opens the isolated storage.
		/// </summary>
		/// <returns></returns>
		private static IsolatedStorageFile OpenIsolatedStorage()
		{
			return IsolatedStorageFile.GetUserStoreForApplication();
		}
#endif
	}
}