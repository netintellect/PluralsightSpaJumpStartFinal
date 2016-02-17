using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.TreeView.Performance
{
	public class FolderViewModel
	{
		public static int FoldersCount { get; set; }
		public static Random Generator { get; private set; }
		private static readonly string[] adjectives;
		private static readonly string[] nouns;

		static FolderViewModel()
		{
			FolderViewModel.Generator = new Random(12431231);

			FolderViewModel.adjectives = (@"Sales IT Support Admin Administration Management Research QA Quality Shipping Installer " +
						@"Upgrades Fixes Planning Testing New Secret Secretive Security Finace Ecology Environment").
						Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

			FolderViewModel.nouns = "Team Department Branch Division Group".Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		}

		public FolderViewModel(double level)
		{
			this.Id = string.Format("({0})", FolderViewModel.FoldersCount++);
			this.level = level;
			this.Name = string.Format("{0} {1}",
					FolderViewModel.adjectives[FolderViewModel.Generator.Next(adjectives.Length)],
					FolderViewModel.nouns[FolderViewModel.Generator.Next(nouns.Length)]);
			this.Children = new ObservableCollection<object>();
		}

		private readonly double level;

		public string Id { get; private set; }

		public string Name { get; private set; }

		public IList<object> Children { get; private set; }

		public void BuildChildren()
		{
			double childrenLevel = this.level + 1;
			if (childrenLevel < 4)
			{
				for (int organizationIndex = 0; organizationIndex < 100; organizationIndex++)
				{
					this.Children.Add(new FolderViewModel(childrenLevel));
				}
				for (int personIndex = 0; personIndex < 100; personIndex++)
				{
					this.Children.Add(new FileViewModel());
				}
			}
		}
	}
}
