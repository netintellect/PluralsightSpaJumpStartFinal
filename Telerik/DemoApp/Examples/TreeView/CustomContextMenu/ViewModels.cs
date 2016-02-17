using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Telerik.Windows.Examples.TreeView.CustomContextMenu
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<ContextOperation> contextMenuItems = new ObservableCollection<ContextOperation>();

		public MainViewModel()
		{
			this.SolutionItems = DataProvider.GenerateSolutionData();
		}

		public ObservableCollection<SolutionItem> SolutionItems { get; private set; }

		public ObservableCollection<ContextOperation> ContextOperations
		{
			get
			{
				return this.contextMenuItems;
			}
			private set
			{
				if (this.contextMenuItems != value)
				{
					this.contextMenuItems = value;
					this.OnPropertyChanged("ContextOperations");
				}
			}
		}

		internal void PreapreContextOperationsForItem(SolutionItem actionItem)
		{
			if (actionItem != null)
			{
				this.ContextOperations = DataProvider.GetContextoperations(actionItem.ItemType);
			}
			else
			{
				this.ContextOperations = DataProvider.GetContextoperations(SolutionItemType.Solution);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	public class SolutionItem
	{
		public SolutionItem()
		{
			this.SubItems = new ObservableCollection<SolutionItem>();
		}

		public string Name { get; set; }
		public SolutionItemType ItemType { get; set; }
		public Uri ImageUri { get; set; }
		public ObservableCollection<SolutionItem> SubItems { get; private set; }
	}

	public class ContextOperation
	{
		public string Header { get; set; }
		public string ImagePath { get; set; }
		public bool IsSeparator { get; set; }
	}

	public enum SolutionItemType
	{
		Solution,
		Project,
		XamlFile,
		XamlCodeFile,
		CodeFile
	}

	internal static class DataProvider
	{
		internal static ObservableCollection<SolutionItem> GenerateSolutionData()
		{
			//// Project 1

			SolutionItem treeViewXaml = new SolutionItem();
			treeViewXaml.Name = "TreeView.xaml";
			treeViewXaml.ItemType = SolutionItemType.XamlFile;
			treeViewXaml.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlFile.png", UriKind.RelativeOrAbsolute);
			treeViewXaml.SubItems.Add(new SolutionItem()
			{
				Name = "TreeView.xaml.cs",
				ItemType = SolutionItemType.XamlCodeFile,
				ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlCsFile.png", UriKind.RelativeOrAbsolute)
			});

			SolutionItem headerControlXaml = new SolutionItem();
			headerControlXaml.Name = "HeaderControl.xaml";
			headerControlXaml.ItemType = SolutionItemType.XamlFile;
			headerControlXaml.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlFile.png", UriKind.RelativeOrAbsolute);
			headerControlXaml.SubItems.Add(new SolutionItem()
			{
				Name = "HeaderControl.xaml.cs",
				ItemType = SolutionItemType.XamlCodeFile,
				ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlCsFile.png", UriKind.RelativeOrAbsolute)
			});

			SolutionItem virtualizingPanelCS = new SolutionItem();
			virtualizingPanelCS.Name = "VirtualizingPanel.cs";
			virtualizingPanelCS.ItemType = SolutionItemType.CodeFile;
			virtualizingPanelCS.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlCsFile.png", UriKind.RelativeOrAbsolute);


			SolutionItem project1 = new SolutionItem();
			project1.Name = "TreeView.Core";
			project1.ItemType = SolutionItemType.Project;
			project1.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/csFile.png", UriKind.RelativeOrAbsolute);
			project1.SubItems.Add(treeViewXaml);
			project1.SubItems.Add(headerControlXaml);
			project1.SubItems.Add(virtualizingPanelCS);

			//// Project 2

			SolutionItem mainPageXaml = new SolutionItem();
			mainPageXaml.Name = "MainPage.xaml";
			mainPageXaml.ItemType = SolutionItemType.XamlFile;
			mainPageXaml.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlFile.png", UriKind.RelativeOrAbsolute);
			mainPageXaml.SubItems.Add(new SolutionItem()
			{
				Name = "MainPage.xaml.cs",
				ItemType = SolutionItemType.XamlCodeFile,
				ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlCsFile.png", UriKind.RelativeOrAbsolute)
			});

			SolutionItem modelsCS = new SolutionItem();
			modelsCS.Name = "Model.cs";
			modelsCS.ItemType = SolutionItemType.CodeFile;
			modelsCS.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/xamlCsFile.png", UriKind.RelativeOrAbsolute);

			SolutionItem project2 = new SolutionItem();
			project2.Name = "TreeView.Extensions";
			project2.ItemType = SolutionItemType.Project;
			project2.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/csFile.png", UriKind.RelativeOrAbsolute);
			project2.SubItems.Add(mainPageXaml);
			project2.SubItems.Add(modelsCS);

			//// Solution

			SolutionItem solutionFile = new SolutionItem();
			solutionFile.Name = "Solution 'TreeView' (2 projects)";
			solutionFile.ItemType = SolutionItemType.Solution;
			solutionFile.ImageUri = new Uri(@"../Images/TreeView/ContextMenu/solution.png", UriKind.RelativeOrAbsolute);
			solutionFile.SubItems.Add(project1);
			solutionFile.SubItems.Add(project2);

			return new ObservableCollection<SolutionItem>() { solutionFile };
		}

		internal static ObservableCollection<ContextOperation> GetContextoperations(SolutionItemType itemType)
		{
			switch (itemType)
			{
				case SolutionItemType.Solution: return GenerateSolutionContextMenu();

				case SolutionItemType.Project: return GenerateProjectContextMenu();

				case SolutionItemType.XamlFile: return GenerateFileContextMenu();

				case SolutionItemType.XamlCodeFile: return GenerateFileContextMenu();

				case SolutionItemType.CodeFile: return GenerateFileContextMenu();

				default: return GenerateSolutionContextMenu();
			}
		}

		private static ObservableCollection<ContextOperation> GenerateSolutionContextMenu()
		{
			ObservableCollection<ContextOperation> items = new ObservableCollection<ContextOperation>();
			items.Add(new ContextOperation() { Header = "Add..." });

			return items;
		}

		private static ObservableCollection<ContextOperation> GenerateProjectContextMenu()
		{
			ObservableCollection<ContextOperation> items = new ObservableCollection<ContextOperation>();
			items.Add(new ContextOperation() { Header = "Add..." });
			items.Add(new ContextOperation() { IsSeparator = true });
			items.Add(new ContextOperation() { Header = "Remove" });
			items.Add(new ContextOperation() { Header = "Unload" });

			return items;
		}

		private static ObservableCollection<ContextOperation> GenerateFileContextMenu()
		{
			ObservableCollection<ContextOperation> items = new ObservableCollection<ContextOperation>();
			items.Add(new ContextOperation() { Header = "Delete" });
			items.Add(new ContextOperation() { Header = "Exclude From Project" });

			return items;
		}
	}
}
