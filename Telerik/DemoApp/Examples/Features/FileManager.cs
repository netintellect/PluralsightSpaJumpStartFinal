using System;
using System.IO;
using System.IO.IsolatedStorage;

using Microsoft.Win32;

using Telerik.Windows.Controls;
using System.Windows.Controls;

namespace Telerik.Windows.Diagrams.Features
{
	/// <summary>
	/// File management utility geared towards RadDiagram.
	/// </summary>
	public class FileManager
	{
		private readonly RadDiagram diagram;

		/// <summary>
		/// Initializes a new instance of the <see cref="FileManager"/> class.
		/// </summary>
		/// <param name="diagram">The diagram.</param>
		public FileManager(RadDiagram diagram)
		{
			this.CurrentFile = string.Empty;
			if (diagram == null)
			{
				throw new ArgumentNullException("diagram");
			}

			this.diagram = diagram;
		}

		/// <summary>
		/// Gets or sets the current file path.
		/// </summary>
		/// <value>
		/// The current file.
		/// </value>
		public string CurrentFile { get; set; }

		/// <summary>
		/// Saves the diagram to file.
		/// </summary>
		/// <param name="location">The location.</param>
		public void SaveToFile(FileLocation location = FileLocation.Disk)
		{
#if WPF
			switch (location)
			{
				case FileLocation.Disk:
					var dialog = new SaveFileDialog
						{
							DefaultExt = "xml",
							Filter = "Diagram files|*.xml|All Files (*.*)|*.*",
							CheckPathExists = true,
							AddExtension = true,
							Title = "Select a location to save the diagram"
						};
					if (dialog.ShowDialog() == true)
					{
						this.CurrentFile = dialog.FileName;
					}

					if (!string.IsNullOrWhiteSpace(this.CurrentFile))
					{
						var serializationString = this.diagram.Save();
						using (var writer = new StreamWriter(this.CurrentFile))
						{
							writer.Write(serializationString);
							writer.Flush();
						}
					}
					break;
				case FileLocation.IsolatedStorage:
					try
					{
						if (string.IsNullOrEmpty(this.CurrentFile))
						{
							RadWindow.Prompt("File name", (sender, e) =>
							{
								if (string.IsNullOrEmpty(e.PromptResult))
									throw new ArgumentNullException("e");

								this.CurrentFile = Path.GetFileNameWithoutExtension(e.PromptResult);

								if (!Path.HasExtension(this.CurrentFile))
								{
									this.CurrentFile = this.CurrentFile + ".xml";
								}
								else
								{
									if (Path.GetExtension(this.CurrentFile).ToLowerInvariant() != "xml")
									{
										this.CurrentFile = Path.ChangeExtension(this.CurrentFile, "xml");
									}
								}
								var appStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);
								using (var storageFileStream = appStore.CreateFile(this.CurrentFile))
								{
									var serializationString = this.diagram.Save();
									var writer = new StreamWriter(storageFileStream);
									writer.Write(serializationString);
									writer.Flush();
								}
							});
						}
						else
						{
							var appStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);

							using (var storageFileStream = appStore.CreateFile(this.CurrentFile))
							{
								var serializationString = this.diagram.Save();
								var writer = new StreamWriter(storageFileStream);
								writer.Write(serializationString);
								writer.Flush();
							}
						}
					}
					catch (IsolatedStorageException exc)
					{
						RadWindow.Alert(exc.Message);
					}
					break;
				default:
					throw new ArgumentOutOfRangeException("location");
			}
#else
			switch (location)
			{
				case FileLocation.Disk:
					Stream fileStream = null;
					try
					{
						var dialog = new SaveFileDialog { DefaultExt = "xml", Filter = "Diagram files|*.xml|All Files (*.*)|*.*", DefaultFileName = "Diagram.xml" };
						if (dialog.ShowDialog() == true)
						{
							fileStream = dialog.OpenFile();
							this.CurrentFile = dialog.DefaultFileName;
						}
						if (fileStream == null) return; // likely canceled the dialog
						using (fileStream)
						{
							var serializationString = this.diagram.Save();
							var writer = new StreamWriter(fileStream);
							writer.Write(serializationString);
							writer.Flush();
						}
					}
					finally
					{
						if (fileStream != null)
							fileStream.Close();
					}

					break;
				case FileLocation.IsolatedStorage:
					try
					{
						if (string.IsNullOrEmpty(this.CurrentFile))
						{
							RadWindow.Prompt("File name", (sender, e) =>
								{
									if (string.IsNullOrEmpty(e.PromptResult))
										throw new ArgumentNullException("e");
									this.CurrentFile = Path.GetFileNameWithoutExtension(e.PromptResult);
									if (!Path.HasExtension(this.CurrentFile))
									{
										this.CurrentFile = this.CurrentFile + ".xml";
									}
									else
									{
										if (Path.GetExtension(this.CurrentFile).ToLowerInvariant() != "xml")
										{
											this.CurrentFile = Path.ChangeExtension(this.CurrentFile, "xml");
										}
									}
									var appStore = IsolatedStorageFile.GetUserStoreForApplication();
									using (var storageFileStream = appStore.CreateFile(this.CurrentFile))
									{
										var serializationString = this.diagram.Save();
										var writer = new StreamWriter(storageFileStream);
										writer.Write(serializationString);
										writer.Flush();
									}
								});
						}
						else
						{
							var appStore = IsolatedStorageFile.GetUserStoreForApplication();
							using (var storageFileStream = appStore.CreateFile(this.CurrentFile))
							{
								var serializationString = this.diagram.Save();
								var writer = new StreamWriter(storageFileStream);
								writer.Write(serializationString);
								writer.Flush();
							}
						}
					}
					catch (IsolatedStorageException exc)
					{
						RadWindow.Alert(exc.Message);
					}
					catch (Exception)
					{
					}
					break;
				default:
					throw new ArgumentOutOfRangeException("location");
			}
#endif
		}

		/// <summary>
		/// Loads the diagram from file.
		/// </summary>
		/// <param name="location"></param>
		public void LoadFromFile(FileLocation location = FileLocation.Disk)
		{
#if WPF
			switch (location)
			{
				case FileLocation.Disk:
					var dialog = new OpenFileDialog { Multiselect = false, Filter = "Diagram (.xml)|*.xml|All Files (*.*)|*.*" };
					if (dialog.ShowDialog() == true)
					{
						using (var fileStream = File.OpenRead(dialog.FileName))
						{
							var reader = new StreamReader(fileStream);
							var serializationString = reader.ReadToEnd();
							this.diagram.Clear();
							this.diagram.Load(serializationString);
						}
					}
					break;
				case FileLocation.IsolatedStorage:
					if (string.IsNullOrEmpty(this.CurrentFile))
					{
						RadWindow.Prompt("File name", (sender, e) =>
						{
							if (string.IsNullOrEmpty(e.PromptResult))
								throw new ArgumentNullException("e");
							this.CurrentFile = Path.GetFileNameWithoutExtension(e.PromptResult);
							if (!Path.HasExtension(this.CurrentFile))
							{
								this.CurrentFile = this.CurrentFile + ".xml";
							}
							else
							{
								if (Path.GetExtension(this.CurrentFile).ToLowerInvariant() != "xml")
								{
									this.CurrentFile = Path.ChangeExtension(this.CurrentFile, "xml");
								}
							}
							var appStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);

							using (var storageFileStream = appStore.OpenFile(this.CurrentFile, FileMode.Open))
							{
								var reader = new StreamReader(storageFileStream);
								var xml = reader.ReadToEnd();
								if (string.IsNullOrEmpty(xml))
								{
									throw new IsolatedStorageException("The serialized string was null or empty.");
								}
								this.diagram.Load(xml);
							}
						});
					}
					else
					{
						var appStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain, null, null);

						using (var storageFileStream = appStore.OpenFile(this.CurrentFile, FileMode.Open))
						{
							var reader = new StreamReader(storageFileStream);
							var xml = reader.ReadToEnd();
							if (string.IsNullOrEmpty(xml))
							{
								throw new IsolatedStorageException("The serialized string was null or empty.");
							}
							this.diagram.Load(xml);
						}
					}

					break;
				default:
					throw new ArgumentOutOfRangeException("location");
			}

#else
			switch (location)
			{
				case FileLocation.Disk:
					var dialog = new OpenFileDialog { Multiselect = false, Filter = "Diagram (.xml)|*.xml|All Files (*.*)|*.*" };
					if (dialog.ShowDialog() == true)
					{
						this.CurrentFile = System.Windows.Application.Current.HasElevatedPermissions ? dialog.File.FullName : dialog.File.Name;
						using (var fileStream = dialog.File.OpenRead())
						{
							var reader = new StreamReader(fileStream);
							var serializationString = reader.ReadToEnd();
							this.diagram.Clear();
							this.diagram.Load(serializationString);
						}
					}
					break;
				case FileLocation.IsolatedStorage:
					if (string.IsNullOrEmpty(this.CurrentFile))
					{
						RadWindow.Prompt("File name", (sender, e) =>
						{
							if (string.IsNullOrEmpty(e.PromptResult))
								throw new ArgumentNullException("e");
							this.CurrentFile = Path.GetFileNameWithoutExtension(e.PromptResult);
							if (!Path.HasExtension(this.CurrentFile))
							{
								this.CurrentFile = this.CurrentFile + ".xml";
							}
							else
							{
								if (Path.GetExtension(this.CurrentFile).ToLowerInvariant() != "xml")
								{
									this.CurrentFile = Path.ChangeExtension(this.CurrentFile, "xml");
								}
							}
							var appStore = IsolatedStorageFile.GetUserStoreForApplication();
							using (var storageFileStream = appStore.OpenFile(this.CurrentFile, FileMode.Open))
							{
								var reader = new StreamReader(storageFileStream);
								var xml = reader.ReadToEnd();
								if (string.IsNullOrEmpty(xml))
									throw new IsolatedStorageException("The serialed string was null or empty.");
								this.diagram.Load(xml);
							}
						});
					}
					else
					{
						var appStore = IsolatedStorageFile.GetUserStoreForApplication();
						using (var storageFileStream = appStore.OpenFile(this.CurrentFile, FileMode.Open))
						{
							var reader = new StreamReader(storageFileStream);
							var xml = reader.ReadToEnd();
							if (string.IsNullOrEmpty(xml))
								throw new IsolatedStorageException("The serialed string was null or empty.");
							this.diagram.Load(xml);
						}
					}

					break;
				default:
					throw new ArgumentOutOfRangeException("location");
			}

#endif

		}
	}
}