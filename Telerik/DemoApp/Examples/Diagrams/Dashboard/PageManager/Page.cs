using System;
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// Represents a single page or slide.
	/// </summary>
	public sealed class Page : ViewModelBase
	{
		private string name;

		public Page()
		{
			this.Id = Guid.NewGuid().ToString();
		}

		internal Page(string id)
		{
			this.Id = id;
		}

		public string Id { get; private set; }

		public bool IsNew { get; set; }

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
				this.OnPropertyChanged("Name");
			}
		}
	}
}