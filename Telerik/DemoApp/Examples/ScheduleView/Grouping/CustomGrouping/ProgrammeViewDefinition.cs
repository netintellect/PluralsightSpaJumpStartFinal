using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.Grouping.CustomGrouping
{
	public class ProgrammeViewDefinition : WeekViewDefinition
	{
		private ObservableCollection<GroupDescription> groupDescriptions;

		public ProgrammeViewDefinition()
		{
			this.groupDescriptions = new ObservableCollection<GroupDescription>();
			this.groupDescriptions.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnGroupByCollectionChanged);
			this.Title = "Programmes";
		}

		public ObservableCollection<GroupDescription> GroupDescriptions
		{
			get
			{
				return this.groupDescriptions;
			}
		}

		protected override IEnumerable<GroupDescription> GetGroupDescriptions()
		{
			// NOTE: This overrides all the definitions in the ScheduleView.
			return this.groupDescriptions;
		}

		private void OnGroupByCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.OnPropertyChanged(() => this.GroupDescriptions);
		}
	}
}
