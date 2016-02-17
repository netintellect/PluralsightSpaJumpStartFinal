using System;

namespace Telerik.Windows.Examples.TreeView.Performance
{
	public class FileViewModel
	{
		private static readonly string[] nouns;
		private static readonly string[] adjectives;

		private static string[] Split(string source)
		{
			return source.Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		}

		static FileViewModel()
		{
			FileViewModel.nouns = Split(@"contract plan permission certificate design novel company");

			FileViewModel.adjectives = Split(@"Draft Secret Extraordinary House Final Proposed");
		}

		public FileViewModel()
		{
			this.Name = string.Format("{0} {1}.docx",
					FileViewModel.adjectives[FolderViewModel.Generator.Next(adjectives.Length)],
					FileViewModel.nouns[FolderViewModel.Generator.Next(nouns.Length)]);
		}

		public string Name { get; private set; }
	}
}
